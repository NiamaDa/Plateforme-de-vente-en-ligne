namespace ECommerceWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }       // Identifiant de la catégorie à laquelle appartient le produit

        // Propriété de navigation
        public Category Category { get; set; }
    }

}
