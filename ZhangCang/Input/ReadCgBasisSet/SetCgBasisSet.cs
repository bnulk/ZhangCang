using ZhangCang.FundamentalPara.BasisSet;

namespace ZhangCang.Input.ReadCgBasisSet
{
    internal class SetCgBasisSet
    {
        private string _name = "sto-3g";
        private List<string> _listStringAboutCgBasisSet= new List<string>();

        private CgBasisSetStruct cgBasisSetStruct_;

        internal CgBasisSetStruct CgBasisSetStruct_ { get => cgBasisSetStruct_; set => cgBasisSetStruct_ = value; }


        public SetCgBasisSet(string _name)
        {
            this._name = _name;
        }

        public SetCgBasisSet(string _name, List<string> _listStringAboutCgBasisSet)
        {
            this._name= _name;
            this._listStringAboutCgBasisSet = _listStringAboutCgBasisSet;
        }

        public void Run()
        {
            if(_name.ToLower()!="gen" && _name.ToLower()!="genecp") 
            {
                ObtainBasisSetAccordingToName();
            }
            else
            {

            }
        }

        private void ObtainBasisSetAccordingToName()
        {

        }


    }
}
