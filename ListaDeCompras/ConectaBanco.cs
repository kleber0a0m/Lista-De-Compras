using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/////////////////
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
////////////////
namespace ListaDeCompras
{
    class ConectaBanco
    {
        MySqlConnection conexao = new MySqlConnection("server=127.0.0.1; user id=root; password=;database=listadecompras");
        public string mensagem;

        public DataTable lista()
        {
            MySqlCommand cmd = new MySqlCommand("listaItens", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dados = new DataTable();
                da.Fill(dados);
                return dados;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro MySQL (lista): \n" + e.Message;
                MessageBox.Show(mensagem);
                return null;

            }

            finally
            {
                conexao.Close();
            }
        }

        public bool cadastrarIntens(ListaDeCompras l)
        {
            MySqlCommand cmd = new MySqlCommand("cadastrarItem", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("nome", l.Nome);
            cmd.Parameters.AddWithValue("quantidade", l.Quantidade);
            cmd.Parameters.AddWithValue("preco", l.Preco);
            cmd.Parameters.AddWithValue("subTotal", l.Quantidade * l.Preco);


            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro MySQL (cadastrar): \n" + e.Message;
                MessageBox.Show(mensagem);
                return false;
            }
        }

        public bool removeItem(int id)
        {
            MySqlCommand cmd = new MySqlCommand("removerItem", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id1", id);


            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro MySQL (removeItem): \n" + e.Message;
                MessageBox.Show(mensagem);
                return false;
            }

        }

        public bool alteraItenm(ListaDeCompras l, int id)
        {
            MySqlCommand cmd = new MySqlCommand("alterarItens", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id1", id);
            cmd.Parameters.AddWithValue("nome", l.Nome);
            cmd.Parameters.AddWithValue("quantidade", l.Quantidade);
            cmd.Parameters.AddWithValue("preco", l.Preco);
            cmd.Parameters.AddWithValue("subTotal", l.Quantidade * l.Preco);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro MySQL (alterar): \n" + e.Message;
                MessageBox.Show(mensagem);
                return false;
            }

        }

      

        
        
    }
}
