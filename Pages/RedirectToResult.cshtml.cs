using ECommerceWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

public class RedirectToResultModel : PageModel
{
    private readonly ECommerceDbContext _context;

    public RedirectToResultModel(ECommerceDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet(string productName, int? categoryId)
    {
        // Si l'utilisateur a saisi un nom de produit
        if (!string.IsNullOrEmpty(productName))
        {
            // Recherche d'un produit par nom dans la base de donn�es
            var product = _context.Products.FirstOrDefault(p => p.Name.Contains(productName));

            // Si un produit correspondant est trouv�, rediriger vers sa page de d�tails
            if (product != null)
            {
                return RedirectToPage("/Detail", new { id = product.Id });
            }
        }

        // Si une cat�gorie est s�lectionn�e et est valide
        if (categoryId.HasValue && categoryId > 0)
        {
            // Redirige vers la page de produits par cat�gorie
            return RedirectToPage("/ProductsByCategory", new { id = categoryId.Value });
        }

        // Si aucun produit ou cat�gorie ne correspond, retourner � la page actuelle ou afficher un message d'erreur
        return RedirectToPage("/NoResults");
    }
}
