using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOX_Server.Buildings;
using XOX_Server.Spells;

namespace XOX_Server
{
    public class CardDictionary : Singleton<CardDictionary>
    {
        public Dictionary<int, Func<int, Card>> cardDictionary = new()
        {
            { 1, (param) => new LittleRobot(param) },
            {2, (param) => new Laser(param) }
        };
    }
}
