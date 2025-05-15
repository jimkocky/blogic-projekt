using Microsoft.AspNetCore.Mvc;
using projekt_blogic.Models.Products;
using projekt_blogic.ViewModels;

namespace projekt_blogic.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product> _products = new List<Product> { new Product { Name = "Pepsi", Price = 42 } };

        public IActionResult Administration()
        {

            var vm = new AdministrationViewModel
            {
                Products = _products
            };
            return View(vm);
        }

        public IActionResult Insert([FromBody] Product newProduct)
        {
            if (newProduct != null)
            {
                newProduct.ProductID = _products.Max(p => p.ProductID) + 1;
                _products.Add(newProduct);
                return Ok(newProduct);
            }

            return BadRequest();
        }

        public IActionResult Edit([FromBody] Product updatedProduct)
        {
            var existing = _products.FirstOrDefault(p => p.ProductID == updatedProduct.ProductID);
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
            var product = _products.FirstOrDefault(p => p.ProductID == id);
            if (product != null)
            {
                _products.Remove(product);
                return Ok();
            }

            return NotFound();
        }

        private readonly IWebHostEnvironment _environment;
        public ProductsController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
    }

}

