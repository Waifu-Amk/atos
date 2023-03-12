using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ventas.ApplicationServices.VendedorService;
using Ventas.Core;

namespace Ventas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedoresController : ControllerBase
    {
        private readonly IVendedorAppService _appservice;
        public VendedoresController(IVendedorAppService appservice)
        {
            _appservice = appservice;
        }
        [HttpGet]
        public async Task<IEnumerable<Vendedor>> GetAll()
        {
            List<Vendedor> vendedores = await _appservice.GetVendedoresAsync();
            return vendedores;
        }

        [HttpGet("{id}")]
        public async Task<Vendedor> GetVendedor(int id)
        {
            return await _appservice.GetVendedorAsync(id);
        }

        [HttpPost]
        public async Task Post([FromBody] Vendedor vendedores)
        {
            await _appservice.AddVendedorAsync(vendedores);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Vendedor vendedores)
        {
            vendedores.Id = id;
            await _appservice.EditVendedorAsync(vendedores);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _appservice.DeleteVendedorAsync(id);
        }
    }
}
