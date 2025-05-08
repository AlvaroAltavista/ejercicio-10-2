using ejercicio_10_2.Models;

namespace ejercicio_10_2
{
    public partial class FormProfesores : Form
    {
        public FormProfesores()
        {
            InitializeComponent();
        }

        // MIEMBROS -------------------------------------
        // Instancia del objeto de control de BD
        SqlDBHelper sqlDBHelper;

        private int posicion;

        // LOAD -------------------------------------------------------
        private void FormProfesores_Load(object sender, EventArgs e)
        {
            sqlDBHelper = new SqlDBHelper();

            posicion = 0;
            MostrarRegistro(posicion);
            ControlBotonesNavegacion(posicion);

            // Otros botones
            btnGuardarRegistro.Enabled = false;
            btnActualizarRegistro.Enabled = false;
        }

        // MÉTODOS ----------------------------------------------------

        // Método que muestra el registro en los textBox
        private void MostrarRegistro(int posicion)
        {
            Profesor profesor;

            profesor = sqlDBHelper.DevolverProfesor(posicion);

            txtDni.Text = profesor.Dni;
            txtNombre.Text = profesor.Nombre;
            txtApellidos.Text = profesor.Apellidos;
            txtTelefono.Text = profesor.Tlf;
            txtEmail.Text = profesor.Email;

            lblPosicion.Text = $"Profesor {posicion + 1} de {sqlDBHelper.NumeroProfesores}";
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
            else if (posicion == sqlDBHelper.NumeroProfesores - 1)
            {
                btnPrimero.Enabled = true;
                btnSiguiente.Enabled = false;
                btnAnterior.Enabled = true;
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

        // BOTONES ------------------------------------------------------------
        private void btnPrimero_Click(object sender, EventArgs e)
        {
            posicion = 0;
            MostrarRegistro(posicion);
            ControlBotonesNavegacion(posicion);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            posicion++;
            MostrarRegistro(posicion);
            ControlBotonesNavegacion(posicion);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            posicion--;
            MostrarRegistro(posicion);
            ControlBotonesNavegacion(posicion);
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            posicion = sqlDBHelper.NumeroProfesores - 1;
            MostrarRegistro(posicion);
            ControlBotonesNavegacion(posicion);
        }
    }
}
