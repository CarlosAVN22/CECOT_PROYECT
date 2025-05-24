using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using CECOT_PROYECT.Resources;

namespace CECOT_PROYECT
{
    public partial class AgregarForm : Form
    {
        public AgregarForm()
        {
            InitializeComponent();
        }

        private void AgregarForm_Load(object sender, EventArgs e)
        {
            txtid.ReadOnly = true;
            CargarCeldasDisponibles();
        }

        private void CargarCeldasDisponibles()
        {
            using (SqlConnection conn = conexionBD.ObtenerConexion())
            {
                string query = @"
                    SELECT 
                        C.Id, 
                        'Celda ' + CAST(C.Id AS VARCHAR) + ' - ' + S.Nombre AS Descripcion
                    FROM Celdas C
                    INNER JOIN Secciones S ON C.IdSeccion = S.Id
                    WHERE C.ReosActuales < C.CapacidadReos";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbCelda.DataSource = dt;
                cmbCelda.DisplayMember = "Descripcion";
                cmbCelda.ValueMember = "Id";
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (cmbCelda.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una celda disponible.");
                return;
            }

            Cecot persona = new Cecot
            {
                Nombre = txtnombre.Text.Trim(),
                Edad = txtedad.Text.Trim(),
                DUI = txtdui.Text.Trim(),
                IdCelda = Convert.ToInt32(cmbCelda.SelectedValue),


                FechaIngreso = dateTimePicker1.Value.ToString("yyyy-MM-dd"),
            };

            int resultado = cecotAgregar.AgregarPersona(persona);

            if (resultado > 0)
            {
                MessageBox.Show("Reo agregado correctamente.");
                this.Close();
                ReosCRUD reosCRUD = new ReosCRUD();
                reosCRUD.Show();
            }
            else
            {
                MessageBox.Show("Error al agregar el reo.");
            }
        }

        private void AumentarReosActuales(int idCelda)
        {
            using (SqlConnection conn = conexionBD.ObtenerConexion())
            {
                string query = "UPDATE Celdas SET ReosActuales = ReosActuales + 1 WHERE Id = @IdCelda";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdCelda", idCelda);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtdui_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == (char)Keys.Back) return;

            string currentText = txtdui.Text;
            if (currentText.Length >= 10) { e.Handled = true; return; }

            if (currentText.Length == 8)
            {
                if (ch != '-') e.Handled = true;
            }
            else if (!char.IsDigit(ch))
            {
                e.Handled = true;
            }
        }

        private void txtedad_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(txtedad.Text, out int edad))
            {
                if (edad < 18)
                {
                    MessageBox.Show("La edad mínima permitida es 18 años.");
                    txtedad.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una edad válida.");
                txtedad.Focus();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > DateTime.Today)
            {
                MessageBox.Show("La fecha de ingreso no puede ser futura.");
                dateTimePicker1.Focus();
            }
        }

        private void txtcelda_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
