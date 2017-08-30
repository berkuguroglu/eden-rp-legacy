using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;
using System.Collections.Generic;
using Eden.Vehicle;

namespace Eden.Core
{
    public class EdenCore : Script
    {
        internal static API api = new API();
        internal static List<Player> PlayerList = new List<Player>();
        internal static List<EdenVehicle> VehicleList = new List<EdenVehicle>();

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
            InitializeServer();
            DatabaseHandler.OpenConnection();
            VehicleEvents.OnResourceStart();
        }

        private void OnPlayerConnectedHandler(Client player)
        {
            if (!DatabaseHandler.IsUserValid(player)) player.kick("Karakter adi bulunamadi!");
        }

        private void OnPlayerDisconnectedHandler(Client player, string reason)
        {
            DatabaseHandler.LogoutPlayer(player);
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
                        if (DatabaseHandler.IsPasswordValid(sender, arguments[0].ToString()))
                        {
                            sender.triggerEvent("loginGranted");
                            InitializePlayer(sender);
                            sender.freeze(false);
                        }
                        else sender.triggerEvent("loginDenied");
                        break;
                    }
            }
        }

        private void InitializePlayer(Client client)
        {
            Player newplayer = new Player(client);
            DatabaseHandler.InitializeCharacter(newplayer);
            PlayerList.Add(newplayer);
        }

        private void InitializeServer()
        {
            API.setCommandErrorMessage("~r~(( HATA:~w~ Böyle bir komut bulunmuyor.~r~ ))");
        }

    }
}
