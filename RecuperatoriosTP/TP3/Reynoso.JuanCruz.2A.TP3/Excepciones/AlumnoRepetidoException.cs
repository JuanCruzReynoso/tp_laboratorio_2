using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor por defecto de AlumnoRepetidoException
        /// </summary>
        public AlumnoRepetidoException()
            : base("Alumno repetido")
        {

        }

        /// <summary>
        /// Constructor parametrizado de AlumnoRepetidoException
        /// </summary>
        /// <param name="mensaje"></param>
        public AlumnoRepetidoException(string mensaje)
            : base(mensaje)
        {

        }
    }
}
