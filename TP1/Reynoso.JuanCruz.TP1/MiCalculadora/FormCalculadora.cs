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
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Borra todos los datos de los campos del formulario.
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Clear();
            cmbOperador.SelectedIndex = 0;
            lblResultado.Text = "";
            txtNumero2.Clear();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Realiza una operacion entre dos numeros
        /// </summary>
        /// <param name="numero1">Primer argumento de la operacion</param>
        /// <param name="numero2">Segundo argumento de la operacion</param>
        /// <param name="operador">Operador</param>
        /// <returns>Resultado de la operacion</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);

            return Calculadora.Operar(n1, n2, operador);
        }

        /// <summary>
        /// Ejecuta el metodo Operar pasando como argumento txtNumero1, txt Numero2 y cmbOperador
        /// Muestra el resultado en lblResultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(cmbOperador.Text) == false)
            {
                double resultado = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);

                this.lblResultado.Text = resultado.ToString();
            }
        }

        /// <summary>
        /// Finaliza la ejecucion del Windows Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Convierte el resultado en lblResultado a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if(this.lblResultado.Text != "")
            {
                this.lblResultado.Text = new Numero().DecimalBinario(this.lblResultado.Text);
            }
        }

        /// <summary>
        /// Convierte el resultado en lblResultado a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text != "")
            {
                this.lblResultado.Text = new Numero().BinarioDecimal(this.lblResultado.Text);
            }
        }
    }
}
