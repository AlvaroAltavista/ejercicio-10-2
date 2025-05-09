using ejercicio_10_2.Models;

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

            // Controlar si la BD no contiene ningún registro. En caso de que no esté vacia, inicializar en posicion 0
            if (_sqlDBHelper.NumeroProfesores > 0)
            {
                _posicion = 0;
                MostrarRegistro(_posicion);
                ControlBotonesNavegacion(_posicion);

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
            }
        }

        // MÉTODOS ----------------------------------------------------

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
            ControlBotonesNavegacion(_posicion);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            _posicion++;
            MostrarRegistro(_posicion);
            ControlBotonesNavegacion(_posicion);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            _posicion--;
            MostrarRegistro(_posicion);
            ControlBotonesNavegacion(_posicion);
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            _posicion = _sqlDBHelper.NumeroProfesores - 1;
            MostrarRegistro(_posicion);
            ControlBotonesNavegacion(_posicion);
        }

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

            // Activamos el botón de cancelar
            btnCancelarAgregar.Visible = true;
        }

        private void btnGuardarRegistro_Click(object sender, EventArgs e)
        {

        }
    }
}
