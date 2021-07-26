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
    public partial class Login : Form
    {
        public int id;
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ConectaBanco con = new ConectaBanco();
            dg.DataSource = con.consultaUsuario(txtUsuario.Text, txtSenha.Text);
            
           if(dg.Rows[0].Cells["id"].Value == null)
            {
                MessageBox.Show("Senha ou usuário incorentos");
            }
            else
            {
                id = Convert.ToInt32(dg.Rows[0].Cells["id"].Value.ToString());

                Form1 lista = new Form1(this);
                lista.Show();
            }








        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            Cadastro cad = new Cadastro();
            cad.Show();
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
