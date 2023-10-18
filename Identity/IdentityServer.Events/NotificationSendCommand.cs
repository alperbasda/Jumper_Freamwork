
namespace IdentityServer.Events
{

    public class NotificationSendCommand : EventBase
    {
        public string Target { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int NotifyType { get; set; }

        public int NotifyStatus => 0;
    }
}
