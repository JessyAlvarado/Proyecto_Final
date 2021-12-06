using Proyecto_Final.Modelos.DAO;
using Proyecto_Final.Modelos.Entidades;
using Proyecto_Final.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final.Controladores
{
    public class AgendarCitaController
    {
        AgendarCitaView vista;
        string operacion = string.Empty;
        AgendarCitaDAO creacionDAO = new AgendarCitaDAO();
        AgendarCita Agendar = new AgendarCita();
       

        public AgendarCitaController(AgendarCitaView view)
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
            Agendar = null;
        }
        private void Eliminar(object serder, EventArgs e)
        {
            if (vista.AgendardataGridView.SelectedRows.Count > 0)
            {
                bool elimino = creacionDAO.EliminarUsuario(Convert.ToInt32(vista.AgendardataGridView.CurrentRow.Cells[0].Value.ToString()));

                if (elimino)
                {
                    DesabilitarControles();
                    LimpiarControles();

                    MessageBox.Show("Cita eliminada exitosamente", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    ListarCitas();
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
            ListarCitas();
        }

        private void Guardar(object serder, EventArgs e)
        {
            if (vista.ServiciosComboBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.ServiciosComboBox, "Ingrese el tipo de servicio que necesita");
                vista.ServiciosComboBox.Focus();
                return;
            }
            if (vista.NombreClienteTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.NombreClienteTextBox, "Ingrese el nombre del cliente");
                vista.NombreClienteTextBox.Focus();
                return;
            }
            if (vista.EmailTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.EmailTextBox, "Ingrese el correo del cliente");
                vista.EmailTextBox.Focus();
                return;
            }
            if (vista.DireccionTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.DireccionTextBox, "Ingrese la direccion del cliente");
                vista.DireccionTextBox.Focus();
                return;
            }
            if (vista.DescripcionProblemaTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.DescripcionProblemaTextBox, "Ingrese una descripcion del Caso");
                vista.DescripcionProblemaTextBox.Focus();
                return;
            }

            Agendar.Servicio = vista.ServiciosComboBox.Text;
            Agendar.NombreCliente = vista.NombreClienteTextBox.Text;
            Agendar.Email = vista.EmailTextBox.Text;
            Agendar.Direccion = vista.DireccionTextBox.Text;
            Agendar.DescripcionCaso = vista.DescripcionProblemaTextBox.Text;

            bool inserto = creacionDAO.AgendarCita(Agendar);

            if (operacion == "Nuevo")
            {

                if (inserto)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    MessageBox.Show("Cita creada exitosamente", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ListarCitas();

                }
                else
                {
                    MessageBox.Show("No se pudo crear la cita", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }


        }

        private void ListarCitas()
        {
            vista.AgendardataGridView.DataSource = creacionDAO.GetAgendar();
        }

        private void LimpiarControles()
        {
            vista.IDTXT.Clear();
            vista.ServiciosComboBox.Text = "";
            vista.NombreClienteTextBox.Clear();
            vista.EmailTextBox.Clear();
            vista.DireccionTextBox.Clear();
            vista.DescripcionProblemaTextBox.Clear();
        }

        private void HabilitarControles()
        {
            vista.IDTXT.Enabled = true;
            vista.ServiciosComboBox.Enabled = true;
            vista.NombreClienteTextBox.Enabled = true;
            vista.EmailTextBox.Enabled = true;
            vista.DireccionTextBox.Enabled = true;
            vista.DescripcionProblemaTextBox.Enabled = true;

            vista.GuardarButton.Enabled = true;
            vista.CancelarButton.Enabled = true;
            vista.NuevoButton.Enabled = false;
        }

        private void DesabilitarControles()
        {
            vista.IDTXT.Enabled = false;
            vista.ServiciosComboBox.Enabled = false;
            vista.NombreClienteTextBox.Enabled = false;
            vista.EmailTextBox.Enabled = false;
            vista.DireccionTextBox.Enabled = false;
            vista.DescripcionProblemaTextBox.Enabled = false;

            vista.GuardarButton.Enabled = false;
            vista.CancelarButton.Enabled = false;
            vista.NuevoButton.Enabled = true;
        }



    }
}

