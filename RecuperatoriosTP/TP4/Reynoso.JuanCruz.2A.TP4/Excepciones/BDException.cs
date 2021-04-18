using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Excepcion que sera lanzada de no poder realizar operaciones en la BD.
    /// </summary>
    public class BDException : Exception
    {
        #region Constructores
        /// <summary>
        /// Constructor parametrizado.
        /// </summary>
        /// <param name="mensaje">Mensaje a arrojar</param>
        public BDException(string mensaje) 
            : base(mensaje)
        {

        }
        #endregion
    }
}
