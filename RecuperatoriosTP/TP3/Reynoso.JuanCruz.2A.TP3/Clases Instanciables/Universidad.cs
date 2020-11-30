using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    /// <summary>
    /// Clase publica Universidad
    /// </summary>
    public class Universidad
    {
        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Universidad
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura y escritura Alumnos
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
        /// Propiedad de lectura y escritura de Instructores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura Jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura i en la lista jornada
        /// </summary>
        /// <param name="i"></param>
        public Jornada this[int i]
        {
            get
            {
                return jornada[i];
            }
            set
            {
                jornada[i] = value;
            }
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Guarda los datos de Universidad en el archivo universidad.xml
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            bool retorno;

            Xml<Universidad> xml = new Xml<Universidad>();
            retorno = xml.Guardar("Universidad.xml", uni);

            return retorno;
        }

        /// <summary>
        /// Lee los datos guardados en universidad.xml
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Universidad retorno = new Universidad();
            Xml<Universidad> xml = new Xml<Universidad>();

            xml.Leer("Universidad.xml", out retorno);

            return retorno;
        }

        /// <summary>
        /// Crea un StringBuilder con los datos de Universidad y lo pasa a stringd
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>String con los datos</returns>
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada item in uni.jornada)
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
            return MostrarDatos(this);
        }
        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Compara una Universidad con un Alumno
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>True si el alumno esta inscripto</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno item in g.Alumnos)
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
        /// Compara una Universidad con un Alumno
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>True si el alumno no esta inscripto</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }


        /// <summary>
        /// Compara una Universidad con un Profesor 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>True si el profesor esta dando clases en esa universidad</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor item in g.profesores)
            {
                if (item == i)
                {
                    retorno = true;
                }
            }

            return retorno;
        }


        /// <summary>
        /// Compara una Universidad con un Profesor 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>True si el profesor esta dando clases en esa universidad</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }


        /// <summary>
        /// La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase.
        /// Sino, lanzará la Excepción SinProfesorException
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor profesorAux = null;

            foreach (Profesor item in u.profesores)
            {
                if (item == clase)
                {
                    profesorAux = item;
                    break;
                }
            }

            if (profesorAux is null)
            {
                throw new SinProfesorException("No hay profesor para la clase");
            }

            return profesorAux;
        }


        /// <summary>
        /// Si una universidad y una clase son distintos, retornará el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor profesorAux = null;

            foreach (Profesor item in u.profesores)
            {
                if (item != clase)
                {
                    profesorAux = item;
                    break;
                }
            }

            if (profesorAux is null)
            {
                throw new SinProfesorException("Todos los profesores pueden dar la clase");
            }

            return profesorAux;
        }

        /// <summary>
        /// Valida que el alumno no este previamente agregado
        /// De ser asi lo agrega a la universidad
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns>La universidad</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException("Alumno repetido");
            }

            return u;
        }

        /// <summary>
        /// Valida que el profesor no este previamente agregado
        /// De ser asi lo agrega a la universidad
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns>La universidad</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }

            return u;
        }

        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada 
        /// indicando la lase, un Profesor que pueda darla(según su atributo ClasesDelDia) 
        /// y la lista de alumnos que la toman(todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornadaAux = new Jornada(clase, g == clase);

            foreach (Alumno item in g.alumnos)
            {
                if (item == clase)
                {
                    jornadaAux += item;
                }
            }

            g.jornada.Add(jornadaAux);

            return g;
        }
        #endregion

        #region Enumerados
        public enum EClases { 
            Programacion, 
            Laboratorio, 
            Legislacion, 
            SPD }
        #endregion
    }
}
