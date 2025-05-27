using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CECOT_PROYECT.AdministradoresForms;
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
            dataGridView1.DataSource = AdministradoresAgregar.PresentarRegistros();
            dataGridView1.Columns["FotoPath"].Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            AgregarAdmin agregarAdmin = new AgregarAdmin();
            agregarAdmin.Show();
            this.Hide();
        }

        public void EditarFila(int fila, Administradores admin)
        {
            dataGridView1.Rows[fila].Cells[1].Value = admin.Nombre;
            dataGridView1.Rows[fila].Cells[2].Value = admin.Apellido;
            dataGridView1.Rows[fila].Cells[3].Value = admin.Dui;
            dataGridView1.Rows[fila].Cells[4].Value = admin.FechaNacimiento;
            dataGridView1.Rows[fila].Cells[5].Value = admin.Género;
            dataGridView1.Rows[fila].Cells[6].Value = admin.Telefono;
            dataGridView1.Rows[fila].Cells[7].Value = admin.Email;
            dataGridView1.Rows[fila].Cells[8].Value = admin.FechaIngreso;
            dataGridView1.Rows[fila].Cells[9].Value = admin.Cargo;
            dataGridView1.Rows[fila].Cells[10].Value = admin.Departamento;
            dataGridView1.Rows[fila].Cells[11].Value = admin.FotoPath;
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
            
        }

        private void Visualizar_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Editar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int filaSeleccionada = dataGridView1.CurrentRow.Index;

                string ID = dataGridView1.Rows[filaSeleccionada].Cells[0].Value.ToString();
                string Nombre = dataGridView1.Rows[filaSeleccionada].Cells[1].Value.ToString();
                string Apellido = dataGridView1.Rows[filaSeleccionada].Cells[2].Value.ToString();
                string Dui = dataGridView1.Rows[filaSeleccionada].Cells[3].Value.ToString();
                DateTime FechaNacimiento = DateTime.TryParse(dataGridView1.Rows[filaSeleccionada].Cells[4].Value?.ToString(), out DateTime fn) ? fn : DateTime.MinValue;
                string Género = dataGridView1.Rows[filaSeleccionada].Cells[5].Value.ToString();
                string Telefono = dataGridView1.Rows[filaSeleccionada].Cells[6].Value.ToString();
                string Email = dataGridView1.Rows[filaSeleccionada].Cells[7].Value.ToString();
                DateTime FechaIngreso = DateTime.TryParse(dataGridView1.Rows[filaSeleccionada].Cells[8].Value?.ToString(), out DateTime fi) ? fi : DateTime.MinValue;
                string Cargo = dataGridView1.Rows[filaSeleccionada].Cells[9].Value.ToString();
                string Departamento = dataGridView1.Rows[filaSeleccionada].Cells[10].Value.ToString();
                string FotoPath = dataGridView1.Rows[filaSeleccionada].Cells[11].Value.ToString();

                EditarAdmin editar = new EditarAdmin(this, ID, Nombre, Apellido, Dui, FechaNacimiento, Género, Telefono, Email, FechaIngreso, Cargo, Departamento, FotoPath, filaSeleccionada);
                editar.Show();
            }
            else
            {
                MessageBox.Show("Seleccione un administrador para editar.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Visualizar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.DataSource = AdministradoresAgregar.PresentarRegistros();

            }
            else
            {
                MessageBox.Show("Seleccione un administrador para visualizar.");
            }

        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string dui = dataGridView1.CurrentRow.Cells["Dui"].Value.ToString();

                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este administrador?", "Confirmar eliminación", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    int eliminado = AdministradoresAgregar.EliminarAdministrador(dui);

                    if (eliminado > 0)
                    {
                        MessageBox.Show("Administrador eliminado correctamente.");
                        dataGridView1.DataSource =AdministradoresAgregar.PresentarRegistros(); // refresca la tabla
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar administrador.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un administrador para eliminar.");
            }

        }

        private void btnmin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnmax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            MenuOpciones menuOpciones = new MenuOpciones();
            menuOpciones.Show();
            this.Hide();
        }
    }
}
