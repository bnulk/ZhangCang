using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhangCang.Data.MolecularOrbitalTheoryData
{
    internal class MoData: Element
    {
        public MolecularOrbital molecularOrbital;
        public double? energy;
        public double[]? gradient;
        public double[,]? hessian;        

        public MoData(Element element)
        {
            molecularOrbital = new MolecularOrbital();
            this.control = element.control;
            this.keyword = element.keyword;
            this.zMatrix= element.zMatrix;
            this.molecule= element.molecule;
        }


    }
}
