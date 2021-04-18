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
    public class AccesoDatosComic : ConexionBD<Comic>
    {
        /// <summary>
        /// Carga todos los registros de la tabla Comic
        /// </summary>
        /// <returns>Lista de objetos Comic con los  de la tabla</returns>
        public override List<Comic> Cargar()
        {
            List<Comic> listaComics = new List<Comic>();
            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SELECT * FROM Comic", this.conexion);
                lector = this.comando.ExecuteReader();
                while (lector.Read())
                {
                    Comic comicAux = new Comic((int)lector["id"],
                                               lector["Titulo"].ToString(),
                                               (float)lector["Precio"],
                                               Comic.StringToGenero(lector["Genero"].ToString()));

                    listaComics.Add(comicAux);
                }

                return listaComics;
            }
            catch (Exception)
            {
                throw new BDException("No se logro cargar la tabla Comic.");
            }
            finally
            {
                this.conexion.Close();
            }
        }

        /// <summary>
        /// Agregar un registro a la tabla Comic
        /// </summary>
        /// <param name="comic">Objeto Comic a agregar</param>
        /// <returns>Devuelve true si se pudo agregar, caso contrario arroja excepcion</returns>
        public override bool Agregar(Comic comic)
        {
            bool retorno = false;

            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("INSERT INTO Comic (Titulo,Precio,Genero)" +
                    " VALUES (@titulo, @precio, @genero)", this.conexion);

                this.comando.Parameters.AddWithValue("@titulo", comic.Titulo);
                this.comando.Parameters.AddWithValue("@precio", comic.Precio);
                this.comando.Parameters.AddWithValue("@genero", comic.GeneroComic);

                this.comando.ExecuteNonQuery();

                retorno = true;
            }
            catch
            {
                throw new BDException("No se logro agregar a la tabla Comic");
            }
            finally
            {
                this.conexion.Close();
            }

            return retorno;
        }
    }
}
