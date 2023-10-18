namespace IdentityServer.Events
{
    public class EventBase
    {
        public Guid EventIdentifier { get; set; }

        public string Owner { get; set; } = "IdentityServer";

        public DateTime CreateTime { get; set; }
    }
}
