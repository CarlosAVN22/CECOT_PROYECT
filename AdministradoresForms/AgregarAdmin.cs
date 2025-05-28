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
using CECOT_PROYECT.TrabajadoresForms;

namespace CECOT_PROYECT.AdministradoresForms
{
    public partial class AgregarAdmin : Form
    {
        private string rutaImagenSeleccionada = "";

        public AgregarAdmin()
        {
            InitializeComponent();
        }

        public AgregarAdmin(string AdministradorID, string Nombre, string Apellido, DateTime FechaNacimiento, string Genero, string Dui, string Telefono, string Email, DateTime FechaIngreso, string Cargo, string Departamento, string FotoPath)
        {
            InitializeComponent();

            // Llenar campos
            txtAdminName.Text = Nombre;
            txtAdminApellido.Text = Apellido;
            txtAdminDui.Text = Dui;
            ComboAdminGenero.Text = Genero;
            txtAdminTel.Text = Telefono;
            txtAdminEmail.Text = Email;
            // Validar fecha de nacimiento
            if (FechaNacimiento >= DateAdminBirth.MinDate && FechaNacimiento <= DateAdminBirth.MaxDate)
            {
                DateAdminBirth.Value = FechaNacimiento;
            }
            else
            {
                DateAdminBirth.Value = DateTime.Today; // O cualquier valor seguro por defecto
            }

            // Validar fecha de ingreso
            if (FechaIngreso >= DateAdminIngreso.MinDate && FechaIngreso <= DateAdminIngreso.MaxDate)
            {
                DateAdminIngreso.Value = FechaIngreso;
            }
            else
            {
                DateAdminIngreso.Value = DateTime.Today;
            }

            ComboAdminCargo.Text = Cargo;
            ComboAdminDep.Text = Departamento;

            // Bloquear edición de ID/DUI
            txtAdminDui.Enabled = false;
            ComboAdminGenero.Enabled = false;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            AdministradoresCRUD administradoresCRUD = new AdministradoresCRUD();
            administradoresCRUD.Show();
            this.Hide();
        }

        private void AgregarAdminGuardar_Click(object sender, EventArgs e)
        {
            // Validación de campos requeridos
            if (string.IsNullOrWhiteSpace(txtAdminName.Text) ||
                string.IsNullOrWhiteSpace(txtAdminApellido.Text) ||
                string.IsNullOrWhiteSpace(txtAdminDui.Text) ||
                ComboAdminGenero.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtAdminTel.Text) ||
                string.IsNullOrWhiteSpace(txtAdminEmail.Text) ||
                ComboAdminCargo.SelectedItem == null ||
                ComboAdminDep.SelectedItem == null ||
                string.IsNullOrWhiteSpace(rutaImagenSeleccionada))
            {
                MessageBox.Show("Por favor, completa todos los campos antes de continuar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Administradores admin = new Administradores
                {
                    Nombre = txtAdminName.Text,
                    Apellido = txtAdminApellido.Text,
                    Dui = txtAdminDui.Text,
                    FechaNacimiento = DateAdminBirth.Value,
                    Género = ComboAdminGenero.SelectedItem.ToString(),
                    Telefono = txtAdminTel.Text,
                    Email = txtAdminEmail.Text,
                    FechaIngreso = DateAdminIngreso.Value,
                    Cargo = ComboAdminCargo.SelectedItem.ToString(),
                    Departamento = ComboAdminDep.SelectedItem.ToString(),
                    FotoPath = rutaImagenSeleccionada
                };

                int result = AdministradoresAgregar.AgregarAdministrador(admin);

                if (result > 0)
                {
                    MessageBox.Show("Administrador agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RegistrarCrendenciales registro = new RegistrarCrendenciales(admin.Cargo);
                    registro.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al agregar administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado");
            }

        }

        

        private void AgregarImagenBoton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                ofd.Title = "Selecciona una imagen";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rutaImagenSeleccionada = ofd.FileName;
                    AgregarPicture.Image = Image.FromFile(rutaImagenSeleccionada);
                    AgregarPicture.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }

        }

        private void AgregarPicture_Click(object sender, EventArgs e)
        {

        }
    }
}
