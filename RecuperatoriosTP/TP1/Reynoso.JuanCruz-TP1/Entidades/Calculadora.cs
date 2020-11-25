using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Metodos
        /// <summary>
        /// Realiza una operacion entre dos numeros segun el retorno de ValidarOperador.
        /// </summary>
        /// <param name="num1">Primer argumento de la operacion</param>
        /// <param name="num2">Segundo argumento de la operacion</param>
        /// <param name="operador">Indica la operacion a realizar segun el retorno de ValidarOperador</param> 
        /// <returns>Resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;
            operador = ValidarOperador(operador[0]);
            
            switch (operador)
            {
                case "+":
                    retorno = num1 + num2;
                    break;
                case "-":
                    retorno = num1 - num2;
                    break;
                case "/":
                    retorno = num1 / num2;
                    break;
                case "*":
                    retorno = num1 * num2;
                    break;
                default:
                    retorno = 0;
                    break;
            }

            return retorno;
        }

        /// <summary>
        /// Valida el operador ingresado (+, -, /, *).
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>Operador validado, si es invalido devuelve +</returns>
        private static string ValidarOperador(char operador)
        {
            string retorno = "+";

            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                retorno = operador.ToString();
            }

            return retorno;
        }

        #endregion
    }
}
