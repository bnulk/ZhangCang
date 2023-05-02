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

            //根据关键词进行计算分类
            switch(_element.keyword.task)
            {
                case Task.sp:
                    SinglePoint.SinglePoint_App spApp = new SinglePoint.SinglePoint_App(_element);
                    spApp.Run();
                    break;
                case Task.min:
                    break;
                case Task.ts:
                    break;
                case Task.mecp:
                    break;
                default:
                    break;
            }
        }



    }
}
