
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using BlazorMaster.Server.Models;
using Microsoft.EntityFrameworkCore;
using BlazorMaster.Shared;


namespace BlazorMaster.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly Dbpractica1Context _dbContext;


        public VentaController(Dbpractica1Context dbContext)
        {
            _dbContext = dbContext; ;

        }



        [HttpPost]
        public async Task<IActionResult> Post(VentaDTO ventaDto)
        {
            try
            {

                var mdVenta = new Venta();
                var mdDetalleVenta = new List<DetalleVenta>();

                mdVenta.Cliente = ventaDto.Cliente;
                mdVenta.Total = ventaDto.Total;

                foreach(var item in ventaDto.DetalleVenta)
                {
                    mdDetalleVenta.Add(new DetalleVenta
                    {
                        IdProducto = item.Producto.IdProducto,
                        Cantidad = item.Cantidad,
                        SubTotal = item.SubTotal


                    });
                }
                mdVenta.DetalleVenta = mdDetalleVenta;

                _dbContext.Venta.Add(mdVenta);
                await _dbContext.SaveChangesAsync();
                return Ok();




            }
            catch(Exception ex)
            {
            return BadRequest(ex);

            }

        }

    }
}
