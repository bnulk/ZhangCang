using System.Text;
using ZhangCang.Data;
using ZhangCang.ZhangCangIO.TextIO;

namespace ZhangCang.Input
{
    internal class WriteInputFile_Text
    {
        private bool isRunThisClass;
        private Control control;
        private InputData inputData;
        private TextO textO;

        public WriteInputFile_Text(bool isRunThisClass, Control control, InputData inputData)
        {
            this.isRunThisClass = isRunThisClass;
            this.control = control;
            this.inputData = inputData;
            textO = new TextO(this.control.outputFileFullPath, FileMode.Append);
        }

        public void Run()
        {
            if (isRunThisClass == false)
            {
                WriteEmpty();
            }
            else
            {
                WriteInputData();
            }
        }

        /// <summary>
        /// 写空的输入
        /// </summary>
        private void WriteEmpty()
        {
            textO.WriteError("Empty Input Data.");
        }

        /// <summary>
        /// 写输入数据
        /// </summary>
        private void WriteInputData()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\n\n");
            sb.Append("bnulk@foxmail.com-InputData" + "\n");
            sb.Append("****************************************************************************************************" + "\n\n");

            sb.Append("InputFileType is " + inputData.inputFileType.ToString() + "\n");

            //关键词
            sb.Append(GetKeywordInfo(inputData.keyword).ToString() + "\n");

            //输入zMatrix
            sb.Append(GetInputZMatrix(inputData.zMatrix));

            //分子
            sb.Append(GetMoleculeInfo(inputData.states, inputData.molecule).ToString() + "\n");

            textO.WriteStr(sb.ToString());

            //输入zMatrix
        }


        /// <summary>
        /// 获取关键词的可变字符串
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <returns>关键词的可变字符串</returns>
        private StringBuilder GetKeywordInfo(Keyword keyword)
        {
            StringBuilder sb = new StringBuilder();
            int i, cycle;

            sb.Append("task=" + keyword.task.ToString() + " ");
            sb.Append("cmd=" + keyword.cmd.ToString() + " ");
            sb.Append("\n");

            //计算方法
            cycle = keyword.strMethods.Length;
            sb.Append("method=");
            for (i = 0; i < cycle; i++)
            {
                sb.Append(keyword.strMethods[i].ToString());
                if (i != cycle - 1)
                {
                    sb = sb.Append(":");
                }
            }
            sb.Append(" ");
            //基组
            //TD选项
            if (keyword.td.isTD)
            {
                sb.Append("TD=(");
                cycle = keyword.td.root.Length;
                for (i = 0; i < cycle; i++)
                {
                    sb.Append("root=" + keyword.td.root[i].ToString());
                    if (i != cycle - 1)
                    {
                        sb = sb.Append(":");
                    }
                }
                sb.Append(",");
                sb.Append("nstates=" + keyword.td.nstates.ToString());
                sb.Append(")");
            }
            sb.Append(" ");
            //计算采用坐标类型
            sb.Append("coordinateType=" + keyword.coordinateType.ToString());
            sb.Append("\n\n");

            //MECP关键词
            if (keyword.task == Task.mecp)
            {
                sb.Append("********** MECP Keyword **********" + "\n");
                sb.Append("MECP=" + keyword.mecp.ToString() + " " + "judgement=" + keyword.judgement.ToString() + " " + "Convergence=" + keyword.convergence.ToString() + " "
                    + "Freq=" + keyword.freq.ToString() + "isReadFirst=" + " " + keyword.isReadFirst.ToString() + "\n");
                sb.Append("lambda=" + keyword.lambda.ToString() + " " + "stepSize=" + keyword.stepSize.ToString() + " " + "optCyc=" + keyword.optCyc.ToString());
                sb.Append("guessHessian=" + keyword.guessHessian.ToString() + " " + "gradientN=" + keyword.gradientN.ToString() + " " + "hessianN=" + keyword.hessianN.ToString() + "\n");
                sb.Append("energyCon=" + keyword.energyCon.ToString() + " " + "maxCon=" + keyword.maxCon.ToString() + " " + "energyCon=" + keyword.rmsCon.ToString() + " "
                    + "maxDisplace=" + keyword.maxDisplace.ToString() + " " + "energyCon=" + keyword.rmsDisplace.ToString() + "\n");
                sb.Append("showGradRatioCriterionN=" + keyword.showGradRatioCriterionN.ToString() + " " + "showGradRatioCriterion=" + keyword.showGradRatioCriterion.ToString() + "\n");
                sb.Append("********** MECP Keyword End **********" + "\n");
            }
            return sb;
        }

