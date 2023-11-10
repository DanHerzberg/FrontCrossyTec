using System;

namespace FrontCrossyTec.Model
{
    public class Caja
    {
        public int Id { get; set; }
        public string Nombre { get; set; }  // Campo adicional para el nombre
        public decimal Precio { get; set; }

        // Constructor por defecto
        public Caja()
        {
        }

        // Constructor con parámetros
        public Caja(int id, string nombre, decimal precio)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
        }
    }
}
