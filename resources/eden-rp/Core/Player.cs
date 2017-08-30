using GrandTheftMultiplayer.Server.Elements;
using Eden.Character;

namespace Eden.Core
{
    public class Player
    {
        Client client;
        EdenCharacter character;
        int clientid;
        bool firstlogin;
        int level;
        int experience;
        int adminlevel;

        public Client Client { get { return client; } set { client = value; } }
        public EdenCharacter Character { get { return character; } set { character = value; } }
        public int Clientid { get { return clientid; } set { clientid = value; } }
        public bool Firstlogin { get { return firstlogin; } set { firstlogin = value; } }
        public int Level { get { return level; } set { level = value; } }
        public int Experience { get { return experience; } set { experience = value; } }
        public int Adminlevel { get { return adminlevel; } set { adminlevel = value; } }

        public Player(Client player)
        {
            Client = player;
            Character.Name = Client.name.Replace("_", " ");
        }

        public static Player FindPlayer(Client client)
        {
            Player player = null;
            EdenCore.PlayerList.ForEach(item => { if (item.Client == client) player = item; });
            return player;
        }
    }
}
