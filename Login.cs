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

        private void tbbUser_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void Iniciar_MouseEnter(object sender, EventArgs e)
        {
            Iniciar.Size = new Size(Iniciar.Width + 5, Iniciar.Height + 5);
            Iniciar.BackColor = Color.DimGray;
            Iniciar.ForeColor = Color.White;
            Iniciar.FlatAppearance.BorderColor = Color.White;
        }

        private void Iniciar_Click(object sender, EventArgs e)
        {
            if (tbbUser.Text=="admin1"  && tbPassword.Text =="caca")
            {
                CentroControl buscar = new CentroControl();
                buscar.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(
                "Usuario o contraseña incorrectos",       
                "Advertencia",                             
                MessageBoxButtons.OK,            
                MessageBoxIcon.Warning     
                );
            }
        }

        private void Iniciar_MouseLeave(object sender, EventArgs e)
        {
            Iniciar.Size = new Size(Iniciar.Width - 5, Iniciar.Height - 5);
            Iniciar.BackColor = Color.White;
            Iniciar.ForeColor = Color.Black;
            Iniciar.FlatAppearance.BorderColor = Color.DimGray;
        }

        private void Cerrar_MouseEnter(object sender, EventArgs e)
        {
            Cerrar.Size = new Size(Cerrar.Width + 5, Cerrar.Height + 5);
            Cerrar.BackColor = Color.DimGray;
            Cerrar.ForeColor = Color.White;
            Cerrar.FlatAppearance.BorderColor = Color.White;
        }

        private void Cerrar_MouseLeave(object sender, EventArgs e)
        {
            Cerrar.Size = new Size(Cerrar.Width - 5, Cerrar.Height - 5);
            Cerrar.BackColor = Color.White;
            Cerrar.ForeColor = Color.Black;
            Cerrar.FlatAppearance.BorderColor = Color.DimGray;
        }

        private void Cerrar_MouseClick(object sender, MouseEventArgs e)
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
    }
 }

