using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace ZhangCang.Input.ZhangCangInput
{
    internal class MoleculeList2MoleculeAndInputZMatrix
    {
        List<string> moleculeList;

        //结果
        int numberOfAtoms;
        int[]? atomicNumbers;
        double[]? realAtomicWeights;
        double[,]? cartesian3;
        ZMatrix inputZMatrix;

        public ZMatrix InputZMatrix { get => InputZMatrix1; set => InputZMatrix1 = value; }
        public int NumberOfAtoms { get => numberOfAtoms; set => numberOfAtoms = value; }
        public int[]? AtomicNumbers { get => atomicNumbers; set => atomicNumbers = value; }
        public double[]? RealAtomicWeights { get => realAtomicWeights; set => realAtomicWeights = value; }
        public double[,]? Cartesian3 { get => cartesian3; set => cartesian3 = value; }
        public ZMatrix InputZMatrix1 { get => inputZMatrix; set => inputZMatrix = value; }

        public MoleculeList2MoleculeAndInputZMatrix(List<string> moleculeList)
        {
            this.moleculeList = moleculeList;
        }

        public void Run()
        {
            bool isCartesian = false;
            bool isTwoBlock = false;

            //判断是何种坐标
            if (moleculeList[0].Trim().Length > 3)                    //直角坐标
            {
                isCartesian = true;
            }

            //判断是否两块输入
            for (int i = 0; i < moleculeList.Count; i++)
            {
                if (moleculeList[i].Trim() == "")
                {
                    isTwoBlock = true;
                    i = moleculeList.Count;
                }
            }

            //读分子结构和ZMatrix形式的输入
            int errorRow = ReadMoleculeAndInputZMatrix(isCartesian, isTwoBlock);

            if(errorRow!=0)
            {
                throw new Input_Exception("Input Error" + "\n" + "Molecule ".ToString() + "\n");
            }            
        }

        /// <summary>
        /// 读取分子和输入ZMatrix
        /// </summary>
        /// <param name="isCartesian">是否笛卡尔坐标</param>
        /// <param name="isTwoBlock">是否两块输入</param>
        /// <returns>出错的行数</returns>
        private int ReadMoleculeAndInputZMatrix(bool isCartesian, bool isTwoBlock)
        {
            int errorRow = 0;

            if (isCartesian == true)
            {
                if (isTwoBlock == true)
                {
                    
                }
                else
                {
                    ReadCoordinate.ReadCartesianOneBlock readCartesianOneBlock = new ReadCoordinate.ReadCartesianOneBlock(moleculeList);
                    readCartesianOneBlock.Run();
                    NumberOfAtoms = readCartesianOneBlock.NumberOfAtoms;
                    AtomicNumbers = readCartesianOneBlock.AtomicNumbers;
                    RealAtomicWeights = readCartesianOneBlock.RealAtomicWeights;
                    Cartesian3= readCartesianOneBlock.Cartesian3;
                    InputZMatrix1 = new ZMatrix();
                }
            }
            else
            {
                if (isTwoBlock == true)
                {

                }
                else
                {

                }
            }
            return errorRow;
        }
        




    }
}
