using ZhangCang.LinearAlgebra;
using ZhangCang.NumericalRecipes;
using ZhangCang.FundamentalConstants;
using System.Reflection.Metadata;

namespace ZhangCang.MolecularGeometryAnalysis
{
    internal partial class MolecularGeometryAnalysis_App
    {
        /// <summary>
        /// 计算距离
        /// </summary>
        /// <param name="atom1">第一个向量</param>
        /// <param name="atom2">第二个向量</param>
        /// <returns>键长</returns>
        public double Bond(Vector3D atom1, Vector3D atom2)
        {
            double bond = Math.Sqrt((atom1.x - atom2.x) * (atom1.x - atom2.x) + (atom1.y - atom2.y) * (atom1.y - atom2.y) + (atom1.z - atom2.z) * (atom1.z - atom2.z));
            return bond;
        }

        /// <summary>
        /// 计算键角
        /// </summary>
        /// <param name="i">第一个原子的标号</param>
        /// <param name="j">第二个原子的标号</param>
        /// <param name="k">第三个原子的标号</param>
        /// <returns>键角-弧度</returns>
        public double Angle(Vector3D i, Vector3D j, Vector3D k)
        {
            double angle = 0.0;
            double value = 0.0;
            Vector3D v1 = new Vector3D(j, i);
            Vector3D v2 = new Vector3D(j, k);

            value = v1.Unit() | v2.Unit();
            if (value > 1)
            {
                angle = Math.Acos(1);
            }
            else
            {
                if (value < -1)
                {
                    angle = Math.Acos(-1);
                }
                else
                {
                    angle = Math.Acos(value);
                }
            }

            return angle;
        }

        /// <summary>
        /// 计算二面（扭转）角
        /// </summary>
        /// <param name="i">第一个原子的标号</param>
        /// <param name="j">第二个原子的标号</param>
        /// <param name="k">第三个原子的标号</param>
        /// <param name="l">第四个原子的标号</param>
        /// <returns>二面（扭转）角</returns>
        public double Torsion(Vector3D i, Vector3D j, Vector3D k, Vector3D l)
        {
            double torsion = 0.0;
            double value = 0.0;
            Vector3D ij = new Vector3D(i, j);
            Vector3D jk = new Vector3D(j, k);
            Vector3D kl = new Vector3D(k, l);

            Vector3D ijk = ij.Unit() ^ jk.Unit();
            Vector3D jkl = jk.Unit() ^ kl.Unit();

            value = (ijk | jkl) / Math.Sin(Angle(i, j, k)) / Math.Sin(Angle(j, k, l));

            if (value > 1)
            {
                torsion = Math.Acos(1);
            }
            else
            {
                if (value < -1)
                {
                    torsion = Math.Acos(-1);
                }
                else
                {
                    torsion = Math.Acos(value);
                }
            }

            //计算扭转角的符号
            Vector3D cross = ijk ^ jkl;
            double norm = cross | cross;
            cross = cross / norm;

            double sign = 1.0;
            double dot = cross | jk;
            if (dot < 0.0)
            {
                sign = -1.0;
            }

            return torsion * sign;
        }


        /// <summary>
        /// 计算质心
        /// </summary>
        /// <returns>质心</returns>
        public Vector3D MassCenter()
        {
            Vector3D massCenter = new Vector3D();
            double M = 0.0;



            if (input_molecule.realAtomicWeights != null)
            {
                for (int i = 0; i < input_molecule.numberOfAtoms; i++)
                {
                    M += input_molecule.realAtomicWeights[i];
                }
            }

            double mi = 0.0;
            if (input_molecule.realAtomicWeights != null)
            {
                for (int i = 0; i < input_molecule.numberOfAtoms; i++)
                {
                    mi = input_molecule.realAtomicWeights[i];
                    massCenter.x += mi * _molecularCoordinate[i].x;
                    massCenter.y += mi * _molecularCoordinate[i].y;
                    massCenter.z += mi * _molecularCoordinate[i].z;
                }
            }

            massCenter.x /= M;
            massCenter.y /= M;
            massCenter.z /= M;

            return massCenter;
        }

        /// <summary>
        /// 计算质心
        /// </summary>
        /// <returns>质心</returns>
        public double[] MassCenter_Double()
        {
            double[] massCenter = new double[3];
            double M = 0.0;



            if (input_molecule.realAtomicWeights != null)
            {
                for (int i = 0; i < input_molecule.numberOfAtoms; i++)
                {
                    M += input_molecule.realAtomicWeights[i];
                }
            }

            double mi = 0.0;
            if (input_molecule.realAtomicWeights != null)
            {
                for (int i = 0; i < input_molecule.numberOfAtoms; i++)
                {
                    mi = input_molecule.realAtomicWeights[i];
                    massCenter[0] += mi * _molecularCoordinate[i].x;
                    massCenter[1] += mi * _molecularCoordinate[i].y;
                    massCenter[2] += mi * _molecularCoordinate[i].z;
                }
            }

            massCenter[0] /= M;
            massCenter[1] /= M;
            massCenter[2] /= M;

            return massCenter;
        }

