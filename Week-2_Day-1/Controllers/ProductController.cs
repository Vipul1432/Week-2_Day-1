using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week_2_Day_1.Data;
using Week_2_Day_1.Models;

namespace Week_2_Day_1.Controllers
{
    
    [Route("Products")]
    public class ProductController : Controller
    {
        private readonly List<Product> _products;
        public ProductController()
        {
            _products = SampleData.GetProducts();
        }
        // GET: ProductController
        [AllowAnonymous]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            return await Task.FromResult(View(_products));
        }

        // GET: ProductController/Details/5
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> ProductDetails(int id)
        {
            Product? product = _products.Find(p => p.Id == id);
            if (product == null)
            {
                return View("Error");
            }
            return await Task.FromResult(View(product));
        }

        // GET: ProductController/review
        [Route("{id}/reviews")]
        public async Task<IActionResult> ProductReviews(int id)
        {
            Product? product = _products.Find(p => p.Id == id);
            if(product == null)
            {
                return RedirectToAction("Error");
            }
            return await Task.FromResult(View(product));
        }
    }
}
