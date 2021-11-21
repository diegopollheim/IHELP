using I_HELP.DAO;
using I_HELP.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_HELP.Controller
{
    public class PessoaController
    {
        //Insere uma pessoa no banco
        public bool GravarPessoa(PessoaEntity pessoa)
        {
            int id = 0;
            var formattedDate = String.Format("{0:yyyy-MM-dd}", pessoa.DataNasc);

            BancoInstance banco;
            using (banco = new BancoInstance())
            {
                //Comando SQL que insere no banco
                bool ok = false;
                ok = banco.Banco.ExecuteNonQuery(@"insert into pessoa (nompes, cpfpes, rgpes, telpes, naspes) values(@1, @2, @3, @4, @5)", "@1", pessoa.Nome, "@2", pessoa.Cpf, "@3", pessoa.Rg, "@4", pessoa.Telefone, "@5", formattedDate);
                

                return ok;
            }
        }

        //Buscar Pessoa
        public DataTable BuscarPessoa(string cpf)
        {
            DataTable objResultado = new DataTable();
            BancoInstance banco;
            using (banco = new BancoInstance())
            {
                banco.Banco.ExecuteQuery(@"select * from pessoa where cpfpes=@1", out objResultado, "@1", cpf);
                return objResultado;
            }
        }
        // Excluir Pessoa
        public bool Excluir(int id)
        {
            BancoInstance banco = new BancoInstance();
            using (banco = new BancoInstance())
            {
                bool ok = false;
                return ok = banco.Banco.ExecuteNonQuery(@"delete from pessoa where codpes=@1", "@1", id);
            }
        }
        public bool AlterarPessoa(PessoaEntity pesssoa)
        {
            BancoInstance banco;
            bool retorno = false;
            using (banco = new BancoInstance())
            {
                return retorno = banco.Banco.ExecuteNonQuery(
                    @"update pessoa set nompes = @1,
                    cpfpes = @2, rgpes = @3, telpes = @4,
                    naspes = @5 where codpes = @6",
                    "@1", pesssoa.Nome,
                    "@2", pesssoa.Cpf,
                    "@3", pesssoa.Rg,
                    "@4", pesssoa.Telefone,
                    "@5", pesssoa.DataNasc,
                    "@6", pesssoa.Id);
            }
        }

    }
}
