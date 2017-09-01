using Eden.Core;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.API;

namespace Eden.Core.Commands
{
    class Admin : Script
    {
        [Command("gotoplayer", "~w~(( KULLANIM: /gotoplayer [clientid]))", GreedyArg = true)]
        public void GoToPlayer(Client player, int id, int fix = 0)
        {
            if (Core.Player.FindPlayer(player).Adminlevel > 2)
            {
                Core.Player peh = Core.Player.FindPlayer(id);
                if (peh == null) API.sendChatMessageToPlayer(player, "~r~Bu oyuncu oyunda değil.");
                else API.setEntityPosition(player, peh.Client.position);
            }
        }
        [Command("getplayer", "~w~(( KULLANIM: /getplayer [clientid]))", GreedyArg = true)]
        public void GetPlayer(Client player, int id, int fix = 0)
        {
            if (Core.Player.FindPlayer(player).Adminlevel > 2)
            {
                Core.Player peh = Core.Player.FindPlayer(id);
                if (peh == null) API.sendChatMessageToPlayer(player, "~r~Bu oyuncu oyunda değil.");
                else API.setEntityPosition(peh.Client, player.position);
            }

        }
        [Command("setskin", "~w~(( KULLANIM: /setskin [clientid] [pedhash]))", GreedyArg = true)]
        public void SetPlayerSkin(Client player, int id, PedHash ped, int fix = 0)
        {
            if (Core.Player.FindPlayer(player).Adminlevel > 2)
            {
                Core.Player peh = Core.Player.FindPlayer(id);
                if (peh == null) API.sendChatMessageToPlayer(player, "~r~Bu oyuncu oyunda değil.");
                else
                {
                    API.setPlayerSkin(peh.Client, ped);
                }
            }

        }

    }
}
