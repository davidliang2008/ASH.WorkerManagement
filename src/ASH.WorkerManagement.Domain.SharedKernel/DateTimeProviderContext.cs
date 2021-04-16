using System;
using System.Collections.Generic;
using System.Threading;

namespace ASH.WorkerManagement.Domain.SharedKernel
{
    public class DateTimeProviderContext : IDisposable
    {
        private static ThreadLocal<Stack<DateTimeProviderContext>> _threadScopeStack = new ThreadLocal<Stack<DateTimeProviderContext>>(
            () => new Stack<DateTimeProviderContext>()
        );

        public DateTime ContextDateTimeNow { get; private set; }

        public DateTimeProviderContext(System.DateTime contextDateTimeNow)
        {
            this.ContextDateTimeNow = contextDateTimeNow;
            _threadScopeStack.Value.Push(this);
        }

        public static DateTimeProviderContext Current
        {
            get
            {
                if (_threadScopeStack.Value.Count == 0)
                {
                    return null;
                }

                return _threadScopeStack.Value.Peek();
            }
        }

        public void Dispose()
        {
            _threadScopeStack.Value.Pop();
        }
    }
}
