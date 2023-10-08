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

        public void DispatchMessage(string message)
        {
            CommandData commandData = JsonSerializer.Deserialize<CommandData>(message);

            switch (commandData.command)
            {
                case "PlaceBuilding":
                    Building buildingToPlace = (Building)CardDictionary.Instance.cardDictionary[commandData.type](commandData.direction);
                    Field.Instance.PlaceBuilding(buildingToPlace, commandData.target);
                    break;
                case "UseSpell":
                    CardDictionary.Instance.cardDictionary[commandData.type](commandData.direction);
                    break;
            }

        }
    }
}
