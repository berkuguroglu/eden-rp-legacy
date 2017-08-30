using System.Collections.Generic;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace eden_rp.vehicle.commands
{
    class Admin : Script
    {
        static List<Vehicle> vehlist = new List<Vehicle>();
        [Command("createvehicle", "~w~(( KULLANIM: /createvehicle [modelhash] [color1] [color2] [ownerid] ))", GreedyArg = true)]
        public void CreateVehicle(Client player, VehicleHash hash, int c1, int c2, int ownerid)
        {
            // checking player's admin level 
            vehlist.Add(new Vehicle(hash, vehlist.Count, API.createVehicle(hash, new Vector3(player.position.X+2, player.position.Y, player.position.Z), player.rotation, c1, c2), ownerid, c1, c2, player.name, player.position, true);
            API.sendChatMessageToPlayer(player, ownerid.ToString() + " ID'li oyuncuya " + hash.ToString() + "hash model bir araç verdiniz.");
        }

    }
}
