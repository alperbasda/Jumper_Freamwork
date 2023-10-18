using EntityBase.Enum;
using IdentityServer.Entities.Db;
using IdentityServer.Entities.Enum;
using Microsoft.EntityFrameworkCore;
using Tools.Hashing;

namespace IdentityServer.DataAccess.Contexts
{
    public class AuthDbContextInitializer
    {
        public static void Init(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>().HasIndex(w => w.NormalizedEmail);
            modelBuilder.Entity<IdentityUser>().HasIndex(w => w.NormalizedUserName);
            modelBuilder.Entity<IdentityUser>().HasIndex(w => w.ClientId);



            #region Auth Messages

            var authMessages = new[]
                {
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)InputError.NotNullNotContainSpace,
                        LanguageCode = LanguageCode.TR,
                        Type = MessageType.InputError,
                        Message = "Bu Alan Bosluk Içeremez ve Bos Olamaz !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)InputError.NotNullNotContainSpace,
                        LanguageCode = LanguageCode.EN,
                        Type = MessageType.InputError,
                        Message = "This Field Is Required !!! This Field Can Not Contains Space !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)InputError.NullOrEmpty,
                        LanguageCode = LanguageCode.EN,
                        Type = MessageType.InputError,
                        Message = "This Field Is Required !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)InputError.NullOrEmpty,
                        LanguageCode = LanguageCode.TR,
                        Type = MessageType.InputError,
                        Message = "Alan Bos Geçilemez !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)InputError.InvalidEmail,
                        LanguageCode = LanguageCode.EN,
                        Type = MessageType.InputError,
                        Message = "Invalid Email !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)InputError.InvalidEmail,
                        LanguageCode = LanguageCode.TR,
                        Type = MessageType.InputError,
                        Message = "Geçersiz E-posta Adresi !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)InputError.InvalidPasswordRequirement,
                        LanguageCode = LanguageCode.EN,
                        Type = MessageType.InputError,
                        Message = "Your password must contain at least 1 lowercase, 1 uppercase, 1 digit and 1 special character. !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)InputError.InvalidPasswordRequirement,
                        LanguageCode = LanguageCode.TR,
                        Type = MessageType.InputError,
                        Message = "Şifreniz En Az 1 Küçük, 1 Büyük, 1 Rakam ve 1 özel karakter içermelidir !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)InputError.InvalidPhoneNumber,
                        LanguageCode = LanguageCode.EN,
                        Type = MessageType.InputError,
                        Message = "Invalid Phone Number !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)InputError.InvalidPhoneNumber,
                        LanguageCode = LanguageCode.TR,
                        Type = MessageType.InputError,
                        Message = "Geçersiz Telefon Numarası !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)InputError.NotSameValue,
                        LanguageCode = LanguageCode.EN,
                        Type = MessageType.InputError,
                        Message = "Passwords Are Not Same !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)InputError.NotSameValue,
                        LanguageCode = LanguageCode.TR,
                        Type = MessageType.InputError,
                        Message = "Şifreler Eşleşmiyor !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)InputError.NotContainSpace,
                        LanguageCode = LanguageCode.EN,
                        Type = MessageType.InputError,
                        Message = "This Field Can Not Contains Space !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)InputError.NotContainSpace,
                        LanguageCode = LanguageCode.TR,
                        Type = MessageType.InputError,
                        Message = "Bu Alan Bosluk Içeremez !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },

                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)ResponseMessage.NotFound,
                        LanguageCode = LanguageCode.EN,
                        Type = MessageType.ResponseMessage,
                        Message = "Data Not Found !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)ResponseMessage.NotFound,
                        LanguageCode = LanguageCode.TR,
                        Type = MessageType.ResponseMessage,
                        Message = "Veri Bulunamadı !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)ResponseMessage.ValidationCodeSent,
                        LanguageCode = LanguageCode.EN,
                        Type = MessageType.ResponseMessage,
                        Message = "Verification Code has been sent !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)ResponseMessage.ValidationCodeSent,
                        LanguageCode = LanguageCode.TR,
                        Type = MessageType.ResponseMessage,
                        Message = "Doğrulama Kodu Gönderildi !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)ResponseMessage.WrongOldKey,
                        LanguageCode = LanguageCode.EN,
                        Type = MessageType.ResponseMessage,
                        Message = "Old Password Is Incorrect !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)ResponseMessage.WrongOldKey,
                        LanguageCode = LanguageCode.TR,
                        Type = MessageType.ResponseMessage,
                        Message = "Eski Şifre Hatalı !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)ResponseMessage.IntervalError,
                        LanguageCode = LanguageCode.EN,
                        Type = MessageType.ResponseMessage,
                        Message = "Interval Error !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)ResponseMessage.IntervalError,
                        LanguageCode = LanguageCode.TR,
                        Type = MessageType.ResponseMessage,
                        Message = "Sunucu Içi Hata !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)ResponseMessage.MailAddressAlreadyTaken,
                        LanguageCode = LanguageCode.EN,
                        Type = MessageType.ResponseMessage,
                        Message = "Mail Address Already Taken !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)ResponseMessage.MailAddressAlreadyTaken,
                        LanguageCode = LanguageCode.TR,
                        Type = MessageType.ResponseMessage,
                        Message = "E-Posta Daha Once Kayıt Edilmiş !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)ResponseMessage.PhoneNumberAlreadyTaken,
                        LanguageCode = LanguageCode.EN,
                        Type = MessageType.ResponseMessage,
                        Message = "Phone Number Already Taken !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)ResponseMessage.PhoneNumberAlreadyTaken,
                        LanguageCode = LanguageCode.TR,
                        Type = MessageType.ResponseMessage,
                        Message = "Telefon Numarası Daha Onceden Alınmış !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)ResponseMessage.Success,
                        LanguageCode = LanguageCode.EN,
                        Type = MessageType.ResponseMessage,
                        Message = "Success !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)ResponseMessage.Success,
                        LanguageCode = LanguageCode.TR,
                        Type = MessageType.ResponseMessage,
                        Message = "Başarılı !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)ResponseMessage.UserNameAlreadyTaken,
                        LanguageCode = LanguageCode.EN,
                        Type = MessageType.ResponseMessage,
                        Message = "User Name Already Taken !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new AuthMessage
                    {
                        Id= Guid.NewGuid(),
                        Code = (int)ResponseMessage.UserNameAlreadyTaken,
                        LanguageCode = LanguageCode.TR,
                        Type = MessageType.ResponseMessage,
                        Message = "Kullanıcı Adı Daha Onceden Alınmış !!!",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },

                };

