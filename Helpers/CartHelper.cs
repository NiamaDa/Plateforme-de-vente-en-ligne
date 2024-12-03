using System.Collections.Generic; // Importation des collections génériques
using ECommerceWebApp.Models; // Importation des modèles de l'application e-commerce
using Microsoft.AspNetCore.Http; // Importation pour utiliser HttpContext et CookieOptions
using Newtonsoft.Json; // Importation pour la sérialisation/désérialisation JSON

namespace ECommerceWebApp.Helpers // Déclaration de l'espace de noms Helpers pour l'application e-commerce
{
    public static class CartHelper // Classe statique pour gérer le panier d'achats
    {
        private const string CartCookieName = "cart"; // Nom du cookie utilisé pour stocker le panier

        // Récupère les articles du panier depuis le cookie
        public static List<CartItem> GetCartItems(HttpContext httpContext)
        {
            var cookieValue = httpContext.Request.Cookies[CartCookieName]; // Obtention de la valeur du cookie
            // Si le cookie est vide ou nul, retourner une liste vide, sinon désérialiser le cookie en liste d'articles
            return string.IsNullOrEmpty(cookieValue) ? new List<CartItem>() : JsonConvert.DeserializeObject<List<CartItem>>(cookieValue);
        }

        // Ajoute un article au panier
        public static void AddToCart(HttpContext httpContext, CartItem cartItem)
        {
            var cartItems = GetCartItems(httpContext); // Récupère les articles existants dans le panier
            // Vérifie si l'article existe déjà dans le panier
            var existingItem = cartItems.Find(i => i.ProductId == cartItem.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += cartItem.Quantity; // Met à jour la quantité si l'article existe déjà
            }
            else
            {
                cartItems.Add(cartItem); // Ajoute le nouvel article au panier
            }

            UpdateCartCookie(httpContext, cartItems); // Met à jour le cookie du panier
        }

        // Met à jour la quantité d'un article dans le panier
        public static void UpdateCart(HttpContext httpContext, int productId, int quantity)
        {
            var cartItems = GetCartItems(httpContext); // Récupère les articles du panier
            // Cherche l'article par ID
            var item = cartItems.Find(i => i.ProductId == productId);

            if (item != null)
            {
                item.Quantity = quantity; // Met à jour la quantité de l'article
                UpdateCartCookie(httpContext, cartItems); // Met à jour le cookie
            }
        }

        // Supprime un article du panier
        public static void RemoveFromCart(HttpContext httpContext, int productId)
        {
            var cartItems = GetCartItems(httpContext); // Récupère les articles du panier
            cartItems.RemoveAll(i => i.ProductId == productId); // Supprime tous les articles avec cet ID
            UpdateCartCookie(httpContext, cartItems); // Met à jour le cookie
        }

        // Vide le panier en supprimant le cookie
        public static void ClearCart(HttpContext httpContext)
        {
            httpContext.Response.Cookies.Delete(CartCookieName); // Supprime le cookie du panier
        }

        // Met à jour le cookie du panier avec la nouvelle liste d'articles
        private static void UpdateCartCookie(HttpContext httpContext, List<CartItem> cartItems)
        {
            var cookieValue = JsonConvert.SerializeObject(cartItems); // Sérialise la liste d'articles en JSON
            var cookieOptions = new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(30) }; // Définit les options du cookie, comme la durée de vie
            httpContext.Response.Cookies.Append(CartCookieName, cookieValue, cookieOptions); // Ajoute ou met à jour le cookie avec la nouvelle valeur
        }
    }
}
