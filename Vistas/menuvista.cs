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
    public partial class MenuView : Syncfusion.Windows.Forms.Office2010Form
    {
        public MenuView()
        {
            InitializeComponent();
        }

        AgendarCitaView vistaAgendar;
        ConocenosView vistaConocenos;
        ConsultasView vistaConsultas;
       

        private void AgendarToolStripButton_Click(object sender, EventArgs e)
        {
            if (vistaAgendar == null)
            {
                vistaAgendar = new AgendarCitaView();
                vistaAgendar.MdiParent = this;
                vistaAgendar.FormClosed += Vista_FormClosedTipo;
                vistaAgendar.Show();
            }
            else
            {
                vistaAgendar.Activate();
            }
        }

        private void Vista_FormClosedTipo(object sender, FormClosedEventArgs e)
        {
            vistaAgendar = null;
        }

        private void ConsultaToolStripButton_Click(object sender, EventArgs e)
        {
            if (vistaConsultas == null)
            {
                vistaConsultas = new ConsultasView();
                vistaConsultas.MdiParent = this;
                vistaConsultas.FormClosed += Vista_FormClosedEstado;
                vistaConsultas.Show();
            }
            else
            {
                vistaConsultas.Activate();
            }

        }

        private void Vista_FormClosedEstado(object sender, FormClosedEventArgs e)
        {
            vistaConsultas = null;
        }

        private void ConocenosToolStripButton_Click(object sender, EventArgs e)
        {
            if (vistaConocenos == null)
            {
                vistaConocenos = new ConocenosView();
                vistaConocenos.MdiParent = this;
                vistaConocenos.FormClosed += Vista_FormClosedCreacion;
                vistaConocenos.Show();
            }
            else
            {
                vistaConocenos.Activate();
            }

        }

        private void Vista_FormClosedCreacion(object sender, FormClosedEventArgs e)
        {
            vistaConocenos = null;
        }

        
    }
}


