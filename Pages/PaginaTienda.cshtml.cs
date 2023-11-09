using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontCrossyTec.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontCrossyTec.Pages
{
    public class PaginaTiendaModel : PageModel
    {
        public List<Caja> Cajas { get; set; }

        public PaginaTiendaModel()
        {
            // Inicializar la lista
            Cajas = new List<Caja>();

            // Aquí puedes agregar las cajas manualmente o cargarlas desde una base de datos
            Cajas.Add(new Caja(1, "/path/to/image1.jpg", 100.00m));
            Cajas.Add(new Caja(2, "/path/to/image2.jpg", 150.00m));
            Cajas.Add(new Caja(3, "/path/to/image3.jpg", 200.00m));
            Cajas.Add(new Caja(4, "/path/to/image4.jpg", 250.00m));
        }

        
    }
}
