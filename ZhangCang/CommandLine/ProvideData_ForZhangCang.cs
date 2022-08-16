using System;

namespace ZhangCang.CommandLine
{
    internal class ProvideData_ForZhangCang
    {
        CommandLineInformation commandLineInformation;

        Control control;

        public Control Control { get => control; set => control = value; }

        public ProvideData_ForZhangCang(CommandLineInformation commandLineInformation)
        {
            this.commandLineInformation = commandLineInformation;
        }

        public void Run()
        {
            control.inputFileFullPath = commandLineInformation.inputFileFullPath;
            control.outputFileFullPath = commandLineInformation.outputFileFullPath;
            control.inputFileDirectory = commandLineInformation.inputFileDirectory;
            control.currentDirectory = commandLineInformation.currentDirectory;
            control.inputFileType = DetermineInputFileTypeBasedOnTheExtension(commandLineInformation.extensionName);
            control.os = ObtianOSName();
        }

        /// <summary>
        /// 根据文件的扩展名，推测输入文件类型
        /// </summary>
        /// <param name="extension">扩展名</param>
        /// <returns>输入文件类型</returns>
        public static InputFileType DetermineInputFileTypeBasedOnTheExtension(string extension)
        {
            if (string.IsNullOrEmpty(extension))
            {
                return InputFileType.unknown;
            }
            switch (extension)
            {
                case "gjf":
                    return InputFileType.Gaussian;
                case "liu":
                    return InputFileType.ZhangCang;
                default:
                    return InputFileType.unknown;
            }
        }

        /// <summary>
        /// 获取操作系统信息。OS_Name是"linux",或者"windows".
        /// </summary>
        public static OS ObtianOSName()
        {
            OS tmpOsInfo = OS.Linux;
            string str;
            int indexMark;
            str = Environment.OSVersion.VersionString.ToLower();
            indexMark = str.IndexOf("win");
            if (indexMark != -1)
            {
                tmpOsInfo = OS.Windows;
            }
            return tmpOsInfo;
        }

    }
}
