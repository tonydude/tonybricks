using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bricks.Models
{
    public enum UserType
    {
        Buyer, Seller
    }

    public class User
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public UserType InitialUserType { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
        public virtual ICollection<Bid> BidsMade { get; set; }
    }
}