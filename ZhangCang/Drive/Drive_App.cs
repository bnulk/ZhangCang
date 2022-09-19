using ZhangCang.Data;
using ZhangCang.MolecularGeometryAnalysis;

namespace ZhangCang.Drive
{
    internal class Drive_App
    {
        private Element _element;


        public Drive_App(Element element)
        {
            this._element = element;
        }

        public void Run()
        {
            //分子结构分析
            MolecularGeometryAnalysis_App mga = new MolecularGeometryAnalysis_App(ref _element.molecule, _element.control.outputFileFullPath);
            mga.Run();
        }



    }
}
