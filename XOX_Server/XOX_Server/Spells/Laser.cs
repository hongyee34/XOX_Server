using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server.Spells
{
    public class Laser : Spell
    {
        public Laser(int a)
        {
            power = 200;
            targetList = new List<(int, int)>() { (0, 0), (1, 0), (2, 0) };

            direction = a;

            WaitDelayTime();
            TurnDirection();
            Skill();

        }

        protected override void Skill()
        {
            foreach((int x,int y) target in targetList)
            {
                Field.Instance.GetDamage(power, target);
            }
        }
    }
}
