using System.Collections.Generic;
using ZhangCang.Data;

namespace ZhangCang.Input.ZhangCangInput
{
    partial class ReadZhangCangInputFile_App
    {
        /*
        ----------------------------------------------------  类注释  开始----------------------------------------------------
        版本：  V1.0
        作者：  刘鲲
        日期：  2018-06-12

        描述：
            * 处理输入文件的类
        结构：
            * ReadInput --- 处理输入文件。
        ----------------------------------------------------  类注释  结束----------------------------------------------------
        */

        List<string> inputList = new List<string>();

        List<string> keywordList = new List<string>();
        List<string> moleculeList = new List<string>();
        List<string> chargeAndMultiplicityList = new List<string>();
        List<string> forceConstantsInCartesianCoordinates = new List<string>();       //笛卡尔坐标系下力常数部分的文本列表
        

        InputData inputData= new InputData();

        public ReadZhangCangInputFile_App(List<string> inputList)
        {
            this.inputList = inputList;
            inputData.inputFileType = InputFileType.ZhangCang;
        }

        internal InputData InputData { get => inputData; set => inputData = value; }

        public void Run()
        {
            ObtainSpecialLists();

            //获取关键词
            KeywordList2Keyword keywordList2Keyword = new KeywordList2Keyword(keywordList);
            keywordList2Keyword.Run();
            inputData.keyword = keywordList2Keyword.Keyword;

            //获取分子坐标
            MoleculeList2MoleculeAndInputZMatrix moleculeList2MoleculeAndInputZMatrix = new MoleculeList2MoleculeAndInputZMatrix(moleculeList);
            moleculeList2MoleculeAndInputZMatrix.Run();
            inputData.molecule.atomicNumbers = moleculeList2MoleculeAndInputZMatrix.AtomicNumbers;
            inputData.molecule.numberOfAtoms = moleculeList2MoleculeAndInputZMatrix.NumberOfAtoms;
            inputData.molecule.realAtomicWeights = moleculeList2MoleculeAndInputZMatrix.RealAtomicWeights;
            inputData.molecule.cartesian3= moleculeList2MoleculeAndInputZMatrix.Cartesian3;
            inputData.zMatrix = moleculeList2MoleculeAndInputZMatrix.InputZMatrix;

            //获取电荷和自旋多重度
            ChargeAndMultiplicity2ChargeAndMultiplicity chargeAndMultiplicity2Charge = new ChargeAndMultiplicity2ChargeAndMultiplicity(chargeAndMultiplicityList);
            chargeAndMultiplicity2Charge.Run();
            inputData.molecule.charge = chargeAndMultiplicity2Charge.Charge;
            inputData.molecule.multiplicity = chargeAndMultiplicity2Charge.Multiplicity;
        }

        

        /// <summary>
        /// 获取专题列表
        /// </summary>
        private void ObtainSpecialLists()
        {
            string str;       //临时字符串

            //获取标准结构对应的文本列表
            for (int i = 0; i < inputList.Count; i++)
            {
                str = inputList[i];

                //控制部分的文本列表
                if (str.ToLower().Trim() == "<keyword>")
                {
                    i++;
                    str = inputList[i];
                    while (str.ToLower().Trim() != "</keyword>")
                    {
                        if (str.Trim() != "")
                        {
                            keywordList.Add(str);
                        }
                        i++;
                        str = inputList[i];
                    }
                }

                //坐标部分的文本列表
                if (str.ToLower().Trim() == "<molecule>")
                {
                    i++;
                    str = inputList[i];
                    while (str.ToLower().Trim() != "</molecule>")
                    {
                        moleculeList.Add(str);
                        i++;
                        str = inputList[i];
                    }
                }

                //电荷自旋多重度部分的文本列表
                if (str.ToLower().Trim() == "<c&m>")
                {
                    i++;
                    str = inputList[i];
                    while (str.ToLower().Trim() != "</c&m>")
                    {
                        chargeAndMultiplicityList.Add(str);
                        i++;
                        str = inputList[i];
                    }
                }

                //笛卡尔坐标系下的力常数
                if (str.ToLower().Trim() == "<force constants in cartesian coordinates>")
                {
                    i++;
                    str = inputList[i];
                    while (str.ToLower().Trim() != "</force constants in cartesian coordinates>")
                    {
                        forceConstantsInCartesianCoordinates.Add(str);
                        i++;
                        str = inputList[i];
                    }
                }
            }

            return;
        }


    }
}
