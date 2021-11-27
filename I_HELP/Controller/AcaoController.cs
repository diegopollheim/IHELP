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
    public class AcaoController
    {
        public bool CadastrarAcao(AcaoEntity acao)
        {
            BancoInstance banco;
            using (banco = new BancoInstance())
            {
                //Comando SQL que insere no banco
                bool ok = false;
                ok = banco.Banco.ExecuteNonQuery(@"insert into acao (nomeaca, codcid, dateini, datefim) values(@1, @2, @3, @4)", "@1", acao.Nome, "@2", acao.CodCid, "@3", acao.DateIni, "@4", acao.DateFim);

                return ok;
            }
        }

        public bool AlterarAcao(AcaoEntity acao, int id)
        {
            BancoInstance banco;
            using (banco = new BancoInstance())
            {
                //Comando SQL que insere no banco
                bool ok = false;
                ok = banco.Banco.ExecuteNonQuery(@"update acao set nomeaca = @1, codcid = @2, dateini = @3, datefim = @4 where codaca = @5", "@1", acao.Nome, "@2", acao.CodCid, "@3", acao.DateIni, "@4", acao.DateFim, "@5", id);
                return ok;
            }
        }

        public bool ExcluirAcao(int indice)
        {
            BancoInstance banco;
            using (banco = new BancoInstance())
            {
                //Comando SQL que insere no banco
                bool ok = false;
                ok = banco.Banco.ExecuteNonQuery(@"delete from acao where codaca=@1", "@1", indice);

                return ok;
            }
        }

        public bool BuscarAcao(int indice)
        {
            BancoInstance banco;
            using (banco = new BancoInstance())
            {
                //Comando SQL que insere no banco
                bool ok = false;
                ok = banco.Banco.ExecuteNonQuery(@"select * from acao where codaca=@1", "@1", indice);

                return ok;
            }
        }

        public DataTable TrazerAcao(int indice)
        {
            DataTable retorno = new DataTable();
            BancoInstance banco;
            using (banco = new BancoInstance())
            {
                //Comando SQL que insere no banco
                banco.Banco.ExecuteQuery(@"select * from acao where codaca=@1", out retorno, "@1", indice);

                return retorno;
            }
        }

        public DataTable BuscarEstadoCidadeAcao(int codCid)
        {
            DataTable retorno = new DataTable();
            BancoInstance banco;
            using (banco = new BancoInstance())
            {
                // Busca dados em Duas tabelas diferentes e traz o nome do estado e nome da cidade
                banco.Banco.ExecuteQuery(
                    @"select estado.nomest, cidade.nomcid
                    from estado
                    inner join cidade on estado.codest = cidade.codest
                    where codcid = @1", out retorno, "@1", codCid);

                return retorno;
            }
        }
    }
}
