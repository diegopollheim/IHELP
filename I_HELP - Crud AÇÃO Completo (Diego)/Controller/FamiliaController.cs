using I_HELP.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_HELP.Controller
{
    public class FamiliaController
    {
        //Buscar Familias
        public DataTable BuscarPessoa(string registro = "")
        {
            DataTable objResultado = new DataTable();
            BancoInstance banco;
            using (banco = new BancoInstance())
            {
                banco.Banco.ExecuteQuery(@"select * from familia where regfam like @1", out objResultado, "@1", "%" + registro + "%");
                return objResultado;
            }
        }
    }
}
