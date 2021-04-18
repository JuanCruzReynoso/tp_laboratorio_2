using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comic : Articulo
    {
        #region Atributos
        EGenero genero;
        #endregion


        #region Constructores
        public Comic()
            : base()
        {

        }

        public Comic(string titulo, float precio, EGenero genero)
            : base(titulo, precio)
        {
            this.genero = genero;
        }

        public Comic(int id, string titulo, float precio, EGenero genero)
            : base(titulo, precio)
        {
            this.ID = id;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el string equivalente a el genero del comic
        /// </summary>
        public string GeneroComic
        {
            get
            {
                switch (genero)
                {
                    case EGenero.Aventuras:
                        return "Aventuras";
                    case EGenero.Superheroes:
                        return "Superheroes";
                    case EGenero.Comedia:
                        return "Comedia";
                    case EGenero.Deportivo:
                        return "Deportivo";
                    case EGenero.Fantasia:
                        return "Fantasia";
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
                case "Aventuras":
                    return EGenero.Aventuras;
                case "Superheroes":
                    return EGenero.Superheroes;
                case "Comedia":
                    return EGenero.Comedia;
                case "Deportivo":
                    return EGenero.Deportivo;
                case "Fantasia":
                    return EGenero.Fantasia;
                default:
                    return EGenero.Otro;
            }
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Muestra todos los datos del Comic
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
            Aventuras,
            Superheroes,
            Comedia,
            Deportivo,
            Fantasia,
            Otro
        }
        #endregion
    }
}
