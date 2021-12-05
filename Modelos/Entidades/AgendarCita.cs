using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Modelos.Entidades
{
    public class AgendarCita
    {
        public int Id { get; set; }
        public string Servicio { get; set; }
        public string NombreCliente { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string DescripcionProblema
        {
            get; set;


        }
    }
}
