using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos
        private double numero;
        #endregion

        #region Propiedades
        /// <summary>
        /// Permite asignar un número ya validado al atributo numero
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(Convert.ToString(value));
            }
        }

        #endregion

        #region Contructores
        /// <summary>
        /// Constructor por defecto de Numero, asigna valor 0 al atributo numero
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor sobrecargado de Numero, recibe un double por parametro
        /// </summary>
        /// <param name="numero">Numero a guardar</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor sobrecargado de Numero, recibe un string por parametro
        /// </summary>
        /// <param name="strNumero">Numero a guardar de tipo string</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Convierte un numero binario a decimal
        /// </summary>
        /// <param name="binario">Numero binario a convertir</param>
        /// <returns>Numero decimal pasado a string o mensaje de error "valor invalido" </returns>
        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor invalido";

            if(this.EsBinario(binario))
            {
                double numero = 0;

                for (int i = 0; i < binario.Length; i++)
                {
                    if (binario[i] == '1')
                    {
                        numero = numero + Math.Pow(2, binario.Length-1);
                    }
                }

                retorno = numero.ToString();
            }

            return retorno;
        }

        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero">Numero decimal a convertir</param>
        /// <returns>Numero binario pasado a string</returns>
        public string DecimalBinario(double numero)
        {
            string binario = null;
            int numeroAux = (int)numero;
            int resto;

            while (numeroAux > 1)
            {
                resto = numeroAux % 2;
                binario = resto.ToString() + binario;
                numeroAux = numeroAux / 2;
            }
            binario = numeroAux.ToString() + binario;

            return binario;
        }

        /// <summary>
        /// Parsea un string a double y convierte el numero de Decimal a Binario
        /// </summary>
        /// <param name="numero">Numero decimal de tipo string a convertir</param>
        /// <returns>Decimal de tipo double convertido a binario o </returns>
        public string DecimalBinario(string numero)
        {
            double numeroAux;
            string retorno = "Valor invalido";
            
            if(double.TryParse(numero, out numeroAux))
            {
                retorno = DecimalBinario(numeroAux);
            }

            return retorno;
        }

        /// <summary>
        /// Recorre el argumento de tipo string y comprueba si es un numero binario
        /// </summary>
        /// <param name="binario">String a validar</param>
        /// <returns> True si es binario, caso contrario, False </returns>
        private bool EsBinario(string binario)
        {
            bool retorno = true;

            for(int i = 0; i<binario.Length; i++)
            {
                if(binario[i] != '0' && binario[i] != '1')
                {
                    retorno = false;
                    break;
                }
            }

            return retorno;
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Suma dos numeros
        /// </summary>
        /// <param name="n1">Numero uno</param>
        /// <param name="n2">Numero dos</param>
        /// <returns>Resultado de la operacion</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Resta dos numeros
        /// </summary>
        /// <param name="n1">Numero uno</param>
        /// <param name="n2">Numero dos</param>
        /// <returns>Resultado de la operacion</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Divide dos numeros
        /// </summary>
        /// <param name="n1">Numero uno</param>
        /// <param name="n2">Numero dos</param>
        /// <returns>Resultado de la operacion</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno;

            if(n2.numero == 0)
            {
                retorno = double.MinValue;
            }
            else
            {
                retorno = n1.numero / n2.numero;
            }

            return retorno;
        }

        /// <summary>
        /// Multiplica dos numeros
        /// </summary>
        /// <param name="n1">Numero uno</param>
        /// <param name="n2">Numero dos</param>
        /// <returns>Resultado de la operacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Valida que el valor ingresado de tipo string sea un numero
        /// </summary>
        /// <param name="strNumero">Numero de tipo string a validar</param>
        /// <returns>Numero validado y pasado a double, caso contrario devuelve 0</returns>
        private double ValidarNumero(string strNumero)
        {
            double numeroAux = 0;

            double.TryParse(strNumero, out numeroAux);

            return numeroAux;
        }



        #endregion
    }
}
