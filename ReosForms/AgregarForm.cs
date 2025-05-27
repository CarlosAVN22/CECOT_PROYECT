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

        private string rutaImagenSeleccionada = "";
        public AgregarForm()
        {
            InitializeComponent();
        }

        private void AgregarForm_Load(object sender, EventArgs e)
        {
            txtid.ReadOnly = true;
            CargarTiposDeCelda();
            CargarCeldasDisponibles();


            
        }

        private void CargarCeldasDisponibles()
        {
            using (SqlConnection conn = conexionBD.ObtenerConexion())
            {
                string query = @"
                    SELECT 
                        C.Id, 
                        'Celda ' + CAST(C.Id AS VARCHAR) +' - ' +'Bloque ' + CAST(S.Id AS VARCHAR)+' - ' + S.Tipo AS Descripcion
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

        private void CargarTiposDeCelda()
        {
            using (SqlConnection conn = conexionBD.ObtenerConexion())
            {
                string query = "SELECT DISTINCT Tipo FROM Secciones";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbTipoCelda.DataSource = dt;
                cmbTipoCelda.DisplayMember = "Tipo";
                cmbTipoCelda.ValueMember = "Tipo";
            }
        }

        private void CargarCeldasPorTipo(string tipoCelda)
        {
            using (SqlConnection conn = conexionBD.ObtenerConexion())
            {
                string query = @"
            SELECT 
                C.Id, 
                'Celda ' + CAST(C.Id AS VARCHAR) + ' - Bloque ' + CAST(S.Id AS VARCHAR) AS Descripcion
            FROM Celdas C
            INNER JOIN Secciones S ON C.IdSeccion = S.Id
            WHERE C.ReosActuales < C.CapacidadReos AND S.Tipo = @Tipo";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@Tipo", tipoCelda);
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
                Delito = txtcargos.Text.Trim(),
                Sentencia = ((int)sentenciaNum.Value).ToString(),
                IdCelda = Convert.ToInt32(cmbCelda.SelectedValue),
                FechaIngreso = dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                FotoPath = rutaImagenSeleccionada,


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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }


        private void cmbTipoCelda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoCelda.SelectedValue != null)
            {
                string tipoSeleccionado = cmbTipoCelda.SelectedValue.ToString();
                CargarCeldasPorTipo(tipoSeleccionado);
            }
        }

        private void fotoReo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                ofd.Title = "Selecciona una imagen";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rutaImagenSeleccionada = ofd.FileName;
                    reoFoto.Image = Image.FromFile(rutaImagenSeleccionada);
                    reoFoto.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
    }
}
