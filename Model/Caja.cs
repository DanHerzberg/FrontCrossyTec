using System;
namespace FrontCrossyTec.Model
{
    public class Caja
    {
        public int Id { get; set; }
        public string ImagenUrl { get; set; }
        public decimal Precio { get; set; }

        // Constructor, si es necesario
        public Caja(int id, string imagenUrl, decimal precio)
        {
            Id = id;
            ImagenUrl = imagenUrl;
            Precio = precio;
        }
    }

}

