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
        protected int _currentHP;
        public int currentHP 
        {
            get
            { 
                return _currentHP;
            }
            set
            {
                if(barrier > 0)
                {
                    int damage = _currentHP - value;
                    if (value<_currentHP)
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
                            _currentHP += barrierDamage;
                        }
                    }
                }
                else
                {
                    _currentHP = value;
                }

                if (_currentHP <= 0)
                {
                    OnDestroyed();   
                }
                else if(_currentHP > maxHP)
                {
                    _currentHP = maxHP;
                }
            }
        }
        protected int barrier;
        protected int power;
        protected float attackSpeed;

        protected bool destroyed = false;

        protected virtual async void Attack()
        {
            while (true)
            {
                await Task.Delay(TimeSpan.FromSeconds(attackSpeed));
                if (destroyed) break;
                Field.Instance.Damage(power, teamColor, targetList);
            }
        }

        protected virtual void OnDestroyed() {
            destroyed = true;
            Field.Instance.DestroyBuilding(objectPosition);
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
