using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CECOT_PROYECT.Resources;

namespace CECOT_PROYECT.AdministradoresForms
{
    public partial class EditarAdmin : Form
    {
        private string rutaImagenSeleccionada = "";

        private AdministradoresCRUD CentroControlAdmin;
        private int Editar = -1;
        private bool Edicion = false;
        private Administradores administrador;
        private int fila;

        public EditarAdmin(AdministradoresCRUD admin)
        {
            InitializeComponent();
            CentroControlAdmin = admin;
        }

        public EditarAdmin(AdministradoresCRUD admin, string AdministradorID, string Nombre, string Apellido, string Dui, DateTime FechaNacimiento, string Genero, string Telefono, string Email, DateTime FechaIngreso, string Cargo, string Departamento, string FotoPath, int fila)
        {
            InitializeComponent();
            CentroControlAdmin = admin;
            Edicion = true;
            Editar = fila;

            txtAdminId.Text = AdministradorID;
            txtAdminName.Text = Nombre;
            txtAdminApellido.Text = Apellido;
            txtAdminDui.Text = Dui;
            DateAdminBirth.Value = FechaNacimiento;
            ComboAdminGenero.SelectedItem = Genero;
            txtAdminTel.Text = Telefono;
            txtAdminEmail.Text = Email;
            DateAdminIngreso.Value = FechaIngreso;
            ComboAdminCargo.SelectedItem = Cargo;
            ComboAdminDep.SelectedItem = Departamento;

            txtAdminId.Enabled = false;

            if (!string.IsNullOrEmpty(FotoPath) && File.Exists(FotoPath))
            {
                EditarPicture.Image = Image.FromFile(FotoPath);
                EditarPicture.SizeMode = PictureBoxSizeMode.Zoom;
                rutaImagenSeleccionada = FotoPath;
            }
        }

        public EditarAdmin(AdministradoresCRUD admin, Administradores administrador, int fila) : this(admin)
        {
            this.administrador = administrador;
            this.fila = fila;
        }

        public EditarAdmin()
        {
            InitializeComponent();
        }

        private void Regresar_MouseEnter(object sender, EventArgs e)
        {
           Regresar.Size = new Size(Regresar.Width + 5,Regresar.Height + 5);
           Regresar.BackColor = Color.DimGray;
           Regresar.ForeColor = Color.White;
           Regresar.FlatAppearance.BorderColor = Color.White;
        }

        private void Regresar_MouseLeave(object sender, EventArgs e)
        {
           Regresar.Size = new Size(Regresar.Width - 5,Regresar.Height - 5);
           Regresar.BackColor = Color.White;
           Regresar.ForeColor = Color.Black;
           Regresar.FlatAppearance.BorderColor = Color.DimGray;
        }


        private void Regresar_Click(object sender, EventArgs e)
        {
            AdministradoresCRUD administradoresCRUD = new AdministradoresCRUD();
            administradoresCRUD.Show();
            this.Hide();
        }

        private void EditarAdminGuardar_MouseEnter(object sender, EventArgs e)
        {
            EditarAdminGuardar.Size = new Size(EditarAdminGuardar.Width + 5, EditarAdminGuardar.Height + 5);
            EditarAdminGuardar.BackColor = Color.DimGray;
            EditarAdminGuardar.ForeColor = Color.White;
            EditarAdminGuardar.FlatAppearance.BorderColor = Color.White;
        }

        private void EditarAdminGuardar_MouseLeave(object sender, EventArgs e)
        {
            EditarAdminGuardar.Size = new Size(EditarAdminGuardar.Width - 5, EditarAdminGuardar.Height - 5);
            EditarAdminGuardar.BackColor = Color.White;
            EditarAdminGuardar.ForeColor = Color.Black;
            EditarAdminGuardar.FlatAppearance.BorderColor = Color.DimGray;
        }


        private void EditarAdminGuardar_Click(object sender, EventArgs e)
        {
            Administradores admin = new Administradores
            {
                AdministradorID = int.Parse(txtAdminId.Text),
                Nombre = txtAdminName.Text,
                Apellido = txtAdminApellido.Text,
                Dui = txtAdminDui.Text,
                FechaNacimiento = DateAdminBirth.Value,
                Género = (ComboAdminGenero.SelectedItem).ToString(),
                Telefono = txtAdminTel.Text,
                Email = txtAdminEmail.Text,
                FechaIngreso = DateAdminIngreso.Value, // o dtpFechaIngreso.Value si usas DateTimePicker
                Cargo = (ComboAdminCargo.SelectedItem).ToString(),
                Departamento = (ComboAdminDep.SelectedItem).ToString(),
                FotoPath = rutaImagenSeleccionada
            };

          


            bool exito = AdministradoresAgregar.ActualizarAdministrador(admin);

            if (Edicion && Editar != -1)
            {
                CentroControlAdmin.EditarFila(Editar, admin);
            }



            if (exito)
                MessageBox.Show("Administrador actualizado correctamente.");
            else
                MessageBox.Show("No se pudo actualizar el administrador.");


            this.Close();
        }

        private void EditarImagenBoton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                ofd.Title = "Selecciona una imagen";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rutaImagenSeleccionada = ofd.FileName;
                    EditarPicture.Image = Image.FromFile(rutaImagenSeleccionada);
                    EditarPicture.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
    }
}
