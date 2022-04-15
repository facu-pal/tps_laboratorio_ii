using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class formCalculadora : Form
    {
        public formCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Limpia el formulario al iniciar el programa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Vacía todos los controles (menos el historial de operaciones)
        /// </summary>
        private void Limpiar()
        {
            lblResultado.Text = "0";
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.SelectedIndex = 0;
        }

        /// <summary>
        /// Llama al método limpiar, para vaciar los controles.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Crea los objetos Operando, 
        /// controla que el operador no sea espacio vacío
        /// y devuelve el resultado de la operación correspondiente
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns> resultado de la operación </returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double retorno;
            char charOperador = '\0';

            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);

            if (operador != "")
            {
                charOperador = char.Parse(operador);
            }

            retorno = Calculadora.Operar(num1, num2, charOperador);

            return retorno;
        }

        /// <summary>
        /// Llama al método Operar, y escribe el resultado en lblResultado
        /// También escribe la operación en lstOperaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            StringBuilder Operacion = new StringBuilder();

            if (txtNumero1.Text == "" || txtNumero2.Text == "")
            {
                MessageBox.Show("le falta ingresar los numeros");
            }
            else if (cmbOperador.Text == "")
            {
                MessageBox.Show("No puso ningun operador, se usa el operador + por defecto");
                lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
                Operacion.Append(txtNumero1.Text);
                Operacion.Append(" + ");
                Operacion.Append(" " + txtNumero2.Text);
                Operacion.Append(" = " + lblResultado.Text);
                lstOperaciones.Items.Add(Operacion);
            }
            else if (txtNumero2.Text == "0" && cmbOperador.Text == "/")
            {
                MessageBox.Show("No se puede dividir por 0(cero)");
            }
            else
            {
                lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
                Operacion.Append(txtNumero1.Text);
                Operacion.Append(" " + cmbOperador.Text);
                Operacion.Append(" " + txtNumero2.Text);
                Operacion.Append(" = " + lblResultado.Text);
                lstOperaciones.Items.Add(Operacion);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Pregunta al usuario si está seguro de querer salir del programa, antes de cerrarlo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Siempre que lblResultado no esté vacío
        /// le escribe su valor convertido a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {

            StringBuilder convercion = new StringBuilder();
            string ResultViejo = lblResultado.Text;

            if (lblResultado.Text != "")
            {
                lblResultado.Text = Operando.DecimalBinario(lblResultado.Text);
                convercion.AppendLine($"{ResultViejo}");
                convercion.Append($" =  {lblResultado.Text}");
                lstOperaciones.Items.Add("convercion a binario");
                lstOperaciones.Items.Add(convercion);

            }
        }

        /// <summary>
        /// Siempre que lblResultado no esté vacío,
        /// le escribe su valor convertido a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            StringBuilder convercion = new StringBuilder();
            string ResultViejo = lblResultado.Text;
            if (lblResultado.Text != "")
            {
                lblResultado.Text = Operando.BinarioDecimal(lblResultado.Text);
                convercion.AppendLine($"{ResultViejo}");
                convercion.Append($" =  {lblResultado.Text}");
                lstOperaciones.Items.Add("convercion a decimal");
                lstOperaciones.Items.Add(convercion);
            }
        }
    }
}
