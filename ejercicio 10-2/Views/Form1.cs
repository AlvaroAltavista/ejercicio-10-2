using ejercicio_10_2.Models;
using System.Text.RegularExpressions;

namespace ejercicio_10_2
{
    public partial class FormProfesores : Form
    {
        // MIEMBROS ----------------------------------------------------------------------------
        // Instancia del objeto de control de BD
        SqlDBHelper _sqlDBHelper;

        private int _posicion;

        // CONSTRUCTOR --------------------------------------------------------------------------
        public FormProfesores()
        {
            InitializeComponent();
        }

        // LOAD -------------------------------------------------------
        private void FormProfesores_Load(object sender, EventArgs e)
        {
            _sqlDBHelper = new SqlDBHelper();

            ControlInterfaz();
        }

        // MÉTODOS ----------------------------------------------------

        // Método que controla la vista de la interfaz en función del número de registros de la BD
        private void ControlInterfaz()
        {
            // Controlar si la BD no contiene ningún registro. En caso de que no esté vacia, inicializar en posicion 0
            if (_sqlDBHelper.NumeroProfesores > 0)
            {
                _posicion = 0;
                MostrarRegistro(_posicion);

                // Otros botones
                btnGuardarRegistro.Enabled = false;
                btnActualizarRegistro.Enabled = false;
                btnCancelarAgregar.Visible = false;
            }
            else // Si la BD está vacía, iniciar pidiendo añadir un nuevo registro
            {
                _posicion = -1;
                lblPosicion.Text = "Añadir Profesor";
                ControlBotonesNavegacion(_posicion);
                btnGuardarRegistro.Enabled = false;
                btnActualizarRegistro.Enabled = false;
                btnEliminarRegistro.Enabled = false;
            }
        }

        // Método que muestra el registro en los textBox
        private void MostrarRegistro(int posicion)
        {
            Profesor profesor;

            profesor = _sqlDBHelper.DevolverProfesor(posicion);

            txtDni.Text = profesor.Dni;
            txtNombre.Text = profesor.Nombre;
            txtApellidos.Text = profesor.Apellidos;
            txtTelefono.Text = profesor.Tlf;
            txtEmail.Text = profesor.Email;

            // Actualizamos los controles de navegación
            ControlBotonesNavegacion(posicion);

            // Actualización del label de posición
            lblPosicion.Text = $"Profesor {posicion + 1} de {_sqlDBHelper.NumeroProfesores}";

        }

        // Método para controlar la activación de los botones de navegación
        private void ControlBotonesNavegacion(int posicion)
        {
            if (posicion == 0)
            {
                btnPrimero.Enabled = false;
                btnSiguiente.Enabled = true;
                btnAnterior.Enabled = false;
                btnUltimo.Enabled = true;
            }
            else if (posicion == _sqlDBHelper.NumeroProfesores - 1)
            {
                btnPrimero.Enabled = true;
                btnSiguiente.Enabled = false;
                btnAnterior.Enabled = true;
                btnUltimo.Enabled = false;
            }
            else if (posicion == -1) // Valor reservado para "Modo Añadir"
            {
                btnPrimero.Enabled = false;
                btnSiguiente.Enabled = false;
                btnAnterior.Enabled = false;
                btnUltimo.Enabled = false;
            }
            else
            {
                btnPrimero.Enabled = true;
                btnSiguiente.Enabled = true;
                btnAnterior.Enabled = true;
                btnUltimo.Enabled = true;
            }
        }

        // Funcion clear de los textBox
        private void LimpiarTextBox()
        {
            txtDni.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
        }

        // BOTONES ------------------------------------------------------------
        private void btnPrimero_Click(object sender, EventArgs e)
        {
            _posicion = 0;
            MostrarRegistro(_posicion);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            _posicion++;
            MostrarRegistro(_posicion);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            _posicion--;
            MostrarRegistro(_posicion);
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            _posicion = _sqlDBHelper.NumeroProfesores - 1;
            MostrarRegistro(_posicion);
        }

