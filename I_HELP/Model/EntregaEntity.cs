using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_HELP.Model
{
    public class EntregaEntity
    {

        public int Codaca { get; private set; }
        public int Codfam { get; private set; }
        public int Codpes { get; private set; }
        public DateTime DataEntrega { get; private set; }
        public EntregaEntity(int codaca, int codfam, int codpes, DateTime dataEntrega)
        {
            Codaca = codaca;
            Codfam = codfam;
            Codpes = codpes;
            DataEntrega = dataEntrega;
        }


    }
}
