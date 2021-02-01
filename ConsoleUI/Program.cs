using Business.Abstract;
using Business.Concrete;
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
            CarManager carManager = new CarManager(new InMemoryManager());
            Car car = new Car { Id = 6, BrandId = 7, ColorId = 1, ModelYear = new DateTime(2020, 01, 01), DailyPrice = 200, Description = "Hyundai otomatik vites" };

            carManager.Add(car);
            Car c=carManager.GetById(5);
            Console.WriteLine(c.Description);

            Console.WriteLine("---------------------------------------------");

            List<Car> cars = carManager.GelAll();
            foreach (var item in cars)
            {
                Console.WriteLine(item.Description);
            }
            
        }
    }
}
