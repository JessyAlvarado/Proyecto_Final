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
    public partial class menuvista : Form
    {
        public partial class MenuView : Syncfusion.Windows.Forms.Office2010Form
        {
            public MenuView()
            {
                InitializeComponent();
            }

            TipoSoporteView vistaTipoSoporte;
            EstadoTicketView vistaEstado;
            CreacionTicketView vistaCreacion;
            DetalleTicketView vistaDetalle;

            private void TiposSoporteToolStripButton_Click(object sender, EventArgs e)
            {
                if (vistaTipoSoporte == null)
                {
                    vistaTipoSoporte = new TipoSoporteView();
                    vistaTipoSoporte.MdiParent = this;
                    vistaTipoSoporte.FormClosed += Vista_FormClosedTipo;
                    vistaTipoSoporte.Show();
                }
                else
                {
                    vistaTipoSoporte.Activate();
                }
            }

            private void Vista_FormClosedTipo(object sender, FormClosedEventArgs e)
            {
                vistaTipoSoporte = null;
            }

            private void EstadoToolStripButton_Click(object sender, EventArgs e)
            {
                if (vistaEstado == null)
                {
                    vistaEstado = new EstadoTicketView();
                    vistaEstado.MdiParent = this;
                    vistaEstado.FormClosed += Vista_FormClosedEstado;
                    vistaEstado.Show();
                }
                else
                {
                    vistaEstado.Activate();
                }

            }

            private void Vista_FormClosedEstado(object sender, FormClosedEventArgs e)
            {
                vistaEstado = null;
            }

            private void CreacionTicketsToolStripButton_Click(object sender, EventArgs e)
            {
                if (vistaCreacion == null)
                {
                    vistaCreacion = new AgendarCitaView();
                    vistaCreacion.MdiParent = this;
                    vistaCreacion.FormClosed += Vista_FormClosedCreacion;
                    vistaCreacion.Show();
                }
                else
                {
                    vistaCreacion.Activate();
                }

            }

            private void Vista_FormClosedCreacion(object sender, FormClosedEventArgs e)
            {
                vistaCreacion = null;
            }

            private void DetalleToolStripButton_Click(object sender, EventArgs e)
            {

                if (vistaDetalle == null)
                {
                    vistaDetalle = new DetalleTicketView();
                    vistaDetalle.MdiParent = this;
                    vistaDetalle.FormClosed += Vista_FormClosedDetalle;
                    vistaDetalle.Show();
                }
                else
                {
                    vistaDetalle.Activate();
                }
            }

            private void Vista_FormClosedDetalle(object sender, FormClosedEventArgs e)
            {
                vistaDetalle = null;
            }
        }

        private void toolStripEx2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
}
