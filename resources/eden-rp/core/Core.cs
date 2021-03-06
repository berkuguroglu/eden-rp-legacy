﻿using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;
using System.Collections.Generic;
using Eden.Vehicle;
using Eden.Character.Creation;
using Eden.Faction;
using System;

namespace Eden.Core
{
    public class EdenCore : Script
    {
        internal static API api = new API();
        internal static List<Player> PlayerList = new List<Player>();
        internal static List<EdenVehicle> VehicleList = new List<EdenVehicle>();
        internal static List<EdenFaction> FactionList = new List<EdenFaction>();

        public EdenCore()
        {
            API.onResourceStart += OnResourceStartHandler;
            API.onResourceStart += VehicleEvents.OnResourceStart;
            API.onPlayerConnected += OnPlayerConnectedHandler;
            API.onPlayerFinishedDownload += OnPlayerFinishedDownloadHandler;
            API.onClientEventTrigger += OnClientEventTriggerHandler;
            API.onClientEventTrigger += CharacterCreationEvents.OnClientEventTriggerHandler;
            API.onPlayerDisconnected += OnPlayerDisconnectedHandler;
            API.onPlayerEnterVehicle += VehicleEvents.OnPlayerEnterVehicle;
            API.onChatMessage += OnChatMessageHandler;
            API.onResourceStop += OnResourceStopHandler;
        }

        private void OnResourceStopHandler()
        {
            DatabaseHandler.UplaodVehicles();
        }

        private void OnChatMessageHandler(Client sender, string message, CancelEventArgs cancel)
        {
            cancel.Cancel = true;
            List<Player> around = Player.FindRange(sender, 20);
            around.ForEach(p => { p.Client.sendChatMessage(p.Character.Name, message); });
        }

            private void OnResourceStartHandler()
        {
            API.consoleOutput("Test script running");
            InitializeServer();
            DatabaseHandler.OpenConnection();
            Statics.Buildings.LoadStaticMarkers();
            
        }

        private void OnPlayerConnectedHandler(Client player)
        {
            player.freeze(true);
            player.position = new Vector3(0.0, 0.0, 500.0);
            if (!DatabaseHandler.IsUserValid(player)) player.kick("Karakter adi bulunamadi!");
        }

        private void OnPlayerDisconnectedHandler(Client player, string reason)
        {
            DatabaseHandler.LogoutPlayer(Player.Find(player));
            API.detachEntity(Player.Find(player).LoginEntity);
        }
        private void OnPlayerFinishedDownloadHandler(Client player)
        {
            player.triggerEvent("login");
        }

        private void OnClientEventTriggerHandler(Client sender, string eventName, params object[] args)
        {
            switch (eventName)
            {
                case "loginCheck":
                    {
                        if (DatabaseHandler.IsPasswordValid(sender, args[0].ToString()))
                        {
                            sender.triggerEvent("loginGranted");
                            InitializePlayer(sender);
                            sender.freeze(false);
                            Player player = Player.Find(sender);
                            if (player.Firstlogin) CharacterCreation.InitializeCreator(player);
                        }
                        else sender.triggerEvent("loginDenied");
                        break;
                    }
                    case "creatingFactionForPlayer":
                    {
                        bool flag = false;
                        foreach (EdenFaction cf in FactionList)
                        {
                            if(cf.fName == args[0].ToString())
                            {
                                flag = true;
                                API.sendChatMessageToPlayer(Player.Find((int)args[1]).Client, "~r~Bu isimde bir oluşum zaten bulunuyor, ismi değiştirin.");
                                break;
                            }
                        }
                        
                        if (!flag)
                        {
                            EdenFaction newfaction = new EdenFaction(args[0].ToString(), EdenCore.FactionList.Count + 1, (int)args[1]);
                            EdenCore.FactionList.Add(newfaction);
                            API.sendChatMessageToPlayer(Player.Find((int)args[1]).Client, "~g~" + newfaction.fName + " isimli yeni bir oluşum oluşturdunuz.");
                            API.sendChatMessageToPlayer(Player.Find((int)args[1]).Client, "~g~Oluşumunuz ile ilgili ayarlar için /olusumduzenle komutunu kullanınız.");
                            Player.Find((int)args[1]).Faction = EdenCore.FactionList.Count;
                            break;
                        }
                        break;
                    }
            }
        }

        private void InitializePlayer(Client client)
        {
            Player player = new Player(client);
            bool freemode = DatabaseHandler.InitializePlayer(player);
            PlayerList.Add(player);
            client.setSkin(player.Character.Skin);
            if (freemode) player.SyncCharacter();
            TextLabel tl =  API.createTextLabel("~r~ID: " + "~w~" + player.Clientid.ToString(), client.position, 10.0f, 3.0f, false, API.getEntityDimension(client.handle));
            API.attachEntityToEntity(tl.handle, client.handle, "SKEL_ROOT", new Vector3(client.position.X, client.position.Y + 2, client.position.Z), client.rotation);
            API.setEntityTransparency(tl.handle, 255);
        }

        private void InitializeServer()
        {
            API.setCommandErrorMessage("~r~(( HATA:~w~ Böyle bir komut bulunmuyor.~r~ ))");
        }

    }
}
