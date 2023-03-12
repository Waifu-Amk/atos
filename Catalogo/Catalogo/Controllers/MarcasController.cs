using Catalogo.ApplicationServices.Marcas;
using Catalogo.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly IMarcaAppService _appService;
        public MarcasController(IMarcaAppService appService)
        {
            _appService = appService;
        }
        [HttpGet]
        public async Task<IEnumerable<Marca>> GetAll()
        {
            List<Marca> marcas = await _appService.GetMarcasAsync();
            return marcas;
        }
        [HttpGet("{id}")]
        public async Task<Marca> GetMarca(int id)
        {
            return await _appService.GetMarcaAsync(id);
        }
        [HttpPost]
        public async Task Post([FromBody] Marca marca)
        {
            await _appService.AddMarcaAsync(marca);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Marca marca)
        {
            marca.Id = id;
            await _appService.EditMarcaAsync(marca);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _appService.DeleteMarcaAsync(id);
        }
    }
}
