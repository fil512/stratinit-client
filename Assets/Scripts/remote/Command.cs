using System;
using System.Collections.Generic;
using api;
using core.Constants;
using core.dto;
using UnityEditor.PackageManager;
using UnityEngine;

namespace remote
{
    public abstract class Command<T>
    {
        private IStatusReporter _statusReporter;

        public Command(IStatusReporter statusReporter)
        {
            _statusReporter = statusReporter;
        }
        
        public abstract Result<T> execute();

        public abstract string getDescription();
        
        // FIXME KHS unit test
        // FIXME KHS asyncoperation
        public AsyncOperation process() {
            try {
                Result<T> result = execute();
                if (result.Success) {
                    handleSuccess(result.Value);
                    processResult(result);
                    processBattleLogs(result.BattleLogs);
                } else {
                    reportError(getDescription());
                }
                _statusReporter.reportResult(this, result);
            // } catch (RemoteConnectFailureException e) {
            //     statusReporter.reportError("The server is down.  Try again later.");
            //     logger.error(e.getMessage(), e);
            // } catch (RemoteAccessException e) {
            //     statusReporter
            //         .reportError("Server error.  Possibly invalid username or password.  Please check stratinit.log or your Account Settings and try again.");
            //     logger.error(e.getMessage(), e);
            } catch (Exception e) {
                _statusReporter.reportError(e);
                Debug.LogException(e);
            }
        }
        
        private void processResult(Result<T> result) {
            if (result.CommandPoints == Constants.UNASSIGNED) {
                return;
            }
            // FIXME KHS
            // NationView nation = db.getNation();
            // if (nation != null) {
            //     nation.setCommandPoints(result.getCommandPoints());
            //     arrivedDataEventAccumulator.addEvent(new CommandPointsArrivedEvent());
            // }
        }
        public abstract void handleSuccess(T result);
        
        protected void reportError(String description) {
            _statusReporter.reportError("ERROR: [" + description + "] FAILED.");
        }

        private void processBattleLogs(List<SIBattleLog> silogs) {
            if (silogs.Count == 0) {
                return;
            }
            // FIXME KHS
            // resultBattleLogProcessor.process(silogs);
            // battleLogProcessor.process(silogs);
        }
    }
}
