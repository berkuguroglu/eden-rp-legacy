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
                    EdenCore.api.sendChatMessageToPlayer(player, "~r~(([ID] ~w~" + edh.Vehid.ToString() + " ~r~|| ~w~" + edh.Modelhash.ToString() +"~r~ || Sahip: ~w~" + edh.Ownername + "~r~ ))");
                    break;
                }
            }
        }
    }
}
