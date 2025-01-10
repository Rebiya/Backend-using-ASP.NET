using System;
using System.Collections.Generic;
using System.Linq;
using HouseRental.Data;
using HouseRental.Modules;

namespace HouseRental
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            // Seed Staff data
            if (!dataContext.Staffs.Any())
            {
                var newStaff = new Staff
                {
                    StaffName = "Wubrist Alemu",
                    StaffEmail = "ristwubrist@gmail.com",
                    StaffPassword = "enter123",
                    StaffPhoneNumber = "0923456788",
                    ProfilePicture = null,
                    branch = "Main Office"
                };

                dataContext.Staffs.Add(newStaff);
                dataContext.SaveChanges();
                int staffId = newStaff.StaffId;

                var newProperty = new Property
                {
                    Title = "Luxury Apartment",
                    Description = "A beautiful apartment in the city center which is in Arat killo  " +
                    "very suitable for transport which is in front of the main road " +
                    "Also have a playing ground in 200sqm for children with a beautiful green area in 110sqm " +
                    "including parking area for every owner of the house.",
                    Price = 8000000.00m,
                    Country = "Ethiopia",
                    City = "Addis Ababa",
                    Subcity = "Arat Killo",
                    PropertyType = "Apartment",
                    Bedrooms = 3,
                    Bathroom = 4,
                    Imgurl = "image.jpg",
                    Status = "Available",
                    Category="For Sale",
                    StaffId = staffId
                };

                dataContext.Properties.Add(newProperty);
            }

            // Seed User data
            if (!dataContext.Users.Any())
            {
                var users = new List<User>
                {
                    new User
                    {
                        UserName = "Hana Abel",
                        UserEmail = "hana@gmail.com",
                        UserPassword = "hana123",
                        UserPhoneNUmber = "0923114344",
                        UserProfilePicture = null
                    },
                    new User
                    {
                        UserName = "Leul Frezer",
                        UserEmail = "leul@gmail.com",
                        UserPassword = "leul123",
                        UserPhoneNUmber = "0911564344",
                        UserProfilePicture = null
                    }
                };
                dataContext.Users.AddRange(users);
            }

            dataContext.SaveChanges();
        }
    }
}
