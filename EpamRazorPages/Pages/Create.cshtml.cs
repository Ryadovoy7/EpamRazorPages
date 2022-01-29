using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EpamRazorPages.Model;
using System;
using Microsoft.EntityFrameworkCore;

namespace EpamRazorPages.Pages
{
    public class CreateModel : PageModel
    {
        private readonly EpamRazorPages.Model.TaxiContext _context;

        [BindProperty]
        public Order order { get; set; }

        public CreateModel(EpamRazorPages.Model.TaxiContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAddAsync(Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now;
                order.Cost = new Random().Next(150, 2000);
                order.Status = 0;

                // без идентификации бессмысленно конечно. —читать плейсхолдером.
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == order.UserName);
                if (user == null)
                {
                    user = new User { Name = order.UserName, ContactNumber = order.ContactNumber };
                    _context.Users.Add(user);
                }
                else
                {
                    order.User = user;
                    user.ContactNumber = order.ContactNumber;
                    _context.Update(user);
                }

                order.User = user;
                           
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Orders");
            }
            return Page();
        }
    }
}