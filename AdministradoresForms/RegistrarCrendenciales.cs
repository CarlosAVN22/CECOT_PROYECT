using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CECOT_PROYECT.AdministradoresForms
{
    public partial class RegistrarCrendenciales : Form
    {
        private string _cargo;

        public RegistrarCrendenciales(string cargo)
        {
            InitializeComponent();
            _cargo = cargo;

            
        }
        private void guardar_MouseLeave(object sender, EventArgs e)
        {
            button1.Size = new Size(button1.Width - 5, button1.Height - 5);
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
            button1.FlatAppearance.BorderColor = Color.DimGray;
        }

        private void guardar_MouseEnter(object sender, EventArgs e)
        {
            button1.Size = new Size(button1.Width + 5, button1.Height + 5);
            button1.BackColor = Color.DimGray;
            button1.ForeColor = Color.White;
            button1.FlatAppearance.BorderColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text;

            if (contraseña.Length >= 8)
            {
                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
                {
                    MessageBox.Show("Por favor ingrese usuario y contraseña.");
                    return;
                }

                GestorUsuarios.GuardarUsuario(usuario, contraseña, _cargo);
                MessageBox.Show("Credenciales guardadas exitosamente.");
                MenuOpciones menuOpciones = new MenuOpciones();
                menuOpciones.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("La contraseña debe ser minimo 8 digitos");
            }
            

        }

        private void txtcontraseña_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
