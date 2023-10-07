using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server.Buildings
{
    public class LittleRobot : Building
    {
        public LittleRobot(int a) {
            grade = 1;
            cost = 3;
            synergy = "Machine";

            hp = 900;
            power = 50;
            attackSpeed = 1.2f;
            direction = a;
            targetList.Add((1, 1));
            TurnDirection();
            Attack();
        }
    }
}
