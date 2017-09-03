using GrandTheftMultiplayer.Server.Constant;
namespace Eden.Character
{
    public class EdenCharacter
    {
        double money;
        int bankaccount;
        double bankmoney;
        int skin;
        int age;
        string name;
        bool gender;

        public double Money { get { return money; } set { money = value; } }
        public int Bankaccount { get { return bankaccount; } set { bankaccount = value; } }
        public double Bankmoney { get { return bankmoney; } set { bankmoney = value; } }
        public int Skin { get { return skin; } set { skin = value; } }
        public int Age { get { return age; } set { age = value; } }
        public string Name { get { return name; } set { name = value; } }
        public bool Gender { get { return gender; } set { gender = value; } }
    }
}
