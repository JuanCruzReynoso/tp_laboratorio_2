using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    /// <summary>
    /// Clase publica Txt<T> que implementa la interfaz IArchivo
    /// </summary>
    public class Txt : IArchivo<string>
    {
        /// <summary>
        /// Guarda el dato en un txt 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="dato"></param>
        /// <returns>true si se guardo correctamente</returns>
        public bool Guardar(string archivo, string dato)
        {
            bool retorno = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, false, Encoding.UTF8))
                {
                    sw.WriteLine(dato);
                }
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivoException(e);
            }

            return retorno;
        }
    }
}
