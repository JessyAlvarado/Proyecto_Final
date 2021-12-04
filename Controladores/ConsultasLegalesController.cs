using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Controladores
{
    class ConsultasLegalesController
    {
        TipoSoporteView vista;
        string operacion = string.Empty;
        TipoSoporteDAO tiposoporteDAO = new TipoSoporteDAO();
        TipoSoportes tiposoporte = new TipoSoportes();

        public TipoSoporteController(TipoSoporteView view)
        {
            vista = view;
            vista.NuevoButton.Click += new EventHandler(Nuevo);
            vista.GuardarButton.Click += new EventHandler(Guardar);
            vista.Load += new EventHandler(Load);
            vista.EliminarButton.Click += new EventHandler(Eliminar);
            vista.CancelarButton.Click += new EventHandler(Cancelar);
        }

        private void Cancelar(object sender, EventArgs e)
        {
            DesabilitarControles();
            LimpiarControles();
            tiposoporte = null;
        }
        private void Eliminar(object serder, EventArgs e)
        {
            if (vista.TipoDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = tiposoporteDAO.EliminarTipo(Convert.ToInt32(vista.TipoDataGridView.CurrentRow.Cells[0].Value.ToString()));

                if (elimino)
                {
                    DesabilitarControles();
                    LimpiarControles();

                    MessageBox.Show("Tipo de soporte eliminado exitosamente", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    ListarTickets();
                }
            }
        }

        private void Nuevo(object serder, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
        }

        private void Load(object serder, EventArgs e)
        {
            ListarTickets();
        }

        private void Guardar(object serder, EventArgs e)
        {

            if (vista.TipoSoporteComboBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.TipoSoporteComboBox, "Ingrese el tipo de soporte");
                vista.TipoSoporteComboBox.Focus();
                return;
            }
            if (vista.DispositivoTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.DispositivoTextBox, "Ingrese el tipo de dispositivo");
                vista.DispositivoTextBox.Focus();
                return;
            }
            if (vista.PrecioTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.PrecioTextBox, "Ingrese el precio del tipo de soporte");
                vista.PrecioTextBox.Focus();
                return;
            }
            if (vista.DescripcionTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.DescripcionTextBox, "Ingrese el nombre del cliente");
                vista.DescripcionTextBox.Focus();
                return;
            }

            tiposoporte.TipoSoporte = vista.TipoSoporteComboBox.Text;
            tiposoporte.Dispositivo = vista.DispositivoTextBox.Text;
            tiposoporte.Precio = Convert.ToDecimal(vista.PrecioTextBox.Text);
            tiposoporte.Descripcion = vista.DescripcionTextBox.Text;

            bool inserto = tiposoporteDAO.EstadoTicket(tiposoporte);

            if (operacion == "Nuevo")
            {

                if (inserto)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    MessageBox.Show("Nuevo tipo de soporte creado exitosamente", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ListarTickets();

                }
                else
                {
                    MessageBox.Show("No se pudo crear el tipo de soporte", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }


        }

        private void ListarTickets()
        {
            vista.TipoDataGridView.DataSource = tiposoporteDAO.GetTipo();
        }

        private void LimpiarControles()
        {
            vista.IdTextBox.Clear();
            vista.TipoSoporteComboBox.Text = "";
            vista.DispositivoTextBox.Clear();
            vista.PrecioTextBox.Clear();
            vista.DescripcionTextBox.Clear();
        }

        private void HabilitarControles()
        {
            vista.IdTextBox.Enabled = true;
            vista.TipoSoporteComboBox.Enabled = true;
            vista.DispositivoTextBox.Enabled = true;
            vista.PrecioTextBox.Enabled = true;
            vista.DescripcionTextBox.Enabled = true;

            vista.GuardarButton.Enabled = true;
            vista.CancelarButton.Enabled = true;
            vista.NuevoButton.Enabled = false;
        }

        private void DesabilitarControles()
        {
            vista.IdTextBox.Enabled = false;
            vista.TipoSoporteComboBox.Enabled = false;
            vista.DispositivoTextBox.Enabled = false;
            vista.PrecioTextBox.Enabled = false;
            vista.DescripcionTextBox.Enabled = false;

            vista.GuardarButton.Enabled = false;
            vista.CancelarButton.Enabled = false;
            vista.NuevoButton.Enabled = true;
        }
    }
} 

