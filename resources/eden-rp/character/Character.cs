using GrandTheftMultiplayer.Server.Constant;
using Eden.Core;

namespace Eden.Character
{
    public class EdenCharacter
    {
        double money;
        int bankAccount;
        double bankMoney;
        PedHash skin;
        int age;
        string name;
        bool gender;

        
        public Heritage Heritage = new Heritage();
        public Face Face = new Face();
        public Hair Hair = new Hair();
        public Outfit Outfit = new Outfit();
        public double Money { get { return money; } set { money = value; } }
        public int BankAccount { get { return bankAccount; } set { bankAccount = value; } }
        public double BankMoney { get { return bankMoney; } set { bankMoney = value; } }
        public PedHash Skin { get { return skin; } set { skin = value; } }
        public int Age { get { return age; } set { age = value; } }
        public string Name { get { return name; } set { name = value; } }
        public bool Gender { get { return gender; } set { gender = value; } }

        int bodyBlemishes;
        bool isBodyBlemishesOn;
        public int BodyBlemishes { get { return bodyBlemishes; } set { bodyBlemishes = value; } }
        public bool IsBodyBlemishesOn { get { return isBodyBlemishesOn; } set { isBodyBlemishesOn = value; } }
    }
}
