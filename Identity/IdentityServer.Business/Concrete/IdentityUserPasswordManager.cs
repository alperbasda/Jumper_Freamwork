using EntityBase.Enum;
using EntityBase.Poco.Responses;
using IdentityServer.Business.Contracts;
using IdentityServer.Business.Extensions;
using IdentityServer.DataAccess.Contracts;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Enum;
using IdentityServer.Entities.Poco.UserPassword;
using MsSqlAdapter.UnitOfWork;
using Tools.Hashing;

namespace IdentityServer.Business.Concrete
{
    public class IdentityUserPasswordManager : IIdentityUserPasswordService
    {
        IIdentityUserPasswordDal _identityUserPasswordDal;
        IUnitOfWork _unitOfWork;
        public IdentityUserPasswordManager(IIdentityUserPasswordDal identityUserPasswordDal, IUnitOfWork unitOfWork)
        {
            _identityUserPasswordDal = identityUserPasswordDal;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CheckPasswordAsync(Guid ownerId, string password)
        {
            var pass = await _identityUserPasswordDal.GetAsync(w => w.OwnerId == ownerId);
            return pass != null && HashingHelper.VerifyPasswordHash(password, pass.PasswordHash, pass.PasswordSalt);
        }

        public async Task<Response<MessageResponse>> CreateAsync(CreateIdentityUserPasswordRequest createIdentityUserPasswordRequest)
        {
            var identityUserPassword = new IdentityUserPassword();
            byte[] secretHash, secretSalt;
            HashingHelper.CreatePasswordHash(createIdentityUserPasswordRequest.NewPassword, out secretHash, out secretSalt);
            identityUserPassword.PasswordSalt = secretSalt;
            identityUserPassword.PasswordHash = secretHash;
            identityUserPassword.OwnerId = createIdentityUserPasswordRequest.OwnerId;
            if (_identityUserPasswordDal.SetState(identityUserPassword, OperationType.Create) == null)
                return Response<MessageResponse>.Fail(ResponseMessage.IntervalError.GetMessage(), 500);

            await _unitOfWork.CommitAsync();
            return Response<MessageResponse>.Success(ResponseMessage.Success.GetMessage(), 201);
        }
    }
}
