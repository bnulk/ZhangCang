using ZhangCang.LinearAlgebra;

namespace ZhangCang.MolecularGeometryAnalysis
{
    internal class Vector3D
    {
        /*
        ----------------------------------------------------  类注释  开始----------------------------------------------------
        版本：  V1.0
        作者：  刘鲲
        日期：  2018-07-26

        描述：
            * 3维空间点类
        结构：
            * x 坐标x
            * y 坐标y
            * z 坐标z
        方法：
            * = 向量相等
                注意该方法不需要自行编写重载函数，
                c#已经实现了对类的等号运算符重载，
                并禁止用户编写等号（=）重载函数
            * + 两向量对应元素相加
            * - 两向量对应元素相减
            * * 两向量对应元素相乘
            * / 两向量对应元素相除
            * 
            * + 重载向量加一实数（所有元素）
            * - 重载向量减一实数（所有元素）
            * * 重载向量乘一实数（所有元素）
            * / 重载向量除一实数（所有元素）
            * 
            * + 重载实数加向量（所有元素）
            * - 重载实数减向量（所有元素）
            * * 重载实数乘以向量（所有元素）
            * / <无> 不重载 <即不能用实数除以向量>
            * 
            * | （VEC1|VEC2） 标量积
            * ~ （~VEC1） 向量2范数的平方
            * - （-VEC1） 向量取负
            * ^ （VEC1^VEC2） 向量积
        ----------------------------------------------------  类注释  结束----------------------------------------------------
    */

        public double x, y, z;

        #region 构造函数

        /// <summary>
        /// 三维向量构造函数
        /// </summary>
        public Vector3D()
        {
            x = 0.0;
            y = 0.0;
            z = 0.0;
        }
        /// <summary>
        /// 三维向量构造函数
        /// </summary>
        /// <param name="v">有三个分量的一维数组</param>
        public Vector3D(double[] v)
        {
            if (v.Length != 3)
            {
                throw new IndexOutOfRangeException("向量维数不为3。");
            }
            x = v[0];
            y = v[1];
            z = v[2];
        }

        /// <summary>
        /// 三维向量构造函数
        /// </summary>
        /// <param name="x">第一个分量</param>
        /// <param name="y">第二个分量</param>
        /// <param name="z">第三个分量</param>
        public Vector3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// 三维向量构造函数
        /// </summary>
        /// <param name="p1">第一个点</param>
        /// <param name="p2">第二个点</param>
        public Vector3D(Vector3D p1, Vector3D p2)
        {
            this.x = p2.x - p1.x;
            this.y = p2.y - p1.y;
            this.z = p2.z - p1.z;
        }
        #endregion 构造函数

        /// <summary>
        /// 向量加法重载
        /// 分量分别相加
        /// </summary>
        /// <param name="v1">第一个向量</param>
        /// <param name="v2">第二个向量</param>
        /// <returns>两个向量之和</returns>
        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            Vector3D v3 = new Vector3D(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
            return v3;
        }

        /// <summary>
        /// 向量减法重载
        /// 分量分别相减
        /// </summary>
        /// <param name="v1">第一个向量</param>
        /// <param name="v2">第二个向量</param>
        /// <returns>两个向量之差</returns>
        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            Vector3D v3 = new Vector3D(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
            return v3;
        }

        /// <summary>
        /// 向量数乘
        /// 分量分别乘以实数
        /// </summary>
        /// <param name="v1">向量</param>
        /// <param name="a">乘数</param>
        /// <returns>向量数乘之积</returns>
        public static Vector3D operator *(Vector3D v1, double a)
        {
            Vector3D v2 = new Vector3D(a * v1.x, a * v1.y, a * v1.z);
            return v2;
        }

        /// <summary>
        /// 向量数乘
        /// 分量分别乘以实数
        /// </summary>
        /// <param name="a">乘数</param>
        /// <param name="v1">向量</param>
        /// <returns>向量数乘之积</returns>
        public static Vector3D operator *(double a, Vector3D v1)
        {
            Vector3D v2 = new Vector3D(a * v1.x, a * v1.y, a * v1.z);
            return v2;
        }

        /// <summary>
        /// 向量数除
        /// 分量分别除以实数
        /// </summary>
        /// <param name="v1">向量</param>
        /// <param name="a">除数</param>
        /// <returns>向量数除之商</returns>
        public static Vector3D operator /(Vector3D v1, double a)
        {
            Vector3D v2 = new Vector3D(v1.x / a, v1.y / a, v1.z / a);
            return v2;
        }

        /// <summary>
        /// 标量积
        /// </summary>
        /// <param name="v1">第一个向量</param>
        /// <param name="v2">第二个向量</param>
        /// <returns>两个向量的标量积</returns>
        public static double operator |(Vector3D v1, Vector3D v2)
        {
            double dotMul = 0.0;

            dotMul = v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;

            return dotMul;
        }

        /// <summary>
        /// 向量积
        /// </summary>
        /// <param name="v1">第一个向量</param>
        /// <param name="v2">第二个向量</param>
        /// <returns>两个向量的向量积</returns>
        public static Vector3D operator ^(Vector3D v1, Vector3D v2)
        {
            Vector3D v3 = new Vector3D(v1.y * v2.z - v1.z * v2.y, v1.z * v2.x - v1.x * v2.z, v1.x * v2.y - v1.y * v2.x);
            return v3;
        }

        /// <summary>
        /// 负向量
        /// </summary>
        /// <param name="v1">向量</param>
        /// <returns>该向量的负向量</returns>
        public static Vector3D operator -(Vector3D v1)
        {
            Vector3D v2 = new Vector3D(-v1.x, -v1.y, -v1.z);
            return v2;
        }

        /// <summary>
        /// 向量长度
        /// </summary>
        /// <returns>向量长度</returns>
        public double Length()
        {
            double length = Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
            return length;
        }

        /// <summary>
        /// 计算单位向量
        /// </summary>
        /// <returns>单位向量</returns>
        public Vector3D Unit()
        {
            Vector3D unit = new Vector3D();
            unit.x = this.x / this.Length();
            unit.y = this.y / this.Length();
            unit.z = this.z / this.Length();
            return unit;
        }

        /// <summary>
        /// 旋转向量
        /// </summary>
        /// <param name="Oper">3×3旋转矩阵</param>
        /// <param name="point">点</param>
        /// <returns>旋转后的向量</returns>
        public static Vector3D Rotation(Matrix Oper, Vector3D point)
        {
            Vector3D tmpVector3D = new Vector3D();
            tmpVector3D.x = Oper[0, 0] * point.x + Oper[0, 1] * point.y + Oper[0, 2] * point.z;
            tmpVector3D.y = Oper[1, 0] * point.x + Oper[1, 1] * point.y + Oper[1, 2] * point.z;
            tmpVector3D.z = Oper[2, 0] * point.x + Oper[2, 1] * point.y + Oper[2, 2] * point.z;
            return tmpVector3D;
        }
    }
}
