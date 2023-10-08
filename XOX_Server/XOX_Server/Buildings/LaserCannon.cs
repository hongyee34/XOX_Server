using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server.Buildings
{
    public class LaserCannon : Building
    {
        public LaserCannon(int a) 
        {
            grade = 2;
            cost = 4;
            synergy = "Machine";
            delayTime = 2;
            AttackDirectionList.Add((1, 0));

            hp = 1100;
            power = 120;
            attackSpeed = 1.3f;

            direction = a;

            WaitDelayTime();
            TurnDirection();
            SetTargetList();
            Attack();
        }

        protected async override void Attack()
        {
            (int x, int y) secondTarget = (Extensions.Sum(targetList[0], AttackDirectionList[0]));
            while (true)
            {
                if (Field.Instance.GetDamage(power, targetList[0]))
                    Field.Instance.GetDamage(power, secondTarget);
                await Task.Delay((int)(attackSpeed * 1000));
            }
        }
    }
}
