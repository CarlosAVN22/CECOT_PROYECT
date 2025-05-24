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

namespace CECOT_PROYECT.SeccionesForms
{
    public partial class AgregarSeccion : Form
    {

        string connectionString = @"Server=CRIS;Database=ProyectoCarcelario;Trusted_Connection=True;";
        public AgregarSeccion()
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
            string nombre = txtNombre.Text.Trim();
            string tipo = cmbSeccion.Text;
            int capacidadCeldas = (int)numCapacidadCelda.Value;

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Ingrese un nombre para la sección.");
                return;
            }

            if (capacidadCeldas <= 0)
            {
                MessageBox.Show("La capacidad debe ser mayor que cero.");
                return;
            }

            BotonesSecciones botonesSecciones = new BotonesSecciones();
            bool exito = botonesSecciones.CrearSeccion(nombre, tipo, capacidadCeldas);

            if (exito)
            {
                MessageBox.Show("Sección agregada correctamente.");
                txtNombre.Clear();
                numCapacidadCelda.Value = 1;
                cmbSeccion.SelectedIndex = 0;

                SeccionesCRUD CRUDsecciones = new SeccionesCRUD();
                CRUDsecciones.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo agregar la sección.");
            }
        }


        private void CargarSeccionesEnComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT Id, Nombre FROM Secciones";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbSeccion.DataSource = dt;
                cmbSeccion.DisplayMember = "Nombre";  // Lo que se muestra en la lista
                cmbSeccion.ValueMember = "Id";        // El valor interno que usarás
            }
        }

        private void AgregarSeccion_Load(object sender, EventArgs e)
        {
            cmbSeccion.Items.Add("Máxima Seguridad");
            cmbSeccion.Items.Add("Común");
            cmbSeccion.Items.Add("Aislamiento");
            cmbSeccion.SelectedIndex = 0;
        }
    }
}
