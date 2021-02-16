using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EfCarDal;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            bool loop = true;
            while (loop)
            {
                Console.WriteLine(
                    "Rent A Car \n***************************MENÜ**********************************" +
                    "\n\n1.Araba Ekleme\n" +
                    "2.Araba Silme\n" +
                    "3.Araba Güncelleme\n" +
                    "4.Arabaların Listelenmesi\n" +
                    "5.Arabaların detaylı bir şekilde Listelenmesi\n" +
                    "6.Arabaların Marka Id'sine göre Listelenmesi\n" +
                    "7.Arabaların Renk Id'sine göre Listelenmesi\n" +
                    "8.Arabaların fiyat aralığına göre Listelenmesi\n" +
                    "9.Arabaların model yılına göre Listelenmesi\n" +
                    "10.Müşteri Ekleme\n" +
                    "11.Müşterilerin Listelenmesi\n" +
                    "12.Kullanıcı Ekleme\n" +
                    "13.Kullanıcıların Listelenmesi\n" +
                    "14.Araba Kiralama\n" +
                    "15.Araba Teslim Etme\n" +
                    "16.Araba Kiralama Listesi\n" +
                    "17.Çıkış\n" +
                    "Yukarıdakilerden hangi işlemi gerçekleştirmek istiyorsunuz ?"
                    );


                int number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n******************************************************************\n");
                switch (number)
                {
                    case 1:
                        AddCar(carManager, colorManager, brandManager);
                        break;
                    case 2:
                        DeleteCar(carManager);
                        break;
                    case 3:
                        UpdateCar(carManager);
                        break;
                    case 4:
                        ListCars(carManager);
                        break;
                    case 5:
                        CarDetail(carManager);
                        break;
                    case 6:
                        GetCarsByBrandId(carManager, brandManager);
                        break;
                    case 7:
                        GetCarsByColorId(carManager, colorManager);
                        break;
                    case 8:
                        CarListByPriceRange(carManager);
                        break;
                    case 9:
                        CarListByMdelYeare(carManager);
                        break;
                    case 10:
                        AddCustomer(customerManager, userManager);
                        break;
                    case 11:
                        ListCustomer(customerManager);
                        break;

                    case 12:
                        AddUser(userManager);
                        break;
                    case 13:
                        ListUser(userManager);
                        break;
                    case 14:
                        RentACar(customerManager, rentalManager, carManager);
                        break;
                    case 15:
                        DeliveryCar(rentalManager);
                        break;
                    case 16:
                        RentalList(rentalManager);
                        break;
                    case 17:
                        Console.WriteLine("Programdan çıkış yaptınız.\nİyi günler...");
                        loop = false;
                        break;
                    default:
                        break;
                }

            }

        }
        private static void AddCar(CarManager carManager, ColorManager colorManager, BrandManager brandManager)
        {
            var colorList = colorManager.GetAll();
            if (colorList.Data != null)
            {
                foreach (var color in colorList.Data)
                {
                    Console.WriteLine(color.Id + "." + color.ColorName);
                }

                Console.WriteLine("********************************************");
            }

            var brandList = brandManager.GetAll();
            if (brandList.Data != null)
            {
                foreach (var brand in brandList.Data)
                {
                    Console.WriteLine(brand.Id + "." + brand.BrandName);
                }
                Console.WriteLine("********************************************");
            }

            Car car = new Car();
            Console.WriteLine("Araç modelini giriniz");
            car.CarName = (Console.ReadLine()).ToString();
            Console.WriteLine("Araç renk idsi giriniz");
            car.ColorId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Araç marka idsi giriniz");
            car.BrandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Araç günlük fiyat bilgisini giriniz");
            car.DailyPrice = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Araç model yılı giriniz");
            car.ModelYear = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Araç detay bilgisini giriniz");
            car.Description = (Console.ReadLine()).ToString();

            var result = carManager.Add(car);
            Console.WriteLine("\n" + result.Message);

            var carList = carManager.GetAll();
            foreach (var item in carList.Data)
            {
                Console.WriteLine("\n" + item.CarName + " " + item.DailyPrice + " " + item.Description);
            }




        }

        private static void DeleteCar(CarManager carManager)
        {
            var carList = carManager.GetAll();
            Console.WriteLine(" Silmek istediğiniz araç İdsini giriniz.");
            foreach (var item in carList.Data)
            {
                Console.WriteLine("\n" + item.Id + " " + item.CarName + " " + item.DailyPrice + " " + item.Description);
            }

            int carId = Convert.ToInt32(Console.ReadLine());
            var car = carManager.GetById(carId);
            var msg = carManager.Delete(car.Data);
            Console.WriteLine("\n" + msg.Message);
        }
        private static void UpdateCar(CarManager carManager)
        {
            var carList = carManager.GetAll();
            Console.WriteLine(" Güncellemek istediğiniz araç İdsini giriniz.");
            foreach (var item in carList.Data)
            {
                Console.WriteLine("\n" + item.Id + " " + item.CarName + " " + item.DailyPrice + " " + item.Description);
            }

            int carId = Convert.ToInt32(Console.ReadLine());
            var car = carManager.GetById(carId);
            Console.WriteLine("Araç modelini giriniz");
            car.Data.CarName = (Console.ReadLine()).ToString();
            Console.WriteLine("Araç renk idsi giriniz");
            car.Data.ColorId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Araç marka idsi giriniz");
            car.Data.BrandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Araç günlük fiyat bilgisini giriniz");
            car.Data.DailyPrice = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Araç model yılı giriniz");
            car.Data.ModelYear = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Araç detay bilgisini giriniz");
            car.Data.Description = (Console.ReadLine()).ToString();

            var msg = carManager.Update(car.Data);
            Console.WriteLine("\n" + msg.Message);
        }

        private static void ListCars(CarManager carManager)
        {
            var carList = carManager.GetAll();
            foreach (var item in carList.Data)
            {
                Console.WriteLine("\n" + item.Id + " " + item.CarName + " " + item.DailyPrice + " " + item.Description);
            }
        }
        private static void CarDetail(CarManager carManager)
        {
            var carList = carManager.GetAll();
            Console.WriteLine("Detayını görmek istediğiniz aracın idsini giriniz. \n");
            foreach (var item in carList.Data)
            {
                Console.WriteLine("\n" + item.Id + " " + item.CarName);
            }

            int carId = Convert.ToInt32(Console.ReadLine());
            var carDetail = carManager.GetCarDetailById(carId);
            Console.WriteLine(carDetail.Data.CarName + " " + carDetail.Data.BrandName + " " + carDetail.Data.ColorName + " " + carDetail.Data.DailyPrice + " " + carDetail.Data.Description);
        }

        private static void GetCarsByBrandId(CarManager carManager, BrandManager brandManager)
        {
            var brandList = brandManager.GetAll();
            foreach (var item in brandList.Data)
            {
                Console.WriteLine("\n" + item.Id + " " + item.BrandName);
            }
            Console.WriteLine("Markaya göre araç listesini görmek için bir marka idsi giriniz. \n");

            var brandId = Convert.ToInt32(Console.ReadLine());
            var carList = carManager.GetCarsByBrandId(brandId);

            foreach (var item in carList.Data)
            {
                Console.WriteLine("\n" + item.CarName + " " + item.DailyPrice + " " + item.Description);
            }


        }
        private static void GetCarsByColorId(CarManager carManager, ColorManager colorManager)
        {
            var colorList = colorManager.GetAll();
            foreach (var item in colorList.Data)
            {
                Console.WriteLine("\n" + item.Id + " " + item.ColorName);
            }
            Console.WriteLine("Renge göre araç listesini görmek için bir marka idsi giriniz. \n");

            var colorId = Convert.ToInt32(Console.ReadLine());
            var carList = carManager.GetCarsByBrandId(colorId);

            foreach (var item in carList.Data)
            {
                Console.WriteLine("\n" + item.CarName + " " + item.DailyPrice + " " + item.Description);
            }


        }
        private static void CarListByPriceRange(CarManager carManager)
        {
            Console.WriteLine("Fiyat aralığına göre araç listesi \n");
            Console.WriteLine("Min. günlük araç fiyatını giriniz. \n");
            var minPrice = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Max günlük araç fiyatını giriniz. \n");
            var maxPrice = Convert.ToInt64(Console.ReadLine());

            var carList = carManager.GetCarDetails(c => c.DailyPrice >= minPrice && c.DailyPrice <= maxPrice);
            foreach (var item in carList.Data)
            {
                Console.WriteLine("\n" + item.Id + ". " + item.CarName + " " + item.BrandName + " " + item.ColorName + " " + item.DailyPrice + " " + item.Description);
            }


        }
        private static void CarListByMdelYeare(CarManager carManager)
        {
            Console.WriteLine("Model yılına göre araç listesi \n");
            Console.WriteLine("Araç model yılı giriniz \n");
            DateTime date = Convert.ToDateTime(Console.ReadLine());


            var carList = carManager.GetCarDetails(c => c.ModelYear == date);
            foreach (var item in carList.Data)
            {
                Console.WriteLine("\n" + item.Id + ". " + item.CarName + " " + item.BrandName + " " + item.ColorName + " " + item.DailyPrice + " " + item.Description);
            }


        }

        private static void AddCustomer(CustomerManager customerManager, UserManager userManager)
        {
            Customer customer = new Customer();

            Console.WriteLine("Bir kullanıcı seçiniz yok ise önce kullanıcı kayıt edin");

            var userList = userManager.GetAll();
            foreach (var user in userList.Data)
            {
                Console.WriteLine(user.Id + " - " + user.FirstName + " " + user.LastName + "\n");
            }

            Console.WriteLine("Kullanıcı idsi");
            customer.UserId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Firma ismi giriniz");
            customer.CompanyName = (Console.ReadLine()).ToString();

            var result = customerManager.Add(customer);
            Console.WriteLine(result.Message);



        }
        private static void ListCustomer(CustomerManager customerManager)
        {
            var customerList = customerManager.GetAll();

            foreach (var user in customerList.Data)
            {
                Console.WriteLine(user.Id + " . " + user.CompanyName);
            }
        }
        private static void AddUser(UserManager userManager)
        {
            User user = new User();
            Console.WriteLine("Kullanıcı adı giriniz");
            user.FirstName = (Console.ReadLine()).ToString();
            Console.WriteLine("Kullanıcı soyadı giriniz");
            user.LastName = (Console.ReadLine()).ToString();
            Console.WriteLine("Kullanıcı email giriniz");
            user.Email = (Console.ReadLine()).ToString();
            Console.WriteLine("Kullanıcı şifresi giriniz");
            user.Password = (Console.ReadLine()).ToString();

            var result = userManager.Add(user);
            Console.WriteLine(result.Message);

        }
        private static void ListUser(UserManager userManager)
        {
            var userList = userManager.GetAll();

            foreach (var user in userList.Data)
            {
                Console.WriteLine(user.Id + " . " + user.FirstName + " " + user.LastName + " " + user.Email + " " + user.Password);
            }
        }
        private static void RentACar(CustomerManager customerManager, RentalManager rentalManager, CarManager carManager)
        {
            Console.WriteLine("\nGereken bilgileri giriniz.\n");
            Console.WriteLine("********************************************");
            Console.WriteLine("Araç listesi");
            var rentList = carManager.GetAll();
            foreach (var rent in rentList.Data)
            {
                Console.WriteLine(rent.Id + " " + rent.CarName);
            }
            Console.WriteLine("\n********************************************");
            Rental rental = new Rental();
           
            Console.WriteLine("Firma idsini giriniz.\n");

            var customerList = customerManager.GetAll();
            foreach (var customer in customerList.Data)
            {
                Console.WriteLine(customer.Id + ". " + customer.CompanyName);
            }
            int companyId = Convert.ToInt32(Console.ReadLine());
            rental.CustomerId = companyId;

            Console.WriteLine("Listeden seçtiğiniz aracın idsini giriniz.\n");
            int carId = Convert.ToInt32(Console.ReadLine());
            var rentInfo = rentalManager.CheckCarAvailable(carId);
            if(rentInfo.Success==true)
            {
                rental.CarId = carId;
                Console.WriteLine("Aracın kiralandığı günü giriniz \n");
                DateTime date = Convert.ToDateTime(Console.ReadLine());
                rental.RentDate = date;

                var result = rentalManager.Add(rental);
                Console.WriteLine("\n" + result.Message);

            }
            else
            {
                Console.WriteLine(rentInfo.Message);
            }



        }

        private static void DeliveryCar(RentalManager rentalManager)
        {
            Console.WriteLine("Kiralanmış araçlar");
            var rentedCar = rentalManager.GetRentalDetails(x => x.ReturnDate == null);
            foreach (var car in rentedCar.Data)
            {
                Console.WriteLine(car.Id + ". " + car.CarName + " " + car.CompanyName + " " + car.RentDate);
            }

            Console.WriteLine("\n Teslim etmek istediğiniz aracın idsini giriniz. \n");
            int rentedCarId = Convert.ToInt32(Console.ReadLine());

            var getRentedCar = rentalManager.Get(rentedCarId);

            Console.WriteLine("\n Teslim tarihini giriniz. \n");
            DateTime returnDate = Convert.ToDateTime(Console.ReadLine());
            getRentedCar.Data.ReturnDate = returnDate;
            rentalManager.Update(getRentedCar.Data);

            Console.WriteLine(getRentedCar.Message);
        }
        private static void RentalList(RentalManager rentalManager)
        {
            var resultList = rentalManager.GetRentalDetails();
            foreach (var rental in resultList.Data)
            {
                Console.WriteLine(rental.CarName + " " + rental.CompanyName + " " + rental.RentDate + " " + rental.ReturnDate);
            }
        }

    }
}
