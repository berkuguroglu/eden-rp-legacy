using Eden.Core;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;


namespace Eden.Vehicle
{
    public static class VehicleEvents
    {
        public static void OnResourceStart() { DatabaseHandler.LoadVehicles(); }
        public static void OnPlayerEnterVehicle(Client player, NetHandle vehicle)
        {
            foreach(EdenVehicle edh in EdenCore.VehicleList)
            {
                if(edh.Veh == vehicle)
                {
                    EdenCore.api.sendChatMessageToPlayer(player, "~w~(([ID] " + edh.Vehid.ToString() + " || " + edh.Modelhash.ToString() +" || Sahip: " + edh.Ownername);
                    break;
                }
            }
        }
    }
}
