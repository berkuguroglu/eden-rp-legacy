using Eden.Core;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.API;
using System.Collections;
namespace Eden.Faction
{
    class EdenFaction
    {
        string FactionName;
        int FactionID;
        int founderID;
        static int fcount = EdenCore.FactionList.Count;
        int members;
        ArrayList memberList;
        ArrayList memberListName;
        public EdenFaction(string name, int id, int clientid)
        {
            this.FactionName = name;
            FactionID = id;
            founderID = clientid;
            members = 1;
            fCount();
            memberList = new ArrayList();
            memberListName = new ArrayList();
            memberList.Add(id);
            memberListName.Add(Player.Find(clientid).Character.Name);

        }
        public string fName{ get {return FactionName;} set {FactionName = value; } }
        public int ID { get { return FactionID; } set { FactionID = value; } }
        public int fID { get { return founderID; } set { founderID = value; } }
        public int mCount { get { return members; } set { members = value; } }
        public ArrayList names { get { return memberListName; } }
        public ArrayList ids { get { return memberList; } }

        private void fCount()
        {
            fcount++;
        }
        internal static EdenFaction Find(int id)
        {         
            foreach(EdenFaction e in EdenCore.FactionList)
            {
                if (e.FactionID == id) return e;
            }
            return null;
        }
        internal void AddMember(int clientid)
        {
            memberList.Add(clientid);
            memberListName.Add(Player.Find(clientid).Character.Name);
        }
    }
}