            modelBuilder.Entity<AuthMessage>().HasData(authMessages);

            #endregion

            #region Client

            Guid vbsClientId = Guid.NewGuid();
            byte[] vbsClientSecret, vbsClientSalt;
            HashingHelper.CreatePasswordHash("jumperPass", out vbsClientSecret, out vbsClientSalt);

            var clients = new[]
               {
                    new Client
                    {
                        Id = vbsClientId,
                        ClientId = "jumper",
                        ClientSecret=vbsClientSecret,
                        ClientSecretSalt = vbsClientSalt,
                        ClientUrl = "",
                        LoginRedirectUrl = "/home",
                        LogoUrl = "",
                        LogoutRedirectUrl ="/login",
                        Name = "DemoSite",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                        Status = EntStatus.Active,
                    },
                };

            modelBuilder.Entity<Client>().HasData(clients);

            #endregion


            #region Client Scope


            var clientScopes = new[]
               {
                    new ClientScope
                    {
                        Id = Guid.NewGuid(),
                      OwnerId= vbsClientId,
                      ExpiredDate= null,
                      Scope = "site_client_scope",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                };

            modelBuilder.Entity<ClientScope>().HasData(clientScopes);

            #endregion

            #region Role

            Guid userRoleId = Guid.Parse("35215d8e-1c9b-49f4-8dce-f257185cf989");
            Guid managerRoleId = Guid.Parse("36215d8e-1c9b-49f4-8dce-f257185cf989");
            Guid adminRoleId = Guid.Parse("37215d8e-1c9b-49f4-8dce-f257185cf989");
            Guid personnelRoleId = Guid.Parse("34215d8e-1c9b-49f4-8dce-f257185cf989");

            var roles = new[]
               {
                    new Role
                    {
                        Id = managerRoleId,
                        Name = "Manager",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new Role
                    {
                        Id = personnelRoleId,
                        Name = "Personnel",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new Role
                    {
                        Id = adminRoleId,
                        Name = "Admin",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },

                    new Role
                    {
                        Id = userRoleId,
                        Name = "User",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                };

            modelBuilder.Entity<Role>().HasData(roles);

            #endregion

            #region Role Scope

            var roleScopes = new[]
               {
                    new RoleScope
                    {
                        Id = Guid.NewGuid(),
                        OwnerId = adminRoleId,
                        ExpiredDate= null,
                        Scope ="admin_user_scope",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new RoleScope
                    {
                        Id = Guid.NewGuid(),
                        OwnerId = userRoleId,
                        ExpiredDate= null,
                        Scope ="user_role_scope",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new RoleScope
                    {
                        Id = Guid.NewGuid(),
                        OwnerId = managerRoleId,
                        ExpiredDate= null,
                        Scope ="manager_role_scope",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                    new RoleScope
                    {
                        Id = Guid.NewGuid(),
                        OwnerId = personnelRoleId,
                        ExpiredDate= null,
                        Scope ="personnel_role_scope",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    },
                };

            modelBuilder.Entity<RoleScope>().HasData(roleScopes);

            #endregion

            #region Identity User

            var identityUserAdminId = Guid.NewGuid();

            var identityUsers = new[]
               {
                    new IdentityUser
                    {
                        Id = identityUserAdminId,
                        Name ="Alper",
                        Surname = "Başda",
                        Email = "admin@admin.com",
                        NormalizedEmail = "admin@admin.com",
                        NormalizedUserName ="admin",
                        UserName="admin",
                        PhoneNumber="5555555555",
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                        ClientId = "jumper",
                        Status = EntStatus.Active
                    }
                };

            modelBuilder.Entity<IdentityUser>().HasData(identityUsers);

            #endregion

            #region Identity User Password

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash("admin", out passwordHash, out passwordSalt);

            var identityUserPasswords = new[]
               {
                    new IdentityUserPassword
                    {
                        Id = Guid.NewGuid(),
                        OwnerId = identityUserAdminId,
                        PasswordHash=passwordHash,
                        PasswordSalt=passwordSalt,
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    }

                };

            modelBuilder.Entity<IdentityUserPassword>().HasData(identityUserPasswords);

            #endregion

            #region Identity User Role

            var identityUserRoles = new[]
               {
                    new IdentityUserRole
                    {
                        Id = Guid.NewGuid(),
                        IdentityUserId= identityUserAdminId,
                        RoleId = adminRoleId,
                        ExpiredDate= null,
                        CreateTime= DateTime.Now,
                        UpdateTime= DateTime.Now,
                    }
                };

            modelBuilder.Entity<IdentityUserRole>().HasData(identityUserRoles);

            #endregion
        }


    }
}
