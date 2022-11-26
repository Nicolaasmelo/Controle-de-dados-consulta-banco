using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoTeste
{
    public partial class frmConsultaBd : Form
    {
        private Usuario usuario;
        
        public frmConsultaBd()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Inserir();
        }
        public void Inserir()
        {            
            try
            {
                this.usuario.Nome = txtNome.Text;
                this.usuario.Cpf = txtCpf.Text;
                this.usuario.Telefone = txtTelefone.Text;
                this.usuario.CadastrarUser();
                LimparCampos();
                AtualizarGrid();
                MessageBox.Show("Informações Inseridas  com sucesso");


            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao Inserir no banco de dados");
            }
            
        }
        

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }
        public void Atualizar()
        {
            try
            {
                this.usuario.Id = txtId.Text;
                this.usuario.Nome = txtNome.Text;
                this.usuario.Cpf = txtCpf.Text;
                this.usuario.Telefone = txtTelefone.Text;
                this.usuario.Alterar();
                LimparCampos();
                AtualizarGrid();
                MessageBox.Show("Informação Alterada com sucesso");
            }
            catch (Exception)
            {

                MessageBox.Show("Erro ao Aterar no banco de dados");
            }
            


        }
        public void AtualizarGrid()
        {
            SqlDataReader temp = this.usuario.ListaUsers();
            DataTable dt = new DataTable();
            dt.Load(temp);
            dtgGrid.DataSource = dt;
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            this.usuario = new Usuario();
            SqlDataReader temp = this.usuario.ListaUsers();
            DataTable dt = new DataTable();
            dt.Load(temp);
            dtgGrid.DataSource = dt;
        }

        private void dtgGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                this.usuario.Id = this.txtId.Text;
                this.usuario.ExcluirUser();
                LimparCampos();
                AtualizarGrid();
                MessageBox.Show("Informação Deletada com sucesso");
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao Deletar no banco de dados");
            }
            

        }



        private void LimparCampos()
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtCpf.Text = "";
            txtTelefone.Text = "";
            
        }

        private void dtgGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow linha = dtgGrid.Rows[e.RowIndex];
            txtId.Text = linha.Cells[0].Value.ToString();
            txtNome.Text = linha.Cells[1].Value.ToString();
            txtCpf.Text = linha.Cells[2].Value.ToString();
            txtTelefone.Text = linha.Cells[3].Value.ToString();
        }
    }
}

