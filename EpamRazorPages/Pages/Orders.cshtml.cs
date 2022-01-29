using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EpamRazorPages.Model;
using EpamRazorPages.Controllers;

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
    }
}
