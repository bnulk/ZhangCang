using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhangCang.LinearAlgebra;

namespace ZhangCang.Geometry
{
    internal class BaseInternalCoordinate
    {
        ZMatrix zMatrix;
        int n;
        List<Matrix> listB = new List<Matrix>();
        List<Matrix> listA = new List<Matrix>();

        double[,] cartesian3;
        Molecule molecule = new Molecule();

        public double[,] Cartesian3 { get => cartesian3; set => cartesian3 = value; }

        public BaseInternalCoordinate(ZMatrix zMatrix)
        {
            this.zMatrix = zMatrix;
            if(zMatrix.atomicNumbers!=null)
            {
                n = zMatrix.atomicNumbers.Length;
            }
            else
            {
                n = 0;
            }

            Cartesian3 = new double[n, 3];
            GenerateEyringList(ref listB);
            GenerateCartesian3(ref cartesian3);
        }


        private void GenerateEyringList(ref List<Matrix> listB)
        {
            double[,] B = new double[4, 4];
            int i, j;

            ///第0个原子
            for(i = 0; i < 4; i++)
            {
                for(j=0; j < 4; j++)
                {
                    B[i, j] = 0.0;
                }
                B[i, i] = 1.0;
            }
            listB.Add(new Matrix(B));
            listA.Add(new Matrix(B));
            B = new double[4, 4];
            //第1个原子
            if(zMatrix.connectionInfo[1, 0] == 0)
            {
                for (i = 0; i < 4; i++)
                {
                    for (j = 0; j < 4; j++)
                    {
                        B[i, j] = 0.0;
                    }
                    B[i, i] = 1.0;
                }
                B[2, 3] = zMatrix.connectionInfoValue[1, 0];

                listB.Add(new Matrix(B));
                listA.Add(listB[0] * new Matrix(B));
                B = new double[4, 4];
            }
            else
            {
                throw new Geometry_Exception("zMatrix Error, site: Line" + "2");
            }
            //第2个原子
            if (zMatrix.connectionInfo[2,0]==1)
            {
                B[0, 0] = -Math.Cos(Math.PI * zMatrix.connectionInfoValue[2, 1] / 180.0);
                B[0, 1] = 0.0;
                B[0, 2] = Math.Sin(Math.PI * zMatrix.connectionInfoValue[2, 1] / 180.0);
                B[0, 3] = zMatrix.connectionInfoValue[2, 0] * Math.Sin(Math.PI * zMatrix.connectionInfoValue[2, 1] / 180.0);

                B[1, 0] = 0.0;
                B[1, 1] = 1.0;
                B[1, 2] = 0.0;
                B[1, 3] = 0.0;

                B[2, 0] = -Math.Sin(Math.PI * zMatrix.connectionInfoValue[2, 1] / 180.0);
                B[2, 1] = 0.0;
                B[2, 2] = -Math.Cos(Math.PI * zMatrix.connectionInfoValue[2, 1] / 180.0);
                B[2, 3] = -zMatrix.connectionInfoValue[2, 0] * Math.Cos(Math.PI * zMatrix.connectionInfoValue[2, 1] / 180.0);

                B[3, 0] = 0.0;
                B[3, 1] = 0.0;
                B[3, 2] = 0.0;
                B[3, 3] = 1.0;

                listB.Add(new Matrix(B));
                listA.Add(listB[1] * new Matrix(B));
                B = new double[4, 4];
            }
            else
            {
                if(zMatrix.connectionInfo[2, 0] == 0)
                {
                    B[0, 0] = Math.Cos(Math.PI * zMatrix.connectionInfoValue[2, 1] / 180.0);
                    B[0, 1] = 0.0;
                    B[0, 2] = Math.Sin(Math.PI * zMatrix.connectionInfoValue[2, 1] / 180.0);
                    B[0, 3] = zMatrix.connectionInfoValue[2, 0] * Math.Sin(Math.PI * zMatrix.connectionInfoValue[2, 1] / 180.0);

                    B[1, 0] = 0.0;
                    B[1, 1] = 1.0;
                    B[1, 2] = 0.0;
                    B[1, 3] = 0.0;

                    B[2, 0] = -Math.Sin(Math.PI * zMatrix.connectionInfoValue[2, 1] / 180.0);
                    B[2, 1] = 0.0;
                    B[2, 2] = Math.Cos(Math.PI * zMatrix.connectionInfoValue[2, 1] / 180.0);
                    B[2, 3] = zMatrix.connectionInfoValue[2, 0] * Math.Cos(Math.PI * zMatrix.connectionInfoValue[2, 1] / 180.0);

                    B[3, 0] = 0.0;
                    B[3, 1] = 0.0;
                    B[3, 2] = 0.0;
                    B[3, 3] = 1.0;

                    listB.Add(new Matrix(B));
                    listA.Add(listB[0] * new Matrix(B));
                    B = new double[4, 4];
                }
                else
                {
                    throw new Geometry_Exception("zMatrix Error, site: Line" + "3");
                }
            }



            //第3-n个原子
            /*同面原子
            int nnn = 3;            
            B[0, 0] = -Math.Cos(Math.PI * zMatrix.connectionInfoValue[nnn, 1] / 180.0);
            B[0, 1] = 0.0;
            B[0, 2] = -Math.Sin(Math.PI * zMatrix.connectionInfoValue[nnn, 1] / 180.0);
            B[0, 3] = -zMatrix.connectionInfoValue[nnn, 0] * Math.Sin(Math.PI * zMatrix.connectionInfoValue[nnn, 1] / 180.0);

            B[1, 0] = 0.0;
            B[1, 1] = 1.0;
            B[1, 2] = 0.0;
            B[1, 3] = 0.0;

            B[2, 0] = Math.Sin(Math.PI * zMatrix.connectionInfoValue[nnn, 1] / 180.0);
            B[2, 1] = 0.0;
            B[2, 2] = -Math.Cos(Math.PI * zMatrix.connectionInfoValue[nnn, 1] / 180.0);
            B[2, 3] = -zMatrix.connectionInfoValue[nnn, 0] * Math.Cos(Math.PI * zMatrix.connectionInfoValue[nnn, 1] / 180.0);

            B[3, 0] = 0.0;
            B[3, 1] = 0.0;
            B[3, 2] = 0.0;
            B[3, 3] = 1.0;
            */


            for (i=3;i<n;i++)
            {
                if (zMatrix.connectionInfo[2, 0] < i)
                {
                    B[0, 0] = Math.Cos(Math.PI * zMatrix.connectionInfoValue[i, 1] / 180.0) * Math.Cos(Math.PI * zMatrix.connectionInfoValue[i, 2] / 180.0);
                    B[0, 1] = Math.Sin(Math.PI * zMatrix.connectionInfoValue[i, 2] / 180.0);
                    B[0, 2] = Math.Sin(Math.PI * zMatrix.connectionInfoValue[i, 1] / 180.0) * Math.Cos(Math.PI * zMatrix.connectionInfoValue[i, 2] / 180.0);
                    B[0, 3] = zMatrix.connectionInfoValue[i, 0] * Math.Sin(Math.PI * zMatrix.connectionInfoValue[i, 1] / 180.0) * Math.Cos(Math.PI * zMatrix.connectionInfoValue[i, 2] / 180.0);

                    B[1, 0] = Math.Cos(Math.PI * zMatrix.connectionInfoValue[i, 1] / 180.0) * Math.Sin(Math.PI * zMatrix.connectionInfoValue[i, 2] / 180.0);
                    B[1, 1] = -Math.Cos(Math.PI * zMatrix.connectionInfoValue[i, 2] / 180.0);
                    B[1, 2] = Math.Sin(Math.PI * zMatrix.connectionInfoValue[i, 1] / 180.0) * Math.Sin(Math.PI * zMatrix.connectionInfoValue[i, 2] / 180.0);
                    B[1, 3] = zMatrix.connectionInfoValue[i, 0] * Math.Sin(Math.PI * zMatrix.connectionInfoValue[i, 1] / 180.0) * Math.Sin(Math.PI * zMatrix.connectionInfoValue[i, 2] / 180.0);

                    B[2, 0] = Math.Sin(Math.PI * zMatrix.connectionInfoValue[i, 1] / 180.0);
                    B[2, 1] = 0.0;
                    B[2, 2] = -Math.Cos(Math.PI * zMatrix.connectionInfoValue[i, 1] / 180.0);
                    B[2, 3] = -zMatrix.connectionInfoValue[i, 0] * Math.Cos(Math.PI * zMatrix.connectionInfoValue[i, 1] / 180.0);

                    B[3, 0] = 0.0;
                    B[3, 1] = 0.0;
                    B[3, 2] = 0.0;
                    B[3, 3] = 1.0;

                    listB.Add(new Matrix(B));
                    listA.Add(listA[i-1] * new Matrix(B));
                    B = new double[4, 4];
                }
                else
                {
                    throw new Geometry_Exception("zMatrix Error, site: Line" + (i+1).ToString());
                }
            }
            


        }


