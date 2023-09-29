using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server
{
    public abstract class Card
    {
        public Field targetField;
        public int grade;
        public int cost;
        public string synergy;
    }
}
