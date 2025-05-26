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

            // Establecer el orden de las columnas manualmente
            dataGridView1.Columns["Id"].DisplayIndex = 0;
            dataGridView1.Columns["Nombre"].DisplayIndex = 1;
            dataGridView1.Columns["Edad"].DisplayIndex = 2;
            dataGridView1.Columns["DUI"].DisplayIndex = 3;
            dataGridView1.Columns["Delito"].DisplayIndex = 4;
            dataGridView1.Columns["Sentencia"].DisplayIndex = 5;
            dataGridView1.Columns["FechaIngreso"].DisplayIndex = 6;
            dataGridView1.Columns["IdCelda"].DisplayIndex = 7;
            dataGridView1.Columns["TipoCelda"].DisplayIndex = 8;
            


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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

                EditarForm editar = new EditarForm(reo.Id); // ✅ Le pasas el ID
                editar.ShowDialog(); // También puedes usar ShowDialog() para bloquear la ventana anterior hasta cerrar esta
                 
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
                listaOriginal = cecotAgregar.PresentarRegistros();
                dataGridView1.DataSource = listaOriginal;
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

        private void Regresar_Click_1(object sender, EventArgs e)
        {
            MenuOpciones menu = new MenuOpciones();
            menu.Show();
            this.Close();
        }
    }
}

