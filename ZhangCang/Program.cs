using System;
using ZhangCang.CommandLine;
using ZhangCang.Data;
using ZhangCang.Drive;


namespace ZhangCang
{
    class Program
    {
        /// <summary>
        /// 程序入口
        /// </summary>
        /// <param name="args">命令行参数</param>
        static void Main(string[] args)
        {
            CommandLineInformation commandLineInformation = new CommandLineInformation();
            Control control= new Control();
            InputData inputData = new InputData();

            //读取命令行信息
            try
            {
                CommandLine_App app = new CommandLine_App(args);
                app.Run();
                commandLineInformation = app.CommandLineInformation;

                ProvideData_ForZhangCang provideData = new ProvideData_ForZhangCang(commandLineInformation);
                provideData.Run();
                control = provideData.Control;
            }
            catch (CommandLine_Exception e)
            {
                Console.Write(e.Message);
                return;
            }

            //输出开始信息
            ZhangCangInfo.ZhangCangInfo_App zhangCangInfo_App = new ZhangCangInfo.ZhangCangInfo_App(control);
            zhangCangInfo_App.WriteTitle();

            //读取输入文件信息
            Input.ReadInputFile_App inputApp = new Input.ReadInputFile_App(control);
            inputApp.Run();
            inputData = inputApp.InputData_;
            //输出文件信息
            inputApp.WriteResult();

            //把输入文件部分填入Element
            InputDataToElement.InputData2Element_App toElementApp = new InputDataToElement.InputData2Element_App(inputData, control);
            toElementApp.Run();
            //用输入数据驱动程序运行
            Drive_App drive_App = new Drive_App(toElementApp.Element_);
            drive_App.Run();
        }




    }
}

