using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    /// <summary>
    /// Clase abstracta Articulo
    /// </summary>
    public abstract class Articulo    
    {
        #region Atributos
        private int id;
        private string titulo;
        private float precio;
        #endregion

        #region Constructores
        public Articulo()
        { }

        public Articulo(string titulo, float precio)
        {
            this.titulo = titulo;
            this.precio = precio;
        }

        public Articulo(int id, string titulo, float precio)
            : this (titulo, precio)
        {
            this.id = id;
        }
        #endregion

        #region Propiedades
        public int ID
        {
            get 
            { 
                return this.id; 
            }
            set
            {
                this.id = value;
            }
        }

        public string Titulo
        {
            get
            {
                return this.titulo;
            }
            set
            {
                this.titulo = value;
            }
        }

        public float Precio
        {
            get 
            { 
                return this.precio; 
            }
            set 
            {
                this.precio = value;
            }
        }
        #endregion


        #region Sobrecargas
        /// <summary>
        /// Muestra los datos del articulo
        /// </summary>
        /// <returns>String con los datos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
      
            sb.AppendLine($"TITULO: {this.titulo}");
            sb.AppendLine($"PRECIO: {this.precio}");

            return sb.ToString();
        }
        #endregion
    }

}
