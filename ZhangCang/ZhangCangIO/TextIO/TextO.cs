using System.Text;

namespace ZhangCang.ZhangCangIO.TextIO
{
    internal partial class TextO
    {
        /*
        ----------------------------------------------------  类注释  开始----------------------------------------------------
        版本：  V2.0
        作者：  刘鲲
        日期：  2022-06-07

        描述：
            * 输出文本数据的类
        结构：
            * 
        ----------------------------------------------------  类注释  结束----------------------------------------------------
        */

        private string fileFullPath;                                 //文件完整物理路径
        private StreamWriter? streamWriter;                          //输出文件流

        /// <summary>
        /// 文本输出类
        /// </summary>
        /// <param name="fileName">文件完整物理路径</param>
        /// <param name="fileMode">文件打开模式</param>
        /// <exception cref="ZhangCangIO_Exception">异常处理</exception>
        public TextO(string fileFullPath, FileMode fileMode)
        {
            this.fileFullPath = fileFullPath;
            FileStream fs;

            switch (fileMode)
            {
                case FileMode.Create:
                    fs = new FileStream(fileFullPath, FileMode.Create, FileAccess.Write);
                    streamWriter = new StreamWriter(fs);
                    break;
                case FileMode.Append:
                    fs = new FileStream(fileFullPath, FileMode.Append, FileAccess.Write);
                    streamWriter = new StreamWriter(fs);
                    break;
                default:
                    throw new ZhangCangIO_Exception("ChemKun_ZhangCang.Output.WriteText Error");
            }
        }


        /// <summary>
        /// 在当前打开的写入文件中，写入内容。
        /// </summary>
        public void WriteStr(string str)
        {
            if (streamWriter != null)
            {
                streamWriter.Write(str);
                streamWriter.Flush();
                streamWriter.Close();
            }
            else
            {
                throw new ZhangCangIO_Exception("Error. outputFile streamWriter is null.");
            }
        }

        public void WriteStr(StringBuilder strB)
        {
            if (streamWriter != null)
            {
                streamWriter.Write(strB.ToString());
                streamWriter.Flush();
                streamWriter.Close();
            }
            else
            {
                throw new ZhangCangIO_Exception("Error. outputFile streamWriter is null.");
            }
        }

        /// <summary>
        /// 在当前打开的写入文件中，写入出错提示
        /// </summary>
        /// <param name="Error">错误内容</param>
        public void WriteError(string Error)
        {
            if (streamWriter != null)
            {
                streamWriter.Write("\n");
                streamWriter.Write("-Error-Error-Error-Error-Error-Error-Error-Error-Error-Error-" + "\n");
                streamWriter.Write("Error:" + "\n");
                streamWriter.Write(Error + "\n");
                streamWriter.Write("-Error-Error-Error-Error-Error-Error-Error-Error-Error-Error-" + "\n\n\n");
                streamWriter.Flush();
                streamWriter.Close();
            }
            else
            {
                throw new ZhangCangIO_Exception("Error. outputFile streamWriter is null.");
            }
        }

        /// <summary>
        /// 关闭流文件
        /// </summary>
        public void Close()
        {
            if (streamWriter != null)
            {
                streamWriter.Flush();
                streamWriter.Dispose();
                streamWriter.Close();
            }
            else
            {
                throw new ZhangCangIO_Exception("Error. outputFile streamWriter is null.");
            }
        }

        /// <summary>
        /// 设置流的位置到末尾
        /// </summary>
        public void ToEndOfStreamWriter()
        {
            try
            {
                FileStream fs = new FileStream(fileFullPath, FileMode.Open, FileAccess.Write);
                streamWriter = new StreamWriter(fs);
                //writeLogFile.BaseStream.Seek(0, SeekOrigin.End);                        // 字符追加的位置
                streamWriter.BaseStream.Position = fs.Length;                             // 字符追加的位置，在文件的最后。
            }
            catch
            {
                throw new ZhangCangIO_Exception("Output.Continue() died");
            }
        }


    }
}
