using System.ComponentModel;

namespace IdentityServer.Entities.Enum
{
    public enum MessageType
    {
        [Description("Dönüş Mesajı")]
        ResponseMessage = 0,
        [Description("Input Hata Mesajı")]
        InputError = 1
    }
    public enum ResponseMessage
    {
        [Description("Bulunamadı")]
        NotFound = 0,
        [Description("Başarılı")]
        Success = 1,
        [Description("Sunucu İçi Hata")]
        IntervalError = 2,
        [Description("Kullanıcı Adı Alınmış")]
        UserNameAlreadyTaken = 3,
        [Description("E-Posta Adresi Alınmış")]
        MailAddressAlreadyTaken = 4,
        [Description("Telefon Numarası Alınmış")]
        PhoneNumberAlreadyTaken = 5,
        [Description("Eski Anahtar Hatalı")]
        WrongOldKey = 6,
        [Description("Doğrulama Kodu Gönderildi")]
        ValidationCodeSent = 7
    }

    public enum InputError
    {
        [Description("Boş Geçilemez")]
        NullOrEmpty = 0,
        [Description("Boşluk İçeremez")]
        NotContainSpace = 1,
        [Description("Boşluk İçeremez ve Boş Olamaz")]
        NotNullNotContainSpace = 2,
        [Description("Veriler Eşleşmiyor")]
        NotSameValue = 3,
        [Description("Şifre Gereksinimleri Karşılamıyor")]
        InvalidPasswordRequirement = 4,
        [Description("E-Posta Geçirsiz")]
        InvalidEmail = 5,
        [Description("Telefon Numarası Geçersiz")]
        InvalidPhoneNumber = 6,
    }
}
