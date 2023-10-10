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
        public LaserCannon(int dir) 
        {
            grade = 2;
            cost = 4;
            synergy = "Machine";
            delayTime = 2;
            AttackDirectionList.Add((1, 0));

            maxHP = currentHP = 1100;
            power = 120;
            attackSpeed = 1.3f;

            direction = dir;

            WaitDelayTime();
            TurnDirection();
            SetTargetList();
            Attack();
        }

        protected override void Attack()
        {
            List<(int x, int y)> secondTargetList = new() { Extensions.Sum(targetList[0], AttackDirectionList[0]) };
            while (true)
            {
                Thread.Sleep((int)(delayTime * 1000));
                if (Field.Instance.Damage(power, targetList[0]))
                {
                    Field.Instance.Damage(power/2, secondTargetList[0]);
                    Extensions.SendCommandData("DamageBuilding", power, targetList);
                    Extensions.SendCommandData("DamageBuilding", power, secondTargetList);
                }
            }
        }
    }
}
