using System.Collections.Generic;

namespace EpamRazorPages.Model
{
    public class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
