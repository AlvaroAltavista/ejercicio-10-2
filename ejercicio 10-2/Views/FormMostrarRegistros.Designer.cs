namespace ejercicio_10_2.Views
{
    partial class FormMostrarRegistros
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
            dataGridProfesores = new DataGridView();
            lblPosicion = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridProfesores).BeginInit();
            SuspendLayout();
            // 
            // dataGridProfesores
            // 
            dataGridProfesores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridProfesores.BackgroundColor = SystemColors.ButtonFace;
            dataGridProfesores.BorderStyle = BorderStyle.None;
            dataGridProfesores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProfesores.Location = new Point(38, 113);
            dataGridProfesores.Name = "dataGridProfesores";
            dataGridProfesores.ReadOnly = true;
            dataGridProfesores.RowHeadersWidth = 62;
            dataGridProfesores.RowTemplate.ReadOnly = true;
            dataGridProfesores.Size = new Size(1091, 469);
            dataGridProfesores.TabIndex = 0;
            // 
            // lblPosicion
            // 
            lblPosicion.AutoSize = true;
            lblPosicion.Font = new Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPosicion.Location = new Point(38, 44);
            lblPosicion.Name = "lblPosicion";
            lblPosicion.Size = new Size(300, 42);
            lblPosicion.TabIndex = 2;
            lblPosicion.Text = "Profesores Registrados";
            // 
            // FormMostrarRegistros
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1174, 617);
            Controls.Add(lblPosicion);
            Controls.Add(dataGridProfesores);
            Name = "FormMostrarRegistros";
            Text = "FormMostrarRegistros";
            Load += FormMostrarRegistros_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridProfesores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridProfesores;
        private Label lblPosicion;
    }
}