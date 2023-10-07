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

            if(commandData?.command == "PlaceBuilding")
            {
                Building buildingToPlace = (Building)CardDictionary.Instance.cardDictionary[commandData.type](commandData.direction);
                Field.Instance.PlaceBuilding(buildingToPlace, commandData.target);
            }
        }
    }
}
