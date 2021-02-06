using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EfCarDal;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.CarName = Console.ReadLine().ToString();
            car.DailyPrice = Convert.ToDouble(Console.ReadLine());

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car);

            

            #region Önceki Ödev
            //CarManager carManager = new CarManager(new InMemoryManager());
            //Car car = new Car { Id = 6, BrandId = 7, ColorId = 1, ModelYear = new DateTime(2020, 01, 01), DailyPrice = 200, Description = "Hyundai otomatik vites" };

            //Console.WriteLine("----------------Add/GetById(idsi 5 olan)----------------------");
            //carManager.Add(car);
            //Car carTest1=carManager.GetById(5);
            //Console.WriteLine(carTest1.Description);

            //Console.WriteLine("-------------------GetAll-----------------------");

            //List<Car> cars = carManager.GelAll();
            //foreach (var item in cars)
            //{
            //    Console.WriteLine(item.Description);
            //}

            //Console.WriteLine("--------------------Update(idsi 5 olan)-------------------------");

            //Car carTest2 = new Car { Id = 5, BrandId = 8, ColorId = 1, ModelYear = new DateTime(2020, 01, 01), DailyPrice = 200, Description = "Ford otomatik vites" };
            //carManager.Update(carTest2);

            //List<Car> cars2 = carManager.GelAll();
            //foreach (var item in cars2)
            //{
            //    Console.WriteLine(item.Description);
            //}

            //Console.WriteLine("--------------------Delete(idsi 5 olan)-------------------------");

            //carManager.Delete(carTest2);
            //List<Car> cars3 = carManager.GelAll();
            //foreach (var item in cars3)
            //{
            //    Console.WriteLine(item.Description);
            //} 
            #endregion


        }

    }
}
