using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    /// <summary>
    /// Clase pública Xml<T>, que implementa la interfaz IArchivo
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda el dato en un xml
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true si se guardo correctamente</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;

            try
            {
                using (XmlTextWriter xmlw = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer xmls = new XmlSerializer(typeof(T));

                    xmls.Serialize(xmlw, datos);
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
