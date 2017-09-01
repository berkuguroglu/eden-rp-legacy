using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Server.Elements;

namespace Eden.Core.Commands
{
    class Admin : Script
    {
        [Command("mylocation")]
        public void PrintPosition(Client player) { API.consoleOutput("Location information of {0}\nPosition\nX: {1} Y: {2} Z: {3}\nRotation\nX: {4} Y: {5} Z: {6}", player.name, player.position.X, player.position.Y, player.position.Z, player.rotation.X, player.rotation.Y, player.rotation.Z); }
    }
}
