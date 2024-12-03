using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ECommerceWebApp.Models;
using ECommerceWebApp.Helpers;
using System.Threading.Tasks;

namespace ECommerceWebApp.Pages
{
    public class DetailModel : PageModel
    {
        private readonly ECommerceDbContext _context;

        public DetailModel(ECommerceDbContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int id, int quantity)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null || quantity <= 0)
            {
                return NotFound();
            }

            // Create cart item
            var cartItem = new CartItem
            {
                ProductId = product.Id,
                Quantity = quantity,
                Product = product
            };

            CartHelper.AddToCart(HttpContext, cartItem); // Add item to cart in cookies

            return RedirectToPage("/Cart"); // Redirect to Cart page after adding
        }
    }
}
