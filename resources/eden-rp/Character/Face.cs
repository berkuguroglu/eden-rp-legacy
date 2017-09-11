namespace Eden.Character
{
    public class Face
    {
        int eyeColor = 0;
        int blemishes = 255;
        int ageing = 255;
        int complexion = 255;
        int sunDamage = 255;
        int freckles = 255;
        int makeup = 255;
        int blush = 255;
        int lipstick = 255;

        public int EyeColor { get { return eyeColor; } set { eyeColor = value; } }
        public int Blemishes { get { return blemishes; } set { blemishes = value; } }
        public int Ageing { get { return ageing; } set { ageing = value; } }
        public int Complexion { get { return complexion; } set { complexion = value; } }
        public int SunDamage { get { return sunDamage; } set { sunDamage = value; } }
        public int Freckles { get { return freckles; } set { freckles = value; } }
        public int Makeup { get { return makeup; } set { makeup = value; } }
        public int Blush { get { return blush; } set { blush = value; } }
        public int Lipstick { get { return lipstick; } set { lipstick = value; } }
    }
}
