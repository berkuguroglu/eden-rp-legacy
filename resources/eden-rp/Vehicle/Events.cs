using Eden.Core;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;





namespace Eden.Vehicle
{
    public static class VehicleEvents
    {
        public static void OnResourceStart() { DatabaseHandler.LoadVehicles(); }
        public static void OnPlayerEnterVehicle(Client player, NetHandle vehicle)
        {
            foreach (EdenVehicle edh in EdenCore.VehicleList)
            {
                if (edh.Veh == vehicle)
                {
                    EdenCore.api.sendChatMessageToPlayer(player, "~r~(([ID] ~w~" + edh.Vehid.ToString() + " ~r~|| ~w~" + edh.Modelhash.ToString() + "~r~ || Sahip: ~w~" + edh.Ownername + "~r~ ))");
                    if (edh.LockStatus)
                    {
                        EdenCore.api.setEntityPosition(player, new Vector3(EdenCore.api.getEntityPosition(edh.Veh).X + 3, EdenCore.api.getEntityPosition(edh.Veh).Y, EdenCore.api.getEntityPosition(edh.Veh).Z));
                        EdenCore.api.sendChatMessageToPlayer(player, "~r~Bu araç kilitli.");
                    }
                    break;
                }
            }
        }
    }
}
