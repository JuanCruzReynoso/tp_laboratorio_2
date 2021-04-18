using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Interfaz IArchivo genérica
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IArchivo<T>
    {
 
        /// <summary>
        /// Firma del metodo de escritura
        /// </summary>
        /// <param name="archivo"> </param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);

    }
}
