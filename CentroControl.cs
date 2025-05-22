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
    public partial class CentroControl : Form
    {
        List<Cecot> listaOriginal = new List<Cecot>();
        public CentroControl()
        {
            InitializeComponent();
        }

        private void Buscar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cecotAgregar.PresentarRegistros();
        }

        public void AgregarFila(string ID, string Nombre, string Celda, string Edad, string DUI, string Cargos, string Ingreso)
        {
            dataGridView1.Rows.Add(ID, Nombre, Celda, Edad, DUI, Cargos, Ingreso);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public void EditarFila(int fila,Cecot persona)
        {
            dataGridView1.Rows[fila].Cells[1].Value = persona.Nombre;
            dataGridView1.Rows[fila].Cells[2].Value = persona.Celda;
            dataGridView1.Rows[fila].Cells[3].Value = persona.Edad;
            dataGridView1.Rows[fila].Cells[4].Value = persona.Dui;
            dataGridView1.Rows[fila].Cells[5].Value = persona.Cargos;
            dataGridView1.Rows[fila].Cells[6].Value = persona.FechaIngreso;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            Formulario agregar = new Formulario();
            agregar.Show();
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
            MenuOpciones menu= new MenuOpciones();
            menu.Show();
            this.Hide();
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int filaSeleccionada = dataGridView1.CurrentRow.Index;

                string ID = dataGridView1.Rows[filaSeleccionada].Cells[0].Value.ToString();
                string Nombre = dataGridView1.Rows[filaSeleccionada].Cells[1].Value.ToString();
                string Celda = dataGridView1.Rows[filaSeleccionada].Cells[2].Value.ToString();
                string Edad = dataGridView1.Rows[filaSeleccionada].Cells[3].Value.ToString();
                string DUI = dataGridView1.Rows[filaSeleccionada].Cells[4].Value.ToString();
                string Cargos = dataGridView1.Rows[filaSeleccionada].Cells[5].Value.ToString();
                string Ingreso = dataGridView1.Rows[filaSeleccionada].Cells[6].Value.ToString();

                EditarForm editar = new EditarForm(this, ID, Nombre, Celda, Edad, DUI, Cargos, Ingreso, filaSeleccionada);
                editar.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un reo para editar.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Visualizar_Click(object sender, EventArgs e)
        {

            int filaSeleccionada= dataGridView1.CurrentRow.Index;

            string Id = dataGridView1.Rows[filaSeleccionada].Cells[0].Value.ToString();
            string nombre = dataGridView1.Rows[filaSeleccionada].Cells[1].Value.ToString();
            string  edad= dataGridView1.Rows[filaSeleccionada].Cells[2].Value.ToString();
            string celda = dataGridView1.Rows[filaSeleccionada].Cells[3].Value.ToString();
            string dui = dataGridView1.Rows[filaSeleccionada].Cells[4].Value.ToString();
            string cargo = dataGridView1.Rows[filaSeleccionada].Cells[5].Value.ToString();
            string fechaIngreso = dataGridView1.Rows[filaSeleccionada].Cells[6].Value.ToString();
            Mostrar irMostar = new Mostrar(this,Id,nombre,edad,celda,dui,cargo,fechaIngreso,filaSeleccionada);
            irMostar.Show();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un reo para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Estás seguro de eliminar este reo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                int idReo = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                bool eliminado = cecotAgregar.EliminarRegistro(idReo);

                if (eliminado)
                {
                    MessageBox.Show("Reo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listaOriginal = cecotAgregar.PresentarRegistros();
                    dataGridView1.DataSource = listaOriginal;
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
