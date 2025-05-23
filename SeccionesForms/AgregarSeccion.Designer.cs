namespace CECOT_PROYECT.SeccionesForms
{
    partial class AgregarSeccion
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSeccionId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSeccionGuardar = new System.Windows.Forms.Button();
            this.btnSeccionCancelar = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::CECOT_PROYECT.Properties.Resources.CECOT_Logo_removebg_preview;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(244, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 132);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(284, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 47);
            this.label2.TabIndex = 22;
            this.label2.Text = "ID";
            // 
            // txtSeccionId
            // 
            this.txtSeccionId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeccionId.Location = new System.Drawing.Point(279, 215);
            this.txtSeccionId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSeccionId.Name = "txtSeccionId";
            this.txtSeccionId.ReadOnly = true;
            this.txtSeccionId.Size = new System.Drawing.Size(64, 30);
            this.txtSeccionId.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(224, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 47);
            this.label3.TabIndex = 30;
            this.label3.Text = "Sección";
            // 
            // btnSeccionGuardar
            // 
            this.btnSeccionGuardar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSeccionGuardar.FlatAppearance.BorderSize = 3;
            this.btnSeccionGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnSeccionGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeccionGuardar.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeccionGuardar.Location = new System.Drawing.Point(144, 576);
            this.btnSeccionGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSeccionGuardar.Name = "btnSeccionGuardar";
            this.btnSeccionGuardar.Size = new System.Drawing.Size(150, 50);
            this.btnSeccionGuardar.TabIndex = 36;
            this.btnSeccionGuardar.Text = "Guardar";
            this.btnSeccionGuardar.UseVisualStyleBackColor = true;
            // 
            // btnSeccionCancelar
            // 
            this.btnSeccionCancelar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnSeccionCancelar.FlatAppearance.BorderSize = 3;
            this.btnSeccionCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnSeccionCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeccionCancelar.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeccionCancelar.Location = new System.Drawing.Point(323, 576);
            this.btnSeccionCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSeccionCancelar.Name = "btnSeccionCancelar";
            this.btnSeccionCancelar.Size = new System.Drawing.Size(150, 50);
            this.btnSeccionCancelar.TabIndex = 37;
            this.btnSeccionCancelar.Text = "Cancelar";
            this.btnSeccionCancelar.UseVisualStyleBackColor = true;
            this.btnSeccionCancelar.Click += new System.EventHandler(this.btnSeccionCancelar_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Máxima seguridad",
            "Comunes",
            "Aislamiento"});
            this.comboBox1.Location = new System.Drawing.Point(144, 342);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(329, 37);
            this.comboBox1.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(189, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 47);
            this.label1.TabIndex = 39;
            this.label1.Text = "Capacidad";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(144, 486);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(329, 35);
            this.textBox1.TabIndex = 40;
            // 
            // AgregarSeccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CECOT_PROYECT.Properties.Resources.fondo2;
            this.ClientSize = new System.Drawing.Size(628, 657);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnSeccionCancelar);
            this.Controls.Add(this.btnSeccionGuardar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSeccionId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AgregarSeccion";
            this.Text = "AgregarSeccion";
            this.Load += new System.EventHandler(this.AgregarSeccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSeccionId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSeccionGuardar;
        private System.Windows.Forms.Button btnSeccionCancelar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}