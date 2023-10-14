using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server.Buildings
{
    public class HydroGrenade : Building
    {
        public HydroGrenade(string color, (int x, int y) index, int dir)
        {
            grade = 4;
            cost = 9;
            synergy = "Machine";
            delayTime = 3;
            targetList = new() { (1,-1), (1,0), (1,1), (0,-1), (0,0), (0,1), (-1,-1), (-1,0),(-1,1)};

            maxHP = _currentHP = 2000;
            power = 1100;
            attackSpeed = 10;

            teamColor = color;

            RunCard();
        }

        protected override async void RunCard()
        {
            await Task.Delay(TimeSpan.FromSeconds(delayTime));
            Attack();
        }
    }
}
