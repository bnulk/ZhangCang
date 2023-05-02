using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhangCang.Data;
using ZhangCang.Data.MolecularOrbitalTheoryData;
using ZhangCang.FundamentalPara;
using ZhangCang.FundamentalPara.BasisSet;

namespace ZhangCang.ElectronStructure.HF
{
    internal class Hf_App
    {
        private MoData moData;


        public Hf_App(Element element)
        {
            moData = new MoData(element);
        }

        public void Run()
        {
            //初始化分子轨道信息
            Step1_Initalize initalize= new Step1_Initalize(moData);
            initalize.Run();

        }



    }
}
