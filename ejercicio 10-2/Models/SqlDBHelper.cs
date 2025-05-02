using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ejercicio_10_2.Models
{
    internal class SqlDBHelper
    {
        // MIEMBROS ------------------------------------------------
        private DataSet _dataSetProfesores;
        private SqlDataAdapter _dataAdapterProfesores;
        private int _numeroProfesores;

        // PROPIEDADES ---------------------------------------------
        public int NumeroProfesores
        {
            get => _numeroProfesores;
        }

        // CONSTRUCTOR ---------------------------------------------
        public SqlDBHelper()
        {
            string cadenaConexion = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Álvaro\\source\\repos\\AlvaroAltavista\\ejercicio 10-2\\ejercicio 10-2\\App_Data\\Instituto.mdf\";Integrated Security=True";

            // Conexión
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            // Apertura de conexión
            conexion.Open();

            // Generamos el DataAdapter
            string consultaSql = "SELECT * FROM Profesores";
            _dataAdapterProfesores = new SqlDataAdapter(consultaSql, conexion);

            // Generamos el DataSet y lo llenamos con los datos de la tabla.
            _dataSetProfesores = new DataSet();
            _dataAdapterProfesores.Fill(_dataSetProfesores, "Profesores");

            // Actualizamos el numero total de registros
            _numeroProfesores = _dataSetProfesores.Tables["Profesores"].Rows.Count;

            // Cerramos la conexión
            conexion.Close();
        }

        // MÉTODOS ----------------------------------------------------
        public Profesor DevolverProfesor(int pos)
        {
            Profesor profesor = null;

            if (pos >= 0 && pos < _numeroProfesores)
            {
                // No podemos convertir una row de la tabla en un Profesor directamnte
                DataRow registro;

                registro = _dataSetProfesores.Tables["Profesores"].Rows[pos];

                profesor = new Profesor(registro[0].ToString(),
                                        registro[1].ToString(),
                                        registro[2].ToString(),
                                        registro[3].ToString(),
                                        registro[4].ToString());
            }

            return profesor;
        }

        private void ActualizarNumeroProfesores()
        {
            _numeroProfesores = _dataSetProfesores.Tables["Profesores"].Rows.Count;
        }

        // MÉTODOS CRUD ---------

        // Método que reconecta y actualiza la BD física
        private void ActualizarBD()
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(_dataAdapterProfesores);
            _dataAdapterProfesores.Update(_dataSetProfesores, "Profesores");
        }

        // Método que añade un profesor a la BD
        public void AnyadirProfesorBD(Profesor profesor)
        {
            // Nuevo registro
            DataRow nuevoRegistro = _dataSetProfesores.Tables["Profesores"].NewRow();

            // Agregamos los datos de los TextBox
            nuevoRegistro[0] = profesor.Dni;
            nuevoRegistro[1] = profesor.Nombre;
            nuevoRegistro[2] = profesor.Apellidos;
            nuevoRegistro[3] = profesor.Tlf;
            nuevoRegistro[4] = profesor.Email;

            // Agregamos el registro al DataSet
            _dataSetProfesores.Tables["Profesores"].Rows.Add(nuevoRegistro);

            // Actualizamos la BD y el número de registros
            ActualizarBD();
            ActualizarNumeroProfesores();
        }

        // Método que actualiza los datos de un profesor según la posición
        public void ActualizarDatosProfesor(Profesor profesor, int pos)
        {
            // Recogemos el registro de la posición
            DataRow registroActual = _dataSetProfesores.Tables["Profesores"].Rows[pos];

            // Actualizamos los datos de los TextBox
            registroActual[0] = profesor.Dni;
            registroActual[1] = profesor.Nombre;
            registroActual[2] = profesor.Apellidos;
            registroActual[3] = profesor.Tlf;
            registroActual[4] = profesor.Email;

            // Actualizamos la BD
            ActualizarBD();
        }

        // Método que elimina el registro en la posición que se muestra
        public void EliminarProfesor(int pos)
        {
            // Eliminamos el registro
            _dataSetProfesores.Tables["Profesores"].Rows[pos].Delete();

            // Actualizamos la BD y el número de registros
            ActualizarBD();
            ActualizarNumeroProfesores();
        }
    }
}
