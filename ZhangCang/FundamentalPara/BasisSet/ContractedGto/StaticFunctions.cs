using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhangCang.Auxiliary.TextTools;
using ZhangCang.Data.MolecularOrbitalTheoryData;

namespace ZhangCang.FundamentalPara.BasisSet.ContractedGto
{
    internal class StaticFunctions
    {
        public static CgBasisSetStruct GetCgBasisSet(List<string> basisSetInfo, BasisSetName basisSetName)
        {
            CgBasisSetStruct result = new CgBasisSetStruct();

            int cycle = basisSetInfo.Count;
            string str;
            string[] tmpSingleStoInfo;
            int tmpNumberOfGto;
            CgSto singleSto;
            int i, j;

            result.numberOfSto = 0;
            result.stosForAtom = new List<CgSto>();

            result.name= basisSetName;

            for (i = 0; i < cycle; i++)
            {
                str = basisSetInfo[i];
                if (str.Substring(0, 1) != " ")
                {
                    result.numberOfSto++;
                    switch (str.Substring(0, 2))
                    {
                        case "S ":
                            tmpNumberOfGto = Convert.ToInt32(BasisTextTools.GetStringSeparatedbySpaces(str)[1]);
                            tmpSingleStoInfo = new string[tmpNumberOfGto + 1];
                            tmpSingleStoInfo[0] = str;
                            for (j = 1; j <= tmpNumberOfGto; j++)
                            {
                                str = basisSetInfo[++i];
                                tmpSingleStoInfo[j] = str;
                            }
                            readSto_S(out singleSto, tmpSingleStoInfo);
                            result.stosForAtom.Add(singleSto);
                            break;
                        case "SP":
                            break;
                        case "D ":
                            break;
                        default:
                            break;
                    }
                }
            }
            return result;
        }



        private static void readSto_S(out CgSto s, string[] singleStoInfo)
        {
            string[] tmpStrs;
            int i;
            s = new CgSto();
            s.gtoForSto = new List<CgGto>();
            CgGto singleGto = new CgGto();

            //填充STO
            s.stoType = StoType.S;
            s.l = s.m = s.n = 0;
            tmpStrs = BasisTextTools.GetStringSeparatedbySpaces(singleStoInfo[0]);
            s.numberOfGto = Convert.ToInt32(tmpStrs[1]);
            s.zeta = Convert.ToDouble(tmpStrs[2]);

            //填充GTO
            int cycle = s.numberOfGto;
            for (i = 1; i <= cycle; i++)
            {
                tmpStrs = BasisTextTools.GetStringSeparatedbySpaces(singleStoInfo[i]);
                singleGto.exponential = Convert.ToDouble(tmpStrs[0]);
                singleGto.coefficient = Convert.ToDouble(tmpStrs[1]);
                s.gtoForSto.Add(singleGto);
            }
        }






    }
}
