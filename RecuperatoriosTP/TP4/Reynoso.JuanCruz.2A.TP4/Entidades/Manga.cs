using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Manga : Articulo
    {
        #region Atributos
        EGenero genero;
        #endregion

        #region Constructores
        public Manga()
            : base()
        {

        }

        public Manga(string titulo, float precio, EGenero genero)
            : base(titulo, precio)
        {
            this.genero = genero;
        }

        public Manga(int id, string titulo, float precio, EGenero genero)
            : base(titulo, precio)
        {
            this.ID = id;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el string equivalente a el genero del manga
        /// </summary>
        public string GeneroManga
        {
            get
            {
                switch (genero)
                {
                    case EGenero.Kodomo:
                        return "Kodomo";
                    case EGenero.Shonen:
                        return "Shonen";
                    case EGenero.Shojo:
                        return "Shojo";
                    case EGenero.Seinen:
                        return "Seinen";
                    case EGenero.Josei:
                        return "Josei";
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
                case "Kodomo":
                    return EGenero.Kodomo;
                case "Shonen":
                    return EGenero.Shonen;
                case "Shojo":
                    return EGenero.Shojo;
                case "Seinen":
                    return EGenero.Seinen;
                case "Josei":
                    return EGenero.Josei;
                default:
                    return EGenero.Otro;
            }
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Muestra todos los datos del Manga
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
            Kodomo, 
            Shonen, 
            Shojo,
            Seinen, 
            Josei,
            Otro
        }
        #endregion
    }
}
