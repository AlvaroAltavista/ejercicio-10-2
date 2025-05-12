namespace ejercicio_10_2
{
    partial class FormProfesores
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpDatos = new GroupBox();
            txtEmail = new TextBox();
            txtTelefono = new TextBox();
            lblEmail = new Label();
            lblTelefono = new Label();
            txtApellidos = new TextBox();
            lblApellidos = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtDni = new TextBox();
            lblDni = new Label();
            lblPosicion = new Label();
            grpNavegacion = new GroupBox();
            btnUltimo = new Button();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            btnPrimero = new Button();
            grpNuevoRegistro = new GroupBox();
            btnCancelarAgregar = new Button();
            grpGestionarRegistros = new GroupBox();
            btnEliminarRegistro = new Button();
            btnActualizarRegistro = new Button();
            btnGuardarRegistro = new Button();
            btnAnyadirRegistro = new Button();
            grpDatos.SuspendLayout();
            grpNavegacion.SuspendLayout();
            grpNuevoRegistro.SuspendLayout();
            grpGestionarRegistros.SuspendLayout();
            SuspendLayout();
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(txtEmail);
            grpDatos.Controls.Add(txtTelefono);
            grpDatos.Controls.Add(lblEmail);
            grpDatos.Controls.Add(lblTelefono);
            grpDatos.Controls.Add(txtApellidos);
            grpDatos.Controls.Add(lblApellidos);
            grpDatos.Controls.Add(txtNombre);
            grpDatos.Controls.Add(lblNombre);
            grpDatos.Controls.Add(txtDni);
            grpDatos.Controls.Add(lblDni);
            grpDatos.Location = new Point(45, 103);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(953, 337);
            grpDatos.TabIndex = 0;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(586, 254);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(296, 34);
            txtEmail.TabIndex = 5;
            txtEmail.TextChanged += txtDni_TextChanged;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(121, 254);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(296, 34);
            txtTelefono.TabIndex = 4;
            txtTelefono.TextChanged += txtDni_TextChanged;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(515, 256);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(66, 31);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email:";
            lblEmail.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(22, 257);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(96, 31);
            lblTelefono.TabIndex = 0;
            lblTelefono.Text = "Teléfono:";
            lblTelefono.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(585, 154);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(296, 34);
            txtApellidos.TabIndex = 3;
            txtApellidos.TextChanged += txtDni_TextChanged;
            // 
            // lblApellidos
            // 
            lblApellidos.AutoSize = true;
            lblApellidos.Location = new Point(483, 157);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(98, 31);
            lblApellidos.TabIndex = 0;
            lblApellidos.Text = "Apellidos:";
            lblApellidos.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(121, 155);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(296, 34);
            txtNombre.TabIndex = 2;
            txtNombre.TextChanged += txtDni_TextChanged;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(26, 158);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(92, 31);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            lblNombre.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(121, 64);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(296, 34);
            txtDni.TabIndex = 1;
            txtDni.TextChanged += txtDni_TextChanged;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(70, 67);
            lblDni.Name = "lblDni";
            lblDni.RightToLeft = RightToLeft.No;
            lblDni.Size = new Size(48, 31);
            lblDni.TabIndex = 0;
            lblDni.Text = "DNI:";
            lblDni.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPosicion
            // 
            lblPosicion.AutoSize = true;
            lblPosicion.Font = new Font("Poppins", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPosicion.Location = new Point(45, 51);
            lblPosicion.Name = "lblPosicion";
            lblPosicion.Size = new Size(206, 42);
            lblPosicion.TabIndex = 1;
            lblPosicion.Text = "Posición actual";
            // 
            // grpNavegacion
            // 
            grpNavegacion.Controls.Add(btnUltimo);
            grpNavegacion.Controls.Add(btnAnterior);
            grpNavegacion.Controls.Add(btnSiguiente);
            grpNavegacion.Controls.Add(btnPrimero);
            grpNavegacion.Location = new Point(45, 476);
            grpNavegacion.Name = "grpNavegacion";
            grpNavegacion.Size = new Size(953, 142);
            grpNavegacion.TabIndex = 2;
            grpNavegacion.TabStop = false;
            grpNavegacion.Text = "Navegación";
            // 
            // btnUltimo
            // 
            btnUltimo.Location = new Point(716, 57);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(210, 52);
            btnUltimo.TabIndex = 0;
            btnUltimo.Text = "Último";
            btnUltimo.UseVisualStyleBackColor = true;
            btnUltimo.Click += btnUltimo_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.Location = new Point(485, 57);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(210, 52);
            btnAnterior.TabIndex = 0;
            btnAnterior.Text = "Anterior";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Location = new Point(254, 57);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(210, 52);
            btnSiguiente.TabIndex = 0;
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnPrimero
            // 
            btnPrimero.Location = new Point(23, 57);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(210, 52);
            btnPrimero.TabIndex = 0;
            btnPrimero.Text = "Primero";
            btnPrimero.UseVisualStyleBackColor = true;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // grpNuevoRegistro
            // 
            grpNuevoRegistro.Controls.Add(btnCancelarAgregar);
            grpNuevoRegistro.Controls.Add(grpGestionarRegistros);
            grpNuevoRegistro.Controls.Add(btnGuardarRegistro);
            grpNuevoRegistro.Controls.Add(btnAnyadirRegistro);
            grpNuevoRegistro.Location = new Point(45, 655);
            grpNuevoRegistro.Name = "grpNuevoRegistro";
            grpNuevoRegistro.Size = new Size(953, 142);
            grpNuevoRegistro.TabIndex = 3;
            grpNuevoRegistro.TabStop = false;
            grpNuevoRegistro.Text = "Nuevo Registro";
            // 
            // btnCancelarAgregar
            // 
            btnCancelarAgregar.Location = new Point(23, 58);
            btnCancelarAgregar.Name = "btnCancelarAgregar";
            btnCancelarAgregar.Size = new Size(210, 52);
            btnCancelarAgregar.TabIndex = 4;
            btnCancelarAgregar.Text = "Cancelar";
            btnCancelarAgregar.UseVisualStyleBackColor = true;
            btnCancelarAgregar.Click += btnCancelarAgregar_Click;
            // 
            // grpGestionarRegistros
            // 
            grpGestionarRegistros.Controls.Add(btnEliminarRegistro);
            grpGestionarRegistros.Controls.Add(btnActualizarRegistro);
            grpGestionarRegistros.Location = new Point(473, 0);
            grpGestionarRegistros.Name = "grpGestionarRegistros";
            grpGestionarRegistros.Size = new Size(480, 142);
            grpGestionarRegistros.TabIndex = 3;
            grpGestionarRegistros.TabStop = false;
            grpGestionarRegistros.Text = "Gestionar Registros";
            // 
            // btnEliminarRegistro
            // 
            btnEliminarRegistro.Location = new Point(243, 58);
            btnEliminarRegistro.Name = "btnEliminarRegistro";
            btnEliminarRegistro.Size = new Size(210, 52);
            btnEliminarRegistro.TabIndex = 0;
            btnEliminarRegistro.Text = "Eliminar";
            btnEliminarRegistro.UseVisualStyleBackColor = true;
            btnEliminarRegistro.Click += btnEliminarRegistro_Click;
            // 
            // btnActualizarRegistro
            // 
            btnActualizarRegistro.Location = new Point(12, 58);
            btnActualizarRegistro.Name = "btnActualizarRegistro";
            btnActualizarRegistro.Size = new Size(210, 52);
            btnActualizarRegistro.TabIndex = 0;
            btnActualizarRegistro.Text = "Actualizar";
            btnActualizarRegistro.UseVisualStyleBackColor = true;
            // 
            // btnGuardarRegistro
            // 
            btnGuardarRegistro.Location = new Point(254, 58);
            btnGuardarRegistro.Name = "btnGuardarRegistro";
            btnGuardarRegistro.Size = new Size(210, 52);
            btnGuardarRegistro.TabIndex = 0;
            btnGuardarRegistro.Text = "Guardar";
            btnGuardarRegistro.UseVisualStyleBackColor = true;
            btnGuardarRegistro.Click += btnGuardarRegistro_Click;
            // 
            // btnAnyadirRegistro
            // 
            btnAnyadirRegistro.Location = new Point(23, 58);
            btnAnyadirRegistro.Name = "btnAnyadirRegistro";
            btnAnyadirRegistro.Size = new Size(210, 52);
            btnAnyadirRegistro.TabIndex = 0;
            btnAnyadirRegistro.Text = "Añadir";
            btnAnyadirRegistro.UseVisualStyleBackColor = true;
            btnAnyadirRegistro.Click += btnAnyadirRegistro_Click;
            // 
            // FormProfesores
            // 
            AutoScaleDimensions = new SizeF(11F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 842);
            Controls.Add(grpNuevoRegistro);
            Controls.Add(grpNavegacion);
            Controls.Add(lblPosicion);
            Controls.Add(grpDatos);
            Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormProfesores";
            Text = "Profesores";
            Load += FormProfesores_Load;
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            grpNavegacion.ResumeLayout(false);
            grpNuevoRegistro.ResumeLayout(false);
            grpGestionarRegistros.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpDatos;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private Label lblEmail;
        private Label lblTelefono;
        private TextBox txtApellidos;
        private Label lblApellidos;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtDni;
        private Label lblDni;
        private Label lblPosicion;
        private GroupBox grpNavegacion;
        private Button btnUltimo;
        private Button btnAnterior;
        private Button btnSiguiente;
        private Button btnPrimero;
        private GroupBox grpNuevoRegistro;
        private Button btnGuardarRegistro;
        private Button btnAnyadirRegistro;
        private GroupBox grpGestionarRegistros;
        private Button btnEliminarRegistro;
        private Button btnActualizarRegistro;
        private Button btnCancelarAgregar;
    }
}
