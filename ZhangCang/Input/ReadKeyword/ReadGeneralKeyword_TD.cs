using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhangCang.Input.ReadKeyword
{
    internal partial class ReadGeneralKeyword
    {
        /// <summary>
        /// 获取TD结构
        /// </summary>
        /// <param name="strTD">字符串型TD</param>
        /// <returns>TD结构</returns>
        public TD GetTD(string strTD)
        {
            TD td = new TD();
            string[] strTDs;
            bool isError = true;

            //删除括号
            if (strTD.StartsWith('('))
            {
                strTD = strTD.Remove(0, 1);
            }
            if (strTD.EndsWith(')'))
            {
                strTD = strTD.Remove(strTD.Length - 1, 1);
            }

            strTDs = strTD.Split(',');

            for(int i=0;i<strTDs.Length;i++,isError=true)
            {
                if(strTDs[i].StartsWith("root"))
                {
                    td.root = ReadRoots(strTDs[i]);
                    isError = false;
                }
                if (strTDs[i].StartsWith("nstates"))
                {
                    td.nstates = ReadNstates(strTDs[i]);
                    isError = false;
                }
                if(isError==true)
                {
                    throw new Input_Exception("InputFile TD Keyword Error.");
                }
            }

            td.isTD = true;
            return td;
        }

        /// <summary>
        /// 读计算的根
        /// </summary>
        /// <param name="inputRoots">输入根的部分</param>
        /// <returns>计算的根</returns>
        /// <exception cref="Input_Exception">读取根错误</exception>
        public int[] ReadRoots(string inputRoots)
        {
            string[] strRoots = inputRoots.Split(':');
            int numberOfRoot = strRoots.Length;
            int[] result = new int[numberOfRoot];

            for(int i=0;i<numberOfRoot;i++)
            {
                if(strRoots[i].StartsWith("root="))
                {
                    result[i] = Convert.ToInt32(strRoots[i].Remove(0, 5));
                }
                else
                {
                    throw new Input_Exception("InputFile TD Keyword Error.");
                }
            }
            return result;
        }

        public int ReadNstates(string inputNstates)
        {
            int result = 0;

            if (inputNstates.StartsWith("nstates="))
            {
                result = Convert.ToInt32(inputNstates.Remove(0, 8));
            }
            else
            {
                throw new Input_Exception("InputFile TD Keyword Error.");
            }

            return result;
        }




    }
}
