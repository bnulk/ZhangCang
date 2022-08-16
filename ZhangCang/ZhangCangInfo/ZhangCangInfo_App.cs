using System.Text;
using ZhangCang.ZhangCangIO.TextIO;

namespace ZhangCang.ZhangCangInfo
{
    public class ZhangCangInfo_App
    {
        private Control _control;

        public ZhangCangInfo_App(Control control)
        {
            this._control = control;
        }


        /// <summary>
        /// 写Title部分
        /// </summary>
        public void WriteTitle()
        {
            TextO textO = new TextO(_control.outputFileFullPath, FileMode.Create);
            textO.WriteStr(GetProgramTitle());
        }

        private string GetProgramTitle()
        {
            StringBuilder m_Result = new StringBuilder();
            //程序来源
            m_Result.Append(GlobalVariable.programName + "  " + GlobalVariable.programVersion + "  " + "\n" + GlobalVariable.programDate + "\n" + "\n");
            m_Result.Append(DateTime.Now.ToString() + "\n");
            m_Result.Append("****************************************************************************************************" + "\n");
            m_Result.Append("Author Information: Liu Kun, College of Chemistry, Tianjin Normal University, Tianjin 300387, China" + "\n");
            m_Result.Append("Email: bnulk@foxmail.com" + "\n");
            m_Result.Append("You can obtain the newest version of the program by contacting the author." + "\n");
            m_Result.Append("The code can be downloaded from https://github.com/bnulk" + "\n");
            m_Result.Append("****************************************************************************************************" + "\n");

            m_Result.Append("" + "\n");
            m_Result.Append("" + "\n");
            m_Result.Append("" + "\n");
            m_Result.Append("" + "\n");
            /*
            m_Result.Append("　　　　　　　　　1s　　　　　　　　 " + "\n");
            m_Result.Append("　　　　　　　5,　1s　:r　　　　　　 " + "\n");
            m_Result.Append("　　　　　　　 9i 1s i9　　　　　　　" + "\n");
            m_Result.Append("　　　　　　　　9h1s59　　　　　　　 " + "\n");
            m_Result.Append("　　　　　　　　 9999　　　　　　　　" + "\n");
            m_Result.Append("　　　　　　　　　99　　　　　　　　 " + "\n");
            m_Result.Append("　　　　　　　　　1s　　　　　　　　 " + "\n");
            m_Result.Append("　　　　　　　　　h1　　　　　　　　 " + "\n");
            m_Result.Append("　　　　;99999　 9993　 99999,　　　 " + "\n");
            m_Result.Append("　　　　　 9　　391s93　 rS　　　　　" + "\n");
            m_Result.Append("　　　　　 9　 99 1s 99　rS　　　　　" + "\n");
            m_Result.Append("　　　　　 9　9S　1s　S9 rS　　　　　" + "\n");
            m_Result.Append("　　　　　 9　　　1s　　 rS　　　　　" + "\n");
            m_Result.Append("　　　　　 99;　　　　　i9S　　　　　" + "\n");
            m_Result.Append("　　　　　 9 99,　　　i99sS　　　　　" + "\n");
            m_Result.Append("　　　　　 9　 99　 i99　S1　　　　　" + "\n");
            m_Result.Append("　　　　　 5S　　9999　　9　　　　　 " + "\n");
            m_Result.Append("　　　　9　 9　 r9999.　i9　 9　　　 " + "\n");
            m_Result.Append("　　　 9i　 r9i99　　99 9　　;9　　　" + "\n");
            m_Result.Append("　　　h5　　 59　　　 s9,　　 55　　 " + "\n");
            m_Result.Append("　　　9:　99: ,995::999　.99　.9　　 " + "\n");
            m_Result.Append("　　　9s99:　　　h99;　　　:99i9　　 " + "\n");
            m_Result.Append("　　　.93　　　　　　　　　　S9,　　 " + "\n");
            m_Result.Append("　　　999: r9　　　　　　9r ,999　　 " + "\n");
            m_Result.Append("　　 35　999　　　　　　　399　59　　" + "\n");
            m_Result.Append("　　;9　　　　　　　　　　　　　9;　 " + "\n");
            m_Result.Append("　　9.　　　　　　　　　　　　　.9　 " + "\n");
            m_Result.Append("　　9　　　　　　　　　　　　　　9　 " + "\n");
            m_Result.Append("　 .S　　　　　　　　　　　　　　S.　" + "\n");
            m_Result.Append("　 s1　　　　　　　　　　　　　　11　" + "\n");
            m_Result.Append("    1    2    3" + "     is simplified to     " + "    0    0    3" + "\n");
            m_Result.Append("    2    3    2" + "     is simplified to     " + "    0    5    2" + "\n");
            m_Result.Append("    3    1    1" + "     is simplified to     " + "   36    1    1" + "\n");
            m_Result.Append("   26   34   39" + "     is simplified to     " + "   99   24   39" + "\n");
            */

            m_Result.Append("               " + "　　　　　　　　　1s　　　　　　　　  " + "               " + "\n");
            m_Result.Append("               " + "　　　　　　　5,　1s　:r　　　　　　 " + "               " + "\n");
            m_Result.Append("               " + "　　　　　　　 9i 1s i9　　　　　　　" + "               " + "\n");
            m_Result.Append("               " + "　　　　　　　　9h1s59　　　　　　　 " + "               " + "\n");
            m_Result.Append("               " + "　　　　　　　　 9999　　　　　　　　" + "               " + "\n");
            m_Result.Append("               " + "　　　　　　　　　99　　　　　　　　 " + "               " + "\n");
            m_Result.Append("               " + "　　　　　　　　　1s　　　　　　　　 " + "               " + "\n");
            m_Result.Append("    1    2    3" + "　　　　　　　　　h1　　　　　　　　 " + "    0    0    3" + "\n");
            m_Result.Append("    2    3    2" + "　　　　;99999　 9993　 99999,　　　 " + "    0    5    2" + "\n");
            m_Result.Append("    3    1    1" + "　　　　　 9　　391s93　 rS　　　　　" + "   36    1    1" + "\n");
            m_Result.Append("   26   34   39" + "　　　　　 9　 99 1s 99　rS　　　　　" + "   99   24   39" + "\n");
            m_Result.Append("               " + "　　　　　 9　9S　1s　S9 rS　　　　　" + "               " + "\n");
            m_Result.Append("               " + "　　　　　 9　　　1s　　 rS　　　　　" + "               " + "\n");
            m_Result.Append("               " + "　　　　　 99;　　　　　i9S　　　　　" + "               " + "\n");
            m_Result.Append("               " + "　　　　　 9 99,　　　i99sS　　　　　" + "               " + "\n");
            m_Result.Append("               " + "　　　　　 9　 99　 i99　S1　　　　　" + "               " + "\n");
            m_Result.Append("               " + "　　　　　 5S　　9999　　9　　　　　 " + "               " + "\n");
            m_Result.Append("               " + "　　　　9　 9　 r9999.　i9　 9　　　 " + "               " + "\n");
            m_Result.Append("               " + "　　　 9i　 r9i99　　99 9　　;9　　　" + "               " + "\n");
            m_Result.Append("               " + "　　　h5　　 59　　　 s9,　　 55　　 " + "               " + "\n");
            m_Result.Append("               " + "　　　9:　99: ,995::999　.99　.9　　 " + "               " + "\n");
            m_Result.Append("               " + "　　　9s99:　　　h99;　　　:99i9　　 " + "               " + "\n");
            m_Result.Append("               " + "　　　.93　　　　　　　　　　S9,　　 " + "               " + "\n");
            m_Result.Append("               " + "　　　999: r9　　　　　　9r ,999　　 " + "               " + "\n");
            m_Result.Append("               " + "　　 35　999　　　　　　　399　59　　" + "               " + "\n");
            m_Result.Append("               " + "　　;9　　　　　　　　　　　　　9;　 " + "               " + "\n");
            m_Result.Append("               " + "　　9.　　　　　　　　　　　　　.9　 " + "               " + "\n");
            m_Result.Append("               " + "　　9　　　　　　　　　　　　　　9　 " + "               " + "\n");
            m_Result.Append("               " + "　 .S　　　　　　　　　　　　　　S.　" + "               " + "\n");
            m_Result.Append("               " + "　 s1　　　　　　　　　　　　　　11　" + "               " + "\n");

            m_Result.Append("" + "\n");
            m_Result.Append("" + "\n");
            m_Result.Append("" + "\n");
            m_Result.Append("" + "\n");

            return m_Result.ToString();
        }
    }
}
