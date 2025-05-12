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

        // M�TODOS ----------------------------------------------------

        // M�todo que controla la vista de la interfaz en funci�n del n�mero de registros de la BD
        private void ControlInterfaz()
        {
            // Controlar si la BD no contiene ning�n registro. En caso de que no est� vacia, inicializar en posicion 0
            if (_sqlDBHelper.NumeroProfesores > 0)
            {
                _posicion = 0;
                MostrarRegistro(_posicion);

                // Otros botones
                btnGuardarRegistro.Enabled = false;
                btnActualizarRegistro.Enabled = false;
                btnCancelarAgregar.Visible = false;
            }
            else // Si la BD est� vac�a, iniciar pidiendo a�adir un nuevo registro
            {
                _posicion = -1;
                lblPosicion.Text = "A�adir Profesor";
                ControlBotonesNavegacion(_posicion);
                btnGuardarRegistro.Enabled = false;
                btnActualizarRegistro.Enabled = false;
                btnEliminarRegistro.Enabled = false;
            }
        }

        // M�todo que muestra el registro en los textBox
        private void MostrarRegistro(int posicion)
        {
            Profesor profesor;

            profesor = _sqlDBHelper.DevolverProfesor(posicion);

            txtDni.Text = profesor.Dni;
            txtNombre.Text = profesor.Nombre;
            txtApellidos.Text = profesor.Apellidos;
            txtTelefono.Text = profesor.Tlf;
            txtEmail.Text = profesor.Email;

            // Actualizamos los controles de navegaci�n
            ControlBotonesNavegacion(posicion);

            // Actualizaci�n del label de posici�n
            lblPosicion.Text = $"Profesor {posicion + 1} de {_sqlDBHelper.NumeroProfesores}";

        }

        // M�todo para controlar la activaci�n de los botones de navegaci�n
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
            else if (posicion == -1) // Valor reservado para "Modo A�adir"
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
            // Vaciamos los textBox para a�adir los nuevos datos
            LimpiarTextBox();

            // Establecemos posici�n -1 "Modo Agregar"
            _posicion = -1;
            ControlBotonesNavegacion(_posicion);
            btnActualizarRegistro.Enabled = false;
            btnEliminarRegistro.Enabled = false;
            btnGuardarRegistro.Enabled = false;

            lblPosicion.Text = "A�adir Profesor:";

            // Activamos el bot�n de cancelar
            btnCancelarAgregar.Visible = true;
        }

        private void btnGuardarRegistro_Click(object sender, EventArgs e)
        {
            Profesor profesor = new Profesor(txtDni.Text, txtNombre.Text, txtApellidos.Text, txtTelefono.Text, txtEmail.Text);

            _sqlDBHelper.AnyadirProfesorBD(profesor);

            // Mostramos el profesor agregado como el �ltimo
            _posicion = _sqlDBHelper.NumeroProfesores - 1;
            MostrarRegistro(_posicion);
        }
        private void btnCancelarAgregar_Click(object sender, EventArgs e)
        {
            DialogResult cancelar;

            cancelar = MessageBox.Show("�Desea cancelar la introducci�n del nuevo profesor?", "Cancelar", MessageBoxButtons.YesNo);

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

            eliminar = MessageBox.Show("�Desea eliminar el profesor que se muestra?", "Eliminar", MessageBoxButtons.YesNo);

            if (eliminar == DialogResult.Yes)
            {
                _sqlDBHelper.EliminarProfesor(_posicion);

                // Realizamos el control de vista
                ControlInterfaz();
            }
        }

        // VALIDACIONES ------------------------
        // Validaci�n de DNI
        private bool ValidarDni(string dni)
        {
            bool valido = false;
            string patron = @"^\d{8}[A-Z]$";

            if (Regex.IsMatch(dni, patron)) // Se coloca en anidaci�n para evitar que se ejecute la comprobaci�n sin un dni v�lido.
            {
                if (!_sqlDBHelper.ComprobarDNI(dni))
                {
                    valido = true;
                }
            }

            return valido;
        }

        // Validaci�n del tel�fono
        private bool ValidarTelefono(string telefono)
        {
            string patron = @"^\d{9}$";
            return Regex.IsMatch(telefono, patron);
        }

        // Validaci�n del email
        private bool ValidarEmail(string email)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            bool valido = Regex.IsMatch(email, patron);

            return valido;
        }

        // Validaci�n de profesor
        private bool ValidarProfesor()
        {
            bool valido = false;

            if (ValidarDni(txtDni.Text) && ValidarTelefono(txtTelefono.Text) && ValidarEmail(txtEmail.Text)) // Comprobaci�n de formatos
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
