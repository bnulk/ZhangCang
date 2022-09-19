using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhangCang.LinearAlgebra;

namespace ZhangCang.MolecularGeometryAnalysis
{
    struct MGA
    {
        /// <summary>
        /// 距离矩阵
        /// </summary>
        public double[,] distanceMatrix;
        /// <summary>
        /// 质心
        /// </summary>
        public double[] massCenter;
        /// <summary>
        /// 惯量张量
        /// </summary>
        public Matrix inertiaTensor;
        /// <summary>
        /// 主转动惯量
        /// </summary>
        public Vector principalMomentsOfInertia;
        /// <summary>
        /// 惯量主轴矩阵
        /// </summary>
        public Matrix inertiaPrincipalAxisMatrix;
        /// <summary>
        /// 转子分类
        /// </summary>
        public RotorClassify rotorClassify;
        /// <summary>
        /// 转动常数
        /// </summary>
        public Vector rotationalConstants_GHz;

        public MGA()
        {
            distanceMatrix = new double[0, 0];
            massCenter = new double[3];
            inertiaTensor = new Matrix(3, 3);
            principalMomentsOfInertia = new Vector(3);
            inertiaPrincipalAxisMatrix = new Matrix(3, 3);
            rotorClassify = new RotorClassify();
            rotationalConstants_GHz = new Vector(3);
        }
    }
}