        private void GenerateCartesian3(ref double[,] cartesian3)
        {
            double[] vector = new double[4] { 0, 0, 0, 1 };
            Matrix orginPoint = new Matrix(vector);
            Matrix result3 = new Matrix(4, 1);

            cartesian3[0, 0] = 0.0;
            cartesian3[0, 1] = 0.0;
            cartesian3[0, 2] = 0.0;

            for(int i=1;i<3;i++)
            {
                //result3 = listA[i] * new Matrix(new double[4] { cartesian3[i - 1, 0], cartesian3[i - 1, 1], cartesian3[i - 1, 2], 1 });
                result3 = listA[i] * orginPoint;
                for (int j = 0; j < 3; j++)
                {
                    cartesian3[i, j] = result3.ele[j, 0];
                }
            }

            
            double[] tmpInverseMatrix = new double[16];
            double[] tmpSolve = new double[4];
            double[,] inverseMatrix = new double[4, 4];

            for (int i = 3; i < n; i++)
            {
                /*
                for (int ii=0; ii<4; ii++)
                {
                    for(int jj=0; jj<4; jj++)
                    {
                        tmpInverseMatrix[ii * 4 + jj] = listB[i].ele[ii, jj];
                    }
                }

                LinearAlgebra.LineEquation.gaussj(ref tmpInverseMatrix, 4, ref tmpSolve);

                for (int ii = 0; ii < 4; ii++)
                {
                    for (int jj = 0; jj < 4; jj++)
                    {
                        inverseMatrix[ii, jj] = tmpInverseMatrix[ii * 4 + jj];
                    }
                }
                */


                //result3 = new Matrix(inverseMatrix) * new Matrix(new double[4] { cartesian3[i - 1, 0], cartesian3[i - 1, 1], cartesian3[i - 1, 2], 1 });
                result3 = listA[i] * orginPoint;
                //result3 = listB[i] * orginPoint;
                for (int j = 0; j < 3; j++)
                {
                    cartesian3[i, j] = result3.ele[j, 0];
                }
            }
        }


    }
}
