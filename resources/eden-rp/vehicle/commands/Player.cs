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
        public void engine(Client player)
        {
            if (API.isPlayerInAnyVehicle(player) == true && API.getPlayerVehicleSeat(player) == -1)
            {
                int myveh = EdenVehicle.FindVehicle(API.getPlayerVehicle(player));
                Eden.Core.Player peh = Eden.Core.Player.FindPlayer(player);
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
                        foreach (Client p in lst)
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
        [Command("araclarim", GreedyArg = false)]
        public void CheckingVehicles(Client player)
        {
            Eden.Core.Player thsclient = Eden.Core.Player.FindPlayer(player);
            bool state = false;
            foreach (EdenVehicle veh in EdenCore.VehicleList)
            {
                if(veh.Owc == thsclient.Clientid)
                {
                    state = true;
                    if (veh.EngineStatus)
                    API.sendChatMessageToPlayer(player, "~r~(([ID] ~w~" + veh.Vehid.ToString() + " ~r~|| ~w~" + veh.Modelhash.ToString() + "~r~ || Motor: ~g~Açık" + "~r~ ))");
                    else
                    API.sendChatMessageToPlayer(player, "~r~(([ID] ~w~" + veh.Vehid.ToString() + " ~r~|| ~w~" + veh.Modelhash.ToString() + "~r~ || Motor: ~r~Kapalı" + "~r~ ))");
                }
            }
            if (!state) API.sendChatMessageToPlayer(player, "~r~Aracınız bulunmuyor.");
            
        
        }
        [Command("parket", GreedyArg = false)]
        public void ParkVehicle(Client player)
        {
            NetHandle yvs;
            if (API.isPlayerInAnyVehicle(player))
            {
                yvs = API.getPlayerVehicle(player);
                int index = EdenVehicle.FindVehicle(yvs);
                if (Core.Player.FindPlayer(player).Clientid != EdenCore.VehicleList[index].Owc)
                    API.sendChatMessageToPlayer(player, "~r~Sadece kendi araçlarınızı parkedebilirsiniz.");
                else
                {
                    EdenCore.VehicleList[index].Parkposition = API.getEntityPosition(player);
                    API.sendChatMessageToPlayer(player, "~g~" + EdenCore.VehicleList[index].Vehid.ToString() + " ID'li aracınızı bulunduğunuz konuma parkettiniz.");
                    API.sendChatMessageToPlayer(player, "~g~Aracınız artık bu konumda re-spawn olacak.");
                    EdenCore.VehicleList[index].EngineStatus = false;
                    API.setVehicleEngineStatus(EdenCore.VehicleList[index].Veh, false);
                    API.setEntityPosition(EdenCore.VehicleList[index].Veh, player.position);
                }
                  
            }
            else API.sendChatMessageToPlayer(player, "~r~Bu komutu uygulayabilmek için bir aracın içerisinde olmalısın.");
        }
        [Command("akilit", GreedyArg = false)]
        public void LockVehicle(Client player)
        {

            foreach (EdenVehicle check in EdenCore.VehicleList)
            {
                if (check.Owc == Eden.Core.Player.FindPlayer(player).Clientid)
                {
                    List<Client> lockdoor = API.getPlayersInRadiusOfPosition(3, API.getEntityPosition(check.Veh));
                    foreach (Client t in lockdoor)
                    {
                        if (t == player)
                        {
                            foreach(Client tagain in lockdoor)
                            API.sendChatMessageToPlayer(tagain, "~#ff33cc~", player.name + " aracın anahtarlarını çıkarır ve aracın kilit tuşuna basar.");
                            if (check.LockStatus == true)
                            {
                                API.setVehicleLocked(check.Veh, false);
                                check.LockStatus = false;
                            }
                            else
                            {
                                API.setVehicleLocked(check.Veh, true);
                                check.LockStatus = true;
                            }
                            break;
                        }
                    }
                }
            }
        }

    }
 }
