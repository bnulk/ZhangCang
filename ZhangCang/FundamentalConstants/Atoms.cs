

namespace ZhangCang.FundamentalConstants
{
    public class Atoms
    {
        public readonly Atom[] allAtoms = new Atom[55]
        {
            new Atom(   0,     "x",            "dummy",                  0.0 ),
            new Atom(   1,     "h",         "hydrogen",               1.00783),
            new Atom(   2,    "he",           "helium",              4.002602),
            new Atom(   3,    "li",          "lithium",                 6.94 ),
            new Atom(   4,    "be",        "beryllium",            9.0121831 ),
            new Atom(   5,     "b",            "boron",                10.81 ),
            new Atom(   6,     "c",           "carbon",               12.000 ),
            new Atom(   7,     "n",         "nitrogen",             14.00307 ),
            new Atom(   8,     "o",           "oxygen",             15.99491 ),
            new Atom(   9,     "f",         "fluorine",          18.99840316 ),
            new Atom(   10,   "ne",             "neon",              20.1797 ),
            new Atom(   11,   "na",           "sodium",          22.98976928 ),
            new Atom(   12,   "mg",        "magnesium",               24.305 ),
            new Atom(   13,   "al",         "aluminum",           26.9815385 ),
            new Atom(   14,   "si",          "silicon",               28.085 ),
            new Atom(   15,    "p",       "phosphorus",          30.97376199 ),
            new Atom(   16,    "s",           "sulfur",                32.06 ),
            new Atom(   17,   "cl",         "chlorine",                35.45 ),
            new Atom(   18,   "ar",            "argon",               39.948 ),
            new Atom(   19,    "k",        "potassium",              39.0983 ),
            new Atom(   20,   "ca",          "calcium",               40.078 ),
            new Atom(   21,   "sc",         "scandium",            44.955908 ),
            new Atom(   22,   "ti",         "titanium",               47.867 ),
            new Atom(   23,    "v",         "vanadium",              50.9415 ),
            new Atom(   24,   "cr",         "chromium",              51.9961 ),
            new Atom(   25,   "mn",        "manganese",            54.938044 ),
            new Atom(   26,   "fe",             "iron",               55.845 ),
            new Atom(   27,   "co",           "cobalt",            58.933194 ),
            new Atom(   28,   "ni",           "nickel",              58.6934 ),
            new Atom(   29,   "cu",           "copper",               63.546 ),
            new Atom(   30,   "zn",             "zinc",                65.38 ),
            new Atom(   31,   "ga",          "gallium",               69.723 ),
            new Atom(   32,   "ge",        "germanium",               72.630 ),
            new Atom(   33,   "as",          "arsenic",            74.921595 ),
            new Atom(   34,   "se",         "selenium",               78.971 ),
            new Atom(   35,   "br",          "bromine",               79.904 ),
            new Atom(   36,   "kr",          "krypton",               83.798 ),
            new Atom(   37,   "rb",         "rubidium",              85.4678 ),
            new Atom(   38,   "sr",        "strontium",                87.62 ),
            new Atom(   39,    "y",          "yttrium",             88.90584 ),
            new Atom(   40,   "zr",        "zirconium",               91.224 ),
            new Atom(   41,   "nb",          "niobium",             92.90637 ),
            new Atom(   42,   "mo",       "molybdenum",                95.95 ),
            new Atom(   43,   "tc",       "technetium",                   98 ),
            new Atom(   44,   "ru",        "ruthenium",               101.07 ),
            new Atom(   45,   "rh",          "rhodium",            102.90550 ),
            new Atom(   46,   "pd",        "palladium",               106.42 ),
            new Atom(   47,   "ag",           "silver",             107.8682 ),
            new Atom(   48,   "cd",          "cadmium",              112.414 ),
            new Atom(   49,   "in",           "indium",              114.818 ),
            new Atom(   50,   "sn",              "tin",              118.710 ),
            new Atom(   51,   "sb",         "antimony",              121.760 ),
            new Atom(   52,   "te",        "tellurium",               127.60 ),
            new Atom(   53,    "i",           "iodine",            126.90447 ),
            new Atom(   54,   "xe",            "xenon",              131.293 ),
        };

        /// <summary>
        /// 根据元素符号得到原子序数
        /// </summary>
        /// <param name="Symbol">元素符号</param>
        /// <returns></returns>
        public int SymbolToNumber(string symbol)
        {
            int number = 0;
            int sumNumber = allAtoms.GetLength(0);
            for (int i = 0; i < sumNumber; i++)
            {
                if (symbol.ToLower() == allAtoms[i].GetSymbol())
                {
                    number = allAtoms[i].GetNumber();
                }
            }
            return number;
        }

        /// <summary>
        /// 根据原子序数得到元素符号
        /// </summary>
        /// <param name="number">原子序数</param>
        /// <returns></returns>
        public string NumberToSymbol(int number)
        {
            string symbol = "x";
            int sumSymbol = allAtoms.GetLength(0);
            for (int i = 0; i < sumSymbol; i++)
            {
                if (number == allAtoms[i].GetNumber())
                {
                    symbol = allAtoms[i].GetSymbol();
                }
            }
            return symbol;
        }

        /// <summary>
        /// 根据原子序数得到平均原子量
        /// </summary>
        /// <param name="Symbol">元素符号</param>
        /// <returns></returns>
        public double NumberToMass(int number)
        {
            double mass = 0;
            int sumNumber = allAtoms.GetLength(0);
            for (int i = 0; i < sumNumber; i++)
            {
                if (number == allAtoms[i].GetNumber())
                {
                    mass = allAtoms[i].GetMass();
                }
            }
            return mass;
        }




    }
}
