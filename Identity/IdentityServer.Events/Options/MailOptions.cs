namespace IdentityServer.Events.Options
{
    public class MailOptions
    {
        public string Sender { get; set; }

        public string DisplayName { get; set; }

        public string Password { get; set; }

        public string SmtpClient { get; set; }
    }
}
