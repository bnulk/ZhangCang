using System;
using System.Text.RegularExpressions;
using ZhangCang.Data;
using ZhangCang.FundamentalConstants;

namespace ZhangCang.Input.GaussianInput
{
    internal class ReadInternalCoordinates
    {
        private GaussianInputPackage _gaussianInputPackage;
        private ZMatrix zMatrix_;
        private int numberOfAtoms;

        public ReadInternalCoordinates(GaussianInputPackage gaussianInputPackage)
        {
            this._gaussianInputPackage = gaussianInputPackage;
            if (this._gaussianInputPackage.molecularSpecification_ZMatrix.Count == 0)
            {
                zMatrix_.isExist = false;
                zMatrix_.atomicNumbers = new int[0];
                zMatrix_.connectionInfo = new int[0, 0];
                zMatrix_.paraName = new string[0];
                zMatrix_.paraValue = new double[0];
            }
            else
            {
                zMatrix_.isExist = true;
            }
        }

        public ZMatrix ZMatrix_ { get => zMatrix_; set => zMatrix_ = value; }

        public void Run()
        {
            if (zMatrix_.isExist)
            {
                ObtainZMatrix(_gaussianInputPackage);
            }
            return;
        }

        private void ObtainZMatrix(GaussianInputPackage gaussianInputPackage)
        {
            //初始化
            numberOfAtoms = this._gaussianInputPackage.molecularSpecification_ZMatrix.Count;
            zMatrix_.atomicNumbers = new int[numberOfAtoms];
            zMatrix_.paraName = new string[3 * numberOfAtoms - 6];
            zMatrix_.paraValue = new double[3 * numberOfAtoms - 6];
            zMatrix_.connectionInfo = new int[numberOfAtoms, 3];
            zMatrix_.connectionInfoValue = new double[numberOfAtoms, 3];

            //读取zMatrix中的键连信息
            string[] everyRow;
            Atoms atoms = new Atoms();
            int startAngleSupplementaryDifference = numberOfAtoms - 3;
            int startDihedralAngleSupplementaryDifference = numberOfAtoms * 2 - 6;
            string[,] tmpConnectionInfoValue = new string[numberOfAtoms, 3];                                        //键连信息值。在读分子说明时，存贮参数名。后面再用参数值取代。

            for (int i = 0; i < numberOfAtoms; i++)
            {
                everyRow = Regex.Split(gaussianInputPackage.molecularSpecification_ZMatrix[i].Trim(), "\\s+", RegexOptions.IgnoreCase);
                switch (i)
                {
                    case 0:
                        zMatrix_.atomicNumbers[i] = atoms.SymbolToNumber(everyRow[0]);
                        zMatrix_.connectionInfo[i, 0] = 0;
                        zMatrix_.connectionInfo[i, 1] = 0;
                        zMatrix_.connectionInfo[i, 2] = 0;
                        break;
                    case 1:
                        zMatrix_.atomicNumbers[i] = atoms.SymbolToNumber(everyRow[0]);
                        zMatrix_.connectionInfo[i, 0] = Convert.ToInt32(everyRow[1]) - 1;
                        zMatrix_.connectionInfo[i, 1] = 0;
                        zMatrix_.connectionInfo[i, 2] = 0;

                        zMatrix_.paraName[i - 1] = everyRow[2];
                        tmpConnectionInfoValue[i, 0] = everyRow[2];
                        break;
                    case 2:
                        zMatrix_.atomicNumbers[i] = atoms.SymbolToNumber(everyRow[0]);
                        zMatrix_.connectionInfo[i, 0] = Convert.ToInt32(everyRow[1]) - 1;
                        zMatrix_.connectionInfo[i, 1] = Convert.ToInt32(everyRow[3]) - 1;
                        zMatrix_.connectionInfo[i, 2] = 0;

                        zMatrix_.paraName[i - 1] = everyRow[2];
                        zMatrix_.paraName[startAngleSupplementaryDifference + i] = everyRow[4];
                        tmpConnectionInfoValue[i, 0] = everyRow[2];
                        tmpConnectionInfoValue[i, 1] = everyRow[4];
                        break;
                    default:
                        zMatrix_.atomicNumbers[i] = atoms.SymbolToNumber(everyRow[0]);
                        zMatrix_.connectionInfo[i, 0] = Convert.ToInt32(everyRow[1]) - 1;
                        zMatrix_.connectionInfo[i, 1] = Convert.ToInt32(everyRow[3]) - 1;
                        zMatrix_.connectionInfo[i, 2] = Convert.ToInt32(everyRow[5]) - 1;

                        zMatrix_.paraName[i - 1] = everyRow[2];
                        zMatrix_.paraName[startAngleSupplementaryDifference + i] = everyRow[4];
                        zMatrix_.paraName[startDihedralAngleSupplementaryDifference + i] = everyRow[6];
                        tmpConnectionInfoValue[i, 0] = everyRow[2];
                        tmpConnectionInfoValue[i, 1] = everyRow[4];
                        tmpConnectionInfoValue[i, 2] = everyRow[6];
                        break;
                }
            }

            //读取zMatrix中的变量
            //在输入文件中，变量部分可以不按顺序给出。
            List<string> inputParaName = new List<string>(gaussianInputPackage.molecularPara_ZMatrix);
            List<double> inputParaValue = new List<double>(gaussianInputPackage.molecularVariable);

            int cycle = zMatrix_.paraName.Length;
            bool isDoubleType;
            int indexParaName;
            for (int i = 0; i < zMatrix_.paraName.Length; i++)
            {
                isDoubleType = double.TryParse(zMatrix_.paraName[i], out zMatrix_.paraValue[i]);
                if (isDoubleType == true)
                {
                    zMatrix_.paraName[i] = "para" + i.ToString();
                }
                else
                {
                    indexParaName = inputParaName.IndexOf(zMatrix_.paraName[i]);
                    zMatrix_.paraValue[i] = inputParaValue[indexParaName];
                    inputParaName.RemoveAt(indexParaName);
                    inputParaValue.RemoveAt(indexParaName);
                }
            }

            //获取键连信息值
            startAngleSupplementaryDifference = numberOfAtoms - 3;
            startDihedralAngleSupplementaryDifference = numberOfAtoms * 2 - 6;
            for (int i = 0; i < numberOfAtoms; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    switch (i)
                    {
                        case 0:
                            zMatrix_.connectionInfoValue[i, 0] = 0;
                            zMatrix_.connectionInfoValue[i, 1] = 0;
                            zMatrix_.connectionInfoValue[i, 2] = 0;
                            break;
                        case 1:
                            zMatrix_.connectionInfoValue[i, 0] = zMatrix_.paraValue[i - 1];
                            zMatrix_.connectionInfoValue[i, 1] = 0;
                            zMatrix_.connectionInfoValue[i, 2] = 0;
                            break;
                        case 2:
                            zMatrix_.connectionInfoValue[i, 0] = zMatrix_.paraValue[i - 1];
                            zMatrix_.connectionInfoValue[i, 1] = zMatrix_.paraValue[startAngleSupplementaryDifference + i];
                            zMatrix_.connectionInfoValue[i, 2] = 0;
                            break;
                        default:
                            zMatrix_.connectionInfoValue[i, 0] = zMatrix_.paraValue[i - 1];
                            zMatrix_.connectionInfoValue[i, 1] = zMatrix_.paraValue[startAngleSupplementaryDifference + i];
                            zMatrix_.connectionInfoValue[i, 2] = zMatrix_.paraValue[startDihedralAngleSupplementaryDifference + i];
                            break;
                    }
                }
            }
        }


    }
}
