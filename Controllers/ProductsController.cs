using Microsoft.AspNetCore.Mvc;
using projekt_blogic.Data;
using projekt_blogic.Models.Products;
using projekt_blogic.ViewModels;

namespace projekt_blogic.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product> _products = new List<Product> { new Product { Name = "Pepsi", Price = 42 } };

        [HttpGet]
        public IActionResult Administration()
        {

            var vm = new AdministrationViewModel
            {
                Products = DataBase.GetAllProducts()
            };


            return View(vm);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Product newProduct)
        {
            if (newProduct != null)
            {
                DataBase.ProductInsert(newProduct.Name, newProduct.Price, newProduct.Quantity, newProduct.ImageUrl);
                return Ok(newProduct);
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Product updatedProduct)
        {
            var existing = _products.FirstOrDefault(p => p.ProductID == updatedProduct.ProductID);
            if (existing != null)
            {
                DataBase.ProductEdit(updatedProduct.ProductID, updatedProduct.Name, updatedProduct.ImageUrl, updatedProduct.Quantity, updatedProduct.Price);
                return Ok(existing);
            }

            return NotFound();
        }

        [HttpDelete]
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

