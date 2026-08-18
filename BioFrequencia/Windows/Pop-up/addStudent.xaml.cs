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
using BioFrequencia.Database;

namespace BioFrequencia.Windows.Pop_up
{
    /// <summary>
    /// Lógica interna para addStudent.xaml
    /// </summary>
    public partial class addStudent : Window
    {
        clsApiService api = new clsApiService();
        public addStudent()
        {
            InitializeComponent();
        }

        private async void btnRegisterStudent_Click(object sender, RoutedEventArgs e)
        {
            if (txtNameStudent.Text != "" && txtClassroom.Text != "" && dtpDateOfBirth.SelectedDate != null && genero() != "Não especificado")
            {
                try
                {
                    
                    var resposta = await api.RegisterStudent(txtNameStudent.Text, txtClassroom.Text, dtpDateOfBirth.SelectedDate.Value.ToString("yyyy-MM-dd"), genero());
                    if (resposta.Sucesso && resposta.Dados != null)
                    {
                        MessageBox.Show("Aluno cadastrado com sucesso!");
                        return;
                    }
                    MessageBox.Show(resposta.Mensagem ?? "Erro ao cadastrar aluno: " + resposta.Mensagem); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao executar operação: " + ex.Message);
                }
            }
        }

        public string genero()
        {
            if (rdbF.IsChecked == true)
                return "Feminino";
            else if (rdbM.IsChecked == true)
                return "Masculino";
            else
                return "Não especificado";
        }
    }
}
