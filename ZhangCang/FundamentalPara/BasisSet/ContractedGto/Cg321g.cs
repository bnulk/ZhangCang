using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhangCang.FundamentalPara.BasisSet.ContractedGto
{
    internal partial class Cg321g : CgBasisSet
    {
        string[] arrayBasisSet;
        public Cg321g()
        {
            arrayBasisSet = Cg321gInfo.Split("\r\n");
            Initialize();
        }

        private void Initialize()
        {
            FromArrayToThisBasisSet();
        }

        private void FromArrayToThisBasisSet()
        {
            int cycle = arrayBasisSet.Length;
            string str = "";
            List<string> listBasisInfo = new List<string>();

            for (int i = 0; i < cycle; i++)
            {
                str = arrayBasisSet[i].Trim();
                switch (str)
                {
                    case "H     0":
                        listBasisInfo = new List<string>();
                        i++;
                        str = arrayBasisSet[i];
                        while (str != "****")
                        {
                            listBasisInfo.Add(str);
                            i++;
                            str = arrayBasisSet[i];
                        }
                        CgBasisSets[0] = StaticFunctions.GetCgBasisSet(listBasisInfo, BasisSetName.cg321g);
                        break;
                    case "He     0":
                        break;
                    case "Li     0":
                        break;
                    case "Be     0":
                        break;
                    case "C     0":
                        break;
                    case "N     0":
                        break;
                    case "O     0":
                        break;
                    case "F     0":
                        break;
                    case "Ne     0":
                        break;
                    case "Na     0":
                        break;
                    case "Mg     0":
                        break;
                    case "Al     0":
                        break;
                    case "Si     0":
                        break;
                    case "P     0":
                        break;
                    case "S     0":
                        break;
                    case "Cl     0":
                        break;
                    case "Ar     0":
                        break;
                    case "K     0":
                        break;
                    case "Ca     0":
                        break;
                    case "Sc     0":
                        break;
                    case "Ti     0":
                        break;
                    case "V     0":
                        break;
                    case "Cr     0":
                        break;
                    case "Mn     0":
                        break;
                    case "Fe     0":
                        break;
                    case "Co     0":
                        break;
                    case "Ni     0":
                        break;
                    case "Cu     0":
                        break;
                    case "Zn     0":
                        break;
                    case "Ga     0":
                        break;
                    case "Ge     0":
                        break;
                    case "As     0":
                        break;
                    case "Se     0":
                        break;
                    case "Br     0":
                        break;
                    case "Kr     0":
                        break;
                    case "Rb     0":
                        break;
                    case "Cs     0":
                        break;
                    case "Y     0":
                        break;
                    case "Zr     0":
                        break;
                    case "Nb     0":
                        break;
                    case "Mo     0":
                        break;
                    case "Tc     0":
                        break;
                    case "Ru     0":
                        break;
                    case "Rh     0":
                        break;
                    case "Pd     0":
                        break;
                    case "Ag     0":
                        break;
                    case "Cd     0":
                        break;
                    case "In     0":
                        break;
                    case "Sn     0":
                        break;
                    case "Sb     0":
                        break;
                    case "Te     0":
                        break;
                    case "I     0":
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
