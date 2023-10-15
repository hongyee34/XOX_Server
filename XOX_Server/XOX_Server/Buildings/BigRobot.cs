using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server.Buildings
{
    public class BigRobot : Building
    {
        public BigRobot(string color, (int x, int y) index, int dir) 
        {
            grade = 3;
            cost = 6;
            synergy = "Machine";
            delayTime = 2;
            AttackDirectionList = new() { (1, 1), (1, 0), (1, -1) };

            maxHP = _currentHP = 1900;
            power = 100;
            attackSpeed = 2f;

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
            Thread.Sleep(10 * 1000);
            Field.Instance.DestroyBuilding(objectPosition);
        }
    }
}
