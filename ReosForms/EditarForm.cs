using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CECOT_PROYECT.Resources;

namespace CECOT_PROYECT
{
    public partial class EditarForm : Form
    {
        public int IdReo { get; set; } // ID del reo a editar

        public EditarForm(int idReo)
        {
            InitializeComponent();
            IdReo = idReo;
        }

        private void EditarForm_Load(object sender, EventArgs e)
        {
            txtid.ReadOnly = true;
            txtcargos.ReadOnly = true;

            CargarDatosDelReo();
            CargarTiposDeCelda();
            CargarCeldasDisponibles();
            
        }

        private void CargarDatosDelReo()
        {
            using (SqlConnection conn = conexionBD.ObtenerConexion())
            {
               
                string query = "SELECT Nombre, Edad, DUI, Delito, Sentencia, IdCelda, FechaIngreso FROM Reos WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", IdReo);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtnombre.Text = reader["Nombre"].ToString();
                            txtedad.Text = reader["Edad"].ToString();
                            txtdui.Text = reader["DUI"].ToString();
                            txtcargos.Text = reader["Delito"].ToString();
                            sentenciaNum.Value = Convert.ToInt32(reader["Sentencia"]);
                            dateTimePicker1.Value = Convert.ToDateTime(reader["FechaIngreso"]);
                            cmbCelda.SelectedValue = Convert.ToInt32(reader["IdCelda"]);
                        }
                    }
                }
            }
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

            try
            {
                using (SqlConnection conn = conexionBD.ObtenerConexion())
                {
                  

                    int celdaAnterior = 0;
                    string celdaQuery = "SELECT IdCelda FROM Reos WHERE Id = @IdReo";
                    using (SqlCommand cmdCelda = new SqlCommand(celdaQuery, conn))
                    {
                        cmdCelda.Parameters.AddWithValue("@IdReo", IdReo);
                        celdaAnterior = Convert.ToInt32(cmdCelda.ExecuteScalar());
                    }

                    string updateQuery = @"UPDATE Reos 
                                           SET Nombre = @Nombre, Edad = @Edad, DUI = @DUI, Delito = @Delito, 
                                               Sentencia = @Sentencia, FechaIngreso = @Fecha, IdCelda = @IdCelda
                                           WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", txtnombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@Edad", txtedad.Text.Trim());
                        cmd.Parameters.AddWithValue("@DUI", txtdui.Text.Trim());
                        cmd.Parameters.AddWithValue("@Delito", txtcargos.Text.Trim());
                        cmd.Parameters.AddWithValue("@Sentencia", sentenciaNum.Value);
                        cmd.Parameters.AddWithValue("@Fecha", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@IdCelda", cmbCelda.SelectedValue);
                        cmd.Parameters.AddWithValue("@Id", IdReo);

                        cmd.ExecuteNonQuery();
                    }

                    int celdaNueva = Convert.ToInt32(cmbCelda.SelectedValue);
                    if (celdaAnterior != celdaNueva)
                    {
                        using (SqlCommand cmdUpdate = new SqlCommand("UPDATE Celdas SET ReosActuales = ReosActuales - 1 WHERE Id = @Id", conn))
                        {
                            cmdUpdate.Parameters.AddWithValue("@Id", celdaAnterior);
                            cmdUpdate.ExecuteNonQuery();
                        }
                        using (SqlCommand cmdUpdate = new SqlCommand("UPDATE Celdas SET ReosActuales = ReosActuales + 1 WHERE Id = @Id", conn))
                        {
                            cmdUpdate.Parameters.AddWithValue("@Id", celdaNueva);
                            cmdUpdate.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Reo actualizado correctamente.");
                    this.Close();
                    new ReosCRUD().Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar reo: " + ex.Message);
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

        private void cmbTipoCelda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoCelda.SelectedValue != null)
            {
                string tipoSeleccionado = cmbTipoCelda.SelectedValue.ToString();
                CargarCeldasPorTipo(tipoSeleccionado);
            }
        }
    }
}

