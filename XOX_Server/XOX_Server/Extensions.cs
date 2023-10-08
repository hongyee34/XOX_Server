using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server
{
    public class Extensions
    {
        public static (int, int) Sum((int, int) tuple1, (int, int) tuple2)
        {
            return (tuple1.Item1+tuple2.Item1, tuple1.Item2+tuple2.Item2);
        }
    }
}
