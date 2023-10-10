using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server.Spells
{
    public class Laser : Spell
    {
        public Laser((int,int) index,int dir)
        {
            power = 200;
            delayTime = 0.1f;
            AttackDirectionList = new() { (0, 0), (1, 0), (2, 0) };

            objectIndex = index;
            direction = dir;

            WaitDelayTime();
            TurnDirection();
            SetTargetList();
            Skill();
        }

        protected override void Skill()
        {
            foreach((int x,int y) target in targetList)
            {
                Field.Instance.Damage(power, Extensions.Sum(objectIndex, target));
            }
            Extensions.SendCommandData("DamageBuilding", power, targetList);
        }
    }
}
