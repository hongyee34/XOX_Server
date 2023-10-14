using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server.Buildings
{
    public class UFO : Building
    {
        public UFO(string color, (int x, int y) index, int dir) 
        {
            grade = 1;
            cost = 3;
            synergy = "Machine";
            delayTime = 2;
            AttackDirectionList.Add((0, 1));

            maxHP = _currentHP = 1000;
            power = 50;
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

        protected override void OnDestroyed()
        {
            destroyed = true;
            targetList.Clear();
            (int, int) backOfObject = Extensions.Difference(objectPosition, AttackDirectionList[0]);
            targetList.Add(backOfObject);
            Field.Instance.Damage(500, teamColor, targetList);
        }
    }
}
