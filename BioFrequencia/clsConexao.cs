using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace BioFrequencia
{
    internal class clsConexao
    {
        MySqlConnection conn = new MySqlConnection();
        public MySqlCommand cmd = new MySqlCommand();

        private string _StrSql;

        public string StrSql
        {
            get { return _StrSql; }
            set { _StrSql = value; }
        }

        private string strConexao = "Host=aws-1-sa-east-1.pooler.supabase.com;Database=postgres;Username=postgres.pprctelpnmgxxrftkiwq;Password=ThisMyPerfect$1;SSL Mode=Require;Trust Server Certificate=true";


        private MySqlConnection AbrirBanco()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = strConexao;
            conn.Open();
            return conn;
        }

        private void FecharBanco(MySqlConnection conn)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public DataSet GetTable()
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter();

            try
            {
                MySqlConnection conn = AbrirBanco();
                cmd.CommandText = StrSql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao retornar DataSet: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public MySqlDataReader GetDataReader()
        {

            try
            {
                MySqlConnection conn = AbrirBanco();
                cmd.CommandText = StrSql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao retornar DataReader: " + ex.Message);
            }
        }

        public int ExeComand()
        {
            try
            {
                MySqlConnection conn = AbrirBanco();
                cmd.CommandText = StrSql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                return cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar comando: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
