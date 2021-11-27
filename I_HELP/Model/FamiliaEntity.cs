using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_HELP.Model
{
    public class FamiliaEntity
    {
        public int Codfam { get; private set; }
        public string Regfam { get; private set; }
        public int Codcid { get; private set; }

        public FamiliaEntity(int codfam, string regfam, int codCid)
        {
            Codfam = codfam;
            Regfam = regfam;
            Codcid = codCid;
        }
    }
}
