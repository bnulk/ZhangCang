using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhangCang.FundamentalPara.BasisSet
{
    struct CgBasisSetStruct
    {
        public BasisSetName name;
        public int numberOfSto;
        public List<CgSto> stosForAtom;
    }

    struct CgSto
    {
        /// <summary>
        /// STO类型
        /// </summary>
        public StoType stoType;
        /// <summary>
        /// 角动量
        /// </summary>
        public int l, m, n;
        /// <summary>
        /// Slater指数
        /// </summary>
        public double zeta;
        /// <summary>
        /// 包含GTO个数
        /// </summary>
        public int numberOfGto;

        public List<CgGto> gtoForSto;
    }

    struct CgGto
    {
        public double exponential;
        public double coefficient;
    }


}
