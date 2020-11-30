using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    /// <summary>
    /// Clase sellada Profesor que hereda de Universitario
    /// </summary>
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor estático de profesor
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Constructor por defecto de Profesor
        /// </summary>
        public Profesor()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();

            this._randomClases();
            this._randomClases();
        }

        /// <summary>
        /// Constructor parametrizado de Profesor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"><param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            Profesor profesorAux = new Profesor();

            this.clasesDelDia = profesorAux.clasesDelDia;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Agrega de forma aleatoria una clase y lo asigna a la cola
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)Enum.Parse(typeof(Universidad.EClases), random.Next(0, 4).ToString()));
        }

        /// <summary>
        /// Crea un StringBuilder con los datos de Profesor y lo pasa a string
        /// </summary>
        /// <returns>String con los datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();

        }

        /// <summary>
        /// Crea un StringBuilder con las clase que el profesor debe dictar y lo pasa a string
        /// </summary>
        /// <returns>String con las clases</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA:");
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga de ToString, utiliza MostrarDatos
        /// </summary>
        /// <returns>String con los datos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Compara un profesor con una clase 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>True si el profesor dicta esas clases</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Compara un profesor con una clase  
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns>True si el profesor no dicta esas clases<</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
