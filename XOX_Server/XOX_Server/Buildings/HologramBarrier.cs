using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server.Buildings
{
    public class HologramBarrier : Building
    {
        public HologramBarrier(int dir) {
            grade = 3;
            cost = 5;
            synergy = "Machine";
            delayTime = 3f;
            AttackDirectionList.Add((1, 0));

            maxHP = currentHP = 1700;
            power = 300;

            direction = dir;

            WaitDelayTime();
            TurnDirection();
            SetTargetList();
            Attack();
        }
        protected override void Attack()
        {
            Field.Instance.Barrier(power, targetList[0]);
            Extensions.SendCommandData("BarrierBuilding", power, targetList);
        }
    }
}
