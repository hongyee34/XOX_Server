using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server
{
    public class CommandData
    {
        public string command { get; set; }
        public string color { get; set; }
        public int type { get; set; }
        public (int x, int y) target { get; set; }
        public int direction { get; set; }
        public int amount { get; set; }
        public List<(int x, int y)> targetList { get; set; }
    }
}
