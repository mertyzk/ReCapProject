using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Business.Constans
{
    public static class Messages
    {
        public static string AddedMsg = "Ekleme başarılı";
        public static string InvalidAddMsg = "Ekleme başarısız!";
        public static string DeletedMsg = "Silme başarılı";
        public static string InvalidDeleteMsg = "Silme başarısız!";
        public static string UpdatedMsg = "Güncelleme başarılı";
        public static string InvalidUpdateMsg = "Güncelleme başarısız!";
        public static string InvalidNameMsg = "Lütfen isim kontrolü yapınız";
        public static string MaintenanceTime = "Sistem bakım çalışması...";
        public static string ListedMsg = "Listeleme başarılı";
        public static string InvalidListMsg = "Listeleme işlemi başarısız!";
        public static string CarCountOfBrandError = "Bu markaya eklenebilecek araç sayısı aşıldı";
        public static string CarDescriptionAlreadyExists = "Bu açıklamayla daha önce ekleme yapılmış";
        public static string BrandLimitExceded = "Daha fazla marka ekleyemezsiniz";
        public static string CarImageLimitExceded = "Bir aracın en fazla 5 resmi olabilir";
        public static string ImageAddedMsg= "Resim başarıyla yüklendi";
        public static string UserNotFound = "Kullanıcı bulunamadı!";
        public static string PasswordError = "Hatalı şifre girdiniz!";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kayıt başarılı!";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu";
        public static string AccessTokenCreatingError = "Access Token oluşturulamadı!";
    }
}
