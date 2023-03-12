using Catalogo.ApplicationServices.Product;
using Catalogo.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductAppService _productAppService;
        public ProductosController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<Producto>> Get()
        {
            List<Producto> results = await _productAppService.GetProductoAsync();
            return results;
        }

        [HttpGet("{id}")]
        public async Task<Producto> Get(int id)
        {
            return await _productAppService.GetProductoAsync(id);

        }

        [HttpPost]
        public async Task Post([FromBody] Producto producto)
        {

            await _productAppService.AddProductAsync(producto);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Producto producto)
        {
            producto.Id = id;
           await _productAppService.EditProductoAsync(producto);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
           await _productAppService.DeleteProductoAsync(id);
        }
    }
}
