 namespace ECommerceWebApp.Models
    {
        public class ProductListModel
        {
            public int CategoryId { get; set; }         // Identifiant de la catégorie
            public string CategoryName { get; set; }     // Nom de la catégorie
            public List<Product> Products { get; set; }  // Liste des produits de cette catégorie

            public ProductListModel()
            {
                Products = new List<Product>();           // Initialiser la liste des produits
            }
        }
}

