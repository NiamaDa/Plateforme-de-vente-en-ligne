using ECommerceWebApp.Helpers; // Importation des m�thodes d'aide pour la gestion du panier
using ECommerceWebApp.Models; // Importation des mod�les utilis�s dans l'application e-commerce
using Microsoft.AspNetCore.Mvc; // Importation des classes pour g�rer les contr�leurs et les actions
using Microsoft.AspNetCore.Mvc.RazorPages; // Importation pour travailler avec les pages Razor
using System.Collections.Generic; // Importation pour utiliser des collections g�n�riques

public class CartModel : PageModel // D�claration de la classe CartModel qui h�rite de PageModel
{
    public List<CartItem> CartItems { get; set; } // Propri�t� pour stocker les articles du panier

    // M�thode appel�e lors d'une requ�te GET
    public void OnGet()
    {
        // R�cup�re les articles du panier � partir des cookies en utilisant CartHelper
        CartItems = CartHelper.GetCartItems(HttpContext);
    }

    // M�thode appel�e lors d'une soumission de formulaire pour mettre � jour la quantit� d'un article
    public IActionResult OnPostUpdateQuantity(int productId, int quantity)
    {
        if (quantity > 0) // V�rifie si la quantit� est sup�rieure � 0
        {
            // Met � jour la quantit� de l'article dans le panier
            CartHelper.UpdateCart(HttpContext, productId, quantity);
        }
        return RedirectToPage(); // Redirige vers la m�me page apr�s la mise � jour
    }

    // M�thode appel�e lors d'une soumission de formulaire pour supprimer un article du panier
    public IActionResult OnPostRemoveItem(int productId)
    {
        // Supprime l'article du panier
        CartHelper.RemoveFromCart(HttpContext, productId);
        return RedirectToPage(); // Redirige vers la m�me page apr�s la suppression
    }
}
