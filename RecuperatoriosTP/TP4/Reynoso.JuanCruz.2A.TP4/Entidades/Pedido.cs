using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase genérica Pedido<T>, puede contener Articulos o clases que hereden de Articulo
    /// </summary>

    public class Pedido 
    {
        #region Atributos
        public List<Articulo> listado;
        public float total;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Pedido()
        {
            listado = new List<Articulo>();
        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="total"></param>
        public Pedido(float total) 
            : this()
        {
            this.total = total;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de solo lectura
        /// Retorna el precio total del pedido
        /// </summary>
        public float PrecioTotal
        {
            get
            {
                float total = 0;
                foreach (Articulo item in listado)
                {
                    total += item.Precio;
                }
                return total;
            }
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Permite agregar un articulo al pedido
        /// </summary>
        /// <param name="p"></param>
        /// <param name="a"></param>
        /// <returns>pedido con articulo agregado</returns>
        public static Pedido operator +(Pedido p, Articulo a)
        {
            p.listado.Add(a);
            return p;
        }

        /// <summary>
        /// Método estático Guardar, que guarda en un archivo de texto la venta realizada
        /// </summary>
        /// <param name="p"><T> </param>
        /// <returns> true si pudo, caso contrario false y arroja excepcion</returns>
        public void Guardar(Pedido p)
        {
            Txt txt = new Txt();
            Xml<Pedido> xml = new Xml<Pedido>();

            xml.Guardar("BackupPedido.xml", p);
            txt.Guardar("Pedido.txt", p.ToString());
        }

        /// <summary>
        /// Devuelve los datos del pedido 
        /// </summary>
        /// <returns>string con los datos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("--------------------");
            sb.AppendLine($"FECHA Y HORA: {DateTime.Now.ToString()}");
            sb.AppendLine("LISTA DE PEDIDO");
            sb.AppendLine("--------------------");
            foreach (Articulo item in this.listado)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine($"TOTAL: {this.PrecioTotal}");

            return sb.ToString();
        }
        #endregion
    }
}
