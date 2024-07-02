using Practica_2_WEB.Entities;

namespace Practica_2_WEB.Models
{
    public interface IVehiculoModel
    {
        Respuesta RegistrarVehiculo(Vehiculo entidad);

        Respuesta ConsultarVehiculos();
    }
}
