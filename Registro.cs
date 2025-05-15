using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Win32;

namespace CECOT_PROYECT
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void pbRegistrar_Click(object sender, EventArgs e)
        {
            Registrar registrar = new Registrar();
            registrar.Show();
            this.Hide();

        }

        private void tbBuscar_Click(object sender, EventArgs e)
        {
            Buscar buscar = new Buscar();
            buscar.Show();
            this.Hide();
        }

        private void pbEliminar_Click(object sender, EventArgs e)
        {
            Eliminar eliminar = new Eliminar();
            eliminar.Show();
            this.Hide();
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
           Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
