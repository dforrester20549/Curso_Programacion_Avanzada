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
    public class VendedorController(IConfiguration iConfiguration) : ControllerBase
    {
        [HttpPost]
        [Route("RegistrarVendedor")]
        public async Task<IActionResult> RegistrarVendedor(Vendedor entidad)
        {
            Respuesta respuesta = new Respuesta();

            using (var db = new SqlConnection(iConfiguration.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var result = await db.ExecuteAsync("RegistrarVendedor", new { entidad.Cedula, entidad.Nombre, entidad.Correo }, commandType: CommandType.StoredProcedure);

                if (result > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "El vendedor se registro correctamente";
                    respuesta.Contenido = true;
                    return Ok(respuesta);
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "La información del vendedor ya se encuentra registrada";
                    respuesta.Contenido = false;
                    return Ok(respuesta);
                }
            }
        }
    }
}