        // Botones Nuevo Registro -----------------------
        private void btnAnyadirRegistro_Click(object sender, EventArgs e)
        {
            // Vaciamos los textBox para añadir los nuevos datos
            LimpiarTextBox();

            // Establecemos posición -1 "Modo Agregar"
            _posicion = -1;
            ControlBotonesNavegacion(_posicion);
            btnActualizarRegistro.Enabled = false;
            btnEliminarRegistro.Enabled = false;
            btnGuardarRegistro.Enabled = false;

            lblPosicion.Text = "Añadir Profesor:";

            // Activamos el botón de cancelar
            btnCancelarAgregar.Visible = true;
        }

        private void btnGuardarRegistro_Click(object sender, EventArgs e)
        {
            Profesor profesor = new Profesor(txtDni.Text, txtNombre.Text, txtApellidos.Text, txtTelefono.Text, txtEmail.Text);

            _sqlDBHelper.AnyadirProfesorBD(profesor);

            // Mostramos el profesor agregado como el último
            _posicion = _sqlDBHelper.NumeroProfesores - 1;
            MostrarRegistro(_posicion);
        }
        private void btnCancelarAgregar_Click(object sender, EventArgs e)
        {
            DialogResult cancelar;

            cancelar = MessageBox.Show("¿Desea cancelar la introducción del nuevo profesor?", "Cancelar", MessageBoxButtons.YesNo);

            if (cancelar == DialogResult.Yes)
            {
                _posicion = 0;
                MostrarRegistro(_posicion);
                btnGuardarRegistro.Enabled = false;
                btnCancelarAgregar.Visible = false;
            }

        }

        // Botones Gestion de Registros ----------------
        private void btnEliminarRegistro_Click(object sender, EventArgs e)
        {
            DialogResult eliminar;

            eliminar = MessageBox.Show("¿Desea eliminar el profesor que se muestra?", "Eliminar", MessageBoxButtons.YesNo);

            if (eliminar == DialogResult.Yes)
            {
                _sqlDBHelper.EliminarProfesor(_posicion);

                // Realizamos el control de vista
                ControlInterfaz();
            }
        }

        // VALIDACIONES ------------------------
        // Validación de DNI
        private bool ValidarDni(string dni)
        {
            bool valido = false;
            string patron = @"^\d{8}[A-Z]$";

            if (Regex.IsMatch(dni, patron)) // Se coloca en anidación para evitar que se ejecute la comprobación sin un dni válido.
            {
                if (!_sqlDBHelper.ComprobarDNI(dni))
                {
                    valido = true;
                }
            }

            return valido;
        }

        // Validación del teléfono
        private bool ValidarTelefono(string telefono)
        {
            string patron = @"^\d{9}$";
            return Regex.IsMatch(telefono, patron);
        }

        // Validación del email
        private bool ValidarEmail(string email)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            bool valido = Regex.IsMatch(email, patron);

            return valido;
        }

        // Validación de profesor
        private bool ValidarProfesor()
        {
            bool valido = false;

            if (ValidarDni(txtDni.Text) && ValidarTelefono(txtTelefono.Text) && ValidarEmail(txtEmail.Text)) // Comprobación de formatos
            {
                if (txtNombre.Text != "" && txtApellidos.Text != "")
                {
                    valido = true;
                }
            }

            return valido;
        }

        // Validaciones en tiempo real de TextBox
        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            if (ValidarProfesor())
            {
                if (btnCancelarAgregar.Visible == true)
                {
                    btnGuardarRegistro.Enabled = true;
                }
                else
                {
                    btnActualizarRegistro.Enabled = true;
                }
            }
            else
            {
                btnGuardarRegistro.Enabled = false;
                btnActualizarRegistro.Enabled = false;
            }
        }
    }
}
