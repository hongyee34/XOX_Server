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
        public Dictionary<int, Func<CommandData, Card>> cardDictionary = new()
        {
            { 1, (param) => new LittleRobot(param.direction) },
            { 2, (param) => new Laser(param.target,param.direction) }
        };
    }
}
