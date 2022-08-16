using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZhangCang.Input.ZhangCangInput
{
    internal class ChargeAndMultiplicity2ChargeAndMultiplicity
    {
        //输入
        string chargeAndMultiplicity;

        //输出
        int[]? charge;
        int[]? multiplicity;

        public ChargeAndMultiplicity2ChargeAndMultiplicity(List<string> chargeAndMultiplicityList)
        {
            StringBuilder sb = new StringBuilder();

            //跳过开始的空行
            int startLine = 0;
            for (int i = 0; i < chargeAndMultiplicityList.Count; i++)
            {
                if (chargeAndMultiplicityList[i].Trim() != "")
                {
                    startLine = i;
                    i = chargeAndMultiplicityList.Count;
                }
            }
            for (int i = startLine; i < chargeAndMultiplicityList.Count; i++)
            {
                sb.Append(chargeAndMultiplicityList[i]);
            }

            this.chargeAndMultiplicity = sb.ToString();
        }

        public int[]? Charge { get => charge; set => charge = value; }
        public int[]? Multiplicity { get => multiplicity; set => multiplicity = value; }

        public void Run()
        {
            int numberOfChargeAndMultiplicity;
            string[] tmpData = Regex.Split(chargeAndMultiplicity.Trim(), "\\s+", RegexOptions.IgnoreCase);

            int tmpValue = tmpData.Length % 2;
            if(tmpValue == 0)
            {
                numberOfChargeAndMultiplicity = tmpData.Length / 2;
            }
            else
            {
                throw new Input_Exception("chargeAndMultiplicity input Error. /n The number is not even.");
            }
            
            Charge= new int[numberOfChargeAndMultiplicity];
            Multiplicity= new int[numberOfChargeAndMultiplicity];
            for(int i=0;i< numberOfChargeAndMultiplicity; i++)
            {
                Charge[i] = Convert.ToInt32(tmpData[2 * i]);
                Multiplicity[i] = Convert.ToInt32(tmpData[2 * i + 1]);
            }

        }



    }
}
