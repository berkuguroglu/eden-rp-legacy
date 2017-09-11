using GrandTheftMultiplayer.Server.Elements;
using Eden.Character;
using GrandTheftMultiplayer.Shared;
using System.Collections.Generic;

namespace Eden.Core
{
    public class Player
    {
        Client client;
        EdenCharacter character = new EdenCharacter();
        int clientid;
        bool firstlogin;
        int level;
        int experience;
        int adminlevel;
        int factionID;
        NetHandle loginentity;

        public Client Client { get { return client; } set { client = value; } }
        public EdenCharacter Character { get { return character; } set { character = value; } }
        public int Clientid { get { return clientid; } set { clientid = value; } }
        public bool Firstlogin { get { return firstlogin; } set { firstlogin = value; } }
        public int Level { get { return level; } set { level = value; } }
        public int Experience { get { return experience; } set { experience = value; } }
        public int Adminlevel { get { return adminlevel; } set { adminlevel = value; } }
        public int Faction { get { return factionID; } set { factionID = value; } }
        public NetHandle LoginEntity { get { return loginentity; } set { loginentity = value; } }

        public Player(Client player)
        {
            Client = player;
            Character.Name = Client.name.Replace("_", " ");
            EdenCore.api.setPlayerNametag(player, this.Character.Name); 

        }

        public static Player Find(Client client)
        {
            Player player = null;
            EdenCore.PlayerList.ForEach(item => { if (item.Client == client) player = item; });
            return player;
        }

        public static Player Find(int clientid)
        {
            Player player = null;
            EdenCore.PlayerList.ForEach(item => { if (item.Clientid == clientid) player = item; });
            return player;
        }

        public static List<Player> FindRange(Client client, float radius)
        {
            List<Player> around = new List<Player>();
            List<Client> clients = EdenCore.api.getPlayersInRadiusOfPlayer(radius, client);
            foreach (Player p in EdenCore.PlayerList)
            {
                foreach (Client c in clients)
                {
                    if (c == p.client) around.Add(p);
                }
            }
            if (around.Count > 0) return around; else return null;
        }

        public void SyncCharacter()
        {
            EdenCore.api.sendNativeToAllPlayers(0x9414E18B9434C2FE, Client, Character.Heritage.Mom, Character.Heritage.Dad, 0, Character.Heritage.Mom, Character.Heritage.Dad, 0, Character.Heritage.ShapeMix, Character.Heritage.SkinMix, 0.0f, false);
            EdenCore.api.sendNativeToAllPlayers(0x4CFFC65454C93A49, Client, Character.Hair.Color, Character.Hair.Highlight);
            EdenCore.api.sendNativeToAllPlayers(0x48F44967FA05CC1E, Client, 2, Character.Hair.Eyebrow, 1.0f);
            EdenCore.api.sendNativeToAllPlayers(0x497BF74A7B9CB952, Client, 2, 1, Character.Hair.EyebrowColor, Character.Hair.EyebrowColor);
            EdenCore.api.sendNativeToAllPlayers(0x48F44967FA05CC1E, Client, 1, Character.Hair.FacialHair, 1.0f);
            EdenCore.api.sendNativeToAllPlayers(0x497BF74A7B9CB952, Client, 1, 1, Character.Hair.FacialHairColor, Character.Hair.FacialHairColor);
            EdenCore.api.sendNativeToAllPlayers(0x48F44967FA05CC1E, Client, Character.Face.Blemishes, 1.0f);
            EdenCore.api.sendNativeToAllPlayers(0x48F44967FA05CC1E, Client, Character.Face.Ageing, 1.0f);
            EdenCore.api.sendNativeToAllPlayers(0x48F44967FA05CC1E, Client, Character.Face.Complexion, 1.0f);
            EdenCore.api.sendNativeToAllPlayers(0x48F44967FA05CC1E, Client, 7, Character.Face.SunDamage, 1.0f);
            EdenCore.api.sendNativeToAllPlayers(0x48F44967FA05CC1E, Client, 9, Character.Face.Freckles, 1.0f);
        }
    }
}
