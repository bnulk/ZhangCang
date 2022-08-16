using ZhangCang.LinearAlgebra;

namespace ZhangCang.Geometry
{
    internal class InternalCoordinate2Cartesian
    {
        ZMatrix _zMatrix;
        int n;

        double[,] cartesian3_;

        public double[,] Cartesian3 { get => cartesian3_; set => cartesian3_ = value; }

        public InternalCoordinate2Cartesian(ZMatrix zMatrix)
        {
            this._zMatrix = zMatrix;
            if (zMatrix.atomicNumbers != null)
            {
                n = zMatrix.atomicNumbers.Length;
            }
            else
            {
                n = 0;
            }

            Cartesian3 = new double[n, 3];
            GenerateCartesian3(ref cartesian3_);
        }


        private void GenerateCartesian3(ref double[,] cartesian3)
        {
            double[,] B = new double[4, 4];
            int i, j;

            ///第0个原子
            cartesian3[0, 0] = 0.0;
            cartesian3[0, 1] = 0.0;
            cartesian3[0, 2] = 0.0;
            //第1个原子
            try
            {
                if (n > 1)
                {
                    cartesian3[1, 0] = 0.0;
                    cartesian3[1, 1] = 0.0;
                    cartesian3[1, 2] = _zMatrix.connectionInfoValue[1, 0];
                }
            }
            catch
            {
                throw new Geometry_Exception("zMatrix Error, site: Line" + "2");
            }
            //第2个原子
            try
            {
                if (n > 2)
                {
                    if (_zMatrix.connectionInfo[2, 0] == 1)
                    {
                        cartesian3[2, 0] = _zMatrix.connectionInfoValue[2, 0] * Math.Sin(Math.PI * _zMatrix.connectionInfoValue[2, 1] / 180.0);
                        cartesian3[2, 1] = 0.0;
                        cartesian3[2, 2] = _zMatrix.connectionInfoValue[1, 0] - _zMatrix.connectionInfoValue[2, 0] * Math.Cos(Math.PI * _zMatrix.connectionInfoValue[2, 1] / 180.0);
                    }
                    if (_zMatrix.connectionInfo[2, 0] == 0)
                    {
                        cartesian3[2, 0] = _zMatrix.connectionInfoValue[2, 0] * Math.Sin(Math.PI * _zMatrix.connectionInfoValue[2, 1] / 180.0);
                        cartesian3[2, 1] = 0.0;
                        cartesian3[2, 2] = _zMatrix.connectionInfoValue[2, 0] * Math.Cos(Math.PI * _zMatrix.connectionInfoValue[2, 1] / 180.0);
                    }
                }
            }
            catch
            {
                throw new Geometry_Exception("zMatrix Error, site: Line" + "3");
            }

            //第i(i>=3)个原子
            if (n > 3)
            {
                Vector vectorX = new Vector(3);
                Vector vectorY = new Vector(3);
                Vector vectorZ = new Vector(3);
                double[] arrayX = new double[3];
                double[] arrayY = new double[3];
                double[] arrayZ = new double[3];

                Matrix transformMatrix = new Matrix(3, 3);
                Vector currentCoordinate = new Vector(3);
                Matrix intermediateCoordinate = new Matrix(3, 1);


                for (i = 3; i < n; i++)
                {
                    try
                    {
                        //定义z轴向量
                        arrayZ = new double[3]
                        {
                    cartesian3[_zMatrix.connectionInfo[i,0],0] - cartesian3[_zMatrix.connectionInfo[i,1],0],
                    cartesian3[_zMatrix.connectionInfo[i,0],1] - cartesian3[_zMatrix.connectionInfo[i,1],1],
                    cartesian3[_zMatrix.connectionInfo[i,0],2] - cartesian3[_zMatrix.connectionInfo[i,1],2]
                        };
                        vectorZ = new Vector(arrayZ);
                        vectorZ.Normalize();

                        //定义y轴向量
                        arrayX = new double[3]
                        {
                    cartesian3[_zMatrix.connectionInfo[i,2],0] - cartesian3[_zMatrix.connectionInfo[i,1],0],
                    cartesian3[_zMatrix.connectionInfo[i,2],1] - cartesian3[_zMatrix.connectionInfo[i,1],1],
                    cartesian3[_zMatrix.connectionInfo[i,2],2] - cartesian3[_zMatrix.connectionInfo[i,1],2]
                        };
                        vectorX = new Vector(arrayX);
                        vectorY = CrossMultiplication(vectorZ, vectorX);
                        vectorY.Normalize();

                        //定义x轴向量
                        vectorX = CrossMultiplication(vectorY, vectorZ);
                        vectorX.Normalize();

                        for (j = 0; j < 3; j++)
                        {
                            transformMatrix[j, 0] = vectorX[j];
                            transformMatrix[j, 1] = vectorY[j];
                            transformMatrix[j, 2] = vectorZ[j];
                        }
                        currentCoordinate[0] = _zMatrix.connectionInfoValue[i, 0] * Math.Sin(Math.PI * _zMatrix.connectionInfoValue[i, 1] / 180.0) * Math.Cos(Math.PI * _zMatrix.connectionInfoValue[i, 2] / 180.0);
                        currentCoordinate[1] = _zMatrix.connectionInfoValue[i, 0] * Math.Sin(Math.PI * _zMatrix.connectionInfoValue[i, 1] / 180.0) * Math.Sin(Math.PI * _zMatrix.connectionInfoValue[i, 2] / 180.0);
                        currentCoordinate[2] = -_zMatrix.connectionInfoValue[i, 0] * Math.Cos(Math.PI * _zMatrix.connectionInfoValue[i, 1] / 180.0);

                        intermediateCoordinate = transformMatrix * (new Matrix(currentCoordinate.ele));

                        cartesian3[i, 0] = cartesian3[_zMatrix.connectionInfo[i, 0], 0] + intermediateCoordinate[0, 0];
                        cartesian3[i, 1] = cartesian3[_zMatrix.connectionInfo[i, 0], 1] + intermediateCoordinate[1, 0];
                        cartesian3[i, 2] = cartesian3[_zMatrix.connectionInfo[i, 0], 2] + intermediateCoordinate[2, 0];
                    }
                    catch
                    {
                        throw new Geometry_Exception("zMatrix Error, site: Line" + (i + 1).ToString());
                    }
                }
            }
        }

        private Vector CrossMultiplication(Vector v1, Vector v2)
        {
            if (v1.dim != 3 || v2.dim != 3)
            {
                throw new Exception("内坐标转换为笛卡尔坐标时，维数不对。");
            }
            Vector result = new Vector(3);

            result.ele[0] = v1.ele[1] * v2.ele[2] - v1.ele[2] * v2.ele[1];
            result.ele[1] = v1.ele[2] * v2.ele[0] - v1.ele[0] * v2.ele[2];
            result.ele[2] = v1.ele[0] * v2.ele[1] - v1.ele[1] * v2.ele[0];

            return result;
        }

        private Vector NormalizeVector(Vector v)
        {
            int n = v.dim;
            double sum = 0;
            Vector result = new Vector(n);

            for (int i = 0; i < n; i++)
            {
                sum += v.ele[i] * v.ele[i];
            }
            sum = Math.Sqrt(sum);

            for (int i = 0; i < n; i++)
            {
                result[i] = v.ele[i] / sum;
            }

            return result;
        }



    }
}
