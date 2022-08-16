

namespace ZhangCang.FundamentalConstants
{
    public struct Atom
    {
        private int number;
        private string symbol;
        private string name;
        private double mass;

        public Atom(int number, string symbol, string name, double mass)
        {
            this.number = number;
            this.symbol = symbol;
            this.name = name;
            this.mass = mass;
        }

        public string GetSymbol()
        {
            return symbol;
        }

        public int GetNumber()
        {
            return number;
        }

        public string GetName()
        {
            return name;
        }

        public double GetMass()
        {
            return mass;
        }
    }
}
