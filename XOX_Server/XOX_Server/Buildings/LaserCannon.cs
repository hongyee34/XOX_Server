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
        public LaserCannon(string color, (int x,int y) index, int dir) 
        {
            grade = 2;
            cost = 4;
            synergy = "Machine";
            delayTime = 2;
            AttackDirectionList.Add((0, 1));

            maxHP = _currentHP = 1100;
            power = 120;
            attackSpeed = 1.3f;

            objectPosition = Extensions.ConvertIndexToPosition(index);
            teamColor = color;
            direction = dir;

            RunCard();
        }

        protected override async void RunCard()
        {
            await Task.Delay(TimeSpan.FromSeconds(delayTime));
            TurnDirection();
            SetTargetList();
            Attack();
        }

        protected override async void Attack()
        {
            List<(int x, int y)> secondTargetList = new() { Extensions.Sum(targetList[0], AttackDirectionList[0]) };
            while (true)
            {
                await Task.Delay(TimeSpan.FromSeconds(attackSpeed));
                if (destroyed) break;
                Extensions.SendCommandData("ActiveSkill", Extensions.ConvertPositionToIndex(objectPosition));
                if (Field.Instance.Damage(power, teamColor, targetList))
                {
                    Field.Instance.Damage(power/2, teamColor, secondTargetList);
                }
            }
        }
    }
}
