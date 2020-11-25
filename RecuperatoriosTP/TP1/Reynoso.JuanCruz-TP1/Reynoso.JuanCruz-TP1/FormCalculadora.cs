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

namespace Reynoso.JuanCruz_TP1
{
    public partial class FormCalculadora : Form
    {
        #region Metodos
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Termina con la ejecucion del Windows Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Convierte el resultado alojado en lblResultado a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text != "")
            {
                this.lblResultado.Text = new Numero().DecimalBinario(this.lblResultado.Text);
            }
        }

        /// <summary>
        /// Convierte el resultado alojado en lblResultado a decimal
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

        /// <summary>
        /// Ejecuta el metodo Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Ejecuta el metodo Operar pasando como argumento txtNumero1, txt Numero2
        /// y el operador elegido en cmbOperador
        /// Imprime el resultado en el lblResultado
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
        /// Permite confirmar si desea o no cerrar la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (respuesta == DialogResult.No)
            {
                e.Cancel = true; //Cancela el cierre
            }
        }

        /// <summary>
        /// Ejecuta el metodo limpiar antes de mostrar el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Limpia todos los campos del form
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperador.SelectedIndex = 0;
            lblResultado.Text = "";
        }

        /// <summary>
        /// Realiza una operacion entre dos numeros
        /// </summary>
        /// <param name="numero1">Numero1</param>
        /// <param name="numero2">Numero2</param>
        /// <param name="operador">Operador</param>
        /// <returns>Resultado de la operacion</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);

            return Calculadora.Operar(n1, n2, operador);

        }


        #endregion

    }

}
