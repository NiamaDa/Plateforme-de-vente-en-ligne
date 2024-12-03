using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ECommerceWebApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        // Propriété de navigation pour la relation avec les produits
        public List<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>(); // Initialiser la liste des produits
        }
    }

}
