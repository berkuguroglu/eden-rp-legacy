using System;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Shared.Math;
using Eden.Core;
using Eden.Character;

namespace Eden.Character.Creation
{
    public class CharacterCreation
    {
        public static void InitializeCreator(Player player)
        {
            player.Client.position = new Vector3(402.9086, -996.8259, -99.00024);
            player.Client.rotation = new Vector3(0.0, 0.0, -177.6333);
            player.Client.dimension = player.Clientid;
            player.Client.playAnimation("mp_character_creation@customise@male_a", "drop_loop", 1);
            player.Client.freeze(true);
            player.Client.triggerEvent("ccmenu", player.Character.Gender, player.Character.Age);
        }

        public static void SaveCharacter(Player player, dynamic data)
        {
            player.Character.Heritage.Mom = data.heritage.mom;
            player.Character.Heritage.Dad = data.heritage.dad;
            player.Character.Heritage.ShapeMix = Convert.ToSingle(data.heritage.shapemix);
            player.Character.Heritage.SkinMix = Convert.ToSingle(data.heritage.skinmix);
            player.Character.Face.EyeColor = data.eyeColor;
            player.Character.Hair.Style = data.hairData.style;
            player.Character.Hair.Color = data.hairData.color;
            player.Character.Hair.Highlight = data.hairData.highlight;
            player.Character.Hair.Eyebrow = data.hairData.eyebrow;
            player.Character.Hair.EyebrowColor = data.hairData.eyebrowColor;
            player.Character.Hair.FacialHair = data.hairData.facialHair;
            player.Character.Hair.FacialHairColor = data.hairData.facialHairColor;
            player.Character.Face.Blemishes = data.details.blemishes;
            player.Character.Face.Ageing = data.details.ageing;
            player.Character.Face.Complexion = data.details.complexion;
            player.Character.Face.SunDamage = data.details.sunDamage;
            player.Character.Face.Freckles = data.details.freckles;
            DatabaseHandler.SaveCreatedCharacter(player);
            player.SyncCharacter();
            player.Client.dimension = 0;
            player.Client.stopAnimation();
            // <insert spawn location here>
            player.Client.freeze(false);
            player.Firstlogin = false;
        }

        public static void SavePed(Player player, PedHash skin)
        {
            player.Client.setSkin(skin);
            player.Character.Skin = skin;
        }

    }
}
