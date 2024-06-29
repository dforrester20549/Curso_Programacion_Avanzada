namespace Practica_2_WEB.Entities
{
    public class Vendedor
    {
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
    }

    public class ConfirmacionVendedor
    {
        public int Codigo { get; set; }
        public string Detalle { get; set; }

    }
}
