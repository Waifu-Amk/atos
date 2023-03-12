using Catalogo.ApplicationServices.Categorias;
using Catalogo.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaAppService _appService;
        public CategoriasController(ICategoriaAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public async Task <IEnumerable<Categoria>> GetAll() 
        {
            List<Categoria> categorias = await _appService.GetCategoriasAsync();
            return categorias;
        }

        [HttpGet("{id}")]
        public async Task<Categoria> GetCategoria(int id)
        {
            return await _appService.GetCategoriaAsync(id);
        }

        [HttpPost]
        public async Task Post([FromBody] Categoria categoria)
        {
            await _appService.AddCategoriaAsync(categoria);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Categoria categoria)
        {
            categoria.Id = id;
            await _appService.EditCategoriaAsync(categoria);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _appService.DeleteCategoriaAsync(id);
        }
    }
}
