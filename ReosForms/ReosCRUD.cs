using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CECOT_PROYECT.CeldasForms;
using CECOT_PROYECT.Resources;

namespace CECOT_PROYECT
{
    public partial class ReosCRUD : Form
    {
        List<Cecot> listaOriginal = new List<Cecot>();

        public ReosCRUD()
        {
            InitializeComponent();
        }

        private void ReosCRUD_Load(object sender, EventArgs e)
        {
            listaOriginal = cecotAgregar.PresentarRegistros();
            dataGridView1.DataSource = listaOriginal;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public void AgregarFila(string id, string nombre, string edad, string dui, string sentencia,
                                string fechaIngreso, string celda, string seccion, string tipoSeccion)
        {
            dataGridView1.Rows.Add(id, nombre, edad, dui, sentencia, fechaIngreso, celda, seccion, tipoSeccion);
        }

        public void EditarFila(int fila, Cecot persona)
        {
            dataGridView1.Rows[fila].Cells["Nombre"].Value = persona.Nombre;
            dataGridView1.Rows[fila].Cells["Edad"].Value = persona.Edad;
            dataGridView1.Rows[fila].Cells["DUI"].Value = persona.DUI;
            dataGridView1.Rows[fila].Cells["FechaIngreso"].Value = persona.FechaIngreso;
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            AgregarForm agregar = new AgregarForm();
            agregar.Show();
            this.Close();
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int fila = dataGridView1.CurrentRow.Index;
                Cecot reo = (Cecot)dataGridView1.Rows[fila].DataBoundItem;

                EditarForm editar = new EditarForm(this, reo, fila);
                editar.Show();
            }
            else
            {
                MessageBox.Show("Seleccione un reo para editar.");
            }
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
                    MessageBox.Show("Reo eliminado correctamente.");
                    listaOriginal = cecotAgregar.PresentarRegistros();
                    dataGridView1.DataSource = listaOriginal;
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar.");
                }
            }
        }

        private void Visualizar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int fila = dataGridView1.CurrentRow.Index;
                Cecot reo = (Cecot)dataGridView1.Rows[fila].DataBoundItem;

                Mostrar mostrar = new Mostrar(this, reo, fila);
                mostrar.Show();
            }
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            string texto = txtbuscar.Text.ToLower();

            if (string.IsNullOrWhiteSpace(texto))
            {
                dataGridView1.DataSource = listaOriginal;
                return;
            }

            var resultados = listaOriginal.Where(c =>
                c.Id.ToString().Contains(texto) ||
                (c.Nombre != null && c.Nombre.ToLower().Contains(texto)) ||
                (c.Edad != null && c.Edad.ToLower().Contains(texto)) ||
                (c.FechaIngreso != null && c.FechaIngreso.ToLower().Contains(texto)) ||
                (c.DUI != null && c.DUI.ToLower().Contains(texto))
            ).ToList();

            dataGridView1.DataSource = resultados;
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            MenuOpciones menu = new MenuOpciones();
            menu.Show();
            this.Hide();
        }

        // Efectos visuales (puedes mantener los tuyos)
        private void Boton_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Size = new Size(btn.Width + 5, btn.Height + 5);
            btn.BackColor = Color.DimGray;
            btn.ForeColor = Color.White;
            btn.FlatAppearance.BorderColor = Color.White;
        }

        private void Boton_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Size = new Size(btn.Width - 5, btn.Height - 5);
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.FlatAppearance.BorderColor = Color.DimGray;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ReosCRUD_Load_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cecotAgregar.PresentarRegistros();
        }
    }
}

