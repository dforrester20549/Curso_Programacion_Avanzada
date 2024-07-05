using Caso_Estudio.Entidad;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;

namespace Caso_Estudio.Models
{
    public class EjerciciosModel(HttpClient httpClient, IConfiguration iConfiguration) : IEjerciciosModel
    {
        public Respuesta RegistrarEjercicio(Ejercicios entidad)
        {
            Respuesta respuesta = new Respuesta();
            using (var db = new SqlConnection(iConfiguration.GetConnectionString("DefaultConnection")))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Nombre", entidad.Nombre);
                parameters.Add("@Monto", entidad.Monto);
                parameters.Add("@TipoEjercicio", entidad.TipoEjercicio);

                var resultado = db.Execute("RegistrarEjercicio", parameters, commandType: CommandType.StoredProcedure);

                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "El ejercicio se registró correctamente";
                    respuesta.Contenido = true;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "Ya se encuentran registrados dos ejercicios con el mismo tipo";
                    respuesta.Contenido = false;
                }
            }

            return respuesta;
        }


        public Respuesta ConsultarEjercicios()
        {
            Respuesta respuesta = new Respuesta();

            using (var db = new SqlConnection(iConfiguration.GetConnectionString("DefaultConnection")))
            {
                var resultado = db.Query<EjerciciosModel>("Consultar", commandType: CommandType.StoredProcedure);

                if (resultado.AsList().Count > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "La información de los ejercicios se ha encontrado exitosamente";
                    respuesta.Contenido = resultado;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No hay ejercicios registrados en este momento";
                    respuesta.Contenido = false;
                }
            }

            return respuesta;
        }
    }
}
