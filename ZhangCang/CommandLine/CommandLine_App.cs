
namespace ZhangCang.CommandLine
{
    internal class CommandLine_App
    {
        /// <summary>
        /// 命令行参数
        /// </summary>        
        private readonly string[]? args;


        /// <summary>
        /// 帮助信息的类型
        /// </summary>
        private HelpOptionType helpOptionType;

        /// <summary>
        /// 命令行信息
        /// </summary>
        private CommandLineInformation commandLineInformation;
        /// <summary>
        /// 命令行信息
        /// </summary>
        public CommandLineInformation CommandLineInformation { get => commandLineInformation; set => commandLineInformation = value; }
        public HelpOptionType HelpOptionType { get => helpOptionType; set => helpOptionType = value; }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="args">命令行参数</param>
        public CommandLine_App(string[] args)
        {
            this.args = (string[])args.Clone();
        }

        /// <summary>
        /// 处理命令行参数
        /// </summary>
        public void Run()
        {
            if (args == null)
            {
                ZeroArgsAnalyser zeroArgsAnalyser = new ZeroArgsAnalyser();
                commandLineInformation = zeroArgsAnalyser.CommandLineInformation;
            }
            else
            {
                int numberOfArgsValue = args.Length;
                switch (numberOfArgsValue)
                {
                    case 0:
                        ZeroArgsAnalyser zeroArgsAnalyser = new ZeroArgsAnalyser();
                        zeroArgsAnalyser.Run();
                        commandLineInformation = zeroArgsAnalyser.CommandLineInformation;
                        HelpOptionType = HelpOptionType.none;
                        break;
                    case 1:
                        SingleArgsAnalyser singleArgsAnalyser = new SingleArgsAnalyser(args[0]);
                        singleArgsAnalyser.Run();
                        commandLineInformation= singleArgsAnalyser.CommandLineInformation;
                        HelpOptionType = singleArgsAnalyser.HelpOptionType;
                        break;
                    case 2:
                        DoubleArgsAnalyser doubleArgsAnalyser = new DoubleArgsAnalyser(args);
                        doubleArgsAnalyser.Run();
                        commandLineInformation = doubleArgsAnalyser.CommandLineInformation;
                        HelpOptionType = HelpOptionType.none;
                        break;
                    default:
                        MultiArgsAnalyser multiArgsAnalyser= new MultiArgsAnalyser(args);
                        multiArgsAnalyser.Run();
                        commandLineInformation = multiArgsAnalyser.CommandLineInformation;
                        HelpOptionType = HelpOptionType.none;
                        break;
                }
            }
            
            //处理帮助信息
            if(HelpOptionType!=HelpOptionType.none)
            {
                HelpOptionDisposer_ZhangCang helpOptionDisposer = new HelpOptionDisposer_ZhangCang(HelpOptionType);
                helpOptionDisposer.Run();
            }
        }

    }
}
