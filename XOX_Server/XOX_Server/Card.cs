using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server
{
    public abstract class Card
    {
        protected int grade;
        protected int cost;
        protected string synergy;
        protected float delayTime;

        protected int direction;
        protected List<(int, int)> targetList = new();

        protected void TurnDirection()
        {
            for (int i = 0; i < targetList.Count(); i++)
            {
                for (int j = 0; j < direction; j++)
                {
                    targetList[i] = (targetList[i].Item2, -targetList[i].Item1);
                }
            }
        }

        protected void WaitDelayTime()
        {
            Thread.Sleep((int)(delayTime * 1000));
        }
    }
}
