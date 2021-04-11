using System.Collections;
using System.Collections.Generic;
using core.config;
using core.Constants;
using core.dto;

namespace remote
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T Value { get; set; }
        public List<string> Messages = new List<string>();
        public List<SIBattleLog> BattleLogs = new List<SIBattleLog>();

        public bool MoveSuccess
        {
            get;
            set;
        } = true;

        public int CommandPoints {
            get;
            set;
        } = Constants.UNASSIGNED;

        public RunModeEnum RunMode { get; set; }
    }
}
