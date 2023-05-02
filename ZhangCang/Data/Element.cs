using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhangCang.FundamentalPara.BasisSet;

namespace ZhangCang.Data
{
    internal class Element
    {
        /// <summary>
        /// 控制部分
        /// </summary>
        public Control control;
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
        /// 收缩高斯基组列表信息
        /// </summary>
        public List<CgBasisSetStruct> listCgBasisSet = new List<CgBasisSetStruct>();

        public Element()
        {
            
        }
    }
}
