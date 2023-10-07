using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server
{
    public abstract class Building : Card
    {
        public int hp;
        public int power;
        public float attackSpeed;
        public List<(int, int)> targetList = new();
        public int direction;

        public Building()
        {
            Attack();
        }

        public async virtual void Attack()
        {
            while (true)
            {
                TurnDirection();
                foreach((int,int) index in targetList)
                {
                    targetField.field[index.Item1, index.Item2].hp -= power;
                }
                await Task.Delay((int)(attackSpeed*1000));
            }
        }
        public void TurnDirection()
        {
            for (int i = 0; i < targetList.Count(); i++)
            {
                for (int j = 0; j < direction; j++)
                {
                    targetList[i] = (targetList[i].Item2,-targetList[i].Item1);
                }
            }
        }
    }
}
