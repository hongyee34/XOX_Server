using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server
{
    public abstract class Building : Card
    {
        protected int maxHP;
        protected int currentHP 
        {
            get
            { 
                return currentHP;
            }
            set
            {
                currentHP = value;
                if (currentHP <= 0)
                {
                    OnDestroyed();   
                }
                else if(currentHP > maxHP)
                {
                    currentHP = maxHP;
                }
            }
        }
        protected int power;
        protected float attackSpeed;

        protected Building()
        {
            Attack();
        }

        protected virtual void Attack()
        {
            while (true)
            {
                foreach((int,int) index in targetList)
                {
                    Field.Instance.Damage(power, index);
                }
                Thread.Sleep((int)(delayTime * 1000));
            }
        }

        protected virtual void OnDestroyed() {
            Field.Instance.DestroyBuilding(objectIndex);
        }

        public void GetDamage(int power)
        {
            currentHP -= power;
        }

        public void GetHeal(int power)
        {
            currentHP += power;
        }
    }
}
