using ECommerceWebApp.Helpers;
using ECommerceWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ECommerceWebApp.Pages
{
    public class CheckoutModel : PageModel
    {
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public void OnGet()
        {
            // Retrieve cart from cookies
            CartItems = CartHelper.GetCartItems(HttpContext);
        }

        public IActionResult OnPostCheckout()
        {
            // Handle checkout logic here (e.g., send confirmation email)

            // Clear the cart after checkout
            CartHelper.ClearCart(HttpContext); // Assuming you have a method to clear the cart

            // Redirect to confirmation page
            return RedirectToPage("/OrderConfirmation");
        }
    }
}
