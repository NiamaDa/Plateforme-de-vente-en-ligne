using ECommerceWebApp.Helpers; // Importation des méthodes d'aide pour la gestion du panier
using ECommerceWebApp.Models; // Importation des modèles utilisés dans l'application e-commerce
using Microsoft.AspNetCore.Mvc; // Importation des classes pour gérer les contrôleurs et les actions
using Microsoft.AspNetCore.Mvc.RazorPages; // Importation pour travailler avec les pages Razor
using System.Collections.Generic; // Importation pour utiliser des collections génériques

public class CartModel : PageModel // Déclaration de la classe CartModel qui hérite de PageModel
{
    public List<CartItem> CartItems { get; set; } // Propriété pour stocker les articles du panier

    // Méthode appelée lors d'une requête GET
    public void OnGet()
    {
        // Récupère les articles du panier à partir des cookies en utilisant CartHelper
        CartItems = CartHelper.GetCartItems(HttpContext);
    }

    // Méthode appelée lors d'une soumission de formulaire pour mettre à jour la quantité d'un article
    public IActionResult OnPostUpdateQuantity(int productId, int quantity)
    {
        if (quantity > 0) // Vérifie si la quantité est supérieure à 0
        {
            // Met à jour la quantité de l'article dans le panier
            CartHelper.UpdateCart(HttpContext, productId, quantity);
        }
        return RedirectToPage(); // Redirige vers la même page après la mise à jour
    }

    // Méthode appelée lors d'une soumission de formulaire pour supprimer un article du panier
    public IActionResult OnPostRemoveItem(int productId)
    {
        // Supprime l'article du panier
        CartHelper.RemoveFromCart(HttpContext, productId);
        return RedirectToPage(); // Redirige vers la même page après la suppression
    }
}
