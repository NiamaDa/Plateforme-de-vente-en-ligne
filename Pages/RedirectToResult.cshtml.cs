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
            // Recherche d'un produit par nom dans la base de données
            var product = _context.Products.FirstOrDefault(p => p.Name.Contains(productName));

            // Si un produit correspondant est trouvé, rediriger vers sa page de détails
            if (product != null)
            {
                return RedirectToPage("/Detail", new { id = product.Id });
            }
        }

        // Si une catégorie est sélectionnée et est valide
        if (categoryId.HasValue && categoryId > 0)
        {
            // Redirige vers la page de produits par catégorie
            return RedirectToPage("/ProductsByCategory", new { id = categoryId.Value });
        }

        // Si aucun produit ou catégorie ne correspond, retourner à la page actuelle ou afficher un message d'erreur
        return RedirectToPage("/NoResults");
    }
}
