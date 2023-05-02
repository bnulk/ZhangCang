using System.Text.RegularExpressions;
using ZhangCang.Data;
using ZhangCang.Auxiliary.TextTools;
using System.Collections.Generic;
using System;

namespace ZhangCang.Input.GaussianInput
{
    internal class InputList2GaussianInputPackage
    {
        List<string> _inputList = new List<string>();
        GaussianInputPackage gaussianInputPackage_= new GaussianInputPackage();
        string strKeyword_;
        

        public InputList2GaussianInputPackage(List<string> _inputList)
        {
            this._inputList = _inputList;
            strKeyword_ = "";
        }

        public GaussianInputPackage GaussianInputPackage_ { get => gaussianInputPackage_; set => gaussianInputPackage_ = value; }
        public string StrKeyword_ { get => strKeyword_; set => strKeyword_ = value; }

        public void Run()
        {
            string str = "";                                                        //读取每行数据
            int iSegment = 0;                                                       //分段的标识
            bool isChargeAndMultiplicity = true;                                    //是否为电荷和自旋多重度的那一行
            gaussianInputPackage_.coordinateType = CoordinateType.unknown;           //坐标类型
            string[] tmpStr;                                                        //用于临时分割字符串
            int indexMark;                                                          //特殊字符的索引标识
            //初始化
            gaussianInputPackage_.firstSection = new List<string>();
            gaussianInputPackage_.routeSection = new List<string>();
            gaussianInputPackage_.titleSection = new List<string>();
            gaussianInputPackage_.addition = new List<string>();
            //填入数据
            for (int i = 0; i < _inputList.Count; i++)
            {
                str = _inputList[i].Trim();                                                               //去除前后的空格
                if (str == "" && iSegment <= 3)
                    iSegment++;
                else
                {
                    switch (iSegment)
                    {
                        case 0:
                            if (str.Substring(0, 1) == "%")
                            {
                                gaussianInputPackage_.firstSection.Add(str);
                            }
                            else
                            {
                                gaussianInputPackage_.routeSection.Add(str);
                            }
                            break;
                        case 1:
                            gaussianInputPackage_.titleSection.Add(str);
                            break;
                        case 2:
                            if (isChargeAndMultiplicity == true)
                            {
                                gaussianInputPackage_.chargeAndMultiplicity = new List<int>();
                                str = str + " ";
                                indexMark = str.IndexOf(' ');
                                while (indexMark >= 0)
                                {
                                    gaussianInputPackage_.chargeAndMultiplicity.Add(Convert.ToInt32(str.Substring(0, indexMark)));
                                    str = str.Remove(0, indexMark + 1);
                                    indexMark = str.IndexOf(' ');
                                }
                                isChargeAndMultiplicity = false;
                                break;
                            }
                            else
                            {
                                if (gaussianInputPackage_.coordinateType == CoordinateType.unknown)                                     //判断坐标类型
                                {
                                    str = str.Trim();
                                    if (str.Length < 4)                                                               //已经去掉前后的“ ”后，第一行的长度
                                    {
                                        gaussianInputPackage_.coordinateType = CoordinateType.zMatrix;
                                        gaussianInputPackage_.molecularSpecification_ZMatrix = new List<string>();
                                        gaussianInputPackage_.molecularPara_ZMatrix = new List<string>();
                                        gaussianInputPackage_.molecularVariable = new List<double>();
                                    }
                                    else
                                    {
                                        gaussianInputPackage_.coordinateType = CoordinateType.Cartesian;
                                        gaussianInputPackage_.molecularCartesian = new List<string>();
                                        gaussianInputPackage_.molecularVariable = new List<double>();
                                    }
                                }
                                if (gaussianInputPackage_.coordinateType == CoordinateType.zMatrix)
                                    gaussianInputPackage_.molecularSpecification_ZMatrix.Add(str);
                                else
                                {
                                    str = str.Trim();
                                    tmpStr = Regex.Split(str, "\\s+", RegexOptions.IgnoreCase);
                                    gaussianInputPackage_.molecularCartesian.Add(tmpStr[0]);
                                    for (int j = 1; j < 4; j++)
                                    {
                                        gaussianInputPackage_.molecularVariable.Add(Convert.ToDouble(tmpStr[j]));
                                    }

                                }
                            }
                            break;
                        case 3:
                            if (gaussianInputPackage_.coordinateType == CoordinateType.zMatrix)
                            {
                                str = str.Trim();
                                if (str.Contains('='))
                                {
                                    tmpStr = str.Split('=');
                                    if (tmpStr.Length == 2)
                                    {
                                        gaussianInputPackage_.molecularPara_ZMatrix.Add(tmpStr[0].Trim());
                                        gaussianInputPackage_.molecularVariable.Add(Convert.ToDouble(tmpStr[1].Trim()));
                                    }
                                    else
                                    {
                                        throw new Input_Exception("Molecular parameter input error.\n" + str + "\n");
                                    }
                                }
                                else
                                {
                                    tmpStr = Regex.Split(str, "\\s+", RegexOptions.IgnoreCase);
                                    if (tmpStr.Length == 2)
                                    {
                                        gaussianInputPackage_.molecularPara_ZMatrix.Add(tmpStr[0].Trim());
                                        gaussianInputPackage_.molecularVariable.Add(Convert.ToDouble(tmpStr[1].Trim()));
                                    }
                                    else
                                    {
                                        throw new Input_Exception("Molecular parameter input error.\n" + str + "\n");
                                    }
                                }
                            }
                            break;
                        default:
                            gaussianInputPackage_.addition.Add(str);
                            break;
                    }
                }
            }
            //获取原子个数N
            switch (gaussianInputPackage_.coordinateType)
            {
                case CoordinateType.zMatrix:
                    gaussianInputPackage_.numberOfAtom = gaussianInputPackage_.molecularSpecification_ZMatrix.Count;
                    break;
                case CoordinateType.Cartesian:
                    gaussianInputPackage_.numberOfAtom = gaussianInputPackage_.molecularCartesian.Count;
                    break;
                default:
                    break;
            }

            SplitBrace(ref gaussianInputPackage_.routeSection, ref strKeyword_);
            return;
        }


        private void SplitBrace(ref List<string> routeSection, ref string strKeyword)
        {
            string strRouteSection = "";
            for (int i = 0; i < routeSection.Count; i++)
            {
                strRouteSection += routeSection[i];
            }

            strKeyword = BasisTextTools.GetStringOutsideTwoString(strRouteSection, "{", "}");
            routeSection.Clear();
            routeSection.Add(BasisTextTools.GetStringBetweenTwoString(strRouteSection, "{", "}"));
        }



    }
}
