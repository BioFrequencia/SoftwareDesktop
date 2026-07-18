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
using BioFrequencia.Database;
using BioFrequencia.Model;
using MySql.Data.MySqlClient;

namespace BioFrequencia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        clsApiService api = new clsApiService();
        clsCoordenacao coordLogado;
        StringBuilder str = new StringBuilder();

        public MainWindow()
        {
            InitializeComponent();
        }



        private async void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text == "" || txtSenha.Text == "")
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            var resposta = await api.BuscarCoord(txtEmail.Text, txtSenha.Text);

            if (resposta.Sucesso && resposta.Dados != null)
            {
                coordLogado = resposta.Dados;
                MessageBox.Show("Login realizado com sucesso!");
                Dashboard dash = new Dashboard();
                dash.Show();
                return;
            }

            MessageBox.Show(resposta.Mensagem ?? "Email ou senha incorretos.");
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Cadastro cad = new Cadastro();
            cad.Show();
        }
    }
}