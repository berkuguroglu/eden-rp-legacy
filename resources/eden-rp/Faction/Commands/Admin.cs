using Eden.Core;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.API;

namespace Eden.Faction.Commands
{
    class Admin : Script
    {
        [Command("fcreate", "~w~(( KULLANIM: /fcreate [clientID] [isim]))", GreedyArg = true)]
        public void CreateFaction(Client player, int id, string name)
        {
            if (Core.Player.Find(player).Adminlevel > 4)
            {
                API.setEntityData(player, "fcheck", 0);
                if (EdenCore.FactionList.Count != 0)
                {
                    foreach (EdenFaction cf in EdenCore.FactionList)
                    {
                        if (cf.fName == name)
                        {
                            API.sendChatMessageToPlayer(player, "~r~Bu isimde bir oluşum zaten bulunuyor, ismi değiştirin.");
                            API.setEntityData(player, "fcheck", 1);
                            break;
                        }
                    }
                }
                if ((int)API.getEntityData(player, "fcheck") == 0)
                {
                    if (Core.Player.Find(id) == null)
                        API.sendChatMessageToPlayer(player, "~r~Böyle bir oyuncu bulunamadı.");
                    else
                    {
                        if (Core.Player.Find(id).Faction != 0)
                        {
                            API.sendChatMessageToPlayer(player, "~r~Bu oyuncu şu anda güncel olarak bir oluşumda bulunuyor. Önce bu oluşumdan çıkartın.");
                        }
                        else
                        {
                            // playerin faction idsi gelecek
                            EdenFaction newfaction = new EdenFaction(name, EdenCore.FactionList.Count + 1, id);
                            EdenCore.FactionList.Add(newfaction);
                            API.sendChatMessageToPlayer(player, "~g~" + newfaction.fName + " isimli yeni bir oluşum oluşturdunuz. " + Core.Player.Find(id).Character.Name + " adlı oyuncuyu oluşumun kurucusu yaptınız.");
                            API.sendChatMessageToPlayer(player, "~g~Oluşum ile ilgili ayarlar için /fduzenle komutunu kullanınız.");
                            Core.Player.Find(id).Faction = EdenCore.FactionList.Count;
                        }
                    }

                }
            }
            else
            {
                //
            }

        }
        [Command("fduzenle", "~w~(( KULLANIM: /fduzenle [factionID]))", GreedyArg = true)]
        public void FactionSettings(Client player, int id, int fix = 0)
        {
           if (Core.Player.Find(player).Adminlevel > 3)
           {
                EdenFaction fact = EdenFaction.Find(id);
                if (fact != null)
                    API.triggerClientEvent(player, "factionMenu", fact.fName, Core.Player.Find(fact.fID).Character.Name, fact.fID, fact.ID, fact.mCount);
                else API.sendChatMessageToPlayer(player, "~r~Bu ID'de bir oluşum bulunmuyor. /olusumlar");
           }
           else
           {
                        //
           }
        }
   }
}

