using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EpamRazorPages.Model;

namespace EpamRazorPages.Pages
{
    public class OrdersModel : PageModel
    {
        private readonly EpamRazorPages.Model.TaxiContext _context;

        public OrdersModel(EpamRazorPages.Model.TaxiContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Orders
                .Include(o => o.User).ToListAsync();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderToDelete = await _context.Orders.FindAsync(id);

            if (orderToDelete != null)
            {
                _context.Orders.Remove(orderToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Orders");
        }

        public async Task<IActionResult> OnGetCancelAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderToCancel = await _context.Orders.FindAsync(id);

            if (orderToCancel != null)
            {
                orderToCancel.Status = OrderStatus.Canceled;
                _context.Update(orderToCancel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Orders");
        }
    }
}
