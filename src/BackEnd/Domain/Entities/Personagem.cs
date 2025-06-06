namespace BackEnd.Domain.Entities
{
    public class Personagem
    {
        public int Atk { get; set; }
        public int HpMax { get; set; }
        public int Hp { get; set; }
        public int Speed { get; set; }
        public int Def { get; set; }
        public double CritDmg { get; set; }
        public double CritRate { get; set; }
        public int UltCost { get; set; }
        public int Energy { get; set; }
    }
}
