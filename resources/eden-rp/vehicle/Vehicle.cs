using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace eden_rp.vehicle
{
    class Vehicle : Script  
    {
        VehicleHash modelhash;
        public NetHandle veh;
        int vehid; // UNIQUE_PRIMARY_KEY
        int owc; // OWNER_CLIENT_ID
        int color1, color2;
        // int[] keys; pasif
        string ownername;
        object refs;
        Vector3 parkposition;
        public Vehicle()
        {
            // default constructor
        }
        public Vehicle(VehicleHash hash, NetHandle veh, int owc, int c1, int c2, string name, Vector3 p)
        {
            modelhash = hash;
            this.veh = veh;
            this.owc = owc;
            this.color1 = c1;
            this.color2 = c2;
            ownername = name;
            this.parkposition = p;
            API.consoleOutput("Bir araç oluşturuldu."); // make logger do this
            // mysql insertion işlemi
        }
        public object gData(string objectname)
        {
            switch(objectname)
            {
                 case "model"; return modelhash;
                 case "vehid"; return vehid;
                 case "owc"; return owc;
                 case "c1": return color1;
                 case "c2": return color2;
                 case "posx": return parkposition.X;
                 case "posy": return parkposition.Y;
                 case "posz": return parkposition.Z;
                 default: return refs; // returting a reference thats null 
            }

        }
       
    }
}
