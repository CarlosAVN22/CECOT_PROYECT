using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CECOT_PROYECT.Resources;

namespace CECOT_PROYECT.TrabajadoresForms
{
    public partial class TrabajadoresMostrar : Form
    {
        private string rutaImagenSeleccionada = "";

        public TrabajadoresMostrar()
        {
            InitializeComponent();

        }
        private string trabajadorID = null;
        public TrabajadoresMostrar(string id, string nombre, string apellido, DateTime fechaNacimiento, string genero, string dui, string telefono, string email, DateTime fechaIngreso, string cargo, string departamento)
        {
            InitializeComponent();

            // Llenar campos
            txtnombre.Text = nombre;
            txtapellido.Text = apellido;
            txtdui.Text = dui;
            txtgenero.Text = genero;
            txttelefono.Text = telefono;
            txtemail.Text = email;
            // Validar fecha de nacimiento
            if (fechaNacimiento >= fechanacimiento.MinDate && fechaNacimiento <= fechanacimiento.MaxDate)
            {
                fechanacimiento.Value = fechaNacimiento;
            }
            else
            {
                fechanacimiento.Value = DateTime.Today; // O cualquier valor seguro por defecto
            }

            // Validar fecha de ingreso
            if (fechaIngreso >= fechaingreso.MinDate && fechaIngreso <= fechaingreso.MaxDate)
            {
                fechaingreso.Value = fechaIngreso;
            }
            else
            {
                fechaingreso.Value = DateTime.Today;
            }

            comboCargo.Text = cargo;
            comboDepartamento.Text = departamento;

            // Bloquear edición de ID/DUI
            txtdui.Enabled = false;
            txtgenero.Enabled = false;
            btn_guardar.Text = "Guardar cambios";
        }


        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TrabajadoresCRUD trabajadoresCRUD = new TrabajadoresCRUD();
            trabajadoresCRUD.Show();
            this.Hide();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            Trabajadores trabajador = new Trabajadores();
            trabajador.Nombre = txtnombre.Text;
            trabajador.Apellido = txtapellido.Text;
            trabajador.DUI = txtdui.Text;
            trabajador.FechaNacimiento = DateTime.Parse(fechanacimiento.Text);
            trabajador.Género = txtgenero.Text;
            trabajador.Telefono = txttelefono.Text;
            trabajador.Email = txtemail.Text;
            trabajador.FechaIngreso = DateTime.Parse(fechaingreso.Text);
            trabajador.Cargo = comboCargo.Text;
            trabajador.Departamento = comboDepartamento.Text;
            trabajador.FotoPath = rutaImagenSeleccionada;

            int result = TrabajadoresAgregar.AgregarTrabajador(trabajador);

            if (result > 0)
            {
                MessageBox.Show("Trabajador agregado correctamente");
                TrabajadoresCRUD agregar = new TrabajadoresCRUD();
                agregar.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al agregar trabajador");
            }
        }

        private void AñadirFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Seleccionar imagen";
                ofd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rutaImagenSeleccionada = ofd.FileName;
                    pictureBox2.Image = Image.FromFile(rutaImagenSeleccionada);
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom; // Para ajustar la imagen


                }
            }
        }
        private void GuardarRutaImagenEnBD(string rutaImagen, int idInterno)
        {
            string connectionString = @"Data Source=AFANEE;Initial Catalog=ProyectoCarcelario;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Trabajadores SET FotoPath = @FotoPath WHERE TrabajadorID = @TrabajadorID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FotoPath", rutaImagen);
                    cmd.Parameters.AddWithValue("@TrabajadorID", idInterno);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private void txtdui_TextChanged(object sender, EventArgs e)
        {

        }

        private void TrabajadoresMostrar_Load(object sender, EventArgs e)
        {

        }
    }
}
