using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;

namespace eden_rp.EdenCore
{
    public class EdenCore : Script
    {

        public EdenCore()
        {
            API.onResourceStart += OnResourceStartHandler;
            API.onPlayerConnected += OnPlayerConnectedHandler;
            API.onPlayerFinishedDownload += OnPlayerFinishedDownloadHandler;
            API.onClientEventTrigger += OnClientEventTriggerHandler;
            API.onPlayerDisconnected += OnPlayerDisconnectedHandler;
        }

        private void OnResourceStartHandler()
        {
            API.consoleOutput("Test script running");
            EdenDatabaseHandler.OpenConnection();
            GeneralSettings();
        }

        private void OnPlayerConnectedHandler(Client player)
        {
            if (!EdenDatabaseHandler.IsUserValid(player)) player.kick("Karakter adi bulunamadi!");
        }

        private void OnPlayerDisconnectedHandler(Client player, string reason)
        {
            EdenDatabaseHandler.Logout(player);
        }

        private void OnPlayerFinishedDownloadHandler(Client player)
        {
            player.freeze(true);
            player.position = new Vector3(0.0, 0.0, 500.0);
            player.triggerEvent("loginCamera");
            player.triggerEvent("login");
        }

        private void OnClientEventTriggerHandler(Client sender, string eventName, params object[] arguments)
        {
            switch (eventName)
            {
                case "loginCheck":
                    {
                        if (EdenDatabaseHandler.IsPasswordValid(sender, arguments[0].ToString()))
                        {
                            sender.triggerEvent("loginGranted");
                            sender.position = EdenDatabaseHandler.GetLastPosition(sender);
                            sender.freeze(false);
                        }
                        else sender.triggerEvent("loginDenied");
                        break;
                    }
            }
        }
        private void GeneralSettings()
        {
            API.setCommandErrorMessage("~r~(( HATA:~w~ Böyle bir komut bulunmuyor.~r~ ))");
        }

    }
}
