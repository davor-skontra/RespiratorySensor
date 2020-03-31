using System;

namespace Utilities.UpdateContainers
{
    public class UpdateContainerBuilder
    {
        private readonly Action _action;

        public UpdateContainerBuilder(Action action)
        {
            _action = action;
        }

        public UpdateContainerBuilder RunFirstInstant()
        {
            _action();

            return this;
        }
        
        public OnceEvery Every(TimeSpan timeSpan) => new OnceEvery(_action, timeSpan);
    }
}