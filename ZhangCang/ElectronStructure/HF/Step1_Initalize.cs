
using ZhangCang.Data.MolecularOrbitalTheoryData;
using ZhangCang.FundamentalPara.BasisSet;
using ZhangCang.FundamentalPara.BasisSet.ContractedGto;

namespace ZhangCang.ElectronStructure.HF
{
    internal partial class Step1_Initalize
    {
        /*
        ----------------------------------------------------  类注释  开始----------------------------------------------------
        版本：  V1.0
        作者：  刘鲲
        日期：  2022-11-21

        描述：
            * 初始化分子轨道信息。包括一组原子序数，一组核坐标，一组原子核质量，一套基组，以及电子总数。
            * 初始化信息在moData.molecularOrbital.initialInfo结构中
        ----------------------------------------------------  类注释  结束----------------------------------------------------
        */


        private MoData moData;
        private List<CgBasisSetStruct> listCgBasisSet = new List<CgBasisSetStruct>();


        private BasicInfo basicInfo;
        internal BasicInfo BasicInfo { get => basicInfo; set => basicInfo = value; }


        public Step1_Initalize(MoData moData)
        {
            this.moData = moData;
        }

        

        public void Run()
        {
            //电子个数
            basicInfo.numberOfElectrons = GetNumberOfElectrons();
            //原子核总个数
            basicInfo.numberOfNucleus = moData.molecule.numberOfAtoms;
            //对称操作总个数
            basicInfo.numberOfSymmetryElement = 0;
            //获取原子数组
            ObtainAtoms(ref basicInfo.listAtom);
            //获取基组
            ObtainBasisSet();
        }


        /// <summary>
        /// 获取电子个数
        /// </summary>
        /// <returns>电子个数</returns>
        private int GetNumberOfElectrons()
        {
            int numberOfElectrons = 0;
            if (moData.molecule.atomicNumbers == null)
            {
                return -1;
            }
            else
            {
                int cycle = moData.molecule.atomicNumbers.Length;
                for (int i = 0; i < cycle; i++)
                {
                    numberOfElectrons += moData.molecule.atomicNumbers[i];
                }

                numberOfElectrons += moData.molecule.charge;

                return numberOfElectrons;
            }
        }

        /// <summary>
        /// 获取原子数组
        /// </summary>
        /// <param name="atoms">原子数组</param>
        private void ObtainAtoms(ref List<Atom> listAtom)
        {
            int cycle = basicInfo.numberOfNucleus;
            Atom atom = new Atom();
            basicInfo.listAtom = new List<Atom>();

            for (int i = 0; i < cycle; i++)
            {
                atom.atomLabel = i;
                if (moData.molecule.atomicNumbers != null)
                {
                    atom.atomicNumber = moData.molecule.atomicNumbers[i];
                }
                else
                {
                    atom.atomicNumber = -1;
                }

                //atom.basisSetName = moData.keyword.basisSetName;
                atom.numberOfSto = 0;

                if (moData.molecule.cartesian3 != null)
                {
                    atom.x = moData.molecule.cartesian3[i, 0];
                    atom.y = moData.molecule.cartesian3[i, 1];
                    atom.z = moData.molecule.cartesian3[i, 2];
                }
                else
                {
                    atom.x = -1;
                    atom.y = -1;
                    atom.z = -1;
                }
                basicInfo.listAtom.Add(atom);
            }
        }
        
        /// <summary>
        /// 获取基组
        /// </summary>
        private void ObtainBasisSet()
        {
            int atomCycle = basicInfo.listAtom.Count;
            int stoCycle = 0;
            int gtoCycle = 0;
            Sto sto= new Sto();
            Gto gto= new Gto();
            basicInfo.listSto = new List<Sto>();
            basicInfo.listGto = new List<Gto>();
            int stoLabel = 0;                                            //sto在整个分子中的标号
            int gtoLabel = 0;                                            //gto在整个分子中的标号

            //基组
            CgBasisSet cgBasisSet = new CgBasisSet();
            switch (moData.keyword.basisSetName)
            {
                case BasisSetName.cgSto3g:
                    cgBasisSet = new CgSto3g();
                    break;
                case BasisSetName.cg321g:
                    cgBasisSet = new Cg321g();
                    break;
                case BasisSetName.gen:
                    break;
                default:
                    cgBasisSet = new CgSto3g();
                    break;
            }


            int i = 0, j = 0, k = 0;


            for(i=0; i<atomCycle; i++)                                                           //原子标号 
            {
                stoCycle = cgBasisSet.CgBasisSets[sto.atomLabel].numberOfSto;                    //每个原子中的STO数目
                
                for(j=0;j<stoCycle;j++)                                                          //STO
                {
                    sto.atomLabel = basicInfo.listAtom[i].atomLabel;
                    sto.stoLabel = stoLabel;
                    stoLabel++;
                    sto.stoType = cgBasisSet.CgBasisSets[sto.atomLabel].stosForAtom[j].stoType;
                    sto.zeta = cgBasisSet.CgBasisSets[sto.atomLabel].stosForAtom[j].zeta;
                    sto.numberOfGto = cgBasisSet.CgBasisSets[sto.atomLabel].stosForAtom[j].numberOfGto;


                    sto.accumulatedNumberOfGto = 0;

                    basicInfo.listSto.Add(sto);

                    //gtoCycle=
                    for(k=0;k<gtoCycle;k++)                                                     //GTO
                    {

                    }
                }


            }
        }





    }
}
