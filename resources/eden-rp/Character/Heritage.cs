namespace Eden.Character
{
    public class Heritage
    {
        int mom = 21;
        int dad = 0;
        float shapeMix = 0.5f;
        float skinMix = 0.5f;
        int eyeColor = 0;
        
        public int Mom { get { return mom; } set { mom = value; } }
        public int Dad { get { return dad; } set { dad = value; } }
        public float ShapeMix { get { return shapeMix; } set { shapeMix = value; } }
        public float SkinMix { get { return skinMix; } set { skinMix = value; } }
        public int EyeColor { get { return eyeColor; } set { eyeColor = value; } }
    }
}
