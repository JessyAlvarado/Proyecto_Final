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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            LoginController controlador = new LoginController(this);
        }


    }
}
