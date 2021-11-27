using I_HELP.DAO;
using I_HELP.Model;
using I_HELP.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_HELP.Controller
{
    public class EntregaControler
    {
        public bool CadastrarEntrega(EntregaEntity entrega)
        {
            var formattedDate = String.Format("{0:yyyy-MM-dd}", entrega.DataEntrega);
            BancoInstance banco;
            using (banco = new BancoInstance())
            {
                //Comando SQL que insere no banco
                bool ok = false;
                ok = banco.Banco.ExecuteNonQuery(@"insert into entrega values(@1, @2, @3, @4)", "@1", entrega.Codaca, "@2", entrega.Codfam, "@3", entrega.Codpes, "@4", formattedDate);

                return ok;
            }
        }

        public DataTable BuscarPorAcaoFamilia(int codaca, int codfam)
        {
            DataTable retorno = new DataTable();
            BancoInstance banco;
            using (banco = new BancoInstance())
            {
                // Busca dados em Duas tabelas diferentes e traz o nome do estado e nome da cidade
                banco.Banco.ExecuteQuery(
                    @"select * from entrega where codaca = @1 AND codfam = @2", out retorno, "@1", codaca, "@2", codfam);

                return retorno;
            }
        }
    }
}
