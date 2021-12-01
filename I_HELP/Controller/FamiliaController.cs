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
    public class FamiliaController
    {
        //Buscar Familias
        public bool CadastrarFamilia(FamiliaEntity familia)
        {
            BancoInstance banco;
            using (banco = new BancoInstance())
            {
                //Comando SQL que insere no banco
                bool ok = false;
                ok = banco.Banco.ExecuteNonQuery(@"insert into familia (regfam, codcid) values(@1, @2)", "@1", familia.Regfam, "@2", familia.Codcid);

                return ok;
            }
        }

        public bool AlterarFamilia(FamiliaEntity familia, int id)
        {
            BancoInstance banco;
            using (banco = new BancoInstance())
            {
                //Comando SQL que insere no banco
                bool ok = false;
                ok = banco.Banco.ExecuteNonQuery(@"update familia set regfam = @1, codcid = @2 where codfam = @3", "@1", familia.Regfam, "@2", familia.Codcid, "@3", id);
                return ok;
            }
        }

        public bool ExcluirFamilia(int indice)
        {
            BancoInstance banco;
            using (banco = new BancoInstance())
            {
                //Comando SQL que insere no banco
                bool ok = false;
                ok = banco.Banco.ExecuteNonQuery(@"delete from familia where codfam=@1", "@1", indice);

                return ok;
            }
        }

        public DataTable BuscarFamilia(int indice)
        {
            BancoInstance banco;
            using (banco = new BancoInstance())
            {
                DataTable objResultado = new DataTable();
                //Comando SQL que insere no banco
                banco.Banco.ExecuteQuery(@"select * from familia where codfam=@1", out objResultado, "@1", indice);

                return objResultado;
            }
        }

        public DataTable BuscarFamilias()
        {
            BancoInstance banco;
            using (banco = new BancoInstance())
            {
                DataTable objResultado = new DataTable();
                //Comando SQL que insere no banco
                banco.Banco.ExecuteQuery(@"select * from familia", out objResultado);

                return objResultado;
            }
        }
        public DataTable BuscarPessoa(string registro = "")
        {
            DataTable objResultado = new DataTable();
            BancoInstance banco;
            using (banco = new BancoInstance())
            {
                banco.Banco.ExecuteQuery(@"select familia.codfam,familia.regfam,UPPER(cidade.nomcid) from familia inner join cidade on cidade.codcid = familia.codcid where regfam like @1", out objResultado, "@1", "%" + registro + "%");
                return objResultado;
            }
        }
    }
}
