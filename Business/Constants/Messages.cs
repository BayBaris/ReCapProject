using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarListed = "All Car Listed Successfully";
        public static string BrandListed = "All Brand Listed Successfully";
        public static string ColorListed = "All Color Listed Successfully";
        public static string CarDetailsListed = "All Car Listed With Details Successfully";
        public static string CarAdded = "New Car Added Successfully";
        public static string BrandAdded = "New Brand Added Successfully";
        public static string ColorAdded = "New Color Added Successfully";
        public static string CarDeleted = "New Car Deleted Successfully";
        public static string BrandDeleted = "New Brand Deleted Successfully";
        public static string ColorDeleted = "New Color Deleted Successfully";
        public static string CarUpdated = "New Car Updated Successfully";
        public static string BrandUpdated = "New Brand Updated Successfully";
        public static string ColorUpdated = "New Color Updated Successfully";
        public static string RentalAddError = "This car didn't return right now! Please rent another car";
        public static string CarAddErrorNull = "Car name can't blank!";
        public static string CarAddErrorMinLength = "Car name must be at least 2 character!";
        public static string CarCountLimitError = "System have so many car number! You can't add or update car.";
        public static string NumberOfImagesLimitError;
        public static string AuthorizationDenied;
        internal static string UserRegistered;
        internal static User UserNotFound;
        internal static User PasswordError;
        internal static string SuccessfulLogin;
        internal static string UserAlreadyExists;
        internal static string AccessTokenCreated;
    }
}
