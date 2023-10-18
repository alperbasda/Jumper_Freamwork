using IdentityServer.Business.Concrete;
using IdentityServer.Entities.Enum;

namespace IdentityServer.Business.Extensions
{
    public static class ValidationStringConcat
    {
        public static string Concat(this InputError error,string propName)
        {
            return string.Concat(propName," : *",AuthMessageManager.Get((int)error, MessageType.InputError),"*");
        }

        public static string GetMessage(this ResponseMessage error)
        {
            return AuthMessageManager.Get((int)error, MessageType.ResponseMessage);
        }
    }
}
