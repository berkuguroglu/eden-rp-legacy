using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;
using MySql.Data.MySqlClient;
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
        public Vehicle(VehicleHash hash, int vehid, NetHandle veh, int owc, int c1, int c2, string name, Vector3 p, bool first)
        {
            modelhash = hash;
            this.veh = veh;
            this.owc = owc;
            this.color1 = c1;
            this.color2 = c2;
            ownername = name;
            this.parkposition = p;
            this.vehid = vehid;
            API.consoleOutput("Bir araç oluşturuldu."); // make logger do this
            if (first)
                SetDataForDB();
        }

        // consider getter/setter way instead (Edit->Refactor->Encapsulate field)
        public object GetData(string objectname)
        {
            switch(objectname)
            {
                case "model": return modelhash;
                case "vehid": return vehid;
                case "owc": return owc;
                 case "c1": return color1;
                 case "c2": return color2;
                 case "posx": return parkposition.X;
                 case "posy": return parkposition.Y;
                 case "posz": return parkposition.Z;
                 default: return refs; // returting a reference thats null
            }
        }
        private void SetDataForDB()
        {
            MySqlConnection connectionvehicle = EdenCore.EdenDatabaseHandler.con;
            MySqlCommand command = new MySqlCommand("INSERT INTO erp_vehicles (vehid, ownerclientid, ownername, modelhash, c1, c2, x, y, z) VALUES(@id, @ownercid, @ownname, @model, @colorone, @colortwo, @px, @py, @pz)", connectionvehicle);
            command.Parameters.AddWithValue("@id", this.vehid);
            command.Parameters.AddWithValue("@ownercid", this.owc);
            command.Parameters.AddWithValue("@ownname", this.ownername);
            command.Parameters.AddWithValue("@model", (int)this.modelhash);
            command.Parameters.AddWithValue("@colorone", this.color1);
            command.Parameters.AddWithValue("@colortwo", this.color2);
            command.Parameters.AddWithValue("@px", this.parkposition.X);
            command.Parameters.AddWithValue("@py", this.parkposition.Y);
            command.Parameters.AddWithValue("@pz", this.parkposition.Z);
            command.ExecuteNonQuery();
        }
    }
}
