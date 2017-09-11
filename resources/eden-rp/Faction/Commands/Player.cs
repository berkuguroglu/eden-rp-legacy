
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.API;
using Newtonsoft.Json;
namespace Eden.Faction.Commands
{
    class Player : Script
    {

        [Command("olusum", GreedyArg = false)]
        public void FactionCreatingForPlayer(Client player)
        {
            if (Core.Player.Find(player).Faction == 0)
            {
                if (Core.Player.Find(player).Level >= 5)
                    API.triggerClientEvent(player, "creatingFactionForPlayer", Core.Player.Find(player).Clientid);
                else API.sendChatMessageToPlayer(player, "~r~Oluşum kurabilmeniz için en az 5. seviye olmanız gerekiyor.");
            }
            else API.sendChatMessageToPlayer(player, "~r~Oluşum kurabilmek için önce bulunduğunuz oluşum " + EdenFaction.Find(Core.Player.Find(player).Faction).fName + "'den çıkmanız gerekiyor.");

        }
        [Command("olusumduzenle", GreedyArg = false)]
        public void FactionEditingForPlayer(Client player)
        {
            if (Core.Player.Find(player).Faction != 0 && EdenFaction.Find(Core.Player.Find(player).Faction).fID == Core.Player.Find(player).Clientid)
            {
                API.triggerClientEvent(player, "creatingMenuForPlayer", EdenFaction.Find(Core.Player.Find(player).Faction).fName, EdenFaction.Find(Core.Player.Find(player).Faction).ID, Core.Player.Find(player).Character.Name, EdenFaction.Find(Core.Player.Find(player).Faction).fID, EdenFaction.Find(Core.Player.Find(player).Faction).mCount, JsonConvert.SerializeObject(EdenFaction.Find(Core.Player.Find(player).Faction).names).ToString());
            }
            else API.sendChatMessageToPlayer(player, "~r~Bulunduğunuz oluşumu düzenleyemezsiniz ya da oluşumda bulunmuyorsunuz.");

        }



    }
}
