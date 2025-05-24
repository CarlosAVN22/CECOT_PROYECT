using System;
using System.Drawing;
using System.Windows.Forms;
using CECOT_PROYECT.Resources;

namespace CECOT_PROYECT
{
    public partial class Mostrar : Form
    {
        private ReosCRUD reosCRUD;
        private Cecot reo;
        private int fila;

        public Mostrar(
            Form formularioAnterior,
            string id,
            string nombre,
            string edad,
            string dui,
            string sentencia,
            string delito,
            string celda,
            string seccion,
            string tipoSeccion,
            string fechaIngreso)
        {
            InitializeComponent();

            // Asignar valores a los campos
            txtid.Text = id;
            txtnombre.Text = nombre;
            txtedad.Text = edad;
            txtdui.Text = dui;
            txtcelda.Text = celda;
            txtfechaingreso.Text = fechaIngreso;

            // Hacer los campos solo lectura
            DesactivarCampos();
        }

        public Mostrar(ReosCRUD reosCRUD, Cecot reo, int fila)
        {
            this.reosCRUD = reosCRUD;
            this.reo = reo;
            this.fila = fila;
        }

        private void DesactivarCampos()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox txt)
                {
                    txt.ReadOnly = true;
                    txt.BackColor = Color.LightGray;
                }
            }
        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            ReosCRUD cerrar = new ReosCRUD();
            cerrar.Show();
            this.Close();
        }

        private void btnregresar_MouseEnter(object sender, EventArgs e)
        {
            btnregresar.Size = new Size(btnregresar.Width + 5, btnregresar.Height + 5);
            btnregresar.BackColor = Color.DimGray;
            btnregresar.ForeColor = Color.White;
            btnregresar.FlatAppearance.BorderColor = Color.White;
        }

        private void btnregresar_MouseLeave(object sender, EventArgs e)
        {
            btnregresar.Size = new Size(btnregresar.Width - 5, btnregresar.Height - 5);
            btnregresar.BackColor = Color.White;
            btnregresar.ForeColor = Color.Black;
            btnregresar.FlatAppearance.BorderColor = Color.DimGray;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Si deseas abrir EditarForm desde aquí
            // EditarForm editar = new EditarForm(...);
            // editar.Show();
            // this.Close();
        }
    }
}
