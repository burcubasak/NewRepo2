using CohortHomeworkWeek2.Attributes;
using CohortHomeworkWeek2.Models;
using CohortHomeworkWeek2.Repositories;

using FluentValidation;
using Microsoft.AspNetCore.Mvc;


namespace CohortHomeworkWeek2.Controllers


{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IValidator<Product> _validator;

        public ProductController(IProductRepository repository, IValidator<Product> validator)
        {
            _repository = repository;
            _validator = validator;

        }

        [HttpGet("secure-data")]
        [FakeAuthorize]
        public IActionResult GetSecureData()
        {
            return Ok(new { message = "Bu verilere sadece yetkilendirilmiş kullanıcılar erişebilir." });
        }

        [HttpGet("List")]
        public IActionResult GetAll([FromQuery] string? name)
        {
            var products = _repository.GetAll(name);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _repository.GetById(id);
            if (product == null) return NotFound(new { message = "Product not found" });
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            try
            {
                Console.WriteLine("POST: AddProduct endpoint hit.");
                _repository.Add(product);
                return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product product)
        {
            var existingProduct = _repository.GetById(id);
            if (existingProduct == null) return NotFound(new { message = "Product not found" });

            product.Id = id;
            _repository.Update(product);
            return Ok(product);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _repository.GetById(id);
            if (product == null) return NotFound(new { message = "Product not found" });
            _repository.Delete(id);
            return NoContent();
        }



    }
}
