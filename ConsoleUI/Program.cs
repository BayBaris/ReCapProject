using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            int options = -1;
            while (options != 0)
            {

                Console.WriteLine("1)List All\n" +
                    "2)List All By BrandID\n" +
                    "3)Add\n" +
                    "4)Delete\n" +
                    "5)Update\n" +
                    "0)Exit" +
                    "");
                options = Convert.ToInt32(Console.ReadLine());
                switch (options)
                {
                    case 1:
                        Console.WriteLine("-----Car List-----");
                        foreach (var cars in carManager.GetAll())
                        {
                            Console.WriteLine("Car ID: " + cars.CarID);
                            Console.WriteLine("Brand ID: " + cars.BrandID);
                            Console.WriteLine("Color ID: " + cars.ColorID);
                            Console.WriteLine("Model Year:" + cars.ModelYear);
                            Console.WriteLine("Daily Price: " + cars.DailyPrice);
                            Console.WriteLine("Description: " + cars.Description);
                            Console.WriteLine("------------------");
                        }
                        break;
                    case 2:
                        Console.WriteLine("-----Car List but Only BrandID = 2-----");
                        foreach (var cars in carManager.GetByCarID(2))
                        {
                            Console.WriteLine("Car ID: " + cars.CarID);
                            Console.WriteLine("Color ID: " + cars.ColorID);
                            Console.WriteLine("Model Year:" + cars.ModelYear);
                            Console.WriteLine("Daily Price: " + cars.DailyPrice);
                            Console.WriteLine("Description: " + cars.Description);
                            Console.WriteLine("------------------");
                        }
                        break;
                    case 3:
                        carManager.Add(new Car { CarID = 8, BrandID = 3, ColorID = 4, DailyPrice = 2100, ModelYear = 2020, Description = "Lamborghini Aveador" });
                        break;
                    case 4:
                        carManager.Delete(new Car { CarID = 1 });
                        break;
                    case 5:
                        carManager.Update(new Car { CarID = 2, BrandID = 1, ColorID = 2, DailyPrice = 1100, ModelYear = 2021, Description = "Tesla Roadstar" });
                        break;
                    
                    default:
                        break;
                }

            }
            
            //Adding car in system...
            
            
            
            
        }
    }
}
