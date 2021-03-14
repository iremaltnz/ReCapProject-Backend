using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarAddedError = "Araba günlük fiyati 0 dan büyük olmali ve araba ismi minimum iki karakter olmalidir. Ekleme Basarisiz!!";

        public static string CarDelete = "Araba silme islemi basarili";
        public static string CarDeleteError = "Araba silme islemi basarisiz";

        public static string CarUpdated = "Araba güncelleme islemi basarili";
        public static string CarUpdatedError = "Araba güncelleme islemi basarisiz";

        public static string CarDetail = "Araba detayları listelendi";
        public static string CarDetailError = "Araba detayları listeleme islemi basarisiz";

        public static string CarListed = "Araba listeleme başarili";
        public static string CarListedError = "Araba listeleme basarisiz";



        public static string BrandAdded = "Marka eklendi";
        public static string BrandAddedError = "Marka ekleme islemi basarisiz";

        public static string BrandDeleted = "Marka silindi";
        public static string BrandDeletedError = "Marka silme islemi basarisiz";

        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandUpdatedError = "Marka güncelleme islemi basarisiz";

        public static string BrandListed = "Marka listelendi";
        public static string BrandListedError = "Marka listelenme islemi basarisiz";



        public static string ColorAdded = "Renk eklendi";
        public static string ColorAddedError = "Renk ekleme islemi basarisiz";

        public static string ColorDeleted = "Renk silindi";
        public static string ColorDeletedError = "Renk silme islemi basarisiz";

        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorUpdatedError = "Renk güncellene islemi basarisiz";

        public static string ColorListed = "Renk listelendi";
        public static string ColorListedError = "Renk silme islemi basarisiz";



        public static string RentalAdded = "Kiralama eklendi";
        public static string RentalAddedError = "Yeni Araba kiralayabilmek icin önceki kiralanmis arabanin teslim edilmesi gerekir.";
        public static string RentalDeleted = "Kiralama silindi";
        public static string RentalUpdated = "Kiralama güncellendi";
        public static string RentalListed = "Kiralama listelendi";

        public static string CustomerAdded = "Musteri eklendi";
        public static string CustomerDeleted = "Musteri silindi";
        public static string CustomerUpdated = "Musteri güncellendi";
        public static string CustomerListed = "Musteri listelendi";
        public static string CustomerDetailListed = "Musteri detayi listelendi";
        

        public static string UserAdded = "Kullanici eklendi";
        public static string UserDeleted = "Kullanici silindi";
        public static string UserUpdated = "Kullanici güncellendi";
        public static string UserListed = "Kullanici listelendi";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserNotFound = "Kullanici bulunamadi";
        public static string PasswordError = "Sifre hatali";
        public static string UserRegistered = "Kullanici kaydı başarili";

        public static string RentalDetailListed = "Kira detayi listelendi";
    }
}
