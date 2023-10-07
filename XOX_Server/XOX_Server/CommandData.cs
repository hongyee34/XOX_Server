using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server
{
    public class CommandData
    {
        public string command;
        public int type;
        public (int x,int y) target;
        public int direction;
        public int amount;
        public List<(int x, int y)> targetList;
    }
}
