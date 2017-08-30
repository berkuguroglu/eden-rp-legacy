using System.Collections.Generic;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;

namespace eden_rp.vehicle.events
{
    class Vevents : Script
    {

        public static List<Vehicle> listofvehs;
        public Vevents()
        {
            API.onResourceStart += OnResourceStartHandlerveh;
        }
        private void OnResourceStartHandlerveh()
        {
            listofvehs = new List<Vehicle>();
        }

    }

}
