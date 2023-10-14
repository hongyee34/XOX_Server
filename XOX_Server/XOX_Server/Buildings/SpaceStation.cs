using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server.Buildings
{
    public class SpaceStation : Building
    {
        public SpaceStation(string color, (int x, int y) index, int dir) 
        {
            grade = 1;
            cost = 1;
            synergy = "Machine";
            delayTime = 1f;

            maxHP = _currentHP = 500;
            attackSpeed = 8;

            teamColor = color;

            RunCard();
        }

        protected override async void RunCard()
        {
            await Task.Delay(TimeSpan.FromSeconds(delayTime));
            Attack();
        }

        protected override async void Attack()
        {
            while (true)
            {
                await Task.Delay((int)(attackSpeed * 1000));
                if (destroyed) break;
                //돈 1 추가
                Extensions.SendCommandData("AddMoney", 1);
            }
        }

    }
}
