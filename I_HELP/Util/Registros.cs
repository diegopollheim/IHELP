using I_HELP.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_HELP.Util
{
    public class Registros
    {
        private static Random random = new Random();
        public string CriarRegistro()
        {
            string registro = "";

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            registro = new string(Enumerable.Repeat(chars, 5)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            while (registroUnico(registro))
            {
                registro = new string(Enumerable.Repeat(chars, 5)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }

           
            return registro;
        }

        private static bool registroUnico(string registro)
        {
            FamiliaController familiaController = new FamiliaController();

            DataTable retorno = familiaController.BuscarPessoa(registro);

            if (retorno.Rows.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
