namespace Blobs.Models.Events
{
    using System;

    public class BehaviorToggledEventArgs : EventArgs
    {
        public BehaviorToggledEventArgs(string message)
        {
            this.Message = message;
        }

        public string Message { get; }
    }
}
