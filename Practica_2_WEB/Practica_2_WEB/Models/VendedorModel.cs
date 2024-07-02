using Practica_2_WEB.Entities;

namespace Practica_2_WEB.Models
{
    public class VendedorModel(HttpClient httpClient, IConfiguration iConfiguration) : IVendedorModel
    {
        public Respuesta RegistrarVendedor(Vendedor entidad)
        {
            using (httpClient)
            {
                string url = iConfiguration.GetSection("Llaves:UrlApi").Value + "Vendedor/RegistrarVendedor";
                JsonContent body = JsonContent.Create(entidad);
                var respuesta = httpClient.PostAsync(url, body).Result;

                if (respuesta.IsSuccessStatusCode)
                    return respuesta.Content.ReadFromJsonAsync<Respuesta>().Result!;
                else
                    return new Respuesta();
            }
        }

    }
}
