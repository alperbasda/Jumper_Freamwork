using AutoMapperAdapter;
using EntityBase.Enum;
using EntityBase.Poco.Responses;
using IdentityServer.Business.Contracts;
using IdentityServer.Business.ServiceBase;
using IdentityServer.DataAccess.Concrete;
using IdentityServer.DataAccess.Contexts;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.AuthMessage;
using MsSqlAdapter.UnitOfWork;
using ServerBaseContract.Repository.Abstract;

namespace IdentityServer.Business.Concrete
{
    public class AuthMessageManager : BaseService<AuthMessage, CreateAuthMessageRequest, UpdateAuthMessageRequest, AuthMessageResponse>, IAuthMessageService
    {
        private static List<AuthMessageResponse> _messages { get; set; }

        public AuthMessageManager(IAuthMessageDal repository, IQueryableRepositoryBase<AuthMessage> queryable, IUnitOfWork unitOfWork) : base(repository, queryable, unitOfWork)
        {
            
        }

        public async override Task<Response<AuthMessageResponse>> Create(CreateAuthMessageRequest request)
        {
            var res = await base.Create(request);
            if (res.IsSuccessful)
            {
                _messages.Add(res.Data);
            }
            return res;
        }
        public async override Task<Response<AuthMessageResponse>> Update(UpdateAuthMessageRequest request)
        {
            var res = await base.Update(request);
            if (res.IsSuccessful)
            {
                var data = _messages.First(w=>w.Id == res.Data.Id);
                data = res.Data;
            }
            return res;
        }

        public static string Get(int code, MessageType type = MessageType.ResponseMessage, LanguageCode lang = LanguageCode.TR)
        {
            if (_messages != null && _messages.Any(w => w.Code == code && w.Type == type && w.LanguageCode == lang))
            {
                return _messages.First(w => w.Code == code && w.Type == type && w.LanguageCode == lang).Message;
            }
            return "Message Could Not Be Found !!!";
        }

        public async static void Initialize()
        {
            //TODO : Alper Hoş değilllllll....
            _messages = AutoMapperWrapper.Mapper.Map<List<AuthMessageResponse>>(await new AuthMessageDal(new AuthDbContext()).GetListAsync());
        }
    }
}
