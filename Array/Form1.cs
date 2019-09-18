using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Array
{
    public partial class Form1 : Form
    {
        private Conta[] contas;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 1 - numeros[4]
            // 2 - Para acessar o quinto elemento, fazemos numeros[4], pois as posições do array começam no 0(zero).
            // 3 - numero.Length
            // 4 - 

            // criando o array para guardar as contas
            contas = new Conta[3];

            // vamos inicializar algumas instâncias de Conta.
            this.contas[0] = new Conta();
            this.contas[0].Titular = new Cliente("victor");
            this.contas[0].Numero = 1;
            this.contas[0].Saldo = 100.00;

            this.contas[1] = new ContaPoupanca();
            this.contas[1].Titular = new Cliente("mauricio");
            this.contas[1].Numero = 2;

            this.contas[2] = new ContaCorrente();
            this.contas[2].Titular = new Cliente("osni");
            this.contas[2].Numero = 3;

            foreach (Conta conta in contas)
            {
                comboContas.Items.Add(conta.Titular.Nome);
                comboDestinoTransferencia.Items.Add(conta.Titular.Nome);
            }

        }

        //Questão 01
        private void BotaoBusca_Click(object sender, EventArgs e)
        {
            //int indice = Convert.ToInt32(textoIndice.Text);
            int indice = comboDestinoTransferencia.SelectedIndex;

            Conta selecionada = this.contas[indice];

            textoNumero.Text = Convert.ToString(selecionada.Numero);
            textoTitular.Text = selecionada.Titular.Nome;
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
        }

        private void BotaoDeposito_Click(object sender, EventArgs e)
        {
            // primeiro precisamos recuperar o índice da conta selecionada
            int indice = comboContas.SelectedIndex;

            //int indice = Convert.ToInt32(textoIndice.Text);

            // e depois precisamos ler a posição correta do array.
            Conta selecionada = this.contas[indice];

            double valor = Convert.ToDouble(textoValor.Text);
            selecionada.Deposita(valor);
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
        }

        private void BotaoSaque_Click(object sender, EventArgs e)
        {
            //int indice = Convert.ToInt32(textoIndice.Text);
            int indice = comboContas.SelectedIndex;

            Conta selecionada = this.contas[indice];

            double valor = Convert.ToDouble(textoValor.Text);
            selecionada.Saca(valor);
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
        }

        private void ComboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int indice = comboContas.SelectedIndex;
            Conta selecionada = contas[indice];
            textoTitular.Text = selecionada.Titular.Nome;
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
            textoNumero.Text = Convert.ToString(selecionada.Numero);

        }

        // Questão 2
        private void Button1_Click(object sender, EventArgs e)
        {

            int indiceOrigem = comboContas.SelectedIndex;
            Conta contaOrigem = this.contas[indiceOrigem];
            
            int indiceDaContaDestino = comboDestinoTransferencia.SelectedIndex;
            Conta contaDestino = this.contas[indiceDaContaDestino];
           
            double valorTransferencia = Convert.ToDouble(textoValor.Text);
            
            contaOrigem.Transfere(contaDestino, valorTransferencia);

        }

        private void TextoIndice_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboDestinoTransferencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = comboDestinoTransferencia.SelectedIndex;
            Conta selecionadaDestinoTransferencia = contas[indice];
        }
    }
}
