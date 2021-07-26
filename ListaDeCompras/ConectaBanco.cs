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
using System.Security.Cryptography;
using CadastroBandas;

namespace ListaDeCompras
{
    class ConectaBanco
    {
        MySqlConnection conexao = new MySqlConnection("server=127.0.0.1; user id=root; password=;database=listadecompras");
        public string mensagem;

        public DataTable consultaUsuario(string user, string pass)
        {
            string senhaHash = Hash.makeHash(pass);
            MySqlCommand cmd = new MySqlCommand("consultaSenha", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("usuario", user);
            cmd.Parameters.AddWithValue("senha", senhaHash);
            try
            {
                conexao.Open();//abrindo a conexão;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dados = new DataTable();
                da.Fill(dados);
                return dados;
            }
            catch (MySqlException er)
            {
                mensagem = "Erro" + er.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }
        }
        //-------------------------------------------------
        public bool cadastrarUsuario(string user, string pass)
        {
            string senhaHash = Hash.makeHash(pass);
            MySqlCommand cmd = new MySqlCommand("cadastrarUsuario", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("usuario", user);
            cmd.Parameters.AddWithValue("senha", senhaHash);
            try
            {
                conexao.Open();//abrindo a conexão;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();// tabela virtual
                da.Fill(ds); //passando os valores consultados para o DataSet 
                return true;

            }
            catch (MySqlException er)
            {
                mensagem = "Erro" + er.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }
        //-------------------------------------------------

        public DataTable lista(int idUsuario)
        {
            MySqlCommand cmd = new MySqlCommand("listaItens", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idUsuario", idUsuario);
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

        public bool cadastrarIntens(ListaDeCompras l,int idu)
        {
            MySqlCommand cmd = new MySqlCommand("cadastrarItem", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("nome", l.Nome);
            cmd.Parameters.AddWithValue("quantidade", l.Quantidade);
            cmd.Parameters.AddWithValue("preco", l.Preco);
            cmd.Parameters.AddWithValue("subTotal", l.Quantidade * l.Preco);
            cmd.Parameters.AddWithValue("idUsuario", idu);


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

        public bool removeItem(int id, int idu)
        {
            MySqlCommand cmd = new MySqlCommand("removerItem", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id1", id);
            cmd.Parameters.AddWithValue("idUsuario", idu);


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

        public bool alteraItenm(ListaDeCompras l, int id, int idu)
        {
            MySqlCommand cmd = new MySqlCommand("alterarItens", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id1", id);
            cmd.Parameters.AddWithValue("nome", l.Nome);
            cmd.Parameters.AddWithValue("quantidade", l.Quantidade);
            cmd.Parameters.AddWithValue("preco", l.Preco);
            cmd.Parameters.AddWithValue("subTotal", l.Quantidade * l.Preco);
            cmd.Parameters.AddWithValue("idUsuario", idu);

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
