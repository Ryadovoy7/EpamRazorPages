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
                    ContactNumber = "123",
                };
                context.Users.Add(Ivan);
                context.Orders.Add(
                    new Order
                    {
                        UserName = "Иван",
                        ContactNumber = "123",
                        OrderDate = System.DateTime.Now,
                        CarDeliveryTime = System.TimeSpan.Zero,
                        FromLocation = "Пункт А",
                        ToLocation = "Пункт Б",
                        Cost = 0,
                        Status = "Новый",                        
                        User = Ivan
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