        /// <summary>
        /// 分子平移
        /// </summary>
        /// <param name="x">x方向平移量</param>
        /// <param name="y">y方向平移量</param>
        /// <param name="z">z方向平移量</param>
        public void Translate(double x, double y, double z)
        {
            for (int i = 0; i < input_molecule.numberOfAtoms; i++)
            {
                _molecularCoordinate[i].x += x;
                _molecularCoordinate[i].y += y;
                _molecularCoordinate[i].z += z;
            }
        }

        /// <summary>
        /// 计算惯量张量
        /// </summary>
        /// <returns>惯量张量</returns>
        public Matrix MomentOfInertiaTensor()
        {
            double mi = 0.0;
            Matrix momentOfInertiaTensor = new Matrix(3, 3);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    momentOfInertiaTensor.ele[i, j] = 0.0;
                }
            }
            if (input_molecule.realAtomicWeights != null)
            {
                for (int i = 0; i < input_molecule.numberOfAtoms; i++)
                {
                    mi = input_molecule.realAtomicWeights[i];
                    momentOfInertiaTensor.ele[0, 0] += mi * (_molecularCoordinate[i].y * _molecularCoordinate[i].y + _molecularCoordinate[i].z * _molecularCoordinate[i].z);
                    momentOfInertiaTensor.ele[1, 1] += mi * (_molecularCoordinate[i].x * _molecularCoordinate[i].x + _molecularCoordinate[i].z * _molecularCoordinate[i].z);
                    momentOfInertiaTensor.ele[2, 2] += mi * (_molecularCoordinate[i].x * _molecularCoordinate[i].x + _molecularCoordinate[i].y * _molecularCoordinate[i].y);
                    momentOfInertiaTensor.ele[0, 1] -= mi * (_molecularCoordinate[i].x * _molecularCoordinate[i].y);
                    momentOfInertiaTensor.ele[0, 2] -= mi * (_molecularCoordinate[i].x * _molecularCoordinate[i].z);
                    momentOfInertiaTensor.ele[1, 2] -= mi * (_molecularCoordinate[i].y * _molecularCoordinate[i].z);
                }
            }

            momentOfInertiaTensor.ele[1, 0] = momentOfInertiaTensor.ele[0, 1];
            momentOfInertiaTensor.ele[2, 0] = momentOfInertiaTensor.ele[0, 2];
            momentOfInertiaTensor.ele[2, 1] = momentOfInertiaTensor.ele[1, 2];

