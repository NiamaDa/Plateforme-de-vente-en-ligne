using Microsoft.AspNetCore.Mvc.RazorPages; // Namespace pour les pages Razor
using Microsoft.EntityFrameworkCore; // Namespace pour l'Entity Framework Core
using ECommerceWebApp.Models; // Namespace pour les modèles de l'application
using System.Collections.Generic; // Namespace pour les collections génériques
using System.Linq; // Namespace pour les extensions de requête LINQ
using System.Threading.Tasks; // Namespace pour les tâches asynchrones

namespace ECommerceWebApp.Pages // Déclaration de l'espace de noms pour les pages de l'application
{
    public class ProductsByCategoryModel : PageModel // Classe représentant le modèle de la page pour afficher les produits par catégorie
    {
        private readonly ECommerceDbContext _context; // Contexte de la base de données pour accéder aux données

        // Constructeur qui prend un contexte de base de données en paramètre
        public ProductsByCategoryModel(ECommerceDbContext context)
        {
            _context = context; // Initialisation du contexte
        }

        public ProductListModel ProductList { get; set; } // Propriété pour stocker la liste des produits d'une catégorie

        // Méthode asynchrone qui est appelée lors d'une requête GET
        public async Task OnGetAsync(int categoryId)
        {
            // Recherche de la catégorie par son identifiant
            var category = await _context.Categories.FindAsync(categoryId);

            // Vérification si la catégorie existe
            if (category != null)
            {
                // Initialisation de la liste des produits pour la catégorie trouvée
                ProductList = new ProductListModel
                {
                    CategoryId = category.Id, // ID de la catégorie
                    CategoryName = category.Name, // Nom de la catégorie
                    Products = await _context.Products // Récupération des produits associés à la catégorie
                        .Where(p => p.CategoryId == categoryId) // Filtrage par ID de catégorie
                        .ToListAsync() // Conversion du résultat en liste asynchrone
                };
            }
        }
    }
}
