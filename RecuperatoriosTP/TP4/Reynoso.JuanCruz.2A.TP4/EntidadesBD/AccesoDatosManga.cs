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
    public class AccesoDatosManga : ConexionBD<Manga>
    {
        /// <summary>
        /// Carga todos los registros de la tabla Manga
        /// </summary>
        /// <returns>Lista de objetos Manga con los datos de la tabla</returns>
        public override List<Manga> Cargar()
        {
            List<Manga> listaManga = new List<Manga>();
            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SELECT * FROM Manga", this.conexion);
                lector = this.comando.ExecuteReader();
                while (lector.Read())
                {
                    Manga mangaAux = new Manga((int)lector["id"],
                                               lector["Titulo"].ToString(),
                                               (float)lector["Precio"],
                                               Manga.StringToGenero(lector["Genero"].ToString()));

                    listaManga.Add(mangaAux);
                }

                return listaManga;
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
        /// Agregar un registro a la tabla Manga
        /// </summary>
        /// <param name="manga">Objeto Manga a agregar</param>
        /// <returns>Devuelve true si se pudo agregar, caso contrario arroja excepcion</returns>
        public override bool Agregar(Manga manga)
        {
            bool retorno = false;

            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("INSERT INTO Manga (Titulo,Precio,Genero)" +
                    " VALUES (@titulo, @precio, @genero)", this.conexion);

                this.comando.Parameters.AddWithValue("@titulo", manga.Titulo);
                this.comando.Parameters.AddWithValue("@precio", manga.Precio);
                this.comando.Parameters.AddWithValue("@genero", manga.GeneroManga);

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
