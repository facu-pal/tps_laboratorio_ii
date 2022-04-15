using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida que el operador recibido sea +, -, / o *.
        /// Caso contrario retornará +.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns> Retorna el operador recibido, o '+' en caso de error </returns>
        private static char ValidarOperador(char operador)
        {
            char retorno = '+';
            if (operador == '-' || operador == '*' || operador == '/' || operador == '+')
            {
                retorno = operador;
            }

            return retorno;
        }

        /// <summary>
        /// Realiza la operacion correspondiente entre los dos Operandos.
        /// mediante las sobrecargas de los operadores.
        /// </summary>
        /// <param name=num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns> Retorna el resultado obtenido </returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            operador = ValidarOperador(operador);
            double resultado = 0;

            switch (operador)
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
            }

            return resultado;
        }
    }
}
