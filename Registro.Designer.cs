namespace CECOT_PROYECT
{
    partial class Registro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registro));
            this.pbRegistrar = new System.Windows.Forms.PictureBox();
            this.tbBuscar = new System.Windows.Forms.PictureBox();
            this.pbEliminar = new System.Windows.Forms.PictureBox();
            this.pbCerrar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbRegistrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbRegistrar
            // 
            this.pbRegistrar.BackColor = System.Drawing.Color.White;
            this.pbRegistrar.Image = ((System.Drawing.Image)(resources.GetObject("pbRegistrar.Image")));
            this.pbRegistrar.Location = new System.Drawing.Point(42, 348);
            this.pbRegistrar.Name = "pbRegistrar";
            this.pbRegistrar.Size = new System.Drawing.Size(206, 130);
            this.pbRegistrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRegistrar.TabIndex = 0;
            this.pbRegistrar.TabStop = false;
            this.pbRegistrar.Click += new System.EventHandler(this.pbRegistrar_Click);
            // 
            // tbBuscar
            // 
            this.tbBuscar.BackColor = System.Drawing.Color.White;
            this.tbBuscar.Image = ((System.Drawing.Image)(resources.GetObject("tbBuscar.Image")));
            this.tbBuscar.Location = new System.Drawing.Point(320, 348);
            this.tbBuscar.Name = "tbBuscar";
            this.tbBuscar.Size = new System.Drawing.Size(187, 130);
            this.tbBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tbBuscar.TabIndex = 1;
            this.tbBuscar.TabStop = false;
            this.tbBuscar.Click += new System.EventHandler(this.tbBuscar_Click);
            // 
            // pbEliminar
            // 
            this.pbEliminar.BackColor = System.Drawing.Color.White;
            this.pbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("pbEliminar.Image")));
            this.pbEliminar.Location = new System.Drawing.Point(578, 348);
            this.pbEliminar.Name = "pbEliminar";
            this.pbEliminar.Size = new System.Drawing.Size(195, 130);
            this.pbEliminar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEliminar.TabIndex = 2;
            this.pbEliminar.TabStop = false;
            this.pbEliminar.Click += new System.EventHandler(this.pbEliminar_Click);
            // 
            // pbCerrar
            // 
            this.pbCerrar.BackColor = System.Drawing.Color.White;
            this.pbCerrar.Image = ((System.Drawing.Image)(resources.GetObject("pbCerrar.Image")));
            this.pbCerrar.Location = new System.Drawing.Point(834, 348);
            this.pbCerrar.Name = "pbCerrar";
            this.pbCerrar.Size = new System.Drawing.Size(195, 130);
            this.pbCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCerrar.TabIndex = 3;
            this.pbCerrar.TabStop = false;
            this.pbCerrar.Click += new System.EventHandler(this.pbCerrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(363, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(347, 235);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Registro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::CECOT_PROYECT.Properties.Resources.VERDEEE;
            this.ClientSize = new System.Drawing.Size(1073, 611);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbCerrar);
            this.Controls.Add(this.pbEliminar);
            this.Controls.Add(this.tbBuscar);
            this.Controls.Add(this.pbRegistrar);
            this.Name = "Registro";
            this.Text = "InicioSesion";
            ((System.ComponentModel.ISupportInitialize)(this.pbRegistrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRegistrar;
        private System.Windows.Forms.PictureBox tbBuscar;
        private System.Windows.Forms.PictureBox pbEliminar;
        private System.Windows.Forms.PictureBox pbCerrar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}