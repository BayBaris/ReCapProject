using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            int options = -1;
            while (options != 0)
            {

                Console.WriteLine("1)List All\n" +
                    "2)List All By BrandID\n" +
                    "3)List All By ColorID\n" +
                    "4)Add\n" +
                    "5)Delete\n" +
                    "6)Update\n" +
                    "0)Exit" +
                    "");
                options = Convert.ToInt32(Console.ReadLine());
                switch (options)
                {
                    case 1:
                        Console.WriteLine("-----Car List-----");
                        foreach (var cars in carManager.GetAll())
                        {
                            Console.WriteLine("CarID: " + cars.CarID);
                            Console.WriteLine("BrandID: " + cars.BrandID);
                            Console.WriteLine("ColorID: " + cars.ColorID);
                            Console.WriteLine("Model Year:" + cars.ModelYear);
                            Console.WriteLine("Daily Price: " + cars.DailyPrice);
                            Console.WriteLine("Description: " + cars.Descriptions);
                            Console.WriteLine("------------------");
                        }
                        break;
                    case 2:
                        Console.WriteLine("-----Car List but Only BrandID-----");
                        Console.WriteLine("Enter Brand ID:");
                        int brandID = Convert.ToInt32(Console.ReadLine());
                        foreach (var cars in carManager.GetByBrandID(brandID))
                        {
                            Console.WriteLine("CarID: " + cars.CarID);
                            Console.WriteLine("ColorID: " + cars.ColorID);
                            Console.WriteLine("Model Year:" + cars.ModelYear);
                            Console.WriteLine("Daily Price: " + cars.DailyPrice);
                            Console.WriteLine("Description: " + cars.Descriptions);
                            Console.WriteLine("------------------");
                        }
                        break;
                    case 3:
                        Console.WriteLine("-----Car List but Only ColorID-----");
                        Console.WriteLine("Enter Color ID:");
                        int colorID = Convert.ToInt32(Console.ReadLine());
                        foreach (var cars in carManager.GetByBrandID(colorID))
                        {
                            Console.WriteLine("CarID: " + cars.CarID);
                            Console.WriteLine("BrandID: " + cars.BrandID);
                            Console.WriteLine("Model Year:" + cars.ModelYear);
                            Console.WriteLine("Daily Price: " + cars.DailyPrice);
                            Console.WriteLine("Description: " + cars.Descriptions);
                            Console.WriteLine("------------------");
                        }
                        break;
                    case 4:
                        carManager.Add(new Car {BrandID = 1, ColorID = 1, DailyPrice = 1450, ModelYear = "2019", Descriptions = "Tesla Model Y" });
                        break;
                    case 5:
                        int deleteCar;
                        deleteCar = Convert.ToInt32(Console.ReadLine());
                        carManager.Delete(new Car { CarID = deleteCar });
                        break;
                    case 6:
                        carManager.Update(new Car {CarID = 9,BrandID = 1, ColorID = 2, DailyPrice = 1100, ModelYear = "2021", Descriptions = "Tesla Roadstar" });
                        break;
                    
                    default:
                        break;
                }

            }
            
            //Adding car in system...
            
            
            
            
        }
    }
}
