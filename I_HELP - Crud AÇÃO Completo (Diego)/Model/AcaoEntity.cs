using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_HELP.Model
{
    public class AcaoEntity
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int CodCid { get; private set; }
        public DateTime DateIni { get; private set; }
        public DateTime DateFim { get; private set; }

        public AcaoEntity(int id, string nome, int codCid, DateTime dateIni, DateTime dateFim)
        {
            Id = id;
            Nome = nome;
            CodCid = codCid;
            DateIni = dateIni;
            DateFim = dateFim;
        }
    }
}
