using Microsoft.AspNetCore.Mvc;
using projekt_blogic.Models.Products;

namespace projekt_blogic.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product> _products = new List<Product> { new Product { Name = "Pepsi", Price = 42 } };

        public IActionResult Administration()
        {
            var vm = new AdminViewModel
            {
                Products = _products
            };
            return View(vm);
        }

        public IActionResult Insert([FromBody] Product newProduct)
        {
            if (newProduct != null)
            {
                newProduct.Id = _products.Max(p => p.Id) + 1;
                _products.Add(newProduct);
                return Ok(newProduct);
            }

            return BadRequest();
        }

        public IActionResult Edit([FromBody] Product updatedProduct)
        {
            var existing = _products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (existing != null)
            {
                existing.Name = updatedProduct.Name;
                existing.Price = updatedProduct.Price;
                return Ok(existing);
            }

            return NotFound();
        }

        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
                return Ok();
            }

            return NotFound();
        }
    }

    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class AdminViewModel
    {
        public List<Product> Products { get; set; }
    }
}

