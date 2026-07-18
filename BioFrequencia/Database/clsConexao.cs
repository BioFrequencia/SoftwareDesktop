using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;

namespace BioFrequencia.Database
{
    internal class clsConexao
    {
        public static readonly HttpClient conexao = new()
        {
            BaseAddress = new Uri("http://localhost/BioFrequenciaApi/")
        };
    }
}
