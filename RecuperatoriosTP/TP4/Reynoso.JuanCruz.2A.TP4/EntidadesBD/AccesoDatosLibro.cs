using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;
using Excepciones;

namespace EntidadesBD
{
    public class AccesoDatosLibro : ConexionBD<Libro>
    {
        /// <summary>
        /// Carga todos los registros de la tabla Libro
        /// </summary>
        /// <returns>Lista de objetos Libro con los datos de la tabla</returns>
        public override List<Libro> Cargar()
        {
            List<Libro> listaLibros = new List<Libro>();
            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SELECT * FROM Libro", this.conexion);
                lector = this.comando.ExecuteReader();
                while (lector.Read())
                {
                    Libro libroAux = new Libro((int)lector["id"],
                                               lector["Titulo"].ToString(),
                                               (float)lector["Precio"],
                                               Libro.StringToGenero(lector["Genero"].ToString()));

                    listaLibros.Add(libroAux);
                }

                return listaLibros;
            }
            catch (Exception)
            {
                throw new BDException("No se logro cargar la tabla.");
            }
            finally
            {
                this.conexion.Close();
            }
        }

        /// <summary>
        /// Agregar un registro a la tabla Libro
        /// </summary>
        /// <param name="libro">Objeto Libro a agregar</param>
        /// <returns>Devuelve true si se pudo agregar, caso contrario arroja excepcion</returns>
        public override bool Agregar(Libro libro)
        {
            bool retorno = false;

            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("INSERT INTO Libro (Titulo,Precio,Genero)" +
                    " VALUES (@titulo, @precio, @genero)", this.conexion);

                this.comando.Parameters.AddWithValue("@titulo", libro.Titulo);
                this.comando.Parameters.AddWithValue("@precio", libro.Precio);
                this.comando.Parameters.AddWithValue("@genero", libro.GeneroLibro);

                this.comando.ExecuteNonQuery();

                retorno = true;
            }
            catch 
            {
                throw new BDException("No se logro agregar a la tabla");
            }
            finally 
            {
                this.conexion.Close();
            }

            return retorno;
        }
    }
}
