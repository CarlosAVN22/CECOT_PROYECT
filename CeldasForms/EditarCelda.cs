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
using CECOT_PROYECT.SeccionesForms;

namespace CECOT_PROYECT.CeldasForms
{
    public partial class EditarCelda : Form
    {

        string connectionString = @"Server=CRIS;Database=ProyectoCarcelario;Trusted_Connection=True;";

        private int idSeccion;
        private int idCelda;
        private int idSeccionActual;
        public EditarCelda(int idCelda, int idSeccion,string tipo, int capacidad)
        {

            InitializeComponent();



            this.idCelda = idCelda;
            this.idSeccion = idSeccion;
            this.idSeccionActual = idSeccion;

            MessageBox.Show(idSeccion.ToString());


            numCapacidadReos.Value = capacidad;

            

            CargarSeccionesEnComboBox();

            cmbCelda.SelectedValue = idSeccionActual;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            string nuevoTipo = cmbCelda.Text;
            int nuevaCapacidad = (int)numCapacidadReos.Value;

            if (nuevaCapacidad <= 0)
            {
                MessageBox.Show("La capacidad debe ser mayor que cero.");
                return;
            }

            BotonosCeldas botonesCeldas = new BotonosCeldas();
            bool exito = botonesCeldas.EditarCelda(idCelda,idSeccion, nuevoTipo, nuevaCapacidad);

            if (exito)
            {
                MessageBox.Show("Celda editada correctamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo editar la sección.");
            }
        }

        private void CargarSeccionesEnComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT Id, Tipo FROM Secciones";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Crear una nueva columna para mostrar Nombre + Tipo
                dt.Columns.Add("Descripcion", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    row["Descripcion"] = $"Bloque{row["Id"]} - {row["Tipo"]}";
                }

                
                cmbCelda.DataSource = null;
                cmbCelda.DataSource = dt;
                cmbCelda.DisplayMember = "Descripcion";
                cmbCelda.ValueMember = "Id";

            }
        }
    }
}
