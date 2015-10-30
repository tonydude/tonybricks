using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Bricks.Models;

namespace Bricks.DAL
{
    public class AgencyInitialiser : System.Data.Entity.DropCreateDatabaseIfModelChanges<AgencyContext>
    {
        protected override void Seed(AgencyContext context)
        {
            var users = new List<User>
            {
                new User {FirstName="Aaron",LastName="Adams",AspNetUsersID="seeded-a",InitialUserType=UserType.Seller },
                new User {FirstName="Billy",LastName="Bragg",AspNetUsersID="seeded-b",InitialUserType=UserType.Seller },
                new User {FirstName="Charlie",LastName="Chaplin",AspNetUsersID="seeded-c",InitialUserType=UserType.Seller }
            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();
            
            var properties = new List<Property>
            {
                new Property {ID=999, UserID=1, HouseNumber=19, HousePicUri="https://upload.wikimedia.org/wikipedia/commons/a/ae/Castle_Neuschwanstein.jpg", NumberOfBedrooms=20, NumberOfReceptionRooms=5, Postcode="CF32 1AZ", StreetName="Castle Street", Town="Cardiff" },
                new Property {ID=998, UserID=2, HouseNumber=221, HousePicUri="https://upload.wikimedia.org/wikipedia/commons/7/7b/BlaiseCastleEstate(Castle).JPG", NumberOfBedrooms=8, NumberOfReceptionRooms=4, Postcode="B27 2KE", StreetName="Millionaires Row", Town="Acocks Green" },
                new Property {ID=997, UserID=3, HouseName="La Maison", HousePicUri="http://www.jetoboj.cz/wp-content/detached-house1.jpg", NumberOfBedrooms=3, NumberOfReceptionRooms=2, Postcode="CV1 2AL", StreetName="Harper Road", Town="Coventry" }
            };

            properties.ForEach(p => context.Properties.Add(p));
            context.SaveChanges();
            
        }
    }
}


