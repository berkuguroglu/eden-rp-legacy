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

        [Command("createvehicle", "~w~(( KULLANIM: /createvehicle [color1] [color2] [modelhash] [ownerid] ))", GreedyArg = true)]
        public void CreateVehicle(Client player, int c1, int c2, VehicleHash hash, int ownerid, int fix = 0)
        {
            // checking player's admin level
            List<Vehicle> vehlist = events.Vevents.listofvehs;
            vehlist.Add(new Vehicle(hash, vehlist.Count, API.createVehicle(hash, new Vector3(player.position.X + 5, player.position.Y, player.position.Z), player.rotation, c1, c2), ownerid, c1, c2, player.name, player.position, true));
            API.sendChatMessageToPlayer(player, ownerid.ToString() + " ID'li oyuncuya " + hash.ToString() + " model bir araç verdiniz.");
        }
        [Command("getveh", "~w~(( KULLANIM: /getveh [vehid] ))", GreedyArg = true)]
        public void GetVehicle(Client player, int vehid, int fix = 0)
        {
            // checking player's admin level
            List<Vehicle> vehlist = events.Vevents.listofvehs;
            int turn = FindVehicle(vehid, vehlist);
            if (turn != -1)
                API.setEntityPosition(vehlist[turn].veh, new Vector3(player.position.X + 5, player.position.Y, player.position.Z));
            else API.sendChatMessageToPlayer(player, "Böyle bir araç bulunmuyor.");
        }
        public int FindVehicle(int vehid, List<Vehicle> vhl)
        {
            for (int i = 0; i < vhl.Count; i++)
            {
                if ((int)vhl[i].GetData("vehid") == vehid)
                    return i;
            }
            return -1;
        }

    }
}
