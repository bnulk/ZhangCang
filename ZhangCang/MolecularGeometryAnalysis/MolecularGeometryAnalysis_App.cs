using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhangCang.Data;
using ZhangCang.LinearAlgebra;
using ZhangCang.ZhangCangIO.TextIO;

namespace ZhangCang.MolecularGeometryAnalysis
{
    internal partial class MolecularGeometryAnalysis_App
    {
        /*
        ----------------------------------------------------  类注释  开始----------------------------------------------------
        版本：  V1.0
        作者：  刘鲲
        日期：  2018-07-26

        描述：
            * 本类做分子的构型分析。
            * 本类的输出对象是Element对象。
            * （1）在Element中的Molecule对象中，把分子的重心放到原点，并且把分子摆正。
            *      分子摆正：旋转分子，让分子的三个主轴朝向正好对应三个笛卡尔轴，分子就被摆正了。方法是利用惯性矩张量的本征矢矩阵来对各个原子的坐标做线性变换。
        ----------------------------------------------------  类注释  结束----------------------------------------------------
        */

        private Molecule input_molecule;
        private Vector3D[] _molecularCoordinate;
        private int i, j;

        string outputFileFullPath;
        MGA mga;



        public MolecularGeometryAnalysis_App(ref Molecule molecule, string outputFileFullPath)
        {
            this.input_molecule = molecule;

            _molecularCoordinate = new Vector3D[input_molecule.numberOfAtoms];
            if (input_molecule.cartesian3 != null && input_molecule.cartesian3.GetLength(0) == input_molecule.numberOfAtoms)
            {
                for (int i = 0; i < input_molecule.numberOfAtoms; i++)
                {
                    _molecularCoordinate[i] = new Vector3D(input_molecule.cartesian3[i, 0],
                        input_molecule.cartesian3[i, 1], input_molecule.cartesian3[i, 2]);
                }
            }            
            this.outputFileFullPath = outputFileFullPath;
            mga= new MGA();
        }

        public void Run()
        {
            //计算距离矩阵
            mga.distanceMatrix = GetDistanceMatrix();

            //计算质心
            mga.massCenter = GetMassCenter();

            //把坐标原点平移到质心
            Translate(-mga.massCenter[0], -mga.massCenter[1], -mga.massCenter[2]);
            mga.massCenter[0] = mga.massCenter[1] = mga.massCenter[2] = 0.0;

            //计算惯量张量
            mga.inertiaTensor = MomentOfInertiaTensor();

            //对角化惯量张量，以获得主转动惯量和惯量主轴矩阵。
            DiagonalizeInertiaTensor(mga.inertiaTensor, out mga.principalMomentsOfInertia, out mga.inertiaPrincipalAxisMatrix);

            //对转子进行分类
            mga.rotorClassify = ClassifyTheRotor(mga.principalMomentsOfInertia);

            //计算转动常数_GHz
            mga.rotationalConstants_GHz = RotationalConstants_GHz(mga.principalMomentsOfInertia);

            //摆正分子
            StraightenMolecule(mga.inertiaPrincipalAxisMatrix);


            UpdateInputMoleculeBaseOnmolecularCoordinate();
            WriteMolecularGeometryAnalysis_Text writeOut = new WriteMolecularGeometryAnalysis_Text(outputFileFullPath, mga, input_molecule);
            writeOut.Run();
        }


        /// <summary>
        /// 按照_molecularCoordinate更新molecule.cartesian3
        /// </summary>
        private void UpdateInputMoleculeBaseOnmolecularCoordinate()
        {
            
            if (_molecularCoordinate != null && input_molecule.cartesian3!=null && _molecularCoordinate.Length==input_molecule.cartesian3.GetLength(0))
            {
                for (int i = 0; i < input_molecule.numberOfAtoms; i++)
                {
                    input_molecule.cartesian3[i, 0] = _molecularCoordinate[i].x;
                    input_molecule.cartesian3[i, 1] = _molecularCoordinate[i].y;
                    input_molecule.cartesian3[i, 2] = _molecularCoordinate[i].z;
                }
            }
        }

        /// <summary>
        /// 获取距离矩阵二维数组
        /// </summary>
        /// <returns>距离矩阵二维数组</returns>
        private double[,] GetDistanceMatrix()
        {
            double[,] result= new double[input_molecule.numberOfAtoms,input_molecule.numberOfAtoms];
            for(i=0; i < input_molecule.numberOfAtoms; i++)
            {
                for(j=0;j<i; j++)
                {
                    result[i, j] = result[j, i] = Bond(_molecularCoordinate[i], _molecularCoordinate[j]);
                }
            }
            return result;
        }

        /// <summary>
        /// 获取质心
        /// </summary>
        /// <returns></returns>
        private double[] GetMassCenter()
        {
            double[] result = MassCenter_Double();
            return result;
        }





    }
}
