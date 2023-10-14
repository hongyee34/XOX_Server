using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server.Buildings
{
    public class HologramBarrier : Building
    {
        public HologramBarrier(string color, (int x, int y) index, int dir) {
            grade = 3;
            cost = 5;
            synergy = "Machine";
            delayTime = 3f;
            AttackDirectionList.Add((1, 0));

            maxHP = _currentHP = 1700;
            power = 300;

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

        protected override void Attack()
        {
            Field.Instance.Barrier(power, teamColor, targetList);
        }
    }
}
