using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejercicio_10_2.Views
{
    public partial class FormMostrarRegistros : Form
    {
        private DataSet _dataSetProfesores;

        public FormMostrarRegistros(DataSet dataSetProfesores)
        {
            InitializeComponent();
            this._dataSetProfesores = dataSetProfesores;
        }

        private void FormMostrarRegistros_Load(object sender, EventArgs e)
        {
            // Asignación de datos al DataGridView
            dataGridProfesores.DataSource = _dataSetProfesores.Tables["Profesores"];

            // Se activa el ReadOnly para evitar la edición. Solo se busca mostrar los registros almacenados.
        }
    }
}
