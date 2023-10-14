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

        public string teamColor;
        protected (int x, int y) objectPosition;
        protected int direction;
        protected List<(int x, int y)> AttackDirectionList = new();
        protected List<(int x,int y)> targetList = new();

        protected abstract void RunCard();

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
                targetList.Add(Extensions.Sum(objectPosition, AttackDirectionList[i]));
            }
        }

        public void SetObjectPosition((int,int) index)
        {
            objectPosition = Extensions.ConvertIndexToPosition(index);
        }

    }
}
