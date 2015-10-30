using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bricks.Models
{
    public class Bid
    {
        [Display(Name = "Bid ID")]
        public int ID { get; set; }

        [Display(Name = "Bidder ID")]
        public int UserID { get; set; }

        [Display(Name = "Property ID")]
        public int PropertyID { get; set; }

        [Display(Name = "Bid Amount (£x.xx)")]
        public int BidAmount { get; set; }

        [Display(Name = "Bid Date")]
        public DateTime BidDate { get; set; }

        //public int ModelChangeTrigger_DevTool { get; set; }
    }
}