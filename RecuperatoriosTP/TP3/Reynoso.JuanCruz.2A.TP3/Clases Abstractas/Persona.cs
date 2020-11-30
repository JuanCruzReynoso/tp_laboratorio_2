using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    /// <summary>
    /// Clase abstracta Persona
    /// </summary>
    public abstract class Persona
    {
        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Persona
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor parametrizado de Persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor parametrizado de Persona, agrega el atributo dni
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.dni = dni;
        }

        /// <summary>
        /// Constructor parametrizado de Persona, utiliza la propiedad StringToDNI
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura y escritura de apellido
        /// En la escritura valida el apellido ingresado
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de dni
        /// En la escritura valida el dni ingresado
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de nombre
        /// En la escritura valida el nombre ingresado
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad de escritura, valida el dni ingresado
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Valida el DNI
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Dato validado</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno; 

            if(nacionalidad == ENacionalidad.Argentino && (dato >= 1 && dato <= 89999999))
            {
                retorno = dato;
            }
            else if(nacionalidad == ENacionalidad.Extranjero && (dato >= 90000000 && dato <= 99999999))
            {
                retorno = dato;
            }
            else if(dato < 1 || dato > 99999999)
            {
                throw new DniInvalidoException("El DNI es incorrecto");
            }
            else
            {
                throw new NacionalidadInvalidaException("La nacionalidad no condice con el número de DNI");
            }

            return retorno;
        }

        /// <summary>
        /// Valida que el dato ingresado como string pueda ser pasado a entero
        /// caso contrario arroja excepcion
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Dato validado</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int datoAux;
            int retorno;

            try
            {
                datoAux = int.Parse(dato);
            }
            catch(Exception e)
            {
                throw new DniInvalidoException(e);
            }

            retorno = ValidarDni(nacionalidad, datoAux);

            return retorno;
        }

        /// <summary>
        /// Valida que el dato ingresado no contenga caracteres invalidos
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>Dato validado como string, caso contrario null</returns>
        private static string ValidarNombreApellido(string dato)
        {
            bool flag = true;

            foreach(char item in dato)
            {
                if(char.IsLetter(item) == false)
                {
                    flag = false;
                    break;
                }
            }
            if (flag == false)
            {
                dato = null;
            }

            return dato;
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del metodo ToString
        /// Crea un StringBuilder con los datos de Persona y lo pasa a string
        /// </summary>
        /// <returns>String con los datos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"NOMBRE COMPLETO: {this.apellido}, {this.nombre}");
            sb.AppendLine($"NACIONALIDAD: {this.nacionalidad}");

            return sb.ToString();
        }

        #endregion

        #region Enumerados
        /// <summary>
        /// Enumerado de Nacionalidad
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion
    }
}
