using ZhangCang.FundamentalPara.BasisSet;

namespace ZhangCang.Data
{
    internal class InputData
    {
        /// <summary>
        /// 输入文件的类型
        /// </summary>
        public InputFileType inputFileType = InputFileType.ZhangCang;

        /// <summary>
        /// 关键词部分
        /// </summary>
        public Keyword keyword;

        /// <summary>
        /// 分子描述
        /// </summary>
        public Molecule molecule = new Molecule();

        /// <summary>
        /// 输入内坐标
        /// </summary>
        public ZMatrix zMatrix;

        /// <summary>
        /// 电子态信息
        /// </summary>
        public States states;


        #region 附加信息
        /// <summary>
        /// 收缩高斯基组列表信息
        /// </summary>
        public List<CgBasisSetStruct> listCgBasisSet= new List<CgBasisSetStruct>();
        #endregion

    }
}
