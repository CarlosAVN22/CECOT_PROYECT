using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CECOT_PROYECT
{
    public partial class MenuOpciones : Form
    {
        public MenuOpciones()
        {
            InitializeComponent();
        }
        private void MenuOpciones_Load(object sender, EventArgs e)
        {

        }
        
        private void btnvolver_Click(object sender, EventArgs e)
        {
            Login volver = new Login();
            volver.Show();
            this.Hide();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnmax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnmin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnReos_Click(object sender, EventArgs e)
        {
            ReosCRUD reosCRUD = new ReosCRUD();
            reosCRUD.Show();
            this.Hide();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdministradoresCRUD administradoresCRUD = new AdministradoresCRUD();
            administradoresCRUD.Show();
            this.Hide();
        }

        private void btnTrabajadores_Click(object sender, EventArgs e)
        {
            TrabajadoresCRUD trabajadoresCRUD = new TrabajadoresCRUD();
            trabajadoresCRUD.Show();
            this.Hide();
        }

        private void btnSecciones_Click(object sender, EventArgs e)
        {
            SeccionesCRUD seccionesCRUD = new SeccionesCRUD(); 
            seccionesCRUD.Show();
            this.Hide();    
        }

        private void btnCeldas_Click(object sender, EventArgs e)
        {
            CeldasCRUD celdasCRUD = new CeldasCRUD();  
            celdasCRUD.Show();
            this.Hide();
        }
    }
}
