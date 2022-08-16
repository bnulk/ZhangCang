using System;

namespace ZhangCang.CommandLine
{
    //注意：用到了静态类ZhangCangInfo。

    internal class HelpOptionDisposer_ZhangCang
    {
        private HelpOptionType helpOptionType;
        public HelpOptionDisposer_ZhangCang(HelpOptionType helpOptionType)
        {
            this.helpOptionType = helpOptionType;
        }

        /// <summary>
        /// 运行帮助处理器
        /// </summary>
        public void Run()
        {
            switch (helpOptionType)
            {
                case HelpOptionType.none:
                    break;
                case HelpOptionType.about:
                    About();
                    break;
                case HelpOptionType.help:
                    Help();
                    break;
                case HelpOptionType.unknown:
                    Unknown();
                    break;
                default:
                    Unknown();
                    break;
            }
        }

        /// <summary>
        /// 关于程序
        /// </summary>
        private void About()
        {

            Console.WriteLine("\n");
            Console.WriteLine("\n" + "ZhangCang " + ZhangCangInfo.GlobalVariable.programVersion + "\n");
            Console.WriteLine("\n" + "Author Information: Liu Kun, College of Chemistry, Tianjin Normal University, Tianjin 300387, China" + "\n");
            Console.WriteLine("\n" + "Email: bnulk@foxmail.com" + "\n");
            Console.WriteLine("\n" + "You can obtain the newest version of the program from the authors." + "\n");
            Console.WriteLine("\n" + "Program code can be downloaded from https://github.com/bnulk" + "\n");
            return;
        }

        /// <summary>
        /// 帮助信息
        /// </summary>
        private void Help()
        {
            Console.WriteLine("\n" + "Usage: ZhangCang inputFileName [outputFileName] [parameter]" + "\n");
            Console.WriteLine("\n" + "-a, --about".PadRight(30) + "program infomation" + "\n");
            Console.WriteLine("\n" + "-h, --help".PadRight(30) + "help infomation" + "\n");
            return;
        }

        /// <summary>
        /// 未知输入
        /// </summary>
        private void Unknown()
        {
            Console.WriteLine("\n" + "unknown help option." + "\n");
            Console.WriteLine("\n" + "help command: -h|--help" + "\n");
            return;
        }
    }
}
