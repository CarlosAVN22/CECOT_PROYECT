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
    public partial class EditarForm : Form
    {
        private ReosCRUD CentroControlMain;
        private int Editar = -1;
        private bool Edicion = false;

        public EditarForm(ReosCRUD Main)
        {
            InitializeComponent();
            CentroControlMain = Main;
        }

        public EditarForm(ReosCRUD Main, string ID, string Nombre, string Celda, string Edad, string DUI, string Cargos, string Ingreso, int fila)
        {
            InitializeComponent();
            CentroControlMain = Main;
            Edicion = true;
            Editar = fila;

            txtid.Text = ID;
            txtnombre.Text = Nombre;
            txtsentencia.Text = Celda;
            txtedad.Text = Edad;
            txtdui.Text = DUI;
            txtcargos.Text = Cargos;
            txtfechaingreso.Text = Ingreso;

            txtid.Enabled = false;
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
            Guardar.Size = new Size(Guardar.Width + 5, Guardar.Height + 5);
            Guardar.BackColor = Color.DimGray;
            Guardar.ForeColor = Color.White;
            Guardar.FlatAppearance.BorderColor = Color.White;
        }

        private void Editar_MouseLeave(object sender, EventArgs e)
        {
            Guardar.Size = new Size(Guardar.Width - 5, Guardar.Height - 5);
            Guardar.BackColor = Color.White;
            Guardar.ForeColor = Color.Black;
            Guardar.FlatAppearance.BorderColor = Color.DimGray;
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
            Cecot persona = new Cecot
            {
                Id = int.Parse(txtid.Text),
                Nombre = txtnombre.Text,
                Edad = txtedad.Text, // o int.Parse(txtEdad.Text) si usas int
                Celda = txtsentencia.Text,
                Dui = txtdui.Text,
                Cargos = txtcargos.Text,
                FechaIngreso = txtfechaingreso.Text // o dtpFechaIngreso.Value si usas DateTimePicker
            };

            bool exito = cecotAgregar.ActualizarPersona(persona);

            if(Edicion && Editar != -1)
            {
                CentroControlMain.EditarFila(Editar,persona);  
            }

            

            if (exito)
                MessageBox.Show("Persona actualizada correctamente.");
            else
                MessageBox.Show("No se pudo actualizar la persona.");


            this.Close();

            //Formulario agregar = new Formulario();
            //agregar.Show();
            //this.Close();
        }





        private void txtedad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
