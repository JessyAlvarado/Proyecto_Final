using Proyecto_Final.Modelos.DAO;
using Proyecto_Final.Modelos.Entidades;
using Proyecto_Final.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final.Controladores
{
   
        public class LoginController
        {
            Login vista;

            public LoginController(Login view)
            {
                vista = view;

                vista.AceptarButton.Click += new EventHandler(ValidarUsuarios);
            }

            private void ValidarUsuarios(object serder, EventArgs e)
            {
                bool esValido = false;
                UsuarioDAO userDao = new UsuarioDAO();

                Usuarios user = new Usuarios();

                user.Email = vista.EmailTextBox.Text;
                //

                esValido = userDao.ValidarUsuarios(user);

                if (esValido)
                {
                    MessageBox.Show("Usuario Correcto");

                    MenuView menu = new MenuView();
                    vista.Hide();
                    menu.Show();


                }
                else
                {
                    MessageBox.Show("Usuario Incorrecto");
                }

            }


        //

           
        }
    
}
