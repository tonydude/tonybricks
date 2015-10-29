using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bricks.Models
{
    public class Property
    {
        [Display(Name = "Property ID")]
        public int ID { get; set; }

        [Display(Name = "Owner's ID")]
        public int UserID { get; set; }

        [Display(Name = "House Name")]
        public string HouseName { get; set; }

        [Display(Name = "House Number")]
        public int? HouseNumber { get; set; }

        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [Display(Name = "Town / City Name")]
        public string Town { get; set; }

        [Display(Name = "Postcode")]
        public string Postcode { get; set; }

        [Display(Name = "# Bedrooms")]
        public int NumberOfBedrooms { get; set; }

        [Display(Name = "# Reception Rooms")]
        public int NumberOfReceptionRooms { get; set; }

        [Display(Name = "Picture URL")]
        public string HousePicUri { get; set; }

        public virtual ICollection<Bid> BidsReceived { get; set; }

    }
}