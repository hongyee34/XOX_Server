using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server.Buildings
{
    public class BigRobot : Building
    {
        public BigRobot(int dir) 
        {
            grade = 3;
            cost = 6;
            synergy = "Machine";
            delayTime = 2;
            AttackDirectionList = new() { (1, 2), (1, 1), (1, 0) };

            maxHP = currentHP = 1900;
            power = 100;
            attackSpeed = 2f;

            direction = dir;

            WaitDelayTime();
            TurnDirection();
            SetTargetList();
            Attack();
        }

        protected override void OnDestroyed()
        {
            Thread.Sleep(10 * 1000);
            Field.Instance.DestroyBuilding(objectIndex);
        }
    }
}
