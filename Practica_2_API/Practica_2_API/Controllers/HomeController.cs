using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Practica_2_API.Entities;

namespace Practica_2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        [Route("RegistrarVendedor")]
        public async Task< IActionResult> RegistrarVendedor(Vendedor ent)
        {
            Confirmacion resp = new Confirmacion();

            using (var context = new SqlConnection("Server=127.0.0.1;Database=Practica2;User Id=sa;Password=grupou;Encrypt=True;TrustServerCertificate=True"))
            {
                var result = await context.ExecuteAsync("RegistrarVendedor", new {ent.Cedula, ent.Nombre, ent.Correo }, commandType: System.Data.CommandType.StoredProcedure);

                if (result > 0)
                {
                    resp.Codigo = 1;
                    resp.Detalle = "Ok";
                    resp.Contenido = true;
                    return Ok(resp);
                }
                else
                {
                    resp.Codigo = 0;
                    resp.Detalle = "El vendedor ya se encuentra registrado";
                    resp.Contenido = false;
                    return Ok("Error");
                }
            }
        }

        [HttpPost]
        [Route("RegistrarVehiculo")]
        public async Task<IActionResult> RegistrarVehiculo(Vehiculo ent)
        {
            Confirmacion resp = new Confirmacion();

            using (var context = new SqlConnection("Server=127.0.0.1;Database=Practica2;User Id=sa;Password=grupou;Encrypt=True;TrustServerCertificate=True"))
            {
                var result = await context.ExecuteAsync("RegistrarVehiculo", new { ent.Marca, ent.Modelo, ent.Color, ent.Precio, ent.Vendedor }, commandType: System.Data.CommandType.StoredProcedure);

                if (result > 0)
                {
                    resp.Codigo = 1;
                    resp.Detalle = "Ok";
                    resp.Contenido = true;
                    return Ok(resp);
                }
                else
                {
                    resp.Codigo = 0;
                    resp.Detalle = "El vehiculo ya se encuentra registrado";
                    resp.Contenido = false;
                    return Ok("Error");
                }
            }
        }


    }
}
