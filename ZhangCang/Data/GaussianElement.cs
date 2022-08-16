using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhangCang.Data
{
    internal class GaussianElement : Element
    {
        GaussianInputPackage gaussianInputPackage;

        public GaussianElement(Element element)
        {
            this.control = element.control;
            this.keyword = element.keyword;
            this.molecule = element.molecule;
            this.zMatrix = element.zMatrix;
        }



    }
}
