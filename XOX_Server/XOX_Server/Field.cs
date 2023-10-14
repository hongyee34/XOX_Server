using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX_Server
{
    public class Field : Singleton<Field>
    {
        private Building[,] field = new Building[3,3];

        public void PlaceBuilding(Building building, (int x,int y) target)
        {
            field[target.x, target.y] = building;
        }

        public bool Damage(int power, string color, List<(int x,int y)> targetList)
        {
            List<(int x, int y)> validTargetList = new();
            foreach ((int x, int y) target in targetList)
            {
                (int x,int y) index = Extensions.ConvertPositionToIndex(target);
                if (IndexOutOfRange(index))
                    continue;
                ref Building targetField = ref field[index.x, index.y];
                if (targetField != null && targetField.teamColor != color)
                {
                    targetField.GetDamage(power);
                    validTargetList.Add(index);
                }
            }

            if (validTargetList.Count == 0)
                return false;
            else
            {
                foreach (var target in validTargetList)
                    Console.WriteLine(target.x + " " + target.y);
                Extensions.SendCommandData("DamageBuilding",power,validTargetList);
                return true;
            }
        }

        public bool Heal(int power, string color, List<(int x, int y)> targetList)
        {
            List<(int x, int y)> validTargetList = new();
            foreach ((int x, int y) target in targetList)
            {
                (int x, int y) index = Extensions.ConvertPositionToIndex(target);
                if (IndexOutOfRange(index))
                    continue;
                ref Building targetField = ref field[index.x, index.y];
                if (targetField != null && targetField.teamColor == color)
                {
                    targetField.GetHeal(power);
                    validTargetList.Add(index);
                }
            }

            if (validTargetList.Count == 0)
                return false;
            else
            {
                Extensions.SendCommandData("HealBuilding", power, validTargetList);
                return true;
            }
        }

        public bool Barrier(int power, string color, List<(int x, int y)> targetList)
        {
            List<(int x, int y)> validTargetList = new();
            foreach ((int x, int y) target in targetList)
            {
                (int x, int y) index = Extensions.ConvertPositionToIndex(target);
                if (IndexOutOfRange(index))
                    continue;
                ref Building targetField = ref field[index.x, index.y];
                if (targetField != null && targetField.teamColor == color)
                {
                    targetField.GetBarrier(power);
                    validTargetList.Add(index);
                }
            }

            if (validTargetList.Count == 0)
                return false;
            else
            {
                Extensions.SendCommandData("BarrierBuilding", power, validTargetList);
                return true;
            }
        }

        public void DestroyBuilding((int x,int y) position)
        {
            Console.WriteLine("Dead");
            (int x, int y) index = Extensions.ConvertPositionToIndex(position);
            field[index.x, index.y] = null;
        }

        private bool IndexOutOfRange((int x,int y) index)
        {
            if (index.x <= 2 && index.x >= 0 && index.y <= 2 && index.y >= 0)
                return false;
            else
                return true;
        }
    }
}
