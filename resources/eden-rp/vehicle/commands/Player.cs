using Eden.Core;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using System.Collections.Generic;

namespace Eden.Vehicle.Commands
{
    class Player : Script
    {

        [Command("motor", GreedyArg = false)]
        public void Engine(Client player)
        {
            if (API.isPlayerInAnyVehicle(player) == true && API.getPlayerVehicleSeat(player) == -1)
            {
                int myveh = EdenVehicle.FindVehicle(API.getPlayerVehicle(player));
                Core.Player peh = Core.Player.Find(player);
                if (myveh == -1) API.sendChatMessageToPlayer(player, "Bir hata oluştu.");
                if (EdenCore.VehicleList[myveh].Owc != peh.Clientid)
                API.sendChatMessageToPlayer(player, "Bu araç size ait değil.");
                else
                {
                    if (!EdenCore.VehicleList[myveh].EngineStatus)
                    {
                        API.setVehicleEngineStatus(API.getPlayerVehicle(player), true);
                        EdenCore.VehicleList[myveh].EngineStatus = true;
                        List<Client> lst = API.getPlayersInRadiusOfPlayer(20, player);
                        foreach(Client p in lst)
                        API.sendChatMessageToPlayer(p, "~#ff33cc~", player.name + " aracın anahtarını kontağa sokar ve çevirir.");
                    }
                    else
                    {
                        API.setVehicleEngineStatus(API.getPlayerVehicle(player), false);
                        EdenCore.VehicleList[myveh].EngineStatus = false;
                    }
                }
            }
            else API.sendChatMessageToPlayer(player, "~r~Bu komutu uygulayabilmek için herhangi bir aracın içerisinde olmalısınız ya da araç size ait değil.");
      }
   }
}
