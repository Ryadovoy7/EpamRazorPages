using EpamRazorPages.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EpamRazorPages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Orders : ControllerBase
    {
        private readonly EpamRazorPages.Model.TaxiContext _context;

        public Orders(EpamRazorPages.Model.TaxiContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromForm] int orderId)
        {
            var orderToDelete = await _context.Orders.FindAsync(orderId);

            if (orderToDelete == null)
                return NotFound();

            _context.Orders.Remove(orderToDelete);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Orders");
        }

        [HttpPost]
        [Route("cancel")]
        public async Task<IActionResult> Cancel([FromForm] int orderId)
        {
            var orderToCancel = await _context.Orders.FindAsync(orderId);

            if (orderToCancel == null)
                return NotFound();

            orderToCancel.Status = OrderStatus.Canceled;
            _context.Update(orderToCancel);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Orders");
        }
    }
}
