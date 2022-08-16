using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
