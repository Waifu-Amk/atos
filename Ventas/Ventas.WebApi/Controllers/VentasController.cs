﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ventas.ApplicationServices.VentasService;
using Ventas.Core;
using Ventas.WebApi.Models;

namespace Ventas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IVentasAppService _appservice;

        public VentasController(IVentasAppService appservice)
        {
            _appservice = appservice;
        }


        [HttpGet]
        public async Task<IEnumerable<VentaProducto>> GetAll()
        {
            List<VentaProducto> ventas = await _appservice.GetVentaProductosAsync();
            return ventas;
        }

        [HttpGet("{id}")]
        public async Task<VentaProducto> GetVenta(int id)
        {
            return await _appservice.GetVentaProductoAsync(id);
        }

        [HttpPost]
        public async Task Post([FromBody] VentaProducto venta)
        {
            ProductSearcher response = new ProductSearcher();

            Product product =await response.GetProductAsync(venta.ProductoId);
            venta.ProductoId = product.Id;
            await _appservice.AddVentaAsync(venta);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] VentaProducto venta)
        {
            ProductSearcher response = new ProductSearcher();
            Product product = await response.GetProductAsync(venta.ProductoId);
            venta.ProductoId = product.Id;
            venta.Id = id;
            await _appservice.EditVentaAsync(venta);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _appservice.DeleteVentaAsync(id);
        }
    }
}