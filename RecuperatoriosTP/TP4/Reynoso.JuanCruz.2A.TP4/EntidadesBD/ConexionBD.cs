using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EntidadesBD
{
    public abstract class ConexionBD<T> 
    {
        #region Atributos
        protected SqlConnection conexion;
        protected SqlCommand comando;
        protected SqlDataReader lector;
        #endregion

        #region Constructores
        public ConexionBD()
        {
            this.conexion = new SqlConnection(Properties.Settings.Default.LibreriaBD);
        }
        #endregion

        #region Firmas
        public abstract List<T> Cargar();
        public abstract bool Agregar(T articulo);

        #endregion


    }
}
