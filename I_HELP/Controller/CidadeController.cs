using I_HELP.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_HELP.Controller
{
    public class CidadeController
    {
        public DataTable BuscarCidade(int codest)
        {

            BancoInstance banco;

            DataTable resBusca = new DataTable();

            using (banco = new BancoInstance())
            {
                banco.Banco.ExecuteQuery(

                    @"select * from cidade where codest=@1",

                    out resBusca, "@1", codest);

                return resBusca;

            }

        }
        public DataTable BuscarCidadeIndice(int indice)
        {
            BancoInstance banco;
            using (banco = new BancoInstance())
            {
                DataTable objResultado = new DataTable();
                //Comando SQL que insere no banco
                banco.Banco.ExecuteQuery(@"select * from cidade where codcid=@1", out objResultado, "@1", indice);

                return objResultado;
            }
        }
    }
}
