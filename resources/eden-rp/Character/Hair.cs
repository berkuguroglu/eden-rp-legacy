namespace Eden.Character
{
    public class Hair
    {
        int style = 0;
        int color = 0;
        int highlight = 0;
        int eyebrow = 0;
        int eyebrowColor = 0;
        int facialHair = 255;
        int facialHairColor = 0;
        int chestHair = 255;
        int chestHairColor = 0;
        
        public int Style { get { return style; } set { style = value; } }
        public int Color { get { return color; } set { color = value; } }
        public int Highlight { get { return highlight; } set { highlight = value; } }
        public int Eyebrow { get { return eyebrow; } set { eyebrow = value; } }
        public int EyebrowColor { get { return eyebrowColor; } set { eyebrowColor = value; } }
        public int FacialHair { get { return facialHair; } set { facialHair = value; } }
        public int FacialHairColor { get { return facialHairColor; } set { facialHairColor = value; } }
        public int ChestHair { get { return chestHair; } set { chestHair = value; } }
        public int ChestHairColor { get { return chestHairColor; } set { chestHairColor = value; } }
    }
}
