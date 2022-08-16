

using System.IO;

namespace ZhangCang.CommandLine
{
    internal class SingleArgsAnalyser_FilePath
    {
        /// <summary>
        /// 命令行参数
        /// </summary>
        private string arg;

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
        /// <param name="arg"></param>
        public SingleArgsAnalyser_FilePath(string arg)
        {
            this.arg = arg;
        }

        public void Run()
        {
            ObtainCurrentDirectory();
            ObtainInputFileFullPath();
            ObtainOutputFileFullPath();
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
        private void ObtainInputFileFullPath()
        {
            if (File.Exists(arg))
            {
                if (Path.IsPathRooted(arg))
                {
                    commandLineInformation.inputFileFullPath = arg;
                }
                else
                {
                    commandLineInformation.inputFileFullPath = Path.Combine(commandLineInformation.currentDirectory, arg);
                }
                //获取输入文件所在的目录
                commandLineInformation.inputFileDirectory = Path.GetDirectoryName(commandLineInformation.inputFileFullPath);
            }
            else
            {
                throw new CommandLine_Exception("ZhangCang.CommandLine.Analyser.SingleArgsAnalyser_FilePath.ObtainInputFileFullPath() Error, Input file does not exist.");
            }
            return;
        }

        /// <summary>
        /// 获取输出文件的绝对路径
        /// </summary>
        private void ObtainOutputFileFullPath()
        {
            commandLineInformation.outputFileFullPath = Path.ChangeExtension(commandLineInformation.inputFileFullPath, "kun");
        }

        /// <summary>
        /// 获取输入文件的目录
        /// </summary>
        private void ObtainInputFileDirectory()
        {
            commandLineInformation.inputFileDirectory= Path.GetDirectoryName(commandLineInformation.inputFileFullPath);
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
