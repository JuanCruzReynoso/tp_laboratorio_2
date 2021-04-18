using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivoException : Exception
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public ArchivoException()
            : base()
        {

        }

        /// <summary>
        /// Constructor parametrizado 
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivoException(Exception innerException)
            : base(innerException.Message)
        {

        }
    }
}
