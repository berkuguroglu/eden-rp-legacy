using System;
using GrandTheftMultiplayer.Server.Elements;
using Eden.Core;
using Newtonsoft.Json;
using GrandTheftMultiplayer.Server.Constant;

namespace Eden.Character.Creation
{
    class CharacterCreationEvents
    {
        public static void OnClientEventTriggerHandler(Client sender, string eventName, params object[] arguments)
        {
            switch (eventName)
            {
                case "heritageChanged":
                    {
                        dynamic h = JsonConvert.DeserializeObject(arguments[0].ToString());
                        EdenCore.api.sendNativeToPlayer(sender, 0x9414E18B9434C2FE, sender, Convert.ToInt32(h.mom), Convert.ToInt32(h.dad), 0, Convert.ToInt32(h.mom), Convert.ToInt32(h.dad), 0, Convert.ToSingle(h.shapemix), Convert.ToSingle(h.skinmix), 0.0f, false);
                        break;
                    }
                case "eyeColorChanged":
                    {
                        EdenCore.api.sendNativeToPlayer(sender, 0x50B56988B170AFDF, sender, Convert.ToInt32(arguments[0]));
                        break;
                    }
                case "hairDataChanged":
                    {
                        dynamic h = JsonConvert.DeserializeObject(arguments[0].ToString());
                        EdenCore.api.sendNativeToPlayer(sender, 0x4CFFC65454C93A49, sender, Convert.ToInt32(h.color), Convert.ToInt32(h.highlight));
                        EdenCore.api.sendNativeToPlayer(sender, 0x48F44967FA05CC1E, sender, 2, Convert.ToInt32(h.eyebrow), 1.0f);
                        EdenCore.api.sendNativeToPlayer(sender, 0x497BF74A7B9CB952, sender, 2, 1, Convert.ToInt32(h.eyebrowColor), Convert.ToInt32(h.eyebrowColor));
                        EdenCore.api.sendNativeToPlayer(sender, 0x48F44967FA05CC1E, sender, 1, Convert.ToInt32(h.facialHair), 1.0f);
                        EdenCore.api.sendNativeToPlayer(sender, 0x497BF74A7B9CB952, sender, 1, 1, Convert.ToInt32(h.facialHairColor), Convert.ToInt32(h.facialHairColor));
                        break;
                    }
                case "detailsChanged":
                    {
                        dynamic f = JsonConvert.DeserializeObject(arguments[0].ToString());
                        for (int i = 0; i <= 12; i++)
                       { 
                            switch (i)
                            {
                                case 0: EdenCore.api.sendNativeToPlayer(sender, 0x48F44967FA05CC1E, sender, i, Convert.ToInt32(f.blemishes), 1.0f); break;
                                case 3: EdenCore.api.sendNativeToPlayer(sender, 0x48F44967FA05CC1E, sender, i, Convert.ToInt32(f.ageing), 1.0f); break;
                                case 6: EdenCore.api.sendNativeToPlayer(sender, 0x48F44967FA05CC1E, sender, i, Convert.ToInt32(f.complexion), 1.0f); break;
                                case 7: EdenCore.api.sendNativeToPlayer(sender, 0x48F44967FA05CC1E, sender, i, Convert.ToInt32(f.sunDamage), 1.0f); break;
                                //case 8: EdenCore.api.sendNativeToPlayer(sender, 0x48F44967FA05CC1E, sender, i, f.Lipstick, 1.0f); break;
                                case 9: EdenCore.api.sendNativeToPlayer(sender, 0x48F44967FA05CC1E, sender, i, Convert.ToInt32(f.freckles), 1.0f); break;
                                //case 11: EdenCore.api.sendNativeToPlayer(sender, 0x48F44967FA05CC1E, sender, i, ch.BodyBlemishes, 1.0f); break;
                                //case 12: EdenCore.api.sendNativeToPlayer(sender, 0x48F44967FA05CC1E, sender, i, ch.IsBodyBlemishesOn, 1.0f); break;
                                default: continue;
                            }
                        }
                        break;
                    }
                case "sendFreemodeNative":
                    {
                        dynamic ch = JsonConvert.DeserializeObject(arguments[0].ToString());
                        EdenCore.api.sendNativeToPlayer(sender, 0x9414E18B9434C2FE, sender, ch.heritage.mom, ch.heritage.dad, 0, ch.heritage.mom, ch.heritage.dad, 0, Convert.ToSingle(ch.heritage.shapemix), Convert.ToSingle(ch.heritage.skinmix), 0.0f, false);
                        EdenCore.api.sendNativeToPlayer(sender, 0x4CFFC65454C93A49, sender, Convert.ToInt32(ch.hairData.color), Convert.ToInt32(ch.hairData.highlight));
                        EdenCore.api.sendNativeToPlayer(sender, 0x48F44967FA05CC1E, sender, 2, Convert.ToInt32(ch.hairData.eyebrow), 1.0f);
                        EdenCore.api.sendNativeToPlayer(sender, 0x497BF74A7B9CB952, sender, 2, 1, Convert.ToInt32(ch.hairData.eyebrowColor), Convert.ToInt32(ch.hairData.eyebrowColor));
                        EdenCore.api.sendNativeToPlayer(sender, 0x48F44967FA05CC1E, sender, 1, Convert.ToInt32(ch.hairData.facialHair), 1.0f);
                        EdenCore.api.sendNativeToPlayer(sender, 0x497BF74A7B9CB952, sender, 1, 1, Convert.ToInt32(ch.hairData.facialHairColor), Convert.ToInt32(ch.hairData.facialHairColor));
                        EdenCore.api.sendNativeToPlayer(sender, 0x48F44967FA05CC1E, sender, 0, Convert.ToInt32(ch.details.blemishes), 1.0f);
                        EdenCore.api.sendNativeToPlayer(sender, 0x48F44967FA05CC1E, sender, 3, Convert.ToInt32(ch.details.ageing), 1.0f);
                        EdenCore.api.sendNativeToPlayer(sender, 0x48F44967FA05CC1E, sender, 6, Convert.ToInt32(ch.details.complexion), 1.0f);
                        EdenCore.api.sendNativeToPlayer(sender, 0x48F44967FA05CC1E, sender, 7, Convert.ToInt32(ch.details.sunDamage), 1.0f);
                        EdenCore.api.sendNativeToPlayer(sender, 0x48F44967FA05CC1E, sender, 9, Convert.ToInt32(ch.details.freckles), 1.0f);
                        break;
                    }
                case "savePed":
                    {
                        CharacterCreation.SaveCharacter(Player.Find(sender), EdenCore.api.pedNameToModel(arguments[0].ToString()));
                        break;
                    }
                case "saveCharacter":
                    {
                        dynamic data = JsonConvert.DeserializeObject(arguments[0].ToString());
                        CharacterCreation.SaveCharacter(Player.Find(sender), data);
                        break;
                    }
            }
        }
    }
}
