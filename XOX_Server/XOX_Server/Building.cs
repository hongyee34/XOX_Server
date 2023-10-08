using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server
{
    public abstract class Building : Card
    {
        protected int hp;
        protected int power;
        protected float attackSpeed;

        protected Building()
        {
            Attack();
        }

        protected async virtual void Attack()
        {
            while (true)
            {
                foreach((int,int) index in targetList)
                {
                    Field.Instance.GetDamage(power, index);
                }
                await Task.Delay((int)(attackSpeed*1000));
            }
        }

        public void GetDamage(int power)
        {
            hp -= power;
        }
    }
}
