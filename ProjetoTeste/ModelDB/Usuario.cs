using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste
{
    
     class Usuario
    {
        private string id;
        private string nome;
        private string cpf;
        private string telefone;

        private Banco banco;
        public Usuario()
        {
            this.banco = new Banco();
        }
        public void CadastrarUser()
        {
            this.banco.NonQuery("insert into  Preferencias (Nome, cpf, telefone) values ('"+this.nome+"','"+this.cpf+"','"+this.telefone+"')");
;       }
        public void Alterar()
        {
            this.banco.NonQuery("Update Preferencias set nome='" + this.nome + "',Cpf='" + this.cpf + "',Telefone='" + this.telefone + "' where id ='" + this.id + "'");
        }
        public void ExcluirUser()
        {
            this.banco.NonQuery("Delete from Preferencias where id ='" + this.id + "'");
        }
        public SqlDataReader ListaUsers()
        {
           return this.banco.Query("Select * from Preferencias");
        }

        public string Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get =>cpf; set => cpf = value; }
        public string Telefone { get => telefone; set => telefone = value; }
    }
}
