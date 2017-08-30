﻿using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;
using Eden.Core;

namespace Eden.Vehicle
{
    public class EdenVehicle : Script
    {
        VehicleHash modelhash;
        private NetHandle veh;
        int vehid; // UNIQUE_PRIMARY_KEY
        int owc; // OWNER_CLIENT_ID
        int color1, color2;
        // int[] keys; pasif
        string ownername;
        object refs;
        Vector3 parkposition;

        public VehicleHash Modelhash { get { return modelhash; } set { modelhash = value; } }
        public NetHandle Veh { get { return veh; } set { veh = value; } }
        public int Vehid { get { return vehid; } set { vehid = value; } }
        public int Owc { get { return owc; } set { owc = value; } }
        public int Color1 { get { return color1; } set { color1 = value; } }
        public int Color2 { get { return color2; } set { color2 = value; } }
        public string Ownername { get { return ownername; } set { ownername = value; } }
        public object Refs { get { return refs; } set { refs = value; } }
        public Vector3 Parkposition { get { return parkposition; } set { parkposition = value; } }

        public EdenVehicle()
        {
            // default constructor
        }
        public EdenVehicle(VehicleHash hash, int vehid, NetHandle veh, int owc, int c1, int c2, string name, Vector3 p, bool first)
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
            if (first) DatabaseHandler.AddVehicle(this);
        }
    }
}