        /// <summary>
        /// 获取分子的可变字符串
        /// </summary>
        /// <param name="molecule">分子</param>
        /// <returns>分子可变字符串</returns>
        private StringBuilder GetMoleculeInfo(States states, Molecule molecule)
        {
            StringBuilder sb = new StringBuilder();
            int i, cycle;

            /*
            //电荷和自旋多重度
            try
            {
                if (molecule.charge == null || molecule.multiplicity == null)
                {
                    throw new Input_Exception("input charge and multiplicity Error.");
                }
                else
                {
                    cycle = molecule.charge.Length;
                }
                sb.Append("Charge=");
                for (i = 0; i < cycle; i++)
                {
                    sb.Append(molecule.charge[i].ToString() + " ");
                }
                sb.Append("\n");
                sb.Append("Multiplicity=");
                for (i = 0; i < cycle; i++)
                {
                    sb.Append(molecule.multiplicity[i].ToString() + " ");
                }
                sb.Append("\n");
            }
            catch
            {
                throw new Input_Exception("input charge and multiplicity Error.");
            }
            */

            //分子坐标
            sb.Append("\n");
            sb.Append("****************************************************************************************************" + "\n");
            sb.Append("**********                              Molecular Cartesian                               **********" + "\n");
            sb.Append("****************************************************************************************************" + "\n");

            if (molecule.atomicNumbers == null || molecule.cartesian3 == null)
            {
                throw new Input_Exception("input coordinate Error.");
            }
            else
            {
                cycle = molecule.numberOfAtoms;
                for (i = 0; i < cycle; i++)
                {
                    sb.Append(molecule.atomicNumbers[i].ToString().PadLeft(3) + "     " + molecule.cartesian3[i, 0].ToString("0.000000").PadLeft(12)
                        + molecule.cartesian3[i, 1].ToString("0.000000").PadLeft(12) + molecule.cartesian3[i, 2].ToString("0.000000").PadLeft(12) + "\n");
                }
            }
            sb.Append("\n");

            sb.Append("****************************************************************************************************" + "\n");
            sb.Append("**********                               Atoms Information                                **********" + "\n");
            sb.Append("****************************************************************************************************" + "\n");
            sb.Append("\n");
            sb.Append("Number Of Atoms=" + molecule.numberOfAtoms.ToString());
            sb.Append("\n");
            if (molecule.realAtomicWeights == null)
            {
                throw new Input_Exception("input realAtomicWeights Error.");
            }
            else
            {
                cycle = (int)Math.Floor(Convert.ToDouble(molecule.numberOfAtoms) / 10);

                for (i = 0; i <= cycle; i++)
                {
                    if (i < cycle)
                    {
                        sb.Append("".PadRight(20));
                        for (int j = 0; j < 10; j++)
                        {
                            sb.Append("         " + (i * 10 + 1 + j).ToString().PadRight(3));
                        }
                        sb.Append("\n");

                        sb.Append("atomicNumbers".PadRight(20));
                        for (int j = 0; j < 10; j++)
                        {
                            sb.Append(molecule.atomicNumbers[i * 10 + j].ToString("0.000000").PadLeft(12));
                        }
                        sb.Append("\n");

                        sb.Append("realAtomicWeights".PadRight(20));
                        for (int j = 0; j < 10; j++)
                        {
                            sb.Append(molecule.realAtomicWeights[i * 10 + j].ToString("0.000000").PadLeft(12));
                        }
                        sb.Append("\n");
                    }
                    else
                    {
                        int lastCycle = molecule.numberOfAtoms - 10 * cycle;

                        if(lastCycle!=0)
                        {
                            sb.Append("".PadRight(20));
                            for (int j = 0; j < lastCycle; j++)
                            {
                                sb.Append("         " + (i * 10 + 1 + j).ToString().PadRight(3));
                            }
                            sb.Append("\n");
                            sb.Append("atomicNumbers".PadRight(20));
                            for (int j = 0; j < lastCycle; j++)
                            {
                                sb.Append(molecule.atomicNumbers[i * 10 + j].ToString("0.000000").PadLeft(12));
                            }
                            sb.Append("\n");

                            sb.Append("realAtomicWeights".PadRight(20));
                            for (int j = 0; j < lastCycle; j++)
                            {
                                sb.Append(molecule.realAtomicWeights[i * 10 + j].ToString("0.000000").PadLeft(12));
                            }
                            sb.Append("\n");
                        }
                    }
                }
            }

            return sb;
        }

