using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server.Buildings
{
    public class LittleRobot : Building
    {
        public LittleRobot(Field a,int b) {
            targetField = a;
            grade = 1;
            cost = 3;
            synergy = "Machine";

            hp = 900;
            power = 50;
            attackSpeed = 1.2f;
            direction = b;
            targetList = new List<(int,int)> { (1, 0) };
        }
    }
}
