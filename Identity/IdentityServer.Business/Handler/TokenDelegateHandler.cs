using JwtHelpers.Models;

namespace IdentityServer.Business.Handler
{
    public class TokenDelegateHandler : DelegatingHandler
    {
        TokenParameters _parameters;

        public TokenDelegateHandler(TokenParameters parameters)
        {
            _parameters = parameters;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!request.Headers.Any(w => w.Key == "Authorization"))
                request.Headers.Add("Authorization", _parameters.AccessToken ?? "null");

            return base.SendAsync(request, cancellationToken);
        }
    }
}