            return momentOfInertiaTensor;
        }


        /// <summary>
        /// 对角化惯量张量
        /// </summary>
        /// <param name="inertiaTensor">惯量张量</param>
        /// <param name="principalMomentsOfInertia">主转动惯量</param>
        /// <param name="inertiaPrincipalAxisMatrix">惯量主轴矩阵</param>
        public void DiagonalizeInertiaTensor(Matrix inertiaTensor, out Vector principalMomentsOfInertia, out Matrix inertiaPrincipalAxisMatrix)
        {
            int n = inertiaTensor.row;
            principalMomentsOfInertia = new Vector(n);
            inertiaPrincipalAxisMatrix = new Matrix(n, n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    inertiaPrincipalAxisMatrix[i, j] = inertiaTensor[i, j];
                }
            }
            Vector e = new Vector(n);

            Matrix.tred2(ref inertiaPrincipalAxisMatrix, ref principalMomentsOfInertia, ref e);
            Matrix.tqli(ref principalMomentsOfInertia, ref e, ref inertiaPrincipalAxisMatrix);

        }

        /// <summary>
        /// 对转子进行分类
        /// </summary>
        /// <param name="principalMomentsOfInertia">主转动惯量</param>
        /// <returns></returns>
        public RotorClassify ClassifyTheRotor(Vector principalMomentsOfInertia)
        {
            RotorClassify classify = RotorClassify.Diatomic;

            Vector tmpVec = new Vector(principalMomentsOfInertia.dim);
            for (int i=0;i<principalMomentsOfInertia.dim;i++)
            {
                tmpVec.ele[i] = principalMomentsOfInertia.ele[i];
            }

            Sorting.sort(ref tmpVec);

            if (input_molecule.numberOfAtoms == 2)
            {
                classify = RotorClassify.Diatomic;
                //classify = "Molecule is diatomic.";
            }
            else
            {
                if (tmpVec[0] < 1E-4)
                {
                    classify = RotorClassify.Linear;
                    //classify = "Molecule is linear.";
                }
                else
                {
                    if (Math.Abs(tmpVec[1] - tmpVec[0]) < 1E-4 && Math.Abs(tmpVec[2] - tmpVec[1]) < 1E-4)
                    {
                        classify = RotorClassify.SphericalTop;
                        //classify = "Molecule is a spherical top.";
                    }
                    else
                    {
                        if (Math.Abs(tmpVec[1] - tmpVec[0]) < 1E-4 && Math.Abs(tmpVec[2] - tmpVec[1]) > 1E-4)
                        {
                            classify = RotorClassify.OblateSymmetricTop;
                            //classify = "Molecule is an oblate symmetric top.";
                        }
                        else
                        {
                            if (Math.Abs(tmpVec[1] - tmpVec[0]) > 1E-4 && Math.Abs(tmpVec[2] - tmpVec[1]) < 1E-4)
                            {
                                classify = RotorClassify.ProlateSymmetricTop;
                                //classify = "Molecule is a prolate symmetric top.";
                            }
                            else
                            {
                                classify = RotorClassify.AsymmetricTop;
                                //classify = "Molecule is an asymmetric top.";
                            }
                        }
                    }
                }
            }
            return classify;
        }

        /// <summary>
        /// 计算转动常数
        /// </summary>
        /// <param name="principalMomentsOfInertia">主转动惯量</param>
        /// <returns>转动常数</returns>
        public Vector RotationalConstants_GHz(Vector principalMomentsOfInertia)
        {
            double tmpConstant = 0.0;
            Vector rotationalConstants = new Vector(3);
            for (int i = 0; i < 3; i++)
            {
                rotationalConstants[i] = principalMomentsOfInertia[i];
            }

            tmpConstant = PhysConst.h / (8 * PhysConst.PI * PhysConst.PI);
            tmpConstant /= 1.6605402E-27 * 0.529177249E-10 * 0.529177249E-10;
            tmpConstant *= 1E-9;
            for (int i = 0; i < 3; i++)
            {
                rotationalConstants[i] = tmpConstant / rotationalConstants[i];
            }

            return rotationalConstants;
        }

        /// <summary>
        /// 计算转动常数
        /// </summary>
        /// <param name="principalMomentsOfInertia">主转动惯量</param>
        /// <returns>转动常数</returns>
        public Vector RotationalConstants_wavenumbers(Vector principalMomentsOfInertia)
        {
            double tmpConstant = 0.0;
            Vector rotationalConstants = new Vector(3);
            for (int i = 0; i < 3; i++)
            {
                rotationalConstants[i] = principalMomentsOfInertia[i];
            }

            tmpConstant = PhysConst.h / (8 * PhysConst.PI * PhysConst.PI);
            tmpConstant /= 1.6605402E-27 * 0.529177249E-10 * 0.529177249E-10;
            tmpConstant /= 2.99792458E10;
            for (int i = 0; i < 3; i++)
            {
                rotationalConstants[i] = tmpConstant / rotationalConstants[i];
            }

            return rotationalConstants;
        }

        /*
        /// <summary>
        /// 摆正分子
        /// </summary>
        /// <param name="Oper">惯性矩张量的本征矢矩阵</param>
        /// <param name="molecule">分子坐标</param>
        public Vector3D[] StraightenMolecule(Matrix Oper, Vector3D[] molecule)
        {
            int n = molecule.Length;
            Vector3D[] tmpMolecule = new Vector3D[n];

            for (int i = 0; i < n; i++)
            {
                tmpMolecule[i] = Vector3D.Rotation(Oper, molecule[i]);
            }

            return tmpMolecule;
        }
        */

        /// <summary>
        /// 摆正分子
        /// </summary>
        /// <param name="Oper">惯性矩张量的本征矢矩阵</param>
        private void StraightenMolecule(Matrix Oper)
        {
            int n= _molecularCoordinate.GetLength(0);
            Vector3D[] tmpMolecule = new Vector3D[n];

            for (int i = 0; i < n; i++)
            {
                tmpMolecule[i]= Vector3D.Rotation(Oper, _molecularCoordinate[i]);
            }

            for(int i=0; i < n; i++)
            {
                _molecularCoordinate[i].x = tmpMolecule[i].x;
                _molecularCoordinate[i].y = tmpMolecule[i].y;
                _molecularCoordinate[i].z = tmpMolecule[i].z;
            }
        }

    }
}
