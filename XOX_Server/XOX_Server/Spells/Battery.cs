using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server.Spells
{
    public class Battery : Spell
    {
        public Battery((int, int) index,int dir) 
        {
            power = 500;
            delayTime = 0.2f;

            objectIndex = index;

            WaitDelayTime();
            Skill();
        }

        protected override void Skill()
        {
            Field.Instance.Heal(power, objectIndex);
        }
    }
}
