using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bricks.Models
{
    public class Bid
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int PropertyID { get; set; }

        public int BidAmount { get; set; }
        public DateTime BidDate { get; set; }
    }
}