using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        
        /// <summary>
        /// es una propieda que setea el número, después de validarlo.
        /// </summary>
        private string Numero
        {
            set { this.numero = this.ValidarOperando(value); }
        }

        public Operando() : this(0)
        {
            
        }

        /// <summary>
        /// Constructor parametrizado Operando con double
        /// </summary>
        /// <param name="numero"></param>
        public Operando(double numero)
        {
            this.numero = numero;
        }


        /// <summary>
        /// Constructor parametrizado Operando con string
        /// </summary>
        /// <param name="strNumero"></param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        /// <summary>
        /// Comprueba que el operando sea un número válido.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns> Retorna 0 en caso de error. 
        /// Caso contrario retorna el operando parseado a double. </returns>
        private double ValidarOperando(string strNumero)
        {
            double retorno;
            if (double.TryParse(strNumero, out double parseo) == true)
            {
                retorno = parseo;
            }
            else 
            { 
                retorno = 0; 
            }

            return retorno;
        }

        /// <summary>
        /// Comprueba si el número recibido por parámetro contiene solo 1 y 0
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private static bool EsBinario(string binario) 
        {
            bool retorno = true;

            //for (int i = 0; i < binario.Length; i++)
            //{
            //    if (binario[i] != '0' && binario[i] != '1')
            //    {
            //        retorno = false;
            //    }
            //}
            foreach (char digito in binario)
            {
                if (digito != '0' && digito != '1')
                {
                    retorno = false;
                }
            }
            return retorno;
        }

        /// <summary>
        /// valida que se trate de un binario y luego 
        /// convierte ese número binario a decimal, 
        /// en caso de ser posible.
        /// Caso contrario retorna "Valor inválido".
        /// </summary>
        /// <param name="binario"></param>
        /// <returns> Devuelve el número decimal como string,
        /// o "Valor inválido" en caso de error </returns>
        public static string BinarioDecimal(string binario)
        {
            string exit = "Valor invalido";

            int i;
            double numeroDec = 0;
            int len = binario.Length;

            if (Operando.EsBinario(binario))
            {
                for (i = len; i > 0; i--)
                {
                    if (binario[i - 1] == '1')
                    {
                        numeroDec += Math.Pow(2, len - i);
                    }
                }
                exit = numeroDec.ToString();
            }
            return exit;
        }

        /// <summary>
        /// Convierte un número
        /// decimal a binario, en caso de ser posible.
        /// Caso contrario retornará "Valor inválido".
        /// </summary>
        /// <param name="numero"></param>
        /// <returns> Devuelve el número decimal como string,
        /// o "Valor inválido" en caso de error </returns>
        public static string DecimalBinario(double numero)
        {
            string exit = "Valor invalido";
            double cociente;
            double resto;
            int iNumero;

            iNumero = (int)Math.Abs(numero);
            Console.WriteLine(iNumero);

            if (iNumero > 0)
            {
                exit = "";
                resto = iNumero % 2;
                cociente = Math.Floor((float)iNumero / 2);
                exit = resto.ToString() + exit;

                while (cociente > 1)
                {
                    resto = cociente % 2;
                    cociente = Math.Floor((float)cociente / 2);

                    exit = resto.ToString() + exit;
                }

                exit = cociente.ToString() + exit;
            }

            return exit;
        }

        /// <summary>
        /// Sobrecarga DecimalBinario, recibe un número
        /// en formato string. Lo convierte y llama al
        /// método DecimalBinario(double)
        /// </summary>
        /// <param name="numero"></param>
        /// <returns> Devuelve el número decimal como string,
        /// o "Valor inválido" en caso de error </returns>
        public static string DecimalBinario(string numero)
        {
            //Se crea un objeto, debido a que en el constructor se utiliza el setter,
            //y este permite verificar correctamente el valor recibido.
            //Es una forma de reutilizar código.
            Operando numeroValidado = new Operando(numero);

            return DecimalBinario(Convert.ToDouble(numeroValidado.numero));
        }

        /// <summary>
        /// Sobrecarga de - (resta).
        /// Accede al atributo número de cada operando
        /// y los resta
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns> retorna el resultado de la operación </returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga de * (multiplicación).
        /// Accede al atributo número de cada operando
        /// y los multiplica
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns> retorna el resultado de la operación </returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga de / (división).
        /// Accede al atributo número de cada operando
        /// y los divide, siempre que no sea una división por 0
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns> retorna el resultado de la operación
        /// o double.MinValue en caso de división por 0 </returns>
        public static double operator /(Operando n1, Operando n2)
        {
            double exit = double.MinValue;

            if (n2.numero != 0)
            {
                exit = n1.numero / n2.numero;
            }
            return exit;
        }

        /// <summary>
        /// Sobrecarga de + (suma).
        /// Accede al atributo número de cada operando
        /// y los suma
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns> retorna el resultado de la operación </returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

    }
}
