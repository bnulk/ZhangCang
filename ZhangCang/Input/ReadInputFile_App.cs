using System.Collections.Generic;
using System.IO;
using ZhangCang.Data;

namespace ZhangCang.Input
{
    internal class ReadInputFile_App
    {
        Control _control;
        List<string> inputList = new List<string>();

        Data.InputData inputData_;
        private bool isRun;                                    //是否运行了本类

        public ReadInputFile_App(Control control)
        {
            this._control = control;
            inputData_ = new Data.InputData();
            isRun = false;
        }

        internal InputData InputData_ { get => inputData_; set => inputData_ = value; }

        /// <summary>
        /// 运行本类
        /// </summary>
        /// <exception cref="Input_Exception">未知的输入文件类型</exception>
        public void Run()
        {
            ObtainInputList();
            //根据输入文件类型分配相应驱动
            switch (_control.inputFileType)
            {
                case InputFileType.ZhangCang:
                    ZhangCangInput.ReadZhangCangInputFile_App appZhangCang = new ZhangCangInput.ReadZhangCangInputFile_App(inputList);
                    appZhangCang.Run();
                    inputData_ = appZhangCang.InputData;
                    isRun = true;
                    break;
                case InputFileType.Gaussian:
                    GaussianInput.ReadGaussianInputFile_App appGaussian = new GaussianInput.ReadGaussianInputFile_App(inputList);
                    appGaussian.Run();
                    inputData_ = appGaussian.InputDataGaussian_;
                    isRun = true;
                    break;
                default:
                    throw new Input_Exception("Unknow InputFile Type");
            }
            return;
        }

        /// <summary>
        /// 运行本类后，输出计算结果。
        /// </summary>
        public void WriteResult()
        {
            WriteInputFile_Text writeResult_Text = new WriteInputFile_Text(isRun, _control, inputData_);
            writeResult_Text.Run();
        }

        /// <summary>
        /// 获取输入列表
        /// </summary>
        private void ObtainInputList()
        {
            //打开输入文件
            if (File.Exists(_control.inputFileFullPath))
            {
                using (StreamReader reader = new StreamReader(new FileStream(_control.inputFileFullPath, FileMode.Open, FileAccess.Read, FileShare.Read)))
                {
                    string line = "";
                    inputList = new List<string>();
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine()!;
                        inputList.Add(line);
                    }
                    reader.Dispose();
                }
            }
        }


    }
}
