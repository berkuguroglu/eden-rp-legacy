using Eden.Core;

namespace Eden.Vehicle
{
    public static class VehicleEvents
    {
        public static void OnResourceStart() { DatabaseHandler.LoadVehicles(); }
    }
}
