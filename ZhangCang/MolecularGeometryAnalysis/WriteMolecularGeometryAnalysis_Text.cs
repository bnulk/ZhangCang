
using System.Text;
using ZhangCang.Input;
using ZhangCang.ZhangCangIO.TextIO;
using ZhangCang.FundamentalConstants;

namespace ZhangCang.MolecularGeometryAnalysis
{
    internal class WriteMolecularGeometryAnalysis_Text
    {
        private TextO textO;
        private StringBuilder sb;
        private MGA _mga;
        private Molecule molecule;

        public WriteMolecularGeometryAnalysis_Text(string outputFileFullPath, MGA mga, Molecule molecule)
        {
            textO = new TextO(outputFileFullPath, FileMode.Append);
            this._mga = mga;
            this.molecule = molecule;
            sb = new StringBuilder();
        }

        public void Run()
        {
            sb.Append("\n\n");
            sb.Append("bnulk@foxmail.com-MolecularGeometryAnalysis" + "\n");
            sb.Append("****************************************************************************************************" + "\n\n");

            //距离矩阵
            DistanceMatrix();
            //标准取向坐标
            StandardOrientation();
            //分子转子分类
            MolecularType();
            //转动常数
            RotationalConstant();
            textO.WriteStr(sb);
        }


        /// <summary>
        /// 距离矩阵
        /// </summary>
        private void DistanceMatrix()
        {
            sb.Append("\n");
            sb.Append("****************************************************************************************************" + "\n");
            sb.Append("**********                        Distance matrix (angstroms)                             **********" + "\n");
            sb.Append("****************************************************************************************************" + "\n");
            sb.Append("                    " + "\n");

            double[,] distanceMatrix_Angstroms;
            int row = _mga.distanceMatrix.GetLength(0);
            int col = _mga.distanceMatrix.GetLength(1);
            distanceMatrix_Angstroms = new double[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    distanceMatrix_Angstroms[i, j] = _mga.distanceMatrix[i, j] * PhysConst.bohr2angstroms;
                }
            }

            FixedFormat.Matrix2TextO(distanceMatrix_Angstroms, ref sb);
        }

        /// <summary>
        /// 标准取向
        /// </summary>
        /// <exception cref="Input_Exception">没有分子坐标</exception>
        private void StandardOrientation()
        {
            int i, cycle;
            //分子坐标
            sb.Append("\n");
            sb.Append("****************************************************************************************************" + "\n");
            sb.Append("**********                             Standard orientation                               **********" + "\n");
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
                    sb.Append(molecule.atomicNumbers[i].ToString().PadLeft(3) + "     " 
                        + (molecule.cartesian3[i, 0] * PhysConst.bohr2angstroms).ToString("0.000000").PadLeft(12)
                        + (molecule.cartesian3[i, 1] * PhysConst.bohr2angstroms).ToString("0.000000").PadLeft(12) 
                        + (molecule.cartesian3[i, 2] *PhysConst.bohr2angstroms).ToString("0.000000").PadLeft(12) + "\n");
                }
            }
            sb.Append("\n");
        }

        /// <summary>
        /// 分子类型
        /// </summary>
        private void MolecularType()
        {
            switch(_mga.rotorClassify)
            {
                case RotorClassify.Diatomic:
                    sb.Append("Molecule is diatomic." + "\n");
                    break;
                case RotorClassify.Linear:
                    sb.Append("Molecule is linear." + "\n");
                    break;
                case RotorClassify.SphericalTop:
                    sb.Append("Molecule is a spherical top." + "\n");
                    break;
                case RotorClassify.OblateSymmetricTop:
                    sb.Append("Molecule is an oblate symmetric top." + "\n");
                    break;
                case RotorClassify.ProlateSymmetricTop:
                    sb.Append("Molecule is a prolate symmetric top." + "\n");
                    break;
                case RotorClassify.AsymmetricTop:
                    sb.Append("Molecule is an asymmetric top." + "\n");
                    break;
                default:
                    sb.Append("Unknown Rotor Classify." + "\n");
                    break;
            }            
        }

        private void RotationalConstant()
        {
            sb.Append("Rotational constants(GHZ):" + _mga.rotationalConstants_GHz[0].ToString("0.0000000").PadLeft(20)
                + _mga.rotationalConstants_GHz[1].ToString("0.0000000").PadLeft(20)
                + _mga.rotationalConstants_GHz[2].ToString("0.0000000").PadLeft(20) + "\n");
        }






    }
}
