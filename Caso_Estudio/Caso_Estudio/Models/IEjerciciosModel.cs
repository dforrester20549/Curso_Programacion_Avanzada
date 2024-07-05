using Caso_Estudio.Entidad;

namespace Caso_Estudio.Models
{
    public interface IEjerciciosModel
    {
        Respuesta RegistrarEjercicio(Ejercicios entidad);
        Respuesta ConsultarEjercicios();
        Task<IEnumerable<TipoEjercicios>> ObtenerTiposEjercicio();

    }
}
