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
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            ConectaBanco con = new ConectaBanco();
            if(con.cadastrarUsuario(txtUsuario.Text, txtSenha.Text) == true)
            {
                MessageBox.Show("Usuário '" + txtUsuario.Text + "' cadastrado com sucesso.");
            }
            
            this.Close();
           
        }

        private void Cadastro_Load(object sender, EventArgs e)
        {

        }
    }
}
