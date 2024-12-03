using ECommerceWebApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

public class IndexModel : PageModel
{
    private readonly ECommerceDbContext _context;

    // Constructeur pour injecter le contexte de la base de données
    public IndexModel(ECommerceDbContext context)
    {
        _context = context;
    }

    // Propriété qui contiendra la liste des Categories
    public IList<Category> Categories { get; set; }

    // Méthode OnGet pour récupérer les produits à afficher
    public void OnGet()
    {
        // Récupérer la liste des produits à partir de la base de données
        Categories = _context.Categories.ToList();
    }
}
