﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Kayıt işlemi başarılı bir şekilde gerçekleştirildi.";
        public static string Updatetd = "Kayıt başarılı bir şekilde güncellendi.";
        public static string Deleted = "Kayıt başarılı bir şekilde silindi.";
        public static string Error = "İşlem sırasında hata oluştu!";
        public static string List = "Kayıtlar listendi.";
        public static string RentedCar = "Araç kiralandı.";
        public static string RentCarError = "Araç kiralanmaya Uygun Değildir.";
        internal static string CarImagesLimitedExceeded = "Bir arabaya ait eklenebilecek resim limiti aşıldığı için yeni bir resim eklenemiyor..";
        internal static string AuthorizationDenied = "Yetkiniz yoktur";
        internal static string CarNotAvailable = "Araç kiralanmaya uygun değildir.";
        internal static string CarAvailable = "Araç kiralanmaya uygundur.";
        internal static string CarFindexAvailable = "Findex puanınız aracı kiralamak için yetersizdir.";
    }
}
