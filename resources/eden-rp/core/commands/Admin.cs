using Eden.Core;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.API;

namespace Eden.Core.Commands
{
    class Admin : Script
    {
        [Command("mylocation")]
        public void PrintPosition(Client player) { API.consoleOutput("Location information of {0}\nPosition\nX: {1} Y: {2} Z: {3}\nRotation\nX: {4} Y: {5} Z: {6}", player.name, player.position.X, player.position.Y, player.position.Z, player.rotation.X, player.rotation.Y, player.rotation.Z); }
        [Command("gotoplayer", "~w~(( KULLANIM: /gotoplayer [clientid]))", GreedyArg = true)]
        public void GoToPlayer(Client player, int id, int fix = 0)
        {
            if (Core.Player.Find(player).Adminlevel > 2)
            {
                Core.Player peh = Core.Player.Find(id);
                if (peh == null) API.sendChatMessageToPlayer(player, "~r~Bu oyuncu oyunda değil.");
                else API.setEntityPosition(player, peh.Client.position);
            }
        }
        [Command("getplayer", "~w~(( KULLANIM: /getplayer [clientid]))", GreedyArg = true)]
        public void GetPlayer(Client player, int id, int fix = 0)
        {
            if (Core.Player.Find(player).Adminlevel > 2)
            {
                Core.Player peh = Core.Player.Find(id);
                if (peh == null) API.sendChatMessageToPlayer(player, "~r~Bu oyuncu oyunda değil.");
                else API.setEntityPosition(peh.Client, player.position);
            }

        }
        [Command("setskin", "~w~(( KULLANIM: /setskin [clientid] [pedhash]))", GreedyArg = true)]
        public void SetPlayerSkin(Client player, int id, PedHash ped, int fix = 0)
        {
            if (Core.Player.Find(player).Adminlevel > 2)
            {
                Core.Player peh = Core.Player.Find(id);
                if (peh == null) API.sendChatMessageToPlayer(player, "~r~Bu oyuncu oyunda değil.");
                else
                {
                    API.setPlayerSkin(peh.Client, ped);
                }
            }

        }
        [Command("kick", "~w~(( KULLANIM: /kick [clientid] [sebep]))", GreedyArg = true)]
        public void KickPlayer(Client player, int id, string reason, int fix = 0)
        {
            if (Core.Player.Find(player).Adminlevel >= 2)
            {
                Core.Player peh = Core.Player.Find(id);
                if (peh == null) API.sendChatMessageToPlayer(player, "~r~Bu oyuncu oyunda değil.");
                else
                {
                    string info = "~r~(( ~w~" + peh.Character.Name + " adlı oyuncu " + reason + " nedeniyle " + Core.Player.Find(player).Character.Name + " tarafından sunucudan atıldı. ~r~))";
                    API.sendChatMessageToAll(info);
                    peh.Client.kick();
                }
            }

        }
        [Command("duyuru", "~w~(( KULLANIM: /duyuru [duyuru]))", GreedyArg = true)]
        public void Announce(Client player, string ann)
        {
            if (Core.Player.Find(player).Adminlevel >= 2)
            {
                API.sendChatMessageToAll("~r~(( DUYURU: ~w~" + ann +" ~r~))");
            }

        }


    }

}
