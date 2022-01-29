using EpamRazorPages.Model;
using System.Linq;

namespace EpamRazorPages
{
    public static class SampleData
    {
        public static void Initialize(TaxiContext context)
        {
            if (!context.Users.Any())
            {
                var Ivan = new User
                {
                    Name = "Иван",
                    ContactNumber = "+79990007733",
                };
                context.Users.Add(Ivan);
                var order = new Order
                {
                    UserName = "Иван",
                    OrderDate = System.DateTime.Now,
                    CarDeliveryTime = System.DateTime.Now,
                    FromLocation = "Пункт А",
                    ToLocation = "Пункт Б",
                    Cost = 0,
                    Status = 0,
                    User = Ivan
                };
                context.Orders.Add(order);
                
                context.SaveChanges();
            }
        }
    }
}
