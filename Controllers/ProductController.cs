using System;
using System.Net.Http;
using System.Web.Mvc;



namespace SylviaShopifyWebApp.Controllers
{
    public class ProductController : Controller
    {

        static HttpClient client = new HttpClient();

        // This method will get all the products in the store
       [HttpGet]
       static void GetProducts()
        {
            // connecting to the Shopify store using the Product resource
            dynamic shopify = new Shopify.Api("https://your_store.com/admin/products", "myAPIkey", "myAPIpassword");

            // create a query that pulls all the information in JSON format
            dynamic allProductsQuery = shopify.Products();

            // writes the product title, product price and product image name to the console.
            foreach (dynamic product in allProductsQuery.products)
            {
                Console.WriteLine($"{product.title}\t{product.price}\t{product.images}");
            }
        }


        // This method will update the product price and description given the specific product_id passed to the method.
        [HttpPut]
        static void UpdateProducts(string product_id, double price, string description)
        {
            // connecting to the Shopify store using the Product resource to update a product
            dynamic shopifyUpdate = new Shopify.Api("https://yourstore.com/admin/products/#{product_id}", "myAPIkey", "myAPIpassword");

            // create a query that pulls the information for a specific product.
            dynamic specificProductQuery = shopifyUpdate.Products();

            // update the price and description given the price and description that was passed to the method
            specificProductQuery.price = price;
            specificProductQuery.description = description;

        }
    }
}
