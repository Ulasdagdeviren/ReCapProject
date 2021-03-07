using ReCapProject.Core.Entities.Concrete;
using ReCapProject.Entities.CarDetail;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ReCapProject.Business.Cantact
{
    public class Messages
    {
        internal static string CarListed="Ürün Getilirdi";
        internal static string ProductAdded="Araba Eklendi";
        internal static string CarUpdate="Arabalar Güncellendi";
        internal static string CarDataListed="Arabalar Listelendi";
        internal static string MaintenanceTime="Bakımda";
        internal static string ProductNameReadyExist="bu isimde ürün var";
        internal static string CarImageAdded="Resim eklendi";
        internal static string CarImageDeleted="Resim silindi";
        internal static string CarImageNotAdded="Resim sayısı 5'i geçtiği için resim eklenemedi";
        internal static string Updated="Resim güncellendi";
        internal static string  AuthorizationDenied="yetkiniz yok";
        internal static string UserRegistered="kayıt oldu";
        internal static string UserNotFound="Kullanıcı bulunamadı";
        internal static string PasswordError="Şifre yanlış veya hatalı";
        internal static string SuccessfulLogin="Giriş başarılı";
        internal static string UserAlreadyExists="kullanıcı mevcut";
        internal static string AccessTokenCreated="Access Token başarıyla oluşturuldu";
    }
}
