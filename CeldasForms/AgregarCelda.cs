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

namespace CECOT_PROYECT.CeldasForms
{
    public partial class AgregarCelda : Form
    {

        string connectionString = @"Server=CRIS;Database=ProyectoCarcelario;Trusted_Connection=True;";
        public AgregarCelda()
        {

            InitializeComponent();
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
            if (cmbCelda.SelectedValue != null)
            {
                int idSeccion = Convert.ToInt32(cmbCelda.SelectedValue);
                int capacidadReos = (int)numCapacidadReos.Value;

                BotonosCeldas botonosCeldas = new BotonosCeldas();

                bool exito = botonosCeldas.CrearCelda(idSeccion, capacidadReos);

                if (exito)
                {
                    MessageBox.Show("Celda agregada correctamente.");
                    // Aquí puedes recargar datos o limpiar campos
                }
                else
                {
                    MessageBox.Show("No se pudo agregar la celda: la sección ya alcanzó su capacidad.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una sección.");
            }
        }


        private void CargarSeccionesEnComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT Id, Nombre, Tipo FROM Secciones";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Crear una nueva columna para mostrar Nombre + Tipo
                dt.Columns.Add("Descripcion", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    row["Descripcion"] = $"{row["Nombre"]} - {row["Tipo"]}";
                }

                cmbCelda.DataSource = dt;
                cmbCelda.DisplayMember = "Descripcion";  // Mostrará "Bloque A - Máxima Seguridad"
                cmbCelda.ValueMember = "Id";             // El valor que usarás internamente
            }
        }


        private void AgregarCeldascs_Load(object sender, EventArgs e)
        {
            CargarSeccionesEnComboBox();
        }
    }
}
