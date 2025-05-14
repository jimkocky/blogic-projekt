using Microsoft.AspNetCore.Mvc;
using projekt_blogic.Models.Products;

namespace projekt_blogic.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product> _products = new List<Product> { new Product { Name = "Pepsi", Price = 42 } };

        public IActionResult Administration()
        {
            var vm = new AdministrationViewModel
            {
                vm.Products = _products
            }
            return View(vm);
        }
    }
}
