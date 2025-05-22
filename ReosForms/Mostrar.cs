using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace CECOT_PROYECT
{

    
    public partial class Mostrar : Form
     {
            private int filaSeleccionada;

            public Mostrar(Form formularioAnterior, string id, string nombre, string edad, string celda, string dui, string cargo,string fechaIngreso, int filaSeleccionada)
            {
                InitializeComponent();
                txtid.Text = id;
                txtnombre.Text = nombre;
                txtedad.Text = edad;
                txtcelda.Text = celda;
                txtdui.Text = dui;
                txtcargos.Text = cargo;
                txtfechaingreso.Text = fechaIngreso;

                this.filaSeleccionada = filaSeleccionada;

                txtid.ReadOnly = true;
                txtnombre.ReadOnly = true;
                txtedad.ReadOnly = true;
                txtcelda.ReadOnly = true;
                txtcargos.ReadOnly = true;
                txtfechaingreso.ReadOnly = true;

                txtid.BackColor = Color.Gray;
                txtnombre.BackColor = Color.Gray;
                
        }
        


        private void Registrar_Load(object sender, EventArgs e)
        {
            

        }

        private void label7_Click(object sender, EventArgs e)
        {

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

        private void btnEliminar_MouseEnter(object sender, EventArgs e)
        {
            btnEliminar.Size = new Size(btnEliminar.Width + 5, btnEliminar.Height + 5);
            btnEliminar.BackColor = Color.DimGray;
            btnEliminar.ForeColor = Color.White;
            btnEliminar.FlatAppearance.BorderColor = Color.White;
        }

        private void btnEliminar_MouseLeave(object sender, EventArgs e)
        {
            btnEliminar.Size = new Size(btnEliminar.Width - 5, btnEliminar.Height - 5);
            btnEliminar.BackColor = Color.White;
            btnEliminar.ForeColor = Color.Black;
            btnEliminar.FlatAppearance.BorderColor = Color.DimGray;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Editar_Click(object sender, EventArgs e)
        {
            //EditarForm agregar = new EditarForm(this);
            //agregar.Show();
            //this.Close();
        }
    }
}
