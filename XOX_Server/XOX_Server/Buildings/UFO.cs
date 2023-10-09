using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server.Buildings
{
    public class UFO : Building
    {
        public UFO(int dir) 
        {
            grade = 1;
            cost = 3;
            synergy = "Machine";
            delayTime = 2;
            AttackDirectionList.Add((1, 0));

            maxHP = currentHP = 1000;
            power = 50;
            attackSpeed = 1.3f;

            direction = dir;

            WaitDelayTime();
            TurnDirection();
            SetTargetList();
            Attack();
        }
        protected override void OnDestroyed()
        {
            (int, int) backOfObject = Extensions.Difference(objectIndex, AttackDirectionList[0]);
            Field.Instance.Damage(500, backOfObject);
        }
    }
}
