using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server.Spells
{
    public class Battery : Spell
    {
        public Battery(string color, (int, int) index, int dir) 
        {
            power = 500;
            delayTime = 0.2f;

            teamColor = color;
            targetList.Add(index);
        }

        protected override async void RunCard()
        {
            await Task.Delay(TimeSpan.FromSeconds(delayTime));
            Skill();
        }

        protected override void Skill()
        {
            Field.Instance.Heal(power, teamColor, targetList);
            Extensions.SendCommandData("HealBuilding", power, targetList);
        }
    }
}
