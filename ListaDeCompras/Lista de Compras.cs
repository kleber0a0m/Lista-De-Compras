using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaDeCompras
{
    public partial class Form1 : Form
    {
        int idAlterar;
        public Form1()
        {
            InitializeComponent();
            listaIntens();
            


        }

        void listaIntens()
        {
            ConectaBanco con = new ConectaBanco();
            dgItens.DataSource = con.lista();
            valorTotal();
            valorTotalItens();

        }




        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void limpaFormCadastro()
        {
            txtCadastrarNome.Clear();
            txtCadastrarPreco.Clear();
            txtCadastrarQuantidade.Clear();
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            ListaDeCompras l = new ListaDeCompras();

            if (txtCadastrarNome.Text.Length < 1)
            {
                
                MessageBox.Show("Preencha o campo Nome", "Erro no campo Nome", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtCadastrarNome.Focus();
                return;
            } else
            {
                l.Nome = txtCadastrarNome.Text;
            }

            if (txtCadastrarQuantidade.Text.Length < 1)
            {
                
                MessageBox.Show("Preencha o campo Quantidade", "Erro no campo Quantidade", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCadastrarQuantidade.Focus();
                return;
            }
            else
            {
                l.Quantidade = Convert.ToDouble(txtCadastrarQuantidade.Text);
            }

            if (txtCadastrarPreco.Text.Length < 1)
            {

                MessageBox.Show("Preencha o campo Preço", "Erro no campo Preço", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCadastrarPreco.Focus();
                return;
            }
            else
            {
                l.Preco = Convert.ToDouble(txtCadastrarPreco.Text) / 100;
            }


           
                
            ConectaBanco con = new ConectaBanco();


            bool r = con.cadastrarIntens(l);

            if (r == true)
            {

                MessageBox.Show("Cadastrado com sucesso", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                
                MessageBox.Show("Erro (Cadastro):" + con.mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            listaIntens();
            limpaFormCadastro();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string fil = filtro.Text;

            //(dgItens.DataSource as DataTable).DefaultView.RowFilter = string.Format(fil + " '%{0}%'", textBox1.Text);

            //(dgItens.DataSource as DataTable).DefaultView.RowFilter = "Nome like '%Arroz%'";

            //(dgItens.DataSource as DataTable).DefaultView.RowFilter = "Subtotal = 45";

            if (filtro.Text.Equals("Nome"))
            {
                (dgItens.DataSource as DataTable).DefaultView.RowFilter = string.Format("Nome like '%{0}%'", textBox1.Text);
            }
            else if (filtro.Text.Equals("")){

            }else
            {
                if (textBox1.Text.Equals(""))
                {
                   
                }
                else
                {
                    try
                    {
                        (dgItens.DataSource as DataTable).DefaultView.RowFilter = fil + " = " + textBox1.Text;
                    }
                    catch
                    {

                        MessageBox.Show("Use números e \".\" ", "Informações sobre pesquisa.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }
                
            }

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            int linha = dgItens.CurrentRow.Index;

            int id = Convert.ToInt32(dgItens.Rows[linha].Cells["Id"].Value.ToString());
            
            DialogResult resp = MessageBox.Show("Tem certeza que deseja excluir?", "Remover", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (resp == DialogResult.OK)
            {

                ConectaBanco con = new ConectaBanco();

                bool r = con.removeItem(id);

                if (r == true)
                {

                    
                    MessageBox.Show("Removido com sucesso", "Removido com sucessO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    
                    MessageBox.Show("Erro:" + con.mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                listaIntens();

            }
        }

        private void btnBuscarAlterar_Click(object sender, EventArgs e)
        {
            int linha = dgItens.CurrentRow.Index;

            int id = Convert.ToInt32(dgItens.Rows[linha].Cells["Id"].Value.ToString());
            idAlterar = id;

            txtAlterarNome.Text = dgItens.Rows[linha].Cells["Nome"].Value.ToString();
            txtAlterarQuantidade.Text = dgItens.Rows[linha].Cells["Quantidade"].Value.ToString();
            txtAlterarPreco.Text = dgItens.Rows[linha].Cells["Preco"].Value.ToString();
            

            TabControl.SelectedTab = tabAlterar;

        }

        private void btnAlterarAlterar_Click(object sender, EventArgs e)
        {
            ListaDeCompras l = new ListaDeCompras();
            ConectaBanco con = new ConectaBanco();

            if (txtAlterarNome.Text.Length < 1)
            {
                MessageBox.Show("Preencha o campo Nome", "Erro no campo Nome", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAlterarNome.Focus();
                return;
            }
            else
            {
                l.Nome = txtAlterarNome.Text;
            }

            

            if (txtAlterarQuantidade.Text.Length < 1)
            {
                
                MessageBox.Show("Preencha o campo Quantidade", "Erro no campo Quantidade", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAlterarQuantidade.Focus();
                return;
            }
            else
            {
                try
                {
                    l.Quantidade = Convert.ToDouble(txtAlterarQuantidade.Text);
                }
                catch
                {
                    
                    MessageBox.Show("Digite apenas números no campo Quantidade", "Digite apenas números no campo Quantidade", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAlterarPreco.Focus();
                    txtAlterarPreco.Clear();
                    return;
                }
                
            }

            if (txtAlterarPreco.Text.Length < 1)
            {
                
                MessageBox.Show("Preencha o campo Preço", "Erro no campo Preço", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAlterarPreco.Focus();
                return;
            }
            else
            {
                try
                {
                    l.Preco = Convert.ToDouble(txtAlterarPreco.Text);
                }
                catch
                {
                    
                    MessageBox.Show("Digite apenas número no campo Preço", "Digite apenas número no campo Preço", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAlterarPreco.Clear();
                    txtAlterarPreco.Focus();
                    return;
                }
                
            }

            

            bool res = con.alteraItenm(l, idAlterar);
            if (res == true)
            {
                
                MessageBox.Show("Alterado com Sucesso", "Alterado com Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TabControl.SelectedTab = tabBuscar;
                listaIntens();
            }
        }

        public void valorTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgItens.Rows.Cast<DataGridViewRow>().Where(t => !string.IsNullOrEmpty(t.Cells["SubTotal"].Value?.ToString())))
            {
                total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
            }

            lblTotal.Text = Convert.ToDouble(total).ToString("C");
        }

        public void valorTotalItens()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgItens.Rows.Cast<DataGridViewRow>().Where(t => !string.IsNullOrEmpty(t.Cells["Quantidade"].Value?.ToString())))
            {
                total += Convert.ToDecimal(row.Cells["Quantidade"].Value);
            }

            lblTotalItens.Text = Convert.ToDouble(total).ToString();
        }



        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
    
}
