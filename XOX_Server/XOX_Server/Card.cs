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

        protected (int x, int y) objectIndex;
        protected int direction;
        protected List<(int x, int y)> AttackDirectionList = new();
        protected List<(int x,int y)> targetList = new();

        protected void TurnDirection()
        {
            for (int i = 0; i < AttackDirectionList.Count(); i++)
            {
                for (int j = 0; j < direction; j++)
                {
                    AttackDirectionList[i] = (AttackDirectionList[i].Item2, -AttackDirectionList[i].Item1);
                }
            }
        }
        
        protected void SetTargetList() 
        {
            for(int i = 0;i < AttackDirectionList.Count();i++)
            {
                targetList[i] = Extensions.Sum(objectIndex, AttackDirectionList[i]);
            }
        }

        protected void WaitDelayTime()
        {
            Thread.Sleep((int)(delayTime * 1000));
        }
    }
}
