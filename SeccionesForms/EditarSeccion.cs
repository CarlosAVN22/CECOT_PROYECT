using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CECOT_PROYECT.SeccionesForms
{
    public partial class EditarSeccion : Form
    {
        private int idSeccion;

        public EditarSeccion(int id, string tipo, int capacidad)
        {
            InitializeComponent();

            idSeccion = id;

            // Llenar combo con opciones fijas
            cmbSeccion.Items.Add("Máxima Seguridad");
            cmbSeccion.Items.Add("Común");
            cmbSeccion.Items.Add("Aislamiento");

            cmbSeccion.SelectedItem = tipo;
            numCapacidadCelda.Value = capacidad;
        }

        private void EditarSeccion_Load(object sender, EventArgs e)
        {
             
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nuevoTipo = cmbSeccion.Text;
            int nuevaCapacidad = (int)numCapacidadCelda.Value;

            if (nuevaCapacidad <= 0)
            {
                MessageBox.Show("La capacidad debe ser mayor que cero.");
                return;
            }

            BotonesSecciones botonesSecciones = new BotonesSecciones();
            bool exito = botonesSecciones.EditarSeccion(idSeccion, nuevoTipo, nuevaCapacidad);

            if (exito)
            {
                MessageBox.Show("Sección actualizada correctamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la sección.");
            }
        }

        private void EditarSeccion_Load_1(object sender, EventArgs e)
        {

        }
    }
}

