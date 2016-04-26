using System;
using System.Collections.Generic;
using System.Text;

namespace RUReadyMobileApp.Interfaces
{
    public interface IPushNotifications
    {
        //event EventHandler<IncomingPushNotificationEventArgs> OnPushNotificationReceived;
        void RegisterForPushNotifications();
    }

    public class IncomingPushNotificationEventArgs : EventArgs
    {
        public Dictionary<string, object> Payload
        {
            get;
            set;
        }
    }
}
