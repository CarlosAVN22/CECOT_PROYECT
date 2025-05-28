using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CECOT_PROYECT.CeldasForms;
using CECOT_PROYECT.Resources;
using iTextSharp.text.pdf;
using iTextSharp.text;

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

            dataGridView1.Columns["FotoPath"].Visible = false;


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

            if (Sesion.UsuarioActual.Cargo == "Supervisor" || Sesion.UsuarioActual.Cargo == "Editor")
            {
                AgregarForm agregar = new AgregarForm();
                agregar.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Acceso Denenegado no tienes permisos para acceder a este CRUD");
            }

        }

        private void Editar_Click(object sender, EventArgs e)
        {

            if (Sesion.UsuarioActual.Cargo == "Supervisor" || Sesion.UsuarioActual.Cargo == "Editor")
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int fila = dataGridView1.CurrentRow.Index;
                    Cecot reo = (Cecot)dataGridView1.Rows[fila].DataBoundItem;

                    EditarForm editar = new EditarForm(reo.Id);
                    editar.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Seleccione un reo para editar.");
                }
            }
            else
            {
                MessageBox.Show("Acceso Denenegado no tienes permisos para acceder a esta Opcion");
            }

        }


        private void Eliminar_Click(object sender, EventArgs e)
        {

            if (Sesion.UsuarioActual.Cargo == "Supervisor" || Sesion.UsuarioActual.Cargo == "Editor")
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
            else
            {
                MessageBox.Show("Acceso Denenegado no tienes permisos para acceder a esta Opcion");
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
                (c.DUI != null && c.DUI.ToLower().Contains(texto)) ||
                (c.Delito != null && c.Delito.ToLower().Contains(texto)) ||
                (c.Sentencia != null && c.Sentencia.ToLower().Contains(texto)) ||
                (c.FechaIngreso != null && c.FechaIngreso.ToLower().Contains(texto)) ||
                (c.TipoCelda != null && c.TipoCelda.ToLower().Contains(texto))
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

        private void btnPdf_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4);
            SaveFileDialog save = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Guardar PDF",
                FileName = "ReosExport.pdf"
            };

            if (save.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using (FileStream stream = new FileStream(save.FileName, FileMode.Create))
                {
                    PdfWriter.GetInstance(doc, stream);
                    doc.Open();

                    // Definir columnas que quieres exportar, excluyendo "FotoPath"
                    var columnasAExportar = dataGridView1.Columns
                        .Cast<DataGridViewColumn>()
                        .Where(c => c.Name != "FotoPath")  // excluye FotoPath
                        .ToList();

                    PdfPTable pdfTable = new PdfPTable(columnasAExportar.Count);

                    // Encabezados
                    foreach (var column in columnasAExportar)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText))
                        {
                            BackgroundColor = BaseColor.LIGHT_GRAY
                        };
                        pdfTable.AddCell(cell);
                    }

                    // Datos
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        foreach (var column in columnasAExportar)
                        {
                            string texto = row.Cells[column.Index].Value?.ToString() ?? "";
                            pdfTable.AddCell(texto);
                        }
                    }

                    doc.Add(pdfTable);
                    doc.Close();
                }

                System.Diagnostics.Process.Start(save.FileName);
                MessageBox.Show("PDF generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF: " + ex.Message);
            }
        }



    }
}

