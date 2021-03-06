using System;
using System.Collections.Generic;
using System.Text;

namespace ExemploComboBox.Util
{
    public class ItemComboBox
    {
        public string Texto { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return Texto;
        }
        public ItemComboBox(string texto, int id)
        {
            Texto = texto;
            Id = id;
        }
    }
}
