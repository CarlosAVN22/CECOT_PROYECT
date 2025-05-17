using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CECOT_PROYECT.Resources;

namespace CECOT_PROYECT
{
    public partial class Formulario : Form
    {
        public Formulario()
        {
            InitializeComponent();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            Cecot persona = new Cecot();
            persona.Id = Convert.ToInt32(txtid.Text);
            persona.Nombre = txtnombre.Text;
            persona.Celda = txtcelda.Text;
            persona.Edad = txtedad.Text;
            persona.Dui = txtdui.Text;
            persona.Cargos = txtcargos.Text;
            persona.FechaIngreso = txtfechaIngreso.Text;

            int result = cecotAgregar.AgregarPersona(persona);

            if (result > 0)
            {
                MessageBox.Show("Persona agregada correctamente");
                CentroControl agregar = new CentroControl();
                agregar.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al agregar la persona");
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            CentroControl cerrar = new CentroControl();
            cerrar.Show();
            this.Close();
        }
    }
}
