using BioFrequencia.Database;
using BioFrequencia.Model;
using BioFrequencia.Response;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BioFrequencia
{
    /// <summary>
    /// Lógica interna para Cadastro.xaml
    /// </summary>
    public partial class Cadastro : Window
    {
        clsApiService api = new clsApiService();
        clsCoordenacao coordLogado;
        public Cadastro()
        {
            InitializeComponent();
        }

        private async void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNome.Text == "" || txtEmail.Text == "" || txtSenha.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            if (txtSenha.Text != txtRepSenha.Text)
            {
                MessageBox.Show("Por favor insira senhas iguais!");
                return;
            }

            var existe = await api.EmailExiste(txtEmail.Text);
            if (existe.Dados != null)
            {
                MessageBox.Show("Usuário já cadastrado!");
                return;
            }

            var resultado = await api.CadastrarCoord(txtNome.Text, txtEmail.Text, txtSenha.Text);
            if (resultado.Sucesso)
            {
                MessageBox.Show("Cadastro realizado com sucesso!");
                this.Close();
                return;
            }

            MessageBox.Show(resultado.Mensagem ?? "Erro ao cadastrar.");
        }

        private async Task<Boolean> UserCadastro(String email)
        {


          
            return false;
        }
    }
}
