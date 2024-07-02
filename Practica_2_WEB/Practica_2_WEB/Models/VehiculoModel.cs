using Practica_2_WEB.Entities;

namespace Practica_2_WEB.Models
{
    public class VehiculoModel(HttpClient httpClient, IConfiguration iConfiguration) : IVehiculoModel
    {
        public Respuesta RegistrarVehiculo(Vehiculo entidad)
        {
            using (httpClient)
            {
                string url = iConfiguration.GetSection("Llaves:UrlApi").Value + "Vehiculo/RegistrarVehiculo";
                JsonContent body = JsonContent.Create(entidad);
                var respuesta = httpClient.PostAsync(url, body).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Respuesta>().Result!;
                else
                    return new Respuesta();
            }
        }

        public Respuesta ConsultarVehiculos()
        {
            using (httpClient)
            {
                string url = iConfiguration.GetSection("Llaves:UrlApi").Value + "Vehiculo/ConsultarVehiculos";
                var respuesta = httpClient.GetAsync(url).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Respuesta>().Result!;
                else
                    return new Respuesta();
            }
        }
    }
}
