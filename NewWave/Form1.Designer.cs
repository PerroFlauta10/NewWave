namespace NewWave
{
    partial class Acceso
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Acceso));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.aceptarAcceso = new System.Windows.Forms.Button();
            this.salirAcceso = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textUsuario = new System.Windows.Forms.TextBox();
            this.maskedTextCont = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(541, 230);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // aceptarAcceso
            // 
            this.aceptarAcceso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aceptarAcceso.Location = new System.Drawing.Point(131, 179);
            this.aceptarAcceso.Name = "aceptarAcceso";
            this.aceptarAcceso.Size = new System.Drawing.Size(117, 39);
            this.aceptarAcceso.TabIndex = 1;
            this.aceptarAcceso.Text = "Aceptar";
            this.aceptarAcceso.UseVisualStyleBackColor = true;
            this.aceptarAcceso.Click += new System.EventHandler(this.aceptarAcceso_Click);
            // 
            // salirAcceso
            // 
            this.salirAcceso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.salirAcceso.Location = new System.Drawing.Point(282, 179);
            this.salirAcceso.Name = "salirAcceso";
            this.salirAcceso.Size = new System.Drawing.Size(117, 39);
            this.salirAcceso.TabIndex = 2;
            this.salirAcceso.Text = "Salir";
            this.salirAcceso.UseVisualStyleBackColor = true;
            this.salirAcceso.Click += new System.EventHandler(this.SalirAcceso_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(58, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 46);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(274, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 46);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña";
            // 
            // textUsuario
            // 
            this.textUsuario.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textUsuario.ForeColor = System.Drawing.SystemColors.Window;
            this.textUsuario.Location = new System.Drawing.Point(66, 110);
            this.textUsuario.Name = "textUsuario";
            this.textUsuario.Size = new System.Drawing.Size(159, 26);
            this.textUsuario.TabIndex = 5;
            // 
            // maskedTextCont
            // 
            this.maskedTextCont.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.maskedTextCont.ForeColor = System.Drawing.Color.White;
            this.maskedTextCont.Location = new System.Drawing.Point(299, 110);
            this.maskedTextCont.Name = "maskedTextCont";
            this.maskedTextCont.Size = new System.Drawing.Size(156, 26);
            this.maskedTextCont.TabIndex = 6;
            // 
            // Acceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(541, 230);
            this.Controls.Add(this.maskedTextCont);
            this.Controls.Add(this.textUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.salirAcceso);
            this.Controls.Add(this.aceptarAcceso);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Acceso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewWave";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button aceptarAcceso;
        private System.Windows.Forms.Button salirAcceso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textUsuario;
        private System.Windows.Forms.MaskedTextBox maskedTextCont;
    }
}

