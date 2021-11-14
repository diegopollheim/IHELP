using I_HELP.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_HELP.Controller
{
    public class EstadoController
    {
        public DataTable BuscarEstado()
        {
            BancoInstance banco;

            DataTable resBusca = new DataTable();

            using (banco = new BancoInstance())
            {

                banco.Banco.ExecuteQuery(

                @"select * from estado", out resBusca);

            }

            return resBusca;

        }
    }
}
