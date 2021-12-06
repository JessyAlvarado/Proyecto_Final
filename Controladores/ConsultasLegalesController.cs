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
    public class ConsultasLegalesController
    {
        ConsultasView vista;
        string operacion = string.Empty;
        ConsultasLegalesDAO ConsultasDAO = new ConsultasLegalesDAO();
        ConsultasLegales consultas = new  ConsultasLegales();
       

        public ConsultasLegalesController(ConsultasView view)
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
            consultas = null;
        }
        private void Eliminar(object serder, EventArgs e)
        {
            if (vista.ConsultasDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = ConsultasDAO.EliminarConsulta(Convert.ToInt32(vista.ConsultasDataGridView.CurrentRow.Cells[0].Value.ToString()));

                if (elimino)
                {
                    DesabilitarControles();
                    LimpiarControles();

                    MessageBox.Show("Consulta eliminada exitosamente", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    ListarConsultas();
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
            ListarConsultas();
        }

        private void Guardar(object serder, EventArgs e)
        {

            if (vista.ServiciosComboBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.ServiciosComboBox, "Ingrese el tipo de servicio");
                vista.ServiciosComboBox.Focus();
                return;
            }
            if (vista.NombreTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.NombreTextBox, "Ingrese su nombre ");
                vista.NombreTextBox.Focus();
                return;
            }
            if (vista.NumidTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.NumidTextBox, "Ingrese su numero de identidad");
                vista.NumidTextBox.Focus();
                return;
            }
            if (vista.DescripcionTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.DescripcionTextBox, "Ingrese la descripcion del caso");
                vista.DescripcionTextBox.Focus();
                return;
            }

            consultas.Servicios = vista.ServiciosComboBox.Text;
            consultas.Nombre = vista.NombreTextBox.Text;
            consultas.NumeroID= Convert.ToInt32(vista.NumidTextBox.Text);
            consultas.Descripcion = vista.DescripcionTextBox.Text;

            bool inserto = ConsultasDAO.ConsultasLegales(consultas);

            if (operacion == "Nuevo")
            {

                if (inserto)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    MessageBox.Show("Nueva consulta creada exitosamente", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    ListarConsultas();

                }
                else
                {
                    MessageBox.Show("No se pudo hacer la consulta", "Atención", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }


        }

        private void ListarConsultas()
        {
            vista.ConsultasDataGridView.DataSource = ConsultasDAO.GetConsultas();
        }

        private void LimpiarControles()
        {
            vista.IdTextBox.Clear();
            vista.ServiciosComboBox.Text = "";
            vista.NombreTextBox.Clear();
            vista.NumidTextBox.Clear();
            vista.DescripcionTextBox.Clear();
        }

        private void HabilitarControles()
        {
            vista.IdTextBox.Enabled = true;
            vista.ServiciosComboBox.Enabled = true;
            vista.NombreTextBox.Enabled = true;
            vista.NumidTextBox.Enabled = true;
            vista.DescripcionTextBox.Enabled = true;

            vista.GuardarButton.Enabled = true;
            vista.CancelarButton.Enabled = true;
            vista.NuevoButton.Enabled = false;
        }

        private void DesabilitarControles()
        {
            vista.IdTextBox.Enabled = false;
            vista.ServiciosComboBox.Enabled = false;
            vista.NombreTextBox.Enabled = false;
            vista.NumidTextBox.Enabled = false;
            vista.DescripcionTextBox.Enabled = false;

            vista.GuardarButton.Enabled = false;
            vista.CancelarButton.Enabled = false;
            vista.NuevoButton.Enabled = true;
        }
    }
} 

