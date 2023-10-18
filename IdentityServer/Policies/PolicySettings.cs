namespace IdentityServer.Policies
{
    public class PolicySettings
    {
        public const string Admin = "Admin";

        public const string Manager = "Manager";

        public const string User = "User";

        public const string Personnel = "Personnel";

        public Dictionary<string, List<string>> Policies { get; set; }
    }
}
