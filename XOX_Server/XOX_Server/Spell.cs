using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server
{
    public abstract class Spell : Card
    {
        protected int power;

        protected abstract void Skill();
    }
}
