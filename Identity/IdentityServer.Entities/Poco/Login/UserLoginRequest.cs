﻿namespace IdentityServer.Entities.Poco.Login
{
    public class UserLoginRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }
}
