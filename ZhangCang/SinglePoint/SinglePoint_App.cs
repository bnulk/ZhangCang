using ZhangCang.Data;
using ZhangCang.ElectronStructure;

namespace ZhangCang.SinglePoint
{
    internal class SinglePoint_App
    {
        /*
        ----------------------------------------------------  类注释  开始----------------------------------------------------
        版本：  V1.0
        作者：  刘鲲
        日期：  2022-11-05

        描述：
            * 本类做分子的单点计算。
            * 本类的输出对象是****
            * （1）****
            * （2）****
        ----------------------------------------------------  类注释  结束----------------------------------------------------
        */

        private Element _element;
        private SinglePointData singlePointData;


        public SinglePoint_App(Element element)
        {
            this._element= new SinglePointData(element);
            singlePointData= new SinglePointData(element);
        }

        public void Run()
        {
            CalculateSinglePointBasedOnMethods();
        }
        

        private void CalculateSinglePointBasedOnMethods()
        {
            int n = _element.keyword.methods.Length;
            for(int i=0; i < n; i++)
            {
                OneMethod(_element.keyword.methods[i], _element);
            }
        }

        private void OneMethod(Method method, Element element)
        {
            switch(method)
            {
                case Method.HF:
                    ElectronStructure.HF.Hf_App hf = new ElectronStructure.HF.Hf_App(element);
                    hf.Run();
                    break;
                default:
                    break;
            }
        }

    }
}
