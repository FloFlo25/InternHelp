using DatabaseAPIExercise.Business;
using DatabaseAPIExercise.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DatabaseAPIExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private  IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }


        [HttpGet]
        [Route("AllProducts")]
        public IActionResult GetAllProducts()
        {
            return Ok(_productManager.GetProducts());
        }

        [HttpGet]
        [Route("OldestProduct")]
        public IActionResult GetOldestProduct()
        {
            return Ok(_productManager.GetOldestProduct());
        }

        [HttpGet]
        [Route("MostRecentProduct")]
        public IActionResult GetMostRecentProduct()
        {
            return Ok(_productManager.GetMostRecentProduct());
        }

        [HttpGet]
        [Route("ProductsByAvg")]
        public IActionResult GetProductsByAvg(FilterType filterType)
        {
            return Ok(_productManager.GetProductsByAvgRating(filterType));
        }

        [HttpGet]
        [Route("ProductsByKeyword")]
        public IActionResult GetProductsByKeyword(string keyword)
        {
            return Ok(_productManager.GetProductsByKeyword(keyword));
        }

        [HttpPatch]
        [Route("UpdateProduct")]
        public IActionResult PatchProduct(Product product)
        {
            return Ok(_productManager.UpdateProduct(product));

        }

        [HttpPost]
        [Route("Product")]
        public IActionResult CreateProduct([FromBody]Product product)
        {
            return Ok(_productManager.CreateProduct(product));
        }


        [HttpDelete]
        [Route("{product}")]
        public IActionResult GetAllProducts(Guid product)
        {
            return Ok(_productManager.DeleteProduct(product));
        }
    }
}
