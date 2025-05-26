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
using CECOT_PROYECT.TrabajadoresForms;

namespace CECOT_PROYECT
{
    public partial class TrabajadoresCRUD : Form
    {
        public TrabajadoresCRUD()
        {
            InitializeComponent();
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TrabajadoresAgregar.PresentarRegistros();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            TrabajadoresMostrar trabajadoresMostrar = new TrabajadoresMostrar();
            trabajadoresMostrar.Show();
            this.Hide();
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
            if (dataGridView1.CurrentRow != null)
            {
                string id = dataGridView1.CurrentRow.Cells["TrabajadorID"].Value.ToString();
                string nombre = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                string apellido = dataGridView1.CurrentRow.Cells["Apellido"].Value.ToString();
                string dui = dataGridView1.CurrentRow.Cells["DUI"].Value.ToString();
                DateTime fechaNacimiento = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["FechaNacimiento"].Value);
                string genero = dataGridView1.CurrentRow.Cells["Género"].Value.ToString();
                string telefono = dataGridView1.CurrentRow.Cells["Telefono"].Value.ToString();
                string email = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
                DateTime fechaIngreso = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["FechaIngreso"].Value);
                string cargo = dataGridView1.CurrentRow.Cells["Cargo"].Value.ToString();
                string departamento = dataGridView1.CurrentRow.Cells["Departamento"].Value.ToString();
                string rutaimagen = dataGridView1.CurrentRow.Cells["FotoPath"].Value.ToString();

                // Abrir formulario de edición
                TrabajadoresEditar editarForm = new TrabajadoresEditar(id, nombre, apellido, fechaNacimiento, genero, dui, telefono, email, fechaIngreso, cargo, departamento,rutaimagen);
                editarForm.ShowDialog();

                // Refrescar la grilla después de editar
                dataGridView1.DataSource = TrabajadoresAgregar.PresentarRegistros();
            }

            else
            {
                MessageBox.Show("Seleccione un trabajador para editar.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void Visualizar_Click(object sender, EventArgs e)
        {
           

            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.DataSource = TrabajadoresAgregar.PresentarRegistros();

            }
            else
            {
                MessageBox.Show("Seleccione un trabajador para visualizar.");
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string dui = dataGridView1.CurrentRow.Cells["DUI"].Value.ToString();

                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este trabajador?", "Confirmar eliminación", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    int eliminado = TrabajadoresAgregar.EliminarTrabajador(dui);

                    if (eliminado > 0)
                    {
                        MessageBox.Show("Trabajador eliminado correctamente.");
                        dataGridView1.DataSource = TrabajadoresAgregar.PresentarRegistros(); // refresca la tabla
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar trabajador.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un trabajador para eliminar.");
            }
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            MenuOpciones menuOpciones = new MenuOpciones();
            menuOpciones.Show();
            this.Hide();
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
    }
}
