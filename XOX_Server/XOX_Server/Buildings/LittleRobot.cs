using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server.Buildings
{
    public class LittleRobot : Building
    {
        public LittleRobot(int dir) {
            grade = 1;
            cost = 3;
            synergy = "Machine";
            delayTime = 1.5f;
            AttackDirectionList.Add((1, 1));

            maxHP = currentHP = 900;
            power = 50;
            attackSpeed = 1.2f;

            direction = dir;

            WaitDelayTime();
            TurnDirection();
            SetTargetList();
            Attack();
        }
    }
}
