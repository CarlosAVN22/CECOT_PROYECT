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
    public partial class AdminVisualizar : Form
    {
        public AdminVisualizar(string nombre, string apellido, DateTime fechaNacimiento, string genero, string dui, string telefono, string email, DateTime fechaIngreso, string cargo, string departamento)
        {
            InitializeComponent();

            txtAdminName.Text = nombre;
            txtAdminApellido.Text = apellido;
            txtAdminDui.Text = dui;
            ComboAdminGenero.Text = genero;
            txtAdminTel.Text = telefono;
            txtAdminEmail.Text = email;
            // Validar fecha de nacimiento
            if (fechaNacimiento >= DateAdminBirth.MinDate && fechaNacimiento <= DateAdminBirth.MaxDate)
            {
                DateAdminBirth.Value = fechaNacimiento;
            }
            else
            {
                DateAdminBirth.Value = DateTime.Today; // O cualquier valor seguro por defecto
            }

            // Validar fecha de ingreso
            if (fechaIngreso >= DateAdminIngreso.MinDate && fechaIngreso <= DateAdminIngreso.MaxDate)
            {
                DateAdminIngreso.Value = fechaIngreso;
            }
            else
            {
                DateAdminIngreso.Value = DateTime.Today;
            }

            ComboAdminCargo.Text = cargo;
            ComboAdminDep.Text = departamento;

            // Desactivar edición
            txtAdminName.ReadOnly = true;
            txtAdminApellido.ReadOnly = true;
            txtAdminDui.ReadOnly = true;
            txtAdminTel.ReadOnly = true;
            txtAdminEmail.ReadOnly = true;
            ComboAdminGenero.Enabled = false;
            DateAdminBirth.Enabled = false;
            DateAdminIngreso.Enabled = false;
            ComboAdminCargo.Enabled = false;
            ComboAdminDep.Enabled = false;
        }

        private void TrabajadoresVisualizar_Load(object sender, EventArgs e)
        {

        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            TrabajadoresCRUD trabajadoresCRUD = new TrabajadoresCRUD();
            trabajadoresCRUD.Show();
            this.Hide();
        }


        /*public AdminVisualizar()
        {
            InitializeComponent();
        }*/

        private void AdminCancelar_Click(object sender, EventArgs e)
        {
            AdministradoresCRUD administradoresCRUD = new AdministradoresCRUD();
            administradoresCRUD.Show();
            this.Hide();
        }
    }
}
