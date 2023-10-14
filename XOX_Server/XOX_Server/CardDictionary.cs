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
            { 1, (param) => new LaserCannon(param.color, param.target, param.direction) },
            { 2, (param) => new HologramBarrier(param.color, param.target, param.direction) },
            { 3, (param) => new HydroGrenade(param.color, param.target, param.direction) },
            { 4, (param) => new UFO(param.color, param.target, param.direction) },
            { 5, (param) => new SpaceStation(param.color, param.target, param.direction) },
            { 6, (param) => new LittleRobot(param.color, param.target, param.direction) },
            { 7, (param) => new BigRobot(param.color, param.target, param.direction) },
            { 8, (param) => new Laser(param.color, param.target, param.direction) },
            { 9, (param) => new Battery(param.color, param.target,param.direction) }
        };
    }
}
