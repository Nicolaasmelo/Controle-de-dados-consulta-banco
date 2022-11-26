using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste
{
    
     class Banco
     {
        //private string ConnectionString = @"Data Source=DESKTOP-PII2JGD\MSSQLSERVER01;Initial Catalog=master;Integrated Security=True";
        private SqlConnection conn;
        private SqlCommand command;
        public Banco()
        {
            conectar();
        }
        public void conectar()
        {
            string ConnectionString = @"Data Source=DESKTOP-PII2JGD\MSSQLSERVER01;Initial Catalog=master;Integrated Security=True";
            this.conn = new SqlConnection(ConnectionString);
            this.command = this.conn.CreateCommand();
            this.conn.Open();
        }

        public void NonQuery(string sql)
        {
            this.command.CommandText = sql;
            this.command.ExecuteNonQuery();
        }

        public SqlDataReader Query(String sql)
        {
            this.command.CommandText = sql;
            return this.command.ExecuteReader();
        }
    }
}
