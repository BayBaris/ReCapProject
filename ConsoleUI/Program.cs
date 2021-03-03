using Business.Concrete;
using Core.Entities.Concrete;
using Core.Utilities;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;

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
                    "[4] Run User Manager\n" +
                    "[5] Run Customer Manager\n" +
                    "[6] Run Rental Manager\n" +
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
                    case 4:
                        RunUserManager();
                        break;
                    case 5:
                        RunCustomerManager();
                        break;
                    case 6:
                        RunRentalManager();
                        break;
                    default:
                        break;
                }
            }          
        }
        private static void RunRentalManager()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            int options = -1;
            while (options != 0)
            {
                Console.WriteLine("[1] List All Rentals\n" +
                    "[2] Get Rental By ID\n" +
                    "[3] Get All Rental With Details\n" +
                    "[4] Add Rental\n" +
                    "[5] Delete Rental\n" +
                    "[6] Update Rental\n" +
                    "[0] Exit Menu" +
                    "");
                options = Convert.ToInt32(Console.ReadLine());
                switch (options)
                {
                    case 1:
                        foreach (var rental in rentalManager.GetAll().Data)
                        {
                            Console.WriteLine("Rental ID: " + rental.RentalID);
                            Console.WriteLine("Customer ID: " + rental.CustomerID);
                            Console.WriteLine("Car ID: " + rental.CarID);
                            Console.WriteLine("Rent Date: " + rental.RentDate);
                            Console.WriteLine("Return Date: " + rental.ReturnDate);
                        }
                        break;
                    case 2:
                        Console.WriteLine(rentalManager.GetID(2).Data.CarID);
                        Console.WriteLine(rentalManager.GetID(2).Data.CustomerID);
                        Console.WriteLine(rentalManager.GetID(2).Data.RentDate);
                        Console.WriteLine(rentalManager.GetID(2).Data.ReturnDate);
                        break;
                    case 3:
                        var GetRentDetail = rentalManager.GetRentalDetails();
                        foreach (var rent in GetRentDetail.Data)
                        {
                            Console.WriteLine("No: {0}\n" +
                                "Car: {1}\n" +
                                "First Name: {2}\n" +
                                "Last Name: {3}\n" +
                                "Email: {4}\n" +
                                "Rent Date: {5}\n" +
                                "Return Date: {6}\n" +
                                "Daily Price: {7} $\n" +
                                "----------------------------",
                                rent.RentalID, rent.CarName, rent.FirstName, rent.LastName, rent.Email,rent.RentDate, rent.ReturnDate, rent.DailyPrice);
                        }
                        Console.WriteLine(GetRentDetail.Message);
                        break;
                    case 4:
                        //rentalManager.Add(new Rental { CompanyName = "Holy Mustance", UserID = 2 });
                        Console.WriteLine("Rent Added.");
                        break;
                    case 5:
                        Console.WriteLine("-Enter Rental ID-");
                        int deletedrental = Convert.ToInt32(Console.ReadLine());
                        rentalManager.Delete(new Rental { CustomerID = deletedrental });
                        break;
                    case 6:
                        Console.WriteLine("-Enter Rental ID-");
                        int updatedrental = Convert.ToInt32(Console.ReadLine());
                        rentalManager.Update(new Rental
                        {
                            RentalID = updatedrental,
                            RentDate = DateTime.Now,
                            ReturnDate = DateTime.Now
                        });
                        break;

                    default:
                        break;
                }
            }

        }

        private static void RunCustomerManager()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            int options = -1;
            while (options != 0)
            {
                Console.WriteLine("[1] List All Customers\n" +
                    "[2] Get Customer By ID\n" +
                    "[3] Add Customer\n" +
                    "[4] Delete Customer\n" +
                    "[5] Update Customer\n" +
                    "[0] Exit Menu" +
                    "");
                options = Convert.ToInt32(Console.ReadLine());
                switch (options)
                {
                    case 1:
                        foreach (var customer in customerManager.GetAll().Data)
                        {
                            Console.WriteLine("Customer ID: " + customer.CustomerID);
                            Console.WriteLine("User ID: " + customer.UserID);
                            Console.WriteLine("Company Name: " + customer.CompanyName);                            
                        }
                        break;
                    case 2:
                        Console.WriteLine(customerManager.GetID(2).Data.CompanyName);
                        break;
                    case 3:
                        customerManager.Add(new Customer { CompanyName = "Holy Mustance",UserID = 2});
                        break;
                    case 4:
                        Console.WriteLine("-Enter Customer ID-");
                        int deletedcustomer = Convert.ToInt32(Console.ReadLine());
                        customerManager.Delete(new Customer { CustomerID = deletedcustomer });
                        break;
                    case 5:
                        Console.WriteLine("-Enter Customer ID-");
                        int updatedcustomer = Convert.ToInt32(Console.ReadLine());
                        customerManager.Update(new Customer
                        {
                            CustomerID = updatedcustomer,
                            CompanyName = "Boris"                           
                        });
                        break;
                    default:
                        break;
                }
            }
        }
        private static void RunUserManager()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            int options = -1;
            while (options != 0)
            {
                Console.WriteLine("[1] List All User\n" +
                    "[2] Get User By ID\n" +
                    "[3] Add User\n" +
                    "[4] Delete User\n" +
                    "[5] Update User\n" +
                    "[0] Exit Menu" +
                    "");
                options = Convert.ToInt32(Console.ReadLine());
                switch (options)
                {
                    case 1:
                        foreach (var user in userManager.GetAll().Data)
                        {
                            Console.WriteLine("User ID: " + user.UserId);
                            Console.WriteLine("First Name: " + user.FirstName);
                            Console.WriteLine("Last Name: " + user.LastName);
                            Console.WriteLine("Email: " + user.Email);
                        }
                        break;
                    case 2:
                        Console.WriteLine(userManager.GetID(2).Data.FirstName);
                        Console.WriteLine(userManager.GetID(2).Data.LastName);
                        break;
                    case 3:
                        userManager.Add(new User { FirstName = "Utku",LastName = "Yerimdar",Email = "Bruh@gmail.com"});
                        break;
                    case 4:
                        Console.WriteLine("-Enter User ID-");
                        int deleteduser = Convert.ToInt32(Console.ReadLine());
                        userManager.Delete(new User { UserId = deleteduser });
                        break;
                    case 5:
                        Console.WriteLine("-Enter User ID-");
                        int updateduser = Convert.ToInt32(Console.ReadLine());
                        userManager.Update(new User { UserId = updateduser, FirstName = "Boris",LastName = "Karakaya",
                            Email = "baybarisk@outlook.com" });
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
                Console.WriteLine("[1] List All Brand\n" +
                    "[2] Get Brand By ID\n" +
                    "[3] Add Brand\n" +
                    "[4] Delete Brand\n" +
                    "[5] Update Brand\n" +
                    "[0] Exit Menu" +
                    "");
                options = Convert.ToInt32(Console.ReadLine());
                switch (options)
                {
                    case 1:
                        foreach (var brand in brandManager.GetAll().Data)
                        {
                            Console.WriteLine("Brand ID: {0} = {1}", brand.BrandID, brand.BrandName);
                        }
                        break;
                    case 2:
                        Console.WriteLine(brandManager.GetID(2).Data.BrandName);
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
                        foreach (var color in colorManager.GetAll().Data)
                        {
                            Console.WriteLine("Color ID: {0} = {1}", color.ColorID, color.ColorName);
                        }
                        Console.WriteLine(colorManager.GetAll().Message);
                        break;
                    case 2:
                        Console.WriteLine(colorManager.GetID(2).Data.ColorName);
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
                        var GetAll = carManager.GetAll();
                        Console.WriteLine("-----Car List-----");
                        foreach (var cars in GetAll.Data)
                        {
                            Console.WriteLine("Name: " + cars.CarName);
                            Console.WriteLine("CarID: " + cars.CarID);
                            Console.WriteLine("BrandID: " + cars.BrandID);
                            Console.WriteLine("ColorID: " + cars.ColorID);
                            Console.WriteLine("Model Year:" + cars.ModelYear);
                            Console.WriteLine("Daily Price: " + cars.DailyPrice);
                            Console.WriteLine("Description: " + cars.Descriptions);
                            Console.WriteLine("------------------");
                        }
                        Console.WriteLine(GetAll.Message);
                        Console.WriteLine("------------------");
                        break;
                    case 2:                        
                        Console.WriteLine("-----Car List but Only BrandID-----");
                        Console.WriteLine("Enter Brand ID:");
                        int brandID = Convert.ToInt32(Console.ReadLine());
                        foreach (var cars in carManager.GetByBrandID(brandID).Data)
                        {
                            Console.WriteLine("Name: " + cars.CarName);
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
                        foreach (var cars in carManager.GetByBrandID(colorID).Data)
                        {
                            Console.WriteLine("Name: " + cars.CarName);
                            Console.WriteLine("CarID: "  + cars.CarID);
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
                        var GetAllDetail = carManager.GetCarDetails();
                        foreach (var car in GetAllDetail.Data)
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
                        Console.WriteLine(GetAllDetail.Message);
                        break;
                    default:
                        break;
                }

            }
        }
    }
}
