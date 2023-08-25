using AutoMapper;
using MapperStaticApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MapperStaticApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> _products = new List<Product>();
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetAllProduct()
        {
            var productResponse = _mapper.Map<IEnumerable<ProductDto>>(_products);
            return Ok(productResponse);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ProductDto>> GetById(int id)
        {   
            var productresponse = _mapper.Map<ProductDto>(_products.FirstOrDefault(x => x.Id == id));
            return Ok(productresponse);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            
                product.Id = _products.Count() + 1;
                _products.Add(product);

                return Ok(_products);
           
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct( int id,  Product product )
        {
            var  existingProduct  = _products.FirstOrDefault(x => x.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            else
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;

                return Ok(existingProduct);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var existingProduct = _products.FirstOrDefault(x => x.Id == id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            else
            {
                _products.Remove(existingProduct);
                return Ok(_products);
            }
        }
    }
}
