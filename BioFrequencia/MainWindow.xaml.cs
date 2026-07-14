using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace BioFrequencia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        clsConexao conexao = new clsConexao();
        StringBuilder str = new StringBuilder();
        MySqlDataReader reader;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text == "" || txtSenha.Text == "")
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            try
            {
                str.Clear();
                str.AppendLine("SELECT * FROM  tb_coordenacao WHERE email_coordenacao = @email && senha_coordenacao = @senha");

                conexao.cmd.Parameters.Clear();
                conexao.cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                conexao.cmd.Parameters.AddWithValue("@senha", txtSenha.Text);

                conexao.StrSql = str.ToString();

                reader = conexao.GetDataReader();
                if (reader.Read())
                {
                    MessageBox.Show("Login realizado com sucesso!");
                    Dashboard dash = new Dashboard();
                    dash.Show();
                    return;
                }

                MessageBox.Show("Email ou senha incorretos. Tente novamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar login: " + ex.Message);
            }
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Cadastro cad = new Cadastro();
            cad.Show();
        }
    }
}