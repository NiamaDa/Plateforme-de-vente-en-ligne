using ECommerceWebApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

public class IndexModel : PageModel
{
    private readonly ECommerceDbContext _context;

    // Constructeur pour injecter le contexte de la base de donn�es
    public IndexModel(ECommerceDbContext context)
    {
        _context = context;
    }

    // Propri�t� qui contiendra la liste des Categories
    public IList<Category> Categories { get; set; }

    // M�thode OnGet pour r�cup�rer les produits � afficher
    public void OnGet()
    {
        // R�cup�rer la liste des produits � partir de la base de donn�es
        Categories = _context.Categories.ToList();
    }
}
