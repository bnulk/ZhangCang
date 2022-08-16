using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZhangCang.Input.ReadCoordinate
{
    internal class ReadCartesianOneBlock
    {
        //参量
        List<string> moleculeList=new List<string>();
        //结果
        int numberOfAtoms;
        int[] atomicNumbers;
        double[] realAtomicWeights;
        double[,] cartesian3;

        //用到的对象
        FundamentalConstants.Atoms atoms= new FundamentalConstants.Atoms();

        public ReadCartesianOneBlock(List<string> moleculeList)
        {
            //跳过开始的空行
            int startLine = 0;
            for(int i = 0; i < moleculeList.Count; i++)
            {
                if(moleculeList[i].Trim()!="")
                {
                    startLine = i;
                    i = moleculeList.Count;
                }
            }
            for(int i = startLine; i < moleculeList.Count; i++)
            {
                this.moleculeList.Add(moleculeList[i]);
            }

            //分子中原子个数
            numberOfAtoms = this.moleculeList.Count;
            atomicNumbers = new int[numberOfAtoms];
            realAtomicWeights = new double[numberOfAtoms];
            cartesian3 = new double[numberOfAtoms, 3];
        }

        public int NumberOfAtoms { get => numberOfAtoms; set => numberOfAtoms = value; }
        public int[] AtomicNumbers { get => atomicNumbers; set => atomicNumbers = value; }
        public double[] RealAtomicWeights { get => realAtomicWeights; set => realAtomicWeights = value; }
        public double[,] Cartesian3 { get => cartesian3; set => cartesian3 = value; }

        public void Run()
        {
            string[] tmpData = new string[6];                        //一行四部分，多出的部分无用，为了兼容其它程序的坐标形式

            for (int i = 0; i < moleculeList.Count; i++)
            {
                tmpData = Regex.Split(moleculeList[i].Trim(), "\\s+", RegexOptions.IgnoreCase);
                //元素的原子序数或者元素符号
                if (IsNumber(tmpData[0]) == true)                                       //原子序数
                {
                    atomicNumbers[i] = Convert.ToInt32(tmpData[0]);                     //读取原子序数
                }
                else                                                                             //元素符号
                {
                    atomicNumbers[i] = atoms.SymbolToNumber(tmpData[0].Trim().ToLower());               //根据元素符号，填写原子序数。
                }
                //坐标
                for (int j = 0; j < 3; j++)
                {
                    cartesian3[i, j] = Convert.ToDouble(tmpData[j + 1]);
                }
                //原子量
                realAtomicWeights[i] = atoms.NumberToMass(atomicNumbers[i]);
            }
        }


        /// <summary>
        /// 判断字符串是否是数字
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool IsNumber(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            const string pattern = "^[0-9]*$";
            Regex rx = new Regex(pattern);
            return rx.IsMatch(s);
        }

    }
}
