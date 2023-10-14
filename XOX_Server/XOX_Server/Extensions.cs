using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace XOX_Server
{
    public class Extensions
    {
        public static JsonSerializerOptions options = new() { IncludeFields = true };

        public static (int x, int y) ConvertIndexToPosition((int x,int y) index)
        {
            return (index.x - 1, index.y - 1);
        }

        public static (int x, int y) ConvertPositionToIndex((int x,int y) position)
        {
            return (position.x + 1, position.y + 1);
        }

        public static (int, int) Sum((int, int) tuple1, (int, int) tuple2)
        {
            return (tuple1.Item1+tuple2.Item1, tuple1.Item2+tuple2.Item2);
        }

        public static (int, int) Difference((int, int) tuple1, (int, int) tuple2)
        {
            return (tuple1.Item1 - tuple2.Item1, tuple1.Item2 - tuple2.Item2);
        }

        public static async void SendCommandData(string command,int amount,List<(int x,int y)> targetList) 
        {
            CommandData commandData = new CommandData()
            {
                command = command,
                amount = amount,
                targetList = targetList
            };

            await Program.BroadcastMessage(JsonSerializer.Serialize(commandData, options));
        }

        public static async void SendCommandData(string command, int amount)
        {
            CommandData commandData = new CommandData()
            {
                command = command,
                amount = amount
            };

            await Program.BroadcastMessage(JsonSerializer.Serialize(commandData, options));
        }
    }
}
