using System.Collections.Generic;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;

namespace Eden.Core.Commands
{
    public class Player : Script
    {
        [Command("me", GreedyArg = true)]
        public void EmoteMe(Client player, string message)
        {
            List<Client> melist = API.getPlayersInRadiusOfPlayer(20, player);
            foreach (Client p in melist)
            {
                API.sendChatMessageToPlayer(p, "~#ff33cc~", player.name + " " + message);
            }
        }
        [Command("do", "~w~(( KULLANIM: /do [eylem] ))", GreedyArg = true)]
        public void EmoteDo(Client player, string message)
        {
            List<Client> dolist = API.getPlayersInRadiusOfPlayer(20, player);
            foreach (Client p in dolist)
            {
                API.sendChatMessageToPlayer(p, "~#ff33cc~", message + " (( " + player.name + " ))");
            }
        }
        [Command("c", "~w~(( KULLANIM: /c [konuşma] ))", GreedyArg = true)]
        public void ChatSilent(Client player, string message)
        {
            List<Client> plist = API.getPlayersInRadiusOfPlayer(10, player);
            foreach (Client p in plist)
            {
                API.sendChatMessageToPlayer(p, "~#a6a6a6~", player.name + "(sessizce): " + message);
            }
        }
        [Command("s", "~w~(( KULLANIM: /b [konuşma] ))", GreedyArg = true)]
        public void ChatShout(Client player, string message)
        {
            List<Client> plist = API.getPlayersInRadiusOfPlayer(40, player);
            foreach (Client p in plist)
            {
                API.sendChatMessageToPlayer(p, "~#f2f2f2~", player.name + "(bağırarak): " + message);
            }
        }
        [Command("b", "~w~(( KULLANIM: /b [konuşma] ))", GreedyArg = true)]
        public void ChatOOC(Client player, string message)
        {
            List<Client> plist = API.getPlayersInRadiusOfPlayer(40, player);
            foreach (Client p in plist)
            {
                API.sendChatMessageToPlayer(p, "~#a6a6a6~", "(( OOC )) " + player.name + ": " + message);
            }
        }

        [Command("pm", "~w~(( KULLANIM: /pm [clientID] [mesaj] ))", GreedyArg = true)]
        public void PrivateMessage(Client player, int clid, string message)
        {
            bool state = false;
            foreach (Eden.Core.Player receiver in EdenCore.PlayerList)
            {
                if (clid == receiver.Clientid)
                {
                    string info = "~y~(( [PM] - " + receiver.Character.Name + ": " + message + " ))";
                    API.sendChatMessageToPlayer(player, info);
                    info = "~y~(( [PM] - " + Eden.Core.Player.FindPlayer(player).Character.Name + ": " + message + " ))";
                    API.sendChatMessageToPlayer(receiver.Client, info);
                    state = true;
                    break;
                }
            }
            if (state == false)
                API.sendChatMessageToPlayer(player, "Bu oyuncu oyunda değil."); // replace error message function
        }
    }
}