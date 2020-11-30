using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    /// <summary>
    /// Clase pública Jornada
    /// </summary>
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Jornada
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor parametrizado de Jornada
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura y escritura de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de Instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Guarda los datos de jornada en el archivo Jornada.txt
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno;
            Texto txt = new Texto();

            retorno = txt.Guardar("Jornada.txt", jornada.ToString());

            return retorno;
        }

        /// <summary>
        /// Lee los datos guardados en Jornada.txt
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string retorno;
            Texto txt = new Texto();
           
            txt.Leer("jornada.txt", out retorno);

            return retorno;
        }

        /// <summary>
        /// Crea un StringBuilder con los datos de Jornada y lo pasa a string
        /// </summary>
        /// <returns>String con los datos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA: ");
            sb.AppendLine($"CLASE DE {this.clase} POR {this.instructor.ToString()}");
           
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<-------------------------------------------------->");

            return sb.ToString();
        }
        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Compara una Jornada con un Alumno
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>true si la clase que toma el alumno es igual a la de la jornada</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno item in j.alumnos)
            {
                if (item == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Compara una Jornada con un Alumno
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>true si la clase que toma el alumno es distinta a la de la jornada</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Valida que el alumno no este previamente agregado
        /// De ser asi lo agrega a la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>La jornada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }

            return j;
        }
        #endregion

    }
}
