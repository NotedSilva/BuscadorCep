using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mskCep.Focus();
        }

        private void mskCep_Leave(object sender, EventArgs e)
        {
            BuscarCep(mskCep.Text);
        }

        async Task BuscarCep(string cep) 
        {
            try
            {
                var cepBuscar = RestService.For<ICepApiService>("https://viacep.com.br/");
                var endereco = await cepBuscar.GetAddressAsync(cep);
                
                    txtEndereco.Text = endereco.Endereco;
                    txtComplemento.Text = endereco.Complemento;
                    txtBairro.Text = endereco.Bairro;
                    txtCidade.Text = endereco.Cidade;
                    txtEstado.Text = endereco.Uf;

                    txtNumero.Focus();


            }
            catch (Exception e)
            {
                MessageBox.Show("Falha! /n" + e);
            }
        }

        private void mskCep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {

                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mskCep.Clear();
            txtEndereco.Clear();
            txtNumero.Clear();
            txtComplemento.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            mskCep.Focus();
        }
    }
}
