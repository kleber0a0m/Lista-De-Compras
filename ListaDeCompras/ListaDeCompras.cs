using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompras
{
    class ListaDeCompras
    {
        string nome;
        double quantidade, preco;

        public string Nome { get => nome; set => nome = value; }
        public double Quantidade { get => quantidade; set => quantidade = value; }
        public double Preco { get => preco; set => preco = value; }
    }
}
