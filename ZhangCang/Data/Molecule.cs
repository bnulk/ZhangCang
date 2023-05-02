
namespace ZhangCang
{
    partial class Molecule
    {
        /// <summary>
        /// 原子个数
        /// </summary>
        public int numberOfAtoms;
        /// <summary>
        /// 原子序号（核电荷数）数组
        /// </summary>
        public int[]? atomicNumbers;
        /// <summary>
        /// 原子量数组
        /// </summary>
        public double[]? realAtomicWeights;
        /// <summary>
        /// 笛卡尔坐标数组
        /// </summary>
        public double[,]? cartesian3;
        /// <summary>
        /// 电荷
        /// </summary>
        public int charge;
        /// <summary>
        /// 自旋多重度
        /// </summary>
        public int multiplicity;
    }
}
