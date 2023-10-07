using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server
{
    public class Field : Singleton<Field>
    {
        private Building[,] field = new Building[3,3];

        public void PlaceBuilding(Building building,(int x,int y) index)
        {
            field[index.x, index.y] = building;
        }
    }
}
