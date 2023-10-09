using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server.Buildings
{
    public class HydroGrenade : Building
    {
        public HydroGrenade()
        {
            grade = 4;
            cost = 9;
            synergy = "Machine";
            delayTime = 3;
            targetList = new() { (0, 0), (1, 0), (0, 1), (1, 1), (2, 1), (1, 2), (2, 0), (0, 2) ,(2, 2) };

            maxHP = currentHP = 2000;
            power = 1100;
            attackSpeed = 10;

            WaitDelayTime();
            Attack();
        }
    }
}
