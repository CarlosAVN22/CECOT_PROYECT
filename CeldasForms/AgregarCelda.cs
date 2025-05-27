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
using CECOT_PROYECT.Resources;

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

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (cmbSeccion.SelectedValue != null)
            {
                int idSeccion = Convert.ToInt32(cmbSeccion.SelectedValue);
                int capacidadReos = (int)numCapacidadReos.Value;

                BotonosCeldas botonosCeldas = new BotonosCeldas();

                bool exito = botonosCeldas.CrearCelda(idSeccion, capacidadReos);

                if (exito)
                {
                    MessageBox.Show("Celda agregada correctamente.");
                    CeldasCRUD celdasCRUD = new CeldasCRUD();
                    celdasCRUD.Show();
                    this.Close();
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

                cmbSeccion.DataSource = dt;
                cmbSeccion.DisplayMember = "Descripcion";  
                cmbSeccion.ValueMember = "Id";             
            }
        }

        private void cmbTipoCelda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoCelda.SelectedItem != null)
            {
                string tipoSeleccionado = cmbTipoCelda.SelectedItem.ToString();
                CargarSeccionesPorTipo(tipoSeleccionado);
            }
        }

        private void CargarSeccionesPorTipo(string tipoCelda)
        {
            using (SqlConnection conn = conexionBD.ObtenerConexion())
            {
                string query = @"
                                SELECT 
                                S.Id, 
                                'Seccion ' + CAST(S.Id AS VARCHAR(10)) + ' - ' + S.Tipo AS Descripcion
                            FROM Secciones S                      
                            WHERE S.Tipo=@Tipo";


                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@Tipo", tipoCelda);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbSeccion.DataSource = dt;
                cmbSeccion.DisplayMember = "Descripcion";
                cmbSeccion.ValueMember = "Id";
            }
        }




        private void AgregarCeldascs_Load(object sender, EventArgs e)
        {


        }

        private void cmbSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
