

using System.IO;

namespace ZhangCang.CommandLine
{
    internal class DoubleArgsAnalyser
    {
        /// <summary>
        /// 第一个参数
        /// </summary>
        private string arg0;
        /// <summary>
        /// 第二个参数
        /// </summary>
        private string arg1;

        /// <summary>
        /// 命令行信息
        /// </summary>
        private CommandLineInformation commandLineInformation;
        /// <summary>
        /// 命令行信息
        /// </summary>
        public CommandLineInformation CommandLineInformation { get => commandLineInformation; set => commandLineInformation = value; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="args"></param>
        public DoubleArgsAnalyser(string[] args)
        {
            this.arg0 = args[0];
            this.arg1 = args[1];
        }

        /// <summary>
        /// 运行双参数分析器
        /// </summary>
        public void Run()
        {
            ObtainCurrentDirectory();
            ObtainInputFileFullName();
            ObtainOutputFileFullName();
            ObtainInputFileDirectory();
            ObtainInputFileExtensionName();
        }

        /// <summary>
        /// 获取当前目录
        /// </summary>
        private void ObtainCurrentDirectory()
        {
            commandLineInformation.currentDirectory = Directory.GetCurrentDirectory();
            return;
        }

        /// <summary>
        /// 获取输入文件的绝对路径
        /// </summary>
        private void ObtainInputFileFullName()
        {
            if (File.Exists(arg0))
            {
                if (Path.IsPathRooted(arg0))
                {
                    commandLineInformation.inputFileFullPath = arg0;
                }
                else
                {
                    commandLineInformation.inputFileFullPath = Path.Combine(commandLineInformation.currentDirectory, arg0);
                }
                //获取输入文件所在的目录
                commandLineInformation.inputFileDirectory = Path.GetDirectoryName(commandLineInformation.inputFileFullPath);
            }
            else
            {
                throw new CommandLine_Exception("ZhangCang.CommandLine.Analyser.DoubleArgsAnalyser.ObtainInputFileFullPath() Error, Input file does not exist.");
            }
        }

        /// <summary>
        /// 获取输出文件的绝对路径
        /// </summary>
        private void ObtainOutputFileFullName()
        {
            if (IsValidFilePath(arg1))
            {
                if (Path.GetExtension(arg1).ToLower() != "kun")
                {
                    throw new CommandLine_Exception("ZhangCang.CommandLine.Analyser.DoubleArgsAnalyser.ObtainOutputFileFullName() Error, The extension of the output file must be \" kun \"");
                }
            }
            else
            {
                throw new CommandLine_Exception("ZhangCang.CommandLine.Analyser.DoubleArgsAnalyser.ObtainOutputFileFullName() Error, Invalid Output File Path.");
            }

            if (Path.IsPathRooted(arg1))
            {
                commandLineInformation.outputFileFullPath = arg1;
            }
            else
            {
                commandLineInformation.outputFileFullPath = Path.Combine(commandLineInformation.currentDirectory, arg1);
            }
        }

        /// <summary>
        /// 文件路径是否合法
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private bool IsValidFilePath(string filePath)
        {
            bool isValidFileName = false;
            if (filePath.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0)
            {
                isValidFileName = false;
            }
            else
            {
                isValidFileName = true;
            }
            return isValidFileName;
        }

        /// <summary>
        /// 获取输入文件的目录
        /// </summary>
        private void ObtainInputFileDirectory()
        {
            commandLineInformation.inputFileDirectory = Path.GetDirectoryName(commandLineInformation.inputFileFullPath);
        }

        /// <summary>
        /// 获取输入文件的扩展名
        /// </summary>
        private void ObtainInputFileExtensionName()
        {
            commandLineInformation.extensionName = Path.GetExtension(commandLineInformation.inputFileFullPath);
            commandLineInformation.extensionName = commandLineInformation.extensionName.Remove(0, 1);
        }

    }
}
