using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bricks.Models
{
    public enum UserType
    {
        Buyer, Seller
    }

    public class User
    {
        public int ID { get; set; }
                
        [Display(Name = "Registration ID")]
        public string AspNetUsersID { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "User Type")]
        public UserType InitialUserType { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
        public virtual ICollection<Bid> BidsMade { get; set; }
    }
}

