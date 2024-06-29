namespace Practica_2_WEB.Entities
{
    public class Vehiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public decimal Precio { get; set; }
        public long Vendedor { get; set; }
    }

    public class ConfirmacionVehiculo
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }

    }
}
