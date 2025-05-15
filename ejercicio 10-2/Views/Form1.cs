using ejercicio_10_2.Models;
using ejercicio_10_2.Views;
using System.Data;
using System.Text.RegularExpressions;

namespace ejercicio_10_2
{
    public partial class FormProfesores : Form
    {
        // MIEMBROS ----------------------------------------------------------------------------
        // Instancia del objeto de control de BD
        SqlDBHelper _sqlDBHelper;

        private int _posicion;

        private bool _cargandoRegistro = false; // Evitar parpadeo del boton Actualizar

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

        // MÉTODOS -------------------------------------------------------------------------------

        // Método que controla la vista de la interfaz en función del número de registros de la BD
        private void ControlInterfaz()
        {
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
            _cargandoRegistro = true;

            Profesor profesor;

            profesor = _sqlDBHelper.DevolverProfesor(posicion);

            txtDni.Text = profesor.Dni;
            txtNombre.Text = profesor.Nombre;
            txtApellidos.Text = profesor.Apellidos;
            txtTelefono.Text = profesor.Tlf;
            txtEmail.Text = profesor.Email;

            // Actualizamos los controles de navegación
            ControlBotonesNavegacion(posicion);
            btnActualizarRegistro.Enabled = false;

            // Actualización del label de posición
            lblPosicion.Text = $"Profesor {posicion + 1} de {_sqlDBHelper.NumeroProfesores}";

            // Al mostrar un registro, se desctivan los indicadores de validación
            DesactivarIndicadoresValidacion();

            _cargandoRegistro = false;
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

        // Método clear de los textBox
        private void LimpiarTextBox()
        {
            txtDni.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
        }

        // BOTONES -------------------------------------------------------------------------------------------------------------------------
        private void btnPrimero_Click(object sender, EventArgs e)
        {
            if (ControlarCambiosInterfaz(_posicion))
            {
                DialogResult descartar = MessageBox.Show("Se perderán los cambios sin actualizar.\n\n¿Desea continuar?", "Actualizar", MessageBoxButtons.YesNo);

                if (descartar == DialogResult.Yes)
                {
                    _posicion = 0;
                    MostrarRegistro(_posicion);
                }

            }
            else
            {
                _posicion = 0;
                MostrarRegistro(_posicion);
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (ControlarCambiosInterfaz(_posicion))
            {
                DialogResult descartar = MessageBox.Show("Se perderán los cambios sin actualizar.\n\n¿Desea continuar?", "Actualizar", MessageBoxButtons.YesNo);

                if (descartar == DialogResult.Yes)
                {
                    _posicion++;
                    MostrarRegistro(_posicion);
                }

            }
            else
            {
                _posicion++;
                MostrarRegistro(_posicion);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (ControlarCambiosInterfaz(_posicion))
            {
                DialogResult descartar = MessageBox.Show("Se perderán los cambios sin actualizar.\n\n¿Desea continuar?", "Actualizar", MessageBoxButtons.YesNo);

                if (descartar == DialogResult.Yes)
                {
                    _posicion--;
                    MostrarRegistro(_posicion);
                }

            }
            else
            {
                _posicion--;
                MostrarRegistro(_posicion);
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (ControlarCambiosInterfaz(_posicion))
            {
                DialogResult descartar = MessageBox.Show("Se perderán los cambios sin actualizar.\n\n¿Desea continuar?", "Actualizar", MessageBoxButtons.YesNo);

                if (descartar == DialogResult.Yes)
                {
                    _posicion = _sqlDBHelper.NumeroProfesores - 1;
                    MostrarRegistro(_posicion);
                }
            }
            else
            {
                _posicion = _sqlDBHelper.NumeroProfesores - 1;
                MostrarRegistro(_posicion);
            }
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
            btnGuardarRegistro.Enabled = false;
            btnCancelarAgregar.Visible = false;
            btnEliminarRegistro.Enabled = true;
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

        private void btnActualizarRegistro_Click(object sender, EventArgs e)
        {
            Profesor profesorInterfaz = new Profesor(txtDni.Text, txtNombre.Text, txtApellidos.Text, txtTelefono.Text, txtEmail.Text);
            _sqlDBHelper.ActualizarDatosProfesor(profesorInterfaz, _posicion);

            // Desactivamos el boton de actualizar y mostramos el elemento
            MostrarRegistro(_posicion);
            btnActualizarRegistro.Enabled = false;
        }

        // OTRAS FUNCIONALIDADES -----------------------------------------------------------------------------------
        // Mostrar todos los registros
        private void btnMostrarRegistros_Click(object sender, EventArgs e)
        {
            FormMostrarRegistros formMostrarRegistros = new FormMostrarRegistros(_sqlDBHelper.DataSetProfesores);

            formMostrarRegistros.ShowDialog();
        }

        // VALIDACIONES ----------------------------------------------------------------------------------------------------------
        // Método que desactiva los indicadores de validación
        private void DesactivarIndicadoresValidacion()
        {
            imgDniNo.Visible = false;
            imgNombreNo.Visible = false;
            imgApellidosNo.Visible = false;
            imgTelefonoNo.Visible = false;
            imgEmailNo.Visible = false;

            imgDniOk.Visible = false;
            imgNombreOk.Visible = false;
            imgApellidosOk.Visible = false;
            imgTelefonoOk.Visible = false;
            imgEmailOk.Visible = false;

            lblDniExiste.Visible = false;
        }

        // Validación de DNI
        private bool ValidarDni(string dni)
        {
            bool valido = false;
            string patron = @"^\d{8}[A-Z]$";

            // Control de indicadores
            imgDniNo.Visible = true;
            imgDniOk.Visible = false;
            lblDniExiste.Visible = false;

            if (Regex.IsMatch(dni, patron)) // Se coloca en anidación para evitar que se ejecute la comprobación sin un dni válido.
            {
                if (_posicion == -1) // Modo agregar
                {
                    // Solo comprobar si el DNI ya existe en la BD
                    if (_sqlDBHelper.ComprobarDNI(dni))
                    {
                        lblDniExiste.Visible = true;
                        valido = false;
                    }
                    else
                    {
                        valido = true;
                        imgDniNo.Visible = false;
                        imgDniOk.Visible = true;
                    }
                }
                else // Modo edición
                {
                    if (txtDni.Text != _sqlDBHelper.DevolverProfesor(_posicion).Dni)
                    {
                        if (_sqlDBHelper.ComprobarDNI(dni))
                        {
                            lblDniExiste.Visible = true;
                            valido = false;
                        }
                        else
                        {
                            valido = true;
                            imgDniNo.Visible = false;
                            imgDniOk.Visible = true;
                        }
                    }
                    else
                    {
                        valido = true;
                        imgDniNo.Visible = false;
                        imgDniOk.Visible = true;
                    }
                }
            }

            return valido;
        }

        // Validación del teléfono
        private bool ValidarTelefono(string telefono)
        {
            bool valido = false;
            string patron = @"^\d{9}$";

            // Control de indicadores
            imgTelefonoNo.Visible = true;
            imgTelefonoOk.Visible = false;

            if (Regex.IsMatch(telefono, patron))
            {
                valido = true;

                // Control de indicadores
                imgTelefonoNo.Visible = false;
                imgTelefonoOk.Visible = true;
            }

            return valido;
        }

        // Validación del email
        private bool ValidarEmail(string email)
        {
            bool valido = false;
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Control de indicadores
            imgEmailNo.Visible = true;
            imgEmailOk.Visible = false;

            if (Regex.IsMatch(email, patron))
            {
                valido = true;

                // Control de indicadores
                imgEmailNo.Visible = false;
                imgEmailOk.Visible = true;
            }

            return valido;
        }

        // Validación del nombre
        private bool ValidarNombre(string nombre)
        {
            bool valido = false;

            // Control de indicadores
            imgNombreNo.Visible = true;
            imgNombreOk.Visible = false;

            if (nombre != "")
            {
                valido = true;

                // Control de indicadores
                imgNombreNo.Visible = false;
                imgNombreOk.Visible = true;
            }

            return valido;
        }

        // Validación del Apellidos
        private bool ValidarApellidos(string apellidos)
        {
            bool valido = false;

            // Control de indicadores
            imgApellidosNo.Visible = true;
            imgApellidosOk.Visible = false;

            if (apellidos != "")
            {
                valido = true;

                // Control de indicadores
                imgApellidosNo.Visible = false;
                imgApellidosOk.Visible = true;
            }

            return valido;
        }

        // Validación de profesor
        private bool ValidarProfesor()
        {
            bool validacionDni = ValidarDni(txtDni.Text);
            bool validacionNombre = ValidarNombre(txtNombre.Text);
            bool validacionApellidos = ValidarApellidos(txtApellidos.Text);
            bool validacionTelefono = ValidarTelefono(txtTelefono.Text);
            bool validacionEmail = ValidarEmail(txtEmail.Text);

            bool validacionCompleta = validacionDni && validacionNombre && validacionApellidos && validacionTelefono && validacionEmail;

            return validacionCompleta;
        }

        // Validaciones en tiempo real de TextBox
        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            if (_cargandoRegistro) return; // No validar si estamos cargando los datos del profesor

            if (ValidarProfesor()) // Si hay cambios, comprobamos si estamos añadiendo o queremos actualizar
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

        // Método de control de cambios en la interfaz
        private bool ControlarCambiosInterfaz(int posicion)
        {
            Profesor profesorInterfaz = new Profesor(txtDni.Text, txtNombre.Text, txtApellidos.Text, txtTelefono.Text, txtEmail.Text);
            Profesor profesorBD = _sqlDBHelper.DevolverProfesor(posicion);

            bool cambios = false;

            // Comparación de profesores
            if (profesorInterfaz.Dni != profesorBD.Dni ||
                profesorInterfaz.Nombre != profesorBD.Nombre ||
                profesorInterfaz.Apellidos != profesorBD.Apellidos ||
                profesorInterfaz.Tlf != profesorBD.Tlf ||
                profesorInterfaz.Email != profesorBD.Email)
            {
                cambios = true;
            }

            return cambios;
        }
    }
}
