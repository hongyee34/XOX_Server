using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace XOX_Server
{ 
    public class Dispatcher : Singleton<Dispatcher>
    {

        public async void DispatchMessage(string message)
        {
            CommandData commandData = JsonSerializer.Deserialize<CommandData>(message, Extensions.options);
            Console.WriteLine($"명령: {commandData.command}");
            Console.WriteLine($"타입: {commandData.type}");

            switch (commandData.command)
            {
                case "PlaceBuilding":
                    Building buildingToPlace = (Building)CardDictionary.Instance.cardDictionary[commandData.type](commandData);
                    Field.Instance.PlaceBuilding(buildingToPlace, commandData.target);
                    Console.WriteLine("설치됨");
                    await Program.BroadcastMessage(message);
                    break;
                case "UseSpell":
                    CardDictionary.Instance.cardDictionary[commandData.type](commandData);
                    await Program.BroadcastMessage(message);
                    Console.WriteLine("마법 설치됨");
                    break;
                default:
                    Console.WriteLine("명령 잘못됨");
                    break;
            }

        }
    }
}
