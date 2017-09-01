using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared.Math;
using Eden.Core;

namespace Eden.Character.Creation
{
    public static class CharacterCreation
    {
        public static void InitializeCreator(Player player)
        {
            player.Client.position = new Vector3(402.9086, -996.8259, -99.00024);
            player.Client.rotation = new Vector3(0.0, 0.0, -177.6333);
            player.Client.playAnimation("mp_character_creation@customise@male_a", "drop_loop", 1);
            player.Client.freeze(true);
            player.Client.triggerEvent("CCMain", player.Character.Gender, player.Character.Age);
        }
    }
}
