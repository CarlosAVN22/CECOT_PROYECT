using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CECOT_PROYECT.Resources;

namespace CECOT_PROYECT
{
    public partial class AdministradoresCRUD : Form
    {
        public AdministradoresCRUD()
        {
            InitializeComponent();
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cecotAgregar.PresentarRegistros();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Agregar_Click(object sender, EventArgs e)
        {

        }

        private void Agregar_MouseEnter(object sender, EventArgs e)
        {
            Agregar.Size = new Size(Agregar.Width + 5, Agregar.Height + 5);
            Agregar.BackColor = Color.DimGray;
            Agregar.ForeColor = Color.White;
            Agregar.FlatAppearance.BorderColor = Color.White;
        }

        private void Agregar_MouseLeave(object sender, EventArgs e)
        {
            Agregar.Size = new Size(Agregar.Width - 5, Agregar.Height - 5);
            Agregar.BackColor = Color.White;
            Agregar.ForeColor = Color.Black;
            Agregar.FlatAppearance.BorderColor = Color.DimGray;
        }

        private void Editar_MouseEnter(object sender, EventArgs e)
        {
            Editar.Size = new Size(Editar.Width + 5, Editar.Height + 5);
            Editar.BackColor = Color.DimGray;
            Editar.ForeColor = Color.White;
            Editar.FlatAppearance.BorderColor = Color.White;
        }

        private void Editar_MouseLeave(object sender, EventArgs e)
        {
            Editar.Size = new Size(Editar.Width - 5, Editar.Height - 5);
            Editar.BackColor = Color.White;
            Editar.ForeColor = Color.Black;
            Editar.FlatAppearance.BorderColor = Color.DimGray;
        }

        private void Visualizar_MouseEnter(object sender, EventArgs e)
        {
            Visualizar.Size = new Size(Visualizar.Width + 5, Visualizar.Height + 5);
            Visualizar.BackColor = Color.DimGray;
            Visualizar.ForeColor = Color.White;
            Visualizar.FlatAppearance.BorderColor = Color.White;
        }

        private void Visualizar_MouseLeave(object sender, EventArgs e)
        {
            Visualizar.Size = new Size(Visualizar.Width - 5, Visualizar.Height - 5);
            Visualizar.BackColor = Color.White;
            Visualizar.ForeColor = Color.Black;
            Visualizar.FlatAppearance.BorderColor = Color.DimGray;
        }

        private void Eliminar_MouseEnter(object sender, EventArgs e)
        {
            Eliminar.Size = new Size(Eliminar.Width + 5, Eliminar.Height + 5);
            Eliminar.BackColor = Color.DimGray;
            Eliminar.ForeColor = Color.White;
            Eliminar.FlatAppearance.BorderColor = Color.White;
        }

        private void Eliminar_MouseLeave(object sender, EventArgs e)
        {
            Eliminar.Size = new Size(Eliminar.Width - 5, Eliminar.Height - 5);
            Eliminar.BackColor = Color.White;
            Eliminar.ForeColor = Color.Black;
            Eliminar.FlatAppearance.BorderColor = Color.DimGray;
        }

        private void Regresar_MouseEnter(object sender, EventArgs e)
        {
            Regresar.Size = new Size(Regresar.Width + 5, Regresar.Height + 5);
            Regresar.BackColor = Color.DimGray;
            Regresar.ForeColor = Color.White;
            Regresar.FlatAppearance.BorderColor = Color.White;
        }

        private void Regresar_MouseLeave(object sender, EventArgs e)
        {
            Regresar.Size = new Size(Regresar.Width - 5, Regresar.Height - 5);
            Regresar.BackColor = Color.White;
            Regresar.ForeColor = Color.Black;
            Regresar.FlatAppearance.BorderColor = Color.DimGray;
        }

        private void Regresar_MouseClick(object sender, MouseEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void Visualizar_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Editar_Click(object sender, EventArgs e)
        {
   
        }

        private void Visualizar_Click(object sender, EventArgs e)
        {
        }
    }
}
