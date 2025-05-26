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
using CECOT_PROYECT.SeccionesForms;

namespace CECOT_PROYECT
{
    public partial class SeccionesCRUD : Form
    {
        public SeccionesCRUD()
        {
            InitializeComponent();
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FuncionesSQL.PresentarRegistros();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            AgregarSeccion agregarSeccion = new AgregarSeccion();
            agregarSeccion.Show();
            this.Close();
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
            Actualizar.Size = new Size(Actualizar.Width + 5, Actualizar.Height + 5);
            Actualizar.BackColor = Color.DimGray;
            Actualizar.ForeColor = Color.White;
            Actualizar.FlatAppearance.BorderColor = Color.White;
        }

        private void Visualizar_MouseLeave(object sender, EventArgs e)
        {
            Actualizar.Size = new Size(Actualizar.Width - 5, Actualizar.Height - 5);
            Actualizar.BackColor = Color.White;
            Actualizar.ForeColor = Color.Black;
            Actualizar.FlatAppearance.BorderColor = Color.DimGray;
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
            MenuOpciones menuOpciones = new MenuOpciones();
            menuOpciones.Show();
            this.Hide();
        }

        private void Visualizar_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                string tipo = dataGridView1.CurrentRow.Cells["Tipo"].Value.ToString();
                int capacidad = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CapacidadCeldas"].Value);

                EditarSeccion formEditar = new EditarSeccion(id, tipo, capacidad);
                formEditar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecciona una fila para editar.");
            }
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DialogResult confirmacion = MessageBox.Show(
                    "¿Estás seguro de que deseas eliminar esta sección?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacion == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                    BotonesSecciones botones = new BotonesSecciones();
                    bool eliminado = botones.EliminarSeccion(id);

                    if (eliminado)
                    {
                        MessageBox.Show("Sección eliminada correctamente.");
                        SeccionesCRUD seccionesCRUD = new SeccionesCRUD();
                        
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la sección.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona una fila para eliminar.");
            }
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=FuncionesSQL.PresentarRegistros();
        }
    }
}
