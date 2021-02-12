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
            int managerSelection = -1;
            while (managerSelection != 0)
            {
                Console.WriteLine("[1] Run Car Manager\n" +
                    "[2] Run Color Manager\n" +
                    "[3] Run Brand Manager\n" +
                    "[0] Exit Program");

                managerSelection = Convert.ToInt32(Console.ReadLine());
                switch (managerSelection)
                {
                    case 1:
                        RunCarManager();
                        break;
                    case 2:
                        RunColorManager();
                        break;
                    case 3:
                        RunBrandManager();
                        break;
                    default:
                        break;
                }
            }          
        }

        private static void RunBrandManager()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            int options = -1;
            while (options != 0)
            {
                Console.WriteLine("1)List All Brand\n" +
                    "2)Get Brand By ID\n" +
                    "3)Add Brand\n" +
                    "4)Delete Brand\n" +
                    "5)Update Brand\n" +
                    "0)Exit Menu" +
                    "");
                options = Convert.ToInt32(Console.ReadLine());
                switch (options)
                {
                    case 1:
                        foreach (var brand in brandManager.GetAll())
                        {
                            Console.WriteLine("Brand ID: {0} = {1}", brand.BrandID, brand.BrandName);
                        }
                        break;
                    case 2:
                        Console.WriteLine(brandManager.GetID(2).BrandName);
                        break;
                    case 3:
                        Console.WriteLine("-Enter Brand Name-");
                        string addedbrand = Console.ReadLine();
                        brandManager.Add(new Brand { BrandName = addedbrand });
                        break;
                    case 4:
                        Console.WriteLine("-Enter Brand ID-");
                        int deletedbrand = Convert.ToInt32(Console.ReadLine());
                        brandManager.Delete(new Brand { BrandID = deletedbrand });
                        break;
                    case 5:
                        Console.WriteLine("-Enter Brand ID-");
                        int updatedbrand = Convert.ToInt32(Console.ReadLine());
                        brandManager.Update(new Brand { BrandID = updatedbrand, BrandName = "BMW" });
                        break;
                    default:
                        break;
                }
            }
        }

        private static void RunColorManager()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            int options = -1;
            while (options != 0)
            {
                Console.WriteLine("1)List All Color\n" +
                    "2)Get Color By ID\n" +
                    "3)Add Color\n" +
                    "4)Delete Color\n" +
                    "5)Update Color\n" +
                    "0)Exit Menu" +
                    "");
                options = Convert.ToInt32(Console.ReadLine());
                switch (options)
                {
                    case 1:
                        foreach (var color in colorManager.GetAll())
                        {
                            Console.WriteLine("Color ID: {0} = {1}", color.ColorID, color.ColorName);
                        }
                        break;
                    case 2:
                        Console.WriteLine(colorManager.GetID(2).ColorName);
                        break;
                    case 3:
                        Console.WriteLine("-Enter Color Name-");
                        string addedColor = Console.ReadLine();
                        colorManager.Add(new Color {ColorName = addedColor});
                        break;
                    case 4:
                        Console.WriteLine("-Enter Color ID-");
                        int deletedColor = Convert.ToInt32(Console.ReadLine());
                        colorManager.Delete(new Color { ColorID = deletedColor});
                        break;
                    case 5:
                        Console.WriteLine("-Enter Color ID-");
                        int updatedColor = Convert.ToInt32(Console.ReadLine());
                        colorManager.Update(new Color { ColorID = updatedColor,ColorName = "Sarı"});
                        break;
                    default:
                        break;
                }
            }
        }

        private static void RunCarManager()
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
                    "7)List All Car With Details\n" +
                    "0)Exit Menu" +
                    "");
                options = Convert.ToInt32(Console.ReadLine());
                switch (options)
                {
                    case 1:
                        Console.WriteLine("-----Car List-----");
                        foreach (var cars in carManager.GetAll())
                        {
                            Console.WriteLine("Name: " + cars.CarName);
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
                            Console.WriteLine("Name: " + cars.CarName);
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
                            Console.WriteLine("Name: " + cars.CarName);
                            Console.WriteLine("BrandID: " + cars.BrandID);
                            Console.WriteLine("Model Year:" + cars.ModelYear);
                            Console.WriteLine("Daily Price: " + cars.DailyPrice);
                            Console.WriteLine("Description: " + cars.Descriptions);
                            Console.WriteLine("------------------");
                        }
                        break;
                    case 4:
                        carManager.Add(new Car { BrandID = 1, ColorID = 1, CarName = "Model Y", DailyPrice = 1450, ModelYear = "2019", Descriptions = "Otomatik - Elektrik" });
                        break;
                    case 5:
                        int deleteCar;
                        Console.WriteLine("-Enter Car ID-");
                        deleteCar = Convert.ToInt32(Console.ReadLine());
                        carManager.Delete(new Car { CarID = deleteCar });
                        break;
                    case 6:
                        carManager.Update(new Car { CarID = 2, BrandID = 1, ColorID = 2, CarName = "Model 3", DailyPrice = 1100, ModelYear = "2021", Descriptions = "otomatik - Elektrik" });
                        break;
                    case 7:
                        foreach (var car in carManager.GetCarDetails())
                        {
                            Console.WriteLine("No: {0}\n" +
                                "Car: {1}\n" +
                                "Brand: {2}\n" +
                                "Color: {3}\n" +
                                "Model Year: {4}\n" +
                                "Daily Price: {5} $\n" +
                                "Descriptions: {6}\n" +
                                "----------------------------",
                                car.CarID, car.CarName, car.BrandName, car.ColorName, car.ModelYear, car.DailyPrice, car.Descriptions);
                        }
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
