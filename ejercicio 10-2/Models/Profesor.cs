using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_10_2.Models
{
    internal class Profesor
    {
        // MIEMBROS ------------------------------------------------------------------------------
        private string _dni, _nombre, _apellidos, _tlf, _email;

        // PROPIEDADES ---------------------------------------------------------------------------
        public string Dni
        {
            get => _dni;
            set => _dni = value;
        }

        public string Nombre
        {
            get => _nombre;
            set => _nombre = value; 
        }

        public string Apellidos
        {
            get => _apellidos;
            set => _apellidos = value;
        }

        public string Tlf
        {
            get => _tlf;
            set => _tlf = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        // CONSTRUCTOR --------------------------------------------------------------------------
        public Profesor(string dni, string nombre, string apellidos, string tlf, string email)
        {
            _dni = dni;
            _nombre = nombre;
            _apellidos = apellidos;
            _tlf = tlf;
            _email = email;
        }
    }
}
