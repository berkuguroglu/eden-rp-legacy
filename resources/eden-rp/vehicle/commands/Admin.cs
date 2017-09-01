using Eden.Core;
using Eden.Vehicle;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace Eden.Vehicle.Commands
{
    class Admin : Script
    {
        [Command("createvehicle", "~w~(( KULLANIM: /createvehicle [color1] [color2] [modelhash] [ownerid] ))", GreedyArg = true)]
        public void CreateVehicle(Client player, int c1, int c2, VehicleHash hash, int ownerid, int fix = 0)
        {
            Core.Player sender = Core.Player.FindPlayer(player); 
            if (!sender.Equals(null) && sender.Adminlevel > 3)
            {
                Eden.Core.Player localp = Eden.Core.Player.FindPlayer(ownerid);
                if (localp != null)
                {
                    EdenCore.VehicleList.Add(new EdenVehicle(hash, EdenCore.VehicleList.Count, API.createVehicle(hash, new Vector3(player.position.X + 5, player.position.Y, player.position.Z), player.rotation, c1, c2), ownerid, c1, c2, localp.Character.Name, player.position, true));
                    API.sendChatMessageToPlayer(player, ownerid.ToString() + " ID'li oyuncuya " + hash.ToString() + " model bir araç verdiniz.");
                }
                else API.sendChatMessageToPlayer(player, "Bu ID'de bir oyuncu bulunamadı."); // replace error message function
            }
            else
            {
                // not admin
            }   
        }

        [Command("getveh", "~w~(( KULLANIM: /getveh [vehid] ))", GreedyArg = true)]
        public void GetVehicle(Client player, int vehid, int fix = 0)
        {
            Core.Player sender = Core.Player.FindPlayer(player);
            if (!sender.Equals(null) && sender.Adminlevel > 2)
            {
                int turn = EdenVehicle.FindVehicle(vehid);
                if (turn != -1)
                {
                    API.setEntityPosition(EdenCore.VehicleList[turn].Veh, new Vector3(player.position.X + 5, player.position.Y, player.position.Z));
                }
                    
                else API.sendChatMessageToPlayer(player, "Böyle bir araç bulunmuyor.");
            }
            else
            {
                // not admin
            }
        }
    }
}
