using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Constructor por defecto de DniInvalidoException
        /// </summary>
        public DniInvalidoException() 
            : base("Ha ocurrido un error")
        { }

        /// <summary>
        /// Constructor parametrizado de DniInvalidoException
        /// </summary>
        /// <param name="mensaje"></param>
        public DniInvalidoException(string mensaje)
            : base(mensaje)
        { }

        /// <summary>
        /// constructor parametrizado de DniInvalidoException
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(Exception e) 
            : base(e.Message)
        { }

        /// <summary>
        /// constructor parametrizado de DniInvalidoException
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string mensaje, Exception e) 
            : base(mensaje + e.Message)
        { }

    }
}
