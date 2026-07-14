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
        clsConexao conexao = new clsConexao();
        StringBuilder str = new StringBuilder();
        MySqlDataReader reader;
        public Cadastro()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNome.Text == "" || txtEmail.Text == "" || txtSenha.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            if (UserCadastro(txtEmail.Text))
            {
                return;
            }

            if (txtSenha.Text != txtRepSenha.Text)
            {
                MessageBox.Show("Por favor insira senhas iguais!");
                return;
            }

            try
            {
                str.Clear();
                str.AppendLine("INSERT INTO tb_coordenacao (nome_coordenacao, email_coordenacao, senha_coordenacao)" +
                    " VALUES (@nome, @email, @senha)");

                conexao.cmd.Parameters.Clear();
                conexao.cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                conexao.cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                conexao.cmd.Parameters.AddWithValue("@senha", txtSenha.Text);

                conexao.StrSql = str.ToString();

                if (conexao.ExeComand() > 0)
                {
                    MessageBox.Show("Cadastro realizado com sucesso!");
                    this.Close();
                    return;

                }

                MessageBox.Show("Erro ao realizar cadastro. Tente novamente.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar cadastro: " + ex.Message);
            }
        }

        private Boolean UserCadastro(String email)
        {
            str.Clear();
            str.AppendLine("SELECT * FROM tb_coordenacao WHERE email_coordenacao = @email");

            conexao.cmd.Parameters.Clear();
            conexao.cmd.Parameters.AddWithValue("@email", email);
            conexao.StrSql = str.ToString();

            reader = conexao.GetDataReader();

            if (reader.Read())
            {
                MessageBox.Show("Usuário já cadastrado!");
                return true;
            }
            return false;
        }
    }
}
