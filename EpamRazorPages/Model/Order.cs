using System;

namespace EpamRazorPages.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public string ContactNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public TimeSpan CarDeliveryTime { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public decimal Cost { get; set; }
        public string Status { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
