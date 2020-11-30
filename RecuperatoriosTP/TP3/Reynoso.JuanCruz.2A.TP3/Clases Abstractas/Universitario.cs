using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    /// <summary>
    /// Clase abstracta Universitario que hereda de Persona
    /// </summary>
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de Universitario
        /// </summary>
        public Universitario()
            :base()
        {

        }

        /// <summary>
        /// Constructor parametrizado de Universitario
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"> de tipo ENacionalidad </param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Crea un StringBuilder con los datos de Universitario y lo pasa a string
        /// </summary>
        /// <returns>String con los datos</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"LEGAJO NÚMERO: {this.legajo}");

            return sb.ToString();
        }

        /// <summary>
        /// Metodo abstracto
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Compara si el dni o legajo de dos universitarios son iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>True si Legajo o DNI son iguales</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI;
        }

        /// <summary>
        /// Compara si el dni o legajo de dos universitarios son distintos
        /// </summary>
        /// <param name="pg1"> de tipo Universitario </param>
        /// <param name="pg2"> de tipo Universitario </param>
        /// <returns>True si Legajo o DNI son distintos </returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Sobrecarga de equals 
        /// Compara si Universitario es igual a this
        /// </summary>
        /// <param name="obj"></param>
        /// <returns> True o False </returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Universitario)
            {
                retorno = this == (Universitario)obj;
            }
            return retorno;
        }
        #endregion


    }
}