        private StringBuilder GetInputZMatrix(ZMatrix zMatrix)
        {
            StringBuilder sb = new StringBuilder();
            int i, cycle;

            if (zMatrix.isExist == false)
            {
                sb.Append("No ZMatrix Entered." + "\n\n");
                return sb;
            }

            sb.Append("****************************************************************************************************" + "\n");
            sb.Append("**********                                 Input ZMatrix                                  **********" + "\n");
            sb.Append("****************************************************************************************************" + "\n");
            sb.Append("\n");
            if (zMatrix.atomicNumbers == null || zMatrix.connectionInfo == null || zMatrix.paraName == null || zMatrix.paraValue == null)
            {
                throw new Input_Exception("input realAtomicWeights Error.");
            }

            cycle = zMatrix.connectionInfo.GetLength(0);                                //循环次数，同时也是分子中原子个数
            int angleLabel = 0;
            int dihedralAngleLabel = 0;


            //第一行
            if (cycle > 0)
            {
                sb.Append(zMatrix.atomicNumbers[0].ToString() + "\n");
            }
            //第二行
            if (cycle > 1)
            {
                sb.Append(zMatrix.atomicNumbers[1].ToString().PadRight(19)
                    + (zMatrix.connectionInfo[1, 0]+1).ToString().PadRight(13) + zMatrix.paraName[0].PadRight(6) + "\n");                        //键长
            }
            //第三行
            if (cycle > 2)
            {
                sb.Append(zMatrix.atomicNumbers[2].ToString().PadRight(19)
                    + (zMatrix.connectionInfo[2, 0]+1).ToString().PadRight(13) + zMatrix.paraName[1].PadRight(6)                                 //键长
                    + (zMatrix.connectionInfo[2, 1]+1).ToString().PadRight(13) + zMatrix.paraName[cycle - 1].PadRight(6) + "\n");                //键角   
            }
            if (cycle > 3)
            {
                angleLabel = cycle - 3;
                dihedralAngleLabel = 2 * cycle - 6;

                for (i = 3; i < cycle; i++)
                {
                    sb.Append(zMatrix.atomicNumbers[i].ToString().PadRight(19)
                    + (zMatrix.connectionInfo[i, 0]+1).ToString().PadRight(13) + zMatrix.paraName[i - 1].PadRight(6)                                     //键长
                    + (zMatrix.connectionInfo[i, 1]+1).ToString().PadRight(13) + zMatrix.paraName[angleLabel + i].PadRight(6)                            //键角
                    + (zMatrix.connectionInfo[i, 2]+1).ToString().PadRight(13) + zMatrix.paraName[dihedralAngleLabel + i].PadRight(6) + "\n");           //二面角

                }
            }
            sb.Append("\n");

            cycle = zMatrix.paraName.Length;
            for(i=0;i<cycle;i++)
            {
                sb.Append(("   " + zMatrix.paraName[i]).PadRight(11)
                    + "="
                    + ("    " + zMatrix.paraValue[i].ToString("0.00000000")).PadLeft(20)
                    + "\n");
            }

            sb.Append("\n\n");


            return sb;
        }





    }
}
