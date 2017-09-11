using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared.Math;
using GrandTheftMultiplayer.Shared;
using System.Collections.Generic;

namespace Eden.Core.Statics
{
    class Buildings : Script
    {

        const int markertype = 3;
        internal static List<Vector3> markerstatics = new List<Vector3>();
        internal static List<Vector3> interiorstatics = new List<Vector3>();
        public Buildings()
        {
            //lspd
            markerstatics.Add(new Vector3(478.5573, -979.0364, 27.98388)); // 0 index
            interiorstatics.Add(new Vector3(-141.392, -621.0451, 168.8204)); // 0 index
            //
            
        }
        
        public static void LoadStaticMarkers()
        {

            EdenCore.api.createMarker(markertype, markerstatics[0], new Vector3(), new Vector3(), new Vector3(0.5f, 0.5f, 0.5f), 255, 153, 204, 3, 0);
        }
    }
}
