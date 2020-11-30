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
    /// Clase publica Texto que implementa la interfaz IArchivo
    /// </summary>
    public class Texto : IArchivo<string>
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
                throw new ArchivosException(e);
            }

            return retorno;
        }

        /// <summary>
        /// Lee el archivo txt y pasa el dato por parametro
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>True si se leyo correctamente</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;

            try
            {
                using (StreamReader sr = new StreamReader(archivo, Encoding.UTF8))
                {
                    datos = sr.ReadToEnd();
                }
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }
    }
}
