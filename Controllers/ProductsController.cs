using Microsoft.AspNetCore.Mvc;
using MyApiProject.Models;
using MyApiProject.Services;
using System.Collections.Generic;

namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        // ✅ Use `IProductService` instead of `ProductService`
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> Create([FromBody] Product product)
        {
            _productService.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Product product)
        {
            if (id != product.Id) return BadRequest();
            if (!_productService.Update(id, product)) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!_productService.Delete(id)) return NotFound();
            return NoContent();
        }
    }
}
