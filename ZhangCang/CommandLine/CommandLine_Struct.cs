
using System;

namespace ZhangCang.CommandLine
{
    /// <summary>
    /// 命令行信息
    /// </summary>
    public struct CommandLineInformation
    {
        public string currentDirectory;                         //当前目录
        public string inputFileDirectory;                       //输入文件所在目录
        public string inputFileFullPath;                        //输入文件路径
        public string outputFileFullPath;                       //输出文件路径
        public string extensionName;                            //输入文件扩展名

        public void Initialize()
        {
            currentDirectory = String.Empty;
            inputFileFullPath = String.Empty;
            inputFileDirectory = String.Empty;
            outputFileFullPath = String.Empty;
            extensionName = String.Empty;
        }
    }
}
