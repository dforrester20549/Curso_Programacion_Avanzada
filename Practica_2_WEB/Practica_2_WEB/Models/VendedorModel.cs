using Microsoft.Extensions.Configuration;
using Practica_2_WEB.Entities;
using Practica_2_WEB.Interfaces;
using System.Net.Http;

namespace Practica_2_WEB.Models
{
    public class VendedorModel(HttpClient httpClient, IConfiguration iConfiguration) : IVendedorModel
    {
        public Confirmacion RegistrarVendedor(Vendedor ent) 
        {
            using (httpClient) 
            {
                string url = iConfiguration.GetSection("Llaves:UrlApi").Value + "Usuario/RegistrarVendedor";
                JsonContent body = JsonContent.Create(ent);
                var resp = httpClient.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                    return resp.Content.ReadFromJsonAsync<Confirmacion>().Result!;
                else
                    return new Confirmacion();
            }
        }

    }
}
