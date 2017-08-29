﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

public class Player : Script
{
    [Command("me", GreedyArg = true)]
    public void mes(Client player, string message)
    {
        List<Client> melist = API.getPlayersInRadiusOfPlayer(20, player);
        foreach (Client p in melist)
        {
            API.sendChatMessageToPlayer(p, "~#ff33cc~", player.name + ": " + message);
        }
    }
    [Command("do", "~w~(( KULLANIM: /do [eylem] ))", GreedyArg = true)]
    public void dos (Client player, string message)
    {
        List<Client> dolist = API.getPlayersInRadiusOfPlayer(20, player);
        foreach (Client p in dolist)
        {
            API.sendChatMessageToPlayer(p, "~#ff33cc~", message + "(( " + player.name + " ))");
        }
    }
    [Command("c", "~w~(( KULLANIM: /c [konuşma] ))", GreedyArg = true)]
    public void c(Client player, string message)
    {
        List<Client> plist = API.getPlayersInRadiusOfPlayer(10, player);
        foreach (Client p in plist)
        {
            API.sendChatMessageToPlayer(p, "~#f2f2f2~", player.name + "(sessizce) :" + message);
        }
    }
    [Command("s", "~w~(( KULLANIM: /b [konuşma] ))", GreedyArg = true)]
    public void s(Client player, string message)
    {
        List<Client> plist = API.getPlayersInRadiusOfPlayer(40, player);
        foreach (Client p in plist)
        {
            API.sendChatMessageToPlayer(p, "~#a6a6a6~", player.name+"(bağırarak) :"+message);
        }
    }
    [Command("b", "~w~(( KULLANIM: /b [konuşma] ))", GreedyArg = true)]
    public void b(Client player, string message)
    {
        List<Client> plist = API.getPlayersInRadiusOfPlayer(40, player);
        foreach (Client p in plist)
        {
            API.sendChatMessageToPlayer(p, "~#a6a6a6~", "(( OOC )) " + player.name + " :"+  message);
        }
    }
    /* [Command("pm", GreedyArg = true)]
     public void pm(Client player, int clid, string message)
     {
         bool state = false;
         foreach (players c in connectionfirst.plyrs)
         {
             if (clid == c.clientid)
             {
                 string info = "~y~(( [PM] - " + c.plyr.name + ": " + message + " ))";
                 API.sendChatMessageToPlayer(player, info);
                 info = "~y~(( [PM] - " + player.name + ": " + message + " ))";
                 API.sendChatMessageToPlayer(c.plyr, info);
                 state = true;
                 break;
             }
         }
         if (state == false) dmgs.SendErrorMessage(player, "Bu oyuncu oyunda değil.");
     } // Burası player datalarına göre düzenlenecek.
     [Command("motor", GreedyArg = false)]
     public void engine(Client player)
     {
         defaultmessages dmg = new defaultmessages();
         if (API.isPlayerInAnyVehicle(player) == true && API.getPlayerVehicleSeat(player) == -1)
         {
             foreach (vehicles v in connectionfirst.vehs)
             {
                 if (v.veh == API.getPlayerVehicle(player))
                 {
                     int i;
                     for (i = 0; i < connectionfirst.plyrs.Count; i++)
                     {
                         if (player == connectionfirst.plyrs[i].plyr && v.getowner() == connectionfirst.plyrs[i].getInfo("clientid"))
                         {
                             v.engines(player);
                             break;
                         }

                         else
                         {
                             dmg.SendErrorMessage(player, "Bu araç size ait değil.");
                             break;
                         }
                     }
                 }
             }

         }
         else
         {
             dmg.SendErrorMessage(player, "Bu komutu kullanabilmek için bir aracın içerisinde olmalısınız.");
         }*/
}
