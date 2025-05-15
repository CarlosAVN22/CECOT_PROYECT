using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CECOT_PROYECT
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pbIniciar_Click(object sender, EventArgs e)
        {
            if (tbbUser.Text == "administrador1" && tbPassword.Text == "A1J2J3Y4C5M6C7$")
            {
                Registro registro = new Registro();
                registro.Show();
                this.Hide();
                lbError.Visible = false;
            }
            else
            {
                lbError.Visible = true;
                tbbUser.Text = "";
                tbbUser.Text = "";
            }
            
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "¿Estás seguro de que deseas cerrar el programa?",
            "Confirmar salida",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void tbbUser_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
