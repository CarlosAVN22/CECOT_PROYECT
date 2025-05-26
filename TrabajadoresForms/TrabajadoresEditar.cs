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
using System.IO;

namespace CECOT_PROYECT.TrabajadoresForms
{
    public partial class TrabajadoresEditar : Form
    {
        string idTrabajador;
        string rutaimagen;

        public TrabajadoresEditar(string id, string nombre, string apellido, DateTime fechaNacimiento, string genero, string dui, string telefono, string email, DateTime fechaIngreso, string cargo, string departamento,string ruta)
        {
            InitializeComponent();
            idTrabajador = id;

            txtnombre.Text = nombre;
            txtapellido.Text = apellido;
            txtdui.Text = dui;
            txtdui.Enabled = false; // DUI no editable
            txtgenero.Text = genero;
            txtgenero.Enabled = false; // Género no editable
            fechanacimiento.Value = fechaNacimiento;
            txttelefono.Text = telefono;
            txtemail.Text = email;
            fechaingreso.Value = fechaIngreso;
            comboCargo.Text = cargo;
            comboDepartamento.Text = departamento;
            rutaimagen = ruta.ToString();

            if (File.Exists(rutaimagen))
            {
                pictureBox2.Image = Image.FromFile(rutaimagen);
            }
            else
            {
                MessageBox.Show("La imagen no se encontró en la ruta especificada.");
                MessageBox.Show(rutaimagen.ToString());
            }
        }


        private void TrabajadoresEditar_Load(object sender, EventArgs e)
        {

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            // VALIDAR CAMPOS VACÍOS
            if (string.IsNullOrWhiteSpace(txtnombre.Text) ||
                string.IsNullOrWhiteSpace(txtapellido.Text) ||
                string.IsNullOrWhiteSpace(txttelefono.Text) ||
                string.IsNullOrWhiteSpace(txtemail.Text) ||
                string.IsNullOrWhiteSpace(comboCargo.Text) ||
                string.IsNullOrWhiteSpace(comboDepartamento.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios antes de guardar.",
                                "Campos Vacíos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // VALIDAR IMAGEN
            if (string.IsNullOrWhiteSpace(rutaimagen) || !File.Exists(rutaimagen))
            {
                MessageBox.Show("Debe seleccionar una imagen válida antes de guardar.",
                                "Imagen Faltante",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // SI TODO ESTÁ COMPLETO, GUARDAR EN BASE DE DATOS
            using (SqlConnection conn = new SqlConnection("Server=CRIS;Database=ProyectoCarcelario;Trusted_Connection=true;"))
            {
                conn.Open();
                string query = @"UPDATE Trabajadores SET 
                            Nombre = @Nombre,
                            Apellido = @Apellido,
                            FechaNacimiento = @FechaNacimiento,
                            Telefono = @Telefono,
                            Email = @Email,
                            FechaIngreso = @FechaIngreso,
                            Cargo = @Cargo,
                            Departamento = @Departamento,
                            FotoPath = @FotoPath   
                         WHERE ID = @ID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", idTrabajador);
                    cmd.Parameters.AddWithValue("@Nombre", txtnombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@Apellido", txtapellido.Text.Trim());
                    cmd.Parameters.AddWithValue("@FechaNacimiento", fechanacimiento.Value);
                    cmd.Parameters.AddWithValue("@Telefono", txttelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtemail.Text.Trim());
                    cmd.Parameters.AddWithValue("@FechaIngreso", fechaingreso.Value);
                    cmd.Parameters.AddWithValue("@Cargo", comboCargo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Departamento", comboDepartamento.Text.Trim());
                    cmd.Parameters.AddWithValue("@FotoPath", rutaimagen);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Trabajador actualizado correctamente.");
                    this.Close();
                }
            }
        }



        private bool CamposCompletos()
        {
            return !(string.IsNullOrWhiteSpace(txtnombre.Text) ||
                     string.IsNullOrWhiteSpace(txtapellido.Text) ||
                     string.IsNullOrWhiteSpace(txttelefono.Text) ||
                     string.IsNullOrWhiteSpace(txtemail.Text) ||
                     string.IsNullOrWhiteSpace(comboCargo.Text) ||
                     string.IsNullOrWhiteSpace(comboDepartamento.Text));
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TrabajadoresCRUD trabajadoresCRUD = new TrabajadoresCRUD();
            trabajadoresCRUD.Show();
            this.Hide();
        }

        private void AñadirFoto_Click(object sender, EventArgs e)
        {

        }
    }
}

