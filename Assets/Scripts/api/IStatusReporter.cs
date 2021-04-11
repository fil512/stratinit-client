using System;
using remote;

namespace api
{
    public interface IStatusReporter
    {
        void reportResult(string message);

        void reportError(string text);

        void reportError(Exception e);

        void reportAction(string description);

        void reportLoginError();

        // FIXME KHS probably two different generics
        void reportResult<T> (Command<T> command, Result<T> result);
    }
}
