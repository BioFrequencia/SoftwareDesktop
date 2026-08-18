using BioFrequencia.Model;
using BioFrequencia.Response;
using System;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BioFrequencia.Database
{
    internal class clsApiService
    {
        public async Task<ApiResponse<string>> CadastrarCoord(string nome, string email, string senha)
        {
            var usuario = new { nome, email, senha };
            try
            {
                var response = await clsConexao.conexao.PostAsJsonAsync("user/addCoord.php", usuario);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ApiResponse<string>>();
                }

                return new ApiResponse<string> { Sucesso = false, Mensagem = $"Erro na API ({(int)response.StatusCode})" };
            }
            catch (Exception ex)
            {
                return new ApiResponse<string> { Sucesso = false, Mensagem = "Falha de conexão: " + ex.Message };
            }
        }


        public async Task<ApiResponse<clsCoordenacao>> EmailExiste(string email)
        {
            try
            {
                var response = await clsConexao.conexao.PostAsJsonAsync("user/verificarEmail.php", new { email });
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ApiResponse<clsCoordenacao>>();
                }

                return new ApiResponse<clsCoordenacao> { Sucesso = false, Mensagem = $"Erro na API ({(int)response.StatusCode})" };
            }
            catch (Exception ex)
            {
                return new ApiResponse<clsCoordenacao> { Sucesso = false, Mensagem = "Falha de conexão: " + ex.Message };
            }
        }

        public async Task<ApiResponse<clsCoordenacao>> BuscarCoord(string email, string senha)
        {
            var coordenador = new { email, senha };
            try
            {
                var response = await clsConexao.conexao.PostAsJsonAsync("user/selectCoord.php", coordenador);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ApiResponse<clsCoordenacao>>();
                }

                return new ApiResponse<clsCoordenacao> { Sucesso = false, Mensagem = $"Erro na API ({(int)response.StatusCode})" };
            }
            catch (Exception ex)
            {
                return new ApiResponse<clsCoordenacao> { Sucesso = false, Mensagem = "Falha de conexão: " + ex.Message };
            }
        }

        public async Task<ApiResponse<Student>> RegisterStudent(string nome, string sala, string nasc, string genero)
        {
            var student = new { nome, sala, nasc, genero };
            try
            {
                var response = await clsConexao.conexao.PostAsJsonAsync("user/addaluno.php", student);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ApiResponse<Student>>();
                }
                return new ApiResponse<Student> { Sucesso = false, Mensagem = $"Erro na API ({(int)response.StatusCode})" };
            }
            catch (Exception ex)
            {
                return new ApiResponse<Student> { Sucesso = false, Mensagem = "Falha de conexão: " + ex.Message };
            }
        }
    }
}