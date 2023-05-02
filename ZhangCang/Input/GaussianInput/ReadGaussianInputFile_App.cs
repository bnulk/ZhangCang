using System.Collections.Generic;
using ZhangCang.Data;
using ZhangCang.FundamentalConstants;
using ZhangCang.Geometry;

namespace ZhangCang.Input.GaussianInput
{
    internal class ReadGaussianInputFile_App
    {
        List<string> _inputList = new List<string>();

        InputDataGaussian inputDataGaussian_= new InputDataGaussian();

        public ReadGaussianInputFile_App(List<string> inputList)
        {
            this._inputList = inputList;
            inputDataGaussian_.inputFileType = InputFileType.Gaussian;
        }

        internal InputDataGaussian InputDataGaussian_ { get => inputDataGaussian_; set => inputDataGaussian_ = value; }

        public void Run()
        {
            //把输入列表转换成GaussianInputPackage，把张苍程序中的关键词字符串提取到zhangCangKeyword
            string zhangCangKeyword;
            InputList2GaussianInputPackage i2G_App = new InputList2GaussianInputPackage(_inputList);
            i2G_App.Run();
            inputDataGaussian_.gaussianInputPackage = i2G_App.GaussianInputPackage_;                                 //inputDataGaussian_完成1/4；gaussianInputPackage
            zhangCangKeyword = i2G_App.StrKeyword_;

            //处理张苍关键词
            ReadKeyword.ReadGeneralKeyword rGK = new ReadKeyword.ReadGeneralKeyword(zhangCangKeyword);
            rGK.Run();
            inputDataGaussian_.keyword = rGK.Keyword;                                                                //inputDataGaussian_完成2/4；keyword

            //读内坐标
            ReadInternalCoordinates readInternalCoordinates = new ReadInternalCoordinates(inputDataGaussian_.gaussianInputPackage);
            readInternalCoordinates.Run();
            inputDataGaussian_.zMatrix = readInternalCoordinates.ZMatrix_;                                                             //inputDataGaussian_完成3/4；zMatrix
            //读笛卡尔坐标
            ReadCartesianCoordinates readCartesianCoordinates = new ReadCartesianCoordinates(inputDataGaussian_.gaussianInputPackage);
            readCartesianCoordinates.Run();
            inputDataGaussian_.molecule.atomicNumbers = readCartesianCoordinates.AtomicNumbers_;
            inputDataGaussian_.molecule.numberOfAtoms = inputDataGaussian_.molecule.atomicNumbers.Length;
            inputDataGaussian_.molecule.cartesian3 = readCartesianCoordinates.Cartesian3_;
            
            //内坐标转换为笛卡尔坐标，填入Molecule结构中
            if(inputDataGaussian_.zMatrix.isExist==true)
            {                
                inputDataGaussian_.molecule.atomicNumbers = inputDataGaussian_.zMatrix.atomicNumbers;
                if(inputDataGaussian_.molecule.atomicNumbers!=null)
                {
                    inputDataGaussian_.molecule.numberOfAtoms = inputDataGaussian_.molecule.atomicNumbers.Length;
                }
                InternalCoordinate2Cartesian toCartesian = new InternalCoordinate2Cartesian(inputDataGaussian_.zMatrix);
                inputDataGaussian_.molecule.cartesian3 = toCartesian.Cartesian3;
            }

            //读电荷和自旋多重度，填入States结构中
            if (inputDataGaussian_.gaussianInputPackage.chargeAndMultiplicity.Count>=2)
            {
                int cycleMultiplicity = inputDataGaussian_.gaussianInputPackage.chargeAndMultiplicity.Count - 1;
                inputDataGaussian_.states.charge = new int[cycleMultiplicity];
                inputDataGaussian_.states.multiplicity = new int[cycleMultiplicity];
                inputDataGaussian_.states.strMethod= new string[cycleMultiplicity];

                if (inputDataGaussian_.keyword.strMethods.Length==cycleMultiplicity)
                {
                    for (int i = 0; i < cycleMultiplicity; i++)
                    {
                        inputDataGaussian_.states.charge[i] = inputDataGaussian_.gaussianInputPackage.chargeAndMultiplicity[0];
                        inputDataGaussian_.states.multiplicity[i] = inputDataGaussian_.gaussianInputPackage.chargeAndMultiplicity[i + 1];
                        inputDataGaussian_.states.strMethod[i]= inputDataGaussian_.keyword.strMethods[i];
                    }
                }
                else
                {
                    throw new Input_Exception("charge&multiplicity and number of Methods are inconsistent.");
                }
            }
            else
            {
                throw new Input_Exception("charge and multiplicity Error.");
            }

            //根据核电荷数数组，填写原子量数组。
            Atoms atoms = new Atoms();
            inputDataGaussian_.molecule.realAtomicWeights= new double[inputDataGaussian_.molecule.numberOfAtoms];
            if(inputDataGaussian_.molecule.atomicNumbers!=null)
            {
                for (int i = 0; i < inputDataGaussian_.molecule.numberOfAtoms; i++)
                {
                    inputDataGaussian_.molecule.realAtomicWeights[i] = atoms.NumberToMass(inputDataGaussian_.molecule.atomicNumbers[i]);          
                }
            }                                                                                                                                      //inputDataGaussian_完成4/4；molecule

            //附加部分
            DisposeAdditionSection disposeAdditionSection = new DisposeAdditionSection(inputDataGaussian_.keyword, inputDataGaussian_.gaussianInputPackage.addition);
            disposeAdditionSection.Run();


        }


    }
}
