

using System.Collections.Generic;

namespace ZhangCang.Data
{
    /// <summary>
    /// 高斯程序的输入文件包
    /// </summary>
    public struct GaussianInputPackage
    {
        /// <summary>
        /// 原子个数
        /// </summary>
        public int numberOfAtom;
        public CoordinateType coordinateType;
        public List<string> firstSection;
        public List<string> routeSection;
        public List<string> titleSection;
        public List<int> chargeAndMultiplicity;
        public List<string> molecularSpecification_ZMatrix;
        public List<string> molecularPara_ZMatrix;
        public List<string> molecularCartesian;
        public List<double> molecularVariable;
        public List<string> addition;

        public GaussianInputPackage()
        {
            numberOfAtom = 0;
            coordinateType = CoordinateType.unknown;
            firstSection = new List<string>();
            routeSection = new List<string>();
            titleSection = new List<string>();
            chargeAndMultiplicity = new List<int>();
            molecularSpecification_ZMatrix = new List<string>();
            molecularPara_ZMatrix = new List<string>();
            molecularCartesian = new List<string>();
            molecularVariable = new List<double>();
            addition = new List<string>();
        }
    }
}
