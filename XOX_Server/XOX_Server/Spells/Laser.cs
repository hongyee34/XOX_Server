using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server.Spells
{
    public class Laser : Spell
    {
        public Laser(string color, (int,int) index,int dir)
        {
            power = 200;
            delayTime = 0.1f;
            AttackDirectionList = new() { (0, 0), (1, 0), (2, 0) };

            teamColor = color;
            objectPosition = index;
            direction = dir;
        }

        protected override async void RunCard()
        {
            await Task.Delay(TimeSpan.FromSeconds(delayTime));
            TurnDirection();
            SetTargetList();
            Skill();
        }

        protected override void Skill()
        {
            Field.Instance.Damage(power, teamColor, targetList);
        }
    }
}
