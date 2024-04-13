namespace Consultorio
{
    partial class PBuscarMedicos
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
            this.dgMedicos = new System.Windows.Forms.DataGridView();
            this.cbActivos = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgMedicos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgMedicos
            // 
            this.dgMedicos.AllowUserToAddRows = false;
            this.dgMedicos.AllowUserToDeleteRows = false;
            this.dgMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMedicos.Location = new System.Drawing.Point(29, 115);
            this.dgMedicos.Name = "dgMedicos";
            this.dgMedicos.ReadOnly = true;
            this.dgMedicos.RowHeadersWidth = 51;
            this.dgMedicos.RowTemplate.Height = 24;
            this.dgMedicos.Size = new System.Drawing.Size(742, 313);
            this.dgMedicos.TabIndex = 10;
            this.dgMedicos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgMedicos_CellDoubleClick);
            // 
            // cbActivos
            // 
            this.cbActivos.AutoSize = true;
            this.cbActivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbActivos.Location = new System.Drawing.Point(29, 77);
            this.cbActivos.Margin = new System.Windows.Forms.Padding(4);
            this.cbActivos.Name = "cbActivos";
            this.cbActivos.Size = new System.Drawing.Size(151, 22);
            this.cbActivos.TabIndex = 9;
            this.cbActivos.Text = "Filtrar solo activos";
            this.cbActivos.UseVisualStyleBackColor = true;
            this.cbActivos.CheckedChanged += new System.EventHandler(this.cbActivos_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(220, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Seleccione el Medico que necesite";
            // 
            // PBuscarMedicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgMedicos);
            this.Controls.Add(this.cbActivos);
            this.Controls.Add(this.label1);
            this.Name = "PBuscarMedicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PBuscarMedicos";
            this.Load += new System.EventHandler(this.PBuscarMedicos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMedicos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgMedicos;
        private System.Windows.Forms.CheckBox cbActivos;
        private System.Windows.Forms.Label label1;
    }
}