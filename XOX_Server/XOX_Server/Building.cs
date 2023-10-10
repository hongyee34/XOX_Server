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
                if(value<currentHP)
                {
                    int damage = currentHP- value;
                    if (barrier > 0)
                    {
                        int barrierDamage = barrier - damage;
                        if (barrierDamage >= 0)
                        {
                            // 보호막으로 충분히 데미지를 막을 수 있음
                            barrier -= damage;
                        }
                        else
                        {
                            // 보호막으로 데미지를 막을 수 없음
                            barrier = 0;
                            currentHP += barrierDamage;
                        }
                    }
                }
                else
                {
                    currentHP = value;
                }

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
        protected int barrier;
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
                Thread.Sleep((int)(delayTime * 1000));
                foreach((int,int) index in targetList)
                {
                    Field.Instance.Damage(power, index);
                }
                Extensions.SendCommandData("DamageBuilding",power,targetList);
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

        public void GetBarrier(int power)
        {
            barrier += power;
        }
    }
}
