using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Articulo
    {
        #region Atributos
        EGenero genero;
        #endregion

        #region Constructores
        public Libro()
            : base()
        {

        }

        public Libro(string titulo, float precio, EGenero genero)
            : base(titulo, precio)
        {
            this.genero = genero;
        }

        public Libro(int id, string titulo, float precio, EGenero genero)
            : base(titulo, precio)
        {
            this.ID = id;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el string equivalente a el genero del libro
        /// </summary>
        public string GeneroLibro
        {
            get
            {
                switch (genero)
                {
                    case EGenero.Novela:
                        return "Novela";
                    case EGenero.CienciaFiccion:
                        return "CienciaFiccion";
                    case EGenero.Terror:
                        return "Terror";
                    case EGenero.Biografia:
                        return "Biografia";
                    case EGenero.Infantil:
                        return "Infantil";
                    default:
                        return "Otro";
                }
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Convierte un string recibido a un enumerado de genero
        /// </summary>
        /// <param name="str">string recibido</param>
        /// <returns>Enum equivalente al genero. Si no coincide, por default devuelve otro</returns>
        public static EGenero StringToGenero(string str)
        {
            switch (str)
            {
                case "Novela":
                    return EGenero.Novela;
                case "CienciaFiccion":
                    return EGenero.CienciaFiccion;
                case "Terror":
                    return EGenero.Terror;
                case "Biografia":
                    return EGenero.Biografia;
                case "Infantil":
                    return EGenero.Infantil;
                default:
                    return EGenero.Otro;
            }
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Muestra todos los datos del Libro
        /// </summary>
        /// <returns>String con los datos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"GENERO: {this.genero}");

            return sb.ToString();
        }
        #endregion

        #region Enumerados
        public enum EGenero
        {
            Novela,
            CienciaFiccion,
            Terror,
            Biografia,
            Infantil,
            Otro
        }
        #endregion
    }
}
