using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhangCang.Data
{
    internal class SinglePointData : Element
    {
        List<double> energy;
        List<double[]> gradient;
        List<double[,]> hessian;

        public SinglePointData(Element element)
        {
            this.control = element.control;
            this.keyword = element.keyword;
            this.molecule = element.molecule;
            this.zMatrix = element.zMatrix;

            energy = new List<double>();
            gradient = new List<double[]>();
            hessian = new List<double[,]>();
        }
    }
}
