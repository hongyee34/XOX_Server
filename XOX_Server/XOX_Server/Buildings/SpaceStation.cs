using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server.Buildings
{
    public class SpaceStation : Building
    {
        public SpaceStation(int dir) 
        {
            grade = 1;
            cost = 1;
            synergy = "Machine";
            delayTime = 1f;

            maxHP = currentHP = 500;
            attackSpeed = 8;

            WaitDelayTime();
            Attack();
        }

        protected override void Attack()
        {
            while (true)
            {
                Thread.Sleep((int)(delayTime * 1000));
                //돈 1 추가
                Extensions.SendCommandData("AddMoney", 1);
            }
        }
    }
}
