using Proyecto_Final.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final.Vistas
{
    public partial class AgendarCita : Form
    {
        public AgendarCita()
        {
            InitializeComponent();


            AgendarCitaController controller = new AgendarCitaController(this);
        }

        private void AgendarCita_Load(object sender, EventArgs e)
        {

        }
    }
}
