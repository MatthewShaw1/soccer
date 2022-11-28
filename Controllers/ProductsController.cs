using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftwareProcessAssignment.WebSite.Models;
using SoftwareProcessAssignment.WebSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareProcessAssignment.WebSite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private object productId;

        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }


        //[HttpPatch] "[FromBody]"
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery] string ProductId, [FromQuery] int Rating)
        {
            ProductService.AddRating(ProductId, Rating);
            return Ok();

        }


    }
}
