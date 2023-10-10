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
            field[index.x, index.y].SetObjectIndex(index);
        }

        public bool Damage(int power,(int x,int y) index)
        {
            if (field[index.x, index.y] != null)
            {
                field[index.x, index.y].GetDamage(power);
                return true;
            }
            return false;
        }

        public void Heal(int power,(int x,int y) index)
        {
            if (field[index.x, index.y]!=null)
            {
                field[index.x,index.y].GetHeal(power);
            }
        }

        public void Barrier(int power,( int x,int y) index)
        {
            if (field[index.x,index.y]!=null)
            {
                field[index.x,index.y].GetBarrier(power);
            }
        }

        public void DestroyBuilding((int x,int y) index)
        {
            field[index.x, index.y] = null;
        }
    }
}
