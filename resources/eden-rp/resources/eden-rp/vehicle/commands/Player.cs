using Eden.Core;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;

namespace Eden.Vehicle.Commands
{
    class Player : Script
    {

        [Command("motor", GreedyArg = false)]
        public void engine(Client player)
        {
            if (API.isPlayerInAnyVehicle(player) == true && API.getPlayerVehicleSeat(player) == -1)
            {
                int myveh = EdenVehicle.FindVehicle(API.getPlayerVehicle(player));
                Eden.Core.Player peh = Eden.Core.Player.FindPlayer(player);
                if (myveh == -1) API.sendChatMessageToPlayer(player, "Bir hata oluştu.");
                if (EdenCore.VehicleList[myveh].EngineStatus && EdenCore.VehicleList[myveh].Owc == peh.Clientid)
                {
                    API.setVehicleEngineStatus(API.getPlayerVehicle(player), true);
                    EdenCore.VehicleList[myveh].EngineStatus = true;
                }
                else
                {
                    API.setVehicleEngineStatus(API.getPlayerVehicle(player), false);
                    EdenCore.VehicleList[myveh].EngineStatus = false;
                }

            }
            else API.sendChatMessageToPlayer(player, "Bu komutu uygulayabilmek için herhangi bir aracın içerisinde olmalısınız ya da araç size ait değil.");
    }
}
