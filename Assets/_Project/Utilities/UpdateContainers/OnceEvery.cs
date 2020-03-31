using System;

namespace Utilities.UpdateContainers
{
    public class OnceEvery
    {
        private readonly Action _action;
        private readonly TimeSpan _span;

        private DateTime _nextRunTime;

        public OnceEvery(Action action, TimeSpan span)
        {
            _action = action;
            _span = span;
            
            CalculateNextRuntime();
        }

        public void Update()
        {
            if (!(DateTime.Now > _nextRunTime))
            {
                return;
            }
            
            CalculateNextRuntime();

            _action();
        }
        
        public void CalculateNextRuntime() => _nextRunTime = DateTime.Now + _span; 
    }
}