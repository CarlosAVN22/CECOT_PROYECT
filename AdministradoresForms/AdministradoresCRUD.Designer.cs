namespace CECOT_PROYECT
{
    partial class AdministradoresCRUD
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbuscar = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Agregar = new System.Windows.Forms.Button();
            this.Eliminar = new System.Windows.Forms.Button();
            this.Visualizar = new System.Windows.Forms.Button();
            this.Editar = new System.Windows.Forms.Button();
            this.Regresar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnmin = new System.Windows.Forms.Button();
            this.btnmax = new System.Windows.Forms.Button();
            this.btncerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(44, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtbuscar
            // 
            this.txtbuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuscar.Location = new System.Drawing.Point(171, 97);
            this.txtbuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(693, 38);
            this.txtbuscar.TabIndex = 1;
            this.txtbuscar.TextChanged += new System.EventHandler(this.txtbuscar_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Location = new System.Drawing.Point(30, 161);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(834, 296);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Agregar
            // 
            this.Agregar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Agregar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.Agregar.FlatAppearance.BorderSize = 3;
            this.Agregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Agregar.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Agregar.Location = new System.Drawing.Point(902, 217);
            this.Agregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(128, 56);
            this.Agregar.TabIndex = 3;
            this.Agregar.Text = "Agregar";
            this.Agregar.UseVisualStyleBackColor = false;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            this.Agregar.MouseEnter += new System.EventHandler(this.Agregar_MouseEnter);
            this.Agregar.MouseLeave += new System.EventHandler(this.Agregar_MouseLeave);
            // 
            // Eliminar
            // 
            this.Eliminar.BackColor = System.Drawing.Color.White;
            this.Eliminar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.Eliminar.FlatAppearance.BorderSize = 3;
            this.Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Eliminar.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Eliminar.Location = new System.Drawing.Point(902, 468);
            this.Eliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(128, 50);
            this.Eliminar.TabIndex = 4;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseVisualStyleBackColor = false;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click);
            this.Eliminar.MouseEnter += new System.EventHandler(this.Eliminar_MouseEnter);
            this.Eliminar.MouseLeave += new System.EventHandler(this.Eliminar_MouseLeave);
            // 
            // Visualizar
            // 
            this.Visualizar.BackColor = System.Drawing.Color.White;
            this.Visualizar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.Visualizar.FlatAppearance.BorderSize = 3;
            this.Visualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Visualizar.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Visualizar.Location = new System.Drawing.Point(902, 384);
            this.Visualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Visualizar.Name = "Visualizar";
            this.Visualizar.Size = new System.Drawing.Size(128, 50);
            this.Visualizar.TabIndex = 5;
            this.Visualizar.Text = "Actualizar";
            this.Visualizar.UseVisualStyleBackColor = false;
            this.Visualizar.Click += new System.EventHandler(this.Visualizar_Click);
            this.Visualizar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Visualizar_MouseClick);
            this.Visualizar.MouseEnter += new System.EventHandler(this.Visualizar_MouseEnter);
            this.Visualizar.MouseLeave += new System.EventHandler(this.Visualizar_MouseLeave);
            // 
            // Editar
            // 
            this.Editar.BackColor = System.Drawing.Color.White;
            this.Editar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.Editar.FlatAppearance.BorderSize = 3;
            this.Editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Editar.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Editar.Location = new System.Drawing.Point(902, 303);
            this.Editar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Editar.Name = "Editar";
            this.Editar.Size = new System.Drawing.Size(128, 50);
            this.Editar.TabIndex = 6;
            this.Editar.Text = "Editar";
            this.Editar.UseVisualStyleBackColor = false;
            this.Editar.Click += new System.EventHandler(this.Editar_Click);
            this.Editar.MouseEnter += new System.EventHandler(this.Editar_MouseEnter);
            this.Editar.MouseLeave += new System.EventHandler(this.Editar_MouseLeave);
            // 
            // Regresar
            // 
            this.Regresar.BackColor = System.Drawing.Color.White;
            this.Regresar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.Regresar.FlatAppearance.BorderSize = 3;
            this.Regresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Regresar.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Regresar.Location = new System.Drawing.Point(30, 484);
            this.Regresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Regresar.Name = "Regresar";
            this.Regresar.Size = new System.Drawing.Size(117, 34);
            this.Regresar.TabIndex = 9;
            this.Regresar.Text = "Cerrar ";
            this.Regresar.UseVisualStyleBackColor = false;
            this.Regresar.Click += new System.EventHandler(this.Regresar_Click);
            this.Regresar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Regresar_MouseClick);
            this.Regresar.MouseEnter += new System.EventHandler(this.Regresar_MouseEnter);
            this.Regresar.MouseLeave += new System.EventHandler(this.Regresar_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CECOT_PROYECT.Properties.Resources.CECOT_Logo_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(913, 97);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(276, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(278, 39);
            this.label3.TabIndex = 11;
            this.label3.Text = "Administradores";
            // 
            // btnmin
            // 
            this.btnmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnmin.BackColor = System.Drawing.Color.Transparent;
            this.btnmin.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnmin.FlatAppearance.BorderSize = 0;
            this.btnmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmin.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmin.ForeColor = System.Drawing.Color.White;
            this.btnmin.Location = new System.Drawing.Point(944, 4);
            this.btnmin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnmin.Name = "btnmin";
            this.btnmin.Size = new System.Drawing.Size(46, 48);
            this.btnmin.TabIndex = 23;
            this.btnmin.Text = "O";
            this.btnmin.UseVisualStyleBackColor = false;
            this.btnmin.Click += new System.EventHandler(this.btnmin_Click);
            // 
            // btnmax
            // 
            this.btnmax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnmax.BackColor = System.Drawing.Color.Transparent;
            this.btnmax.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnmax.FlatAppearance.BorderSize = 0;
            this.btnmax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmax.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmax.ForeColor = System.Drawing.Color.White;
            this.btnmax.Location = new System.Drawing.Point(997, 4);
            this.btnmax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnmax.Name = "btnmax";
            this.btnmax.Size = new System.Drawing.Size(46, 48);
            this.btnmax.TabIndex = 22;
            this.btnmax.Text = "O";
            this.btnmax.UseVisualStyleBackColor = false;
            this.btnmax.Click += new System.EventHandler(this.btnmax_Click);
            // 
            // btncerrar
            // 
            this.btncerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btncerrar.BackColor = System.Drawing.Color.Transparent;
            this.btncerrar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btncerrar.FlatAppearance.BorderSize = 0;
            this.btncerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncerrar.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncerrar.ForeColor = System.Drawing.Color.White;
            this.btncerrar.Location = new System.Drawing.Point(1049, 4);
            this.btncerrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(46, 48);
            this.btncerrar.TabIndex = 21;
            this.btncerrar.Text = "O";
            this.btncerrar.UseVisualStyleBackColor = false;
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // AdministradoresCRUD
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::CECOT_PROYECT.Properties.Resources.fondo2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1094, 564);
            this.ControlBox = false;
            this.Controls.Add(this.btnmin);
            this.Controls.Add(this.btnmax);
            this.Controls.Add(this.btncerrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Regresar);
            this.Controls.Add(this.Editar);
            this.Controls.Add(this.Visualizar);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.Agregar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtbuscar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AdministradoresCRUD";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar";
            this.Load += new System.EventHandler(this.Buscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbuscar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.Button Visualizar;
        private System.Windows.Forms.Button Editar;
        private System.Windows.Forms.Button Regresar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnmin;
        private System.Windows.Forms.Button btnmax;
        private System.Windows.Forms.Button btncerrar;
    }
}