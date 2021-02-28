using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün İsmi Geçersiz";
        public static string ProdcutsListed = "Ürinler Listelendi";
        public static string MaintenanceTime = "Bakım Zamanında";
        public static string CategoryAdetUyarısı = "Bu kategoride en fazla 10 ürün eklenebilir.";
        public static string NameAlreadyExists = "Bu ürün ismi zaten daha once kullanılmış.";
        public static string AuthorizationDenied = "Yetkilendirme reddedildi.";
        public static string UserRegistered = "Kullanıcı Kaydedildi.";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Hatalı Şifre";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı Zaten Var";
        public static string AccessTokenCreated = "Token Oluşturuldu";
    }
}
