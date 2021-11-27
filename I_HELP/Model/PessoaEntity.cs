using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_HELP.Model
{
   public class PessoaEntity
    {
        public int Id { get; private set; }
        public int Codfam { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Rg { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataNasc { get; private set; }

        public PessoaEntity(int id, int codfam, string nome, string cpf, string rg, string telefone, DateTime dataNasc)
        {
            Id = id;
            Codfam = codfam;
            Nome = nome;
            Cpf = cpf;
            Rg = rg;
            Telefone = telefone;
            DataNasc = dataNasc;
        }
    }
}
