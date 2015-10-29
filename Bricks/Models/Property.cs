using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bricks.Models
{
    public class Property
    {
        public int ID { get; set; }
        public int UserID { get; set; }

        public string HouseName { get; set; }
        public int? HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfReceptionRooms { get; set; }
        public string HousePicUri { get; set; }

        public virtual ICollection<Bid> BidsReceived { get; set; }

    }
}