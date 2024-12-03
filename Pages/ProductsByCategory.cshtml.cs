using Microsoft.AspNetCore.Mvc.RazorPages; // Namespace pour les pages Razor
using Microsoft.EntityFrameworkCore; // Namespace pour l'Entity Framework Core
using ECommerceWebApp.Models; // Namespace pour les mod�les de l'application
using System.Collections.Generic; // Namespace pour les collections g�n�riques
using System.Linq; // Namespace pour les extensions de requ�te LINQ
using System.Threading.Tasks; // Namespace pour les t�ches asynchrones

namespace ECommerceWebApp.Pages // D�claration de l'espace de noms pour les pages de l'application
{
    public class ProductsByCategoryModel : PageModel // Classe repr�sentant le mod�le de la page pour afficher les produits par cat�gorie
    {
        private readonly ECommerceDbContext _context; // Contexte de la base de donn�es pour acc�der aux donn�es

        // Constructeur qui prend un contexte de base de donn�es en param�tre
        public ProductsByCategoryModel(ECommerceDbContext context)
        {
            _context = context; // Initialisation du contexte
        }

        public ProductListModel ProductList { get; set; } // Propri�t� pour stocker la liste des produits d'une cat�gorie

        // M�thode asynchrone qui est appel�e lors d'une requ�te GET
        public async Task OnGetAsync(int categoryId)
        {
            // Recherche de la cat�gorie par son identifiant
            var category = await _context.Categories.FindAsync(categoryId);

            // V�rification si la cat�gorie existe
            if (category != null)
            {
                // Initialisation de la liste des produits pour la cat�gorie trouv�e
                ProductList = new ProductListModel
                {
                    CategoryId = category.Id, // ID de la cat�gorie
                    CategoryName = category.Name, // Nom de la cat�gorie
                    Products = await _context.Products // R�cup�ration des produits associ�s � la cat�gorie
                        .Where(p => p.CategoryId == categoryId) // Filtrage par ID de cat�gorie
                        .ToListAsync() // Conversion du r�sultat en liste asynchrone
                };
            }
        }
    }
}
