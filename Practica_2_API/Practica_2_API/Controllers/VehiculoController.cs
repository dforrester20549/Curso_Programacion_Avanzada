using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Practica_2_API.Entities;
using System.Data;

namespace Practica_2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController(IConfiguration iConfiguration) : ControllerBase
    {
        [HttpPost]
        [Route("RegistrarVehiculo")]
        public async Task<IActionResult> RegistrarVehiculo(Vehiculo entidad)
        {
            Respuesta respuesta = new Respuesta();

            using (var db = new SqlConnection(iConfiguration.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var resultado = await db.ExecuteAsync("RegistrarVehiculo", new { entidad.Marca, entidad.Modelo, entidad.Color, entidad.Precio, entidad.IdVendedor }, commandType: CommandType.StoredProcedure);

                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "El vehiculo se registro correctamente";
                    respuesta.Contenido = true;
                    return Ok(respuesta);
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "Ya se encuentran registrados dos vehiculos con la misma marca";
                    respuesta.Contenido = false;
                    return Ok(respuesta);
                }
            }
        }

        [HttpGet]
        [Route("ConsultarVehiculos")]
        public async Task<IActionResult> ConsultarVehiculos()
        {
            Respuesta respuesta = new Respuesta();

            using (var context = new SqlConnection(iConfiguration.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var resultado = await context.QueryAsync<Vehiculo>("ConsultarVehiculos", new { }, commandType: CommandType.StoredProcedure);

                if (resultado.Count() > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "La información de los vehiculos se ha encontrado exitosamente";
                    respuesta.Contenido = resultado;
                    return Ok(respuesta);
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No hay usuarios registrados en este momento";
                    respuesta.Contenido = false;
                    return Ok(respuesta);
                }
            }
        }
    }
}
