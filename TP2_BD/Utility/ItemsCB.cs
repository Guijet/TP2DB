using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_BD
{
    public class ItemsCB
    {
        private String textValue;
        private int id;

        public ItemsCB(String textValue,int id)
        {
            this.textValue = textValue;
            this.id = id;
        }

        public String getTextValue()
        {
            return this.textValue;
        }

        public int getId()
        {
            return this.id;
        }

        public override string ToString()
        {
            return textValue;
        }
    }
}
