using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZhangCang.Input.ReadKeyword
{
    internal partial class ReadGeneralKeyword
    {
        List<string> _keywordList = new List<string>();

        Keyword keyword_;
        public ReadGeneralKeyword(List<string> keywordList)
        {
            this._keywordList = keywordList;
            keyword_ = new Keyword();
        }

        public ReadGeneralKeyword(string strKeyword)
        {
            this._keywordList.Clear();
            this._keywordList.Add(strKeyword);
            keyword_ = new Keyword();
        }

        public Keyword Keyword { get => keyword_; set => keyword_ = value; }

        public void Run()
        {
            string str = "";                                        //控制部分文本的字符串形式
            StringBuilder sb = new StringBuilder();                 //控制部分文本的字符串形式

            string[] allKeyWordAndPara;                             //全部关键词和参数组成的数组
            int indexOfSplit = 0;
            string[] inputKeyWord = new string[2];                  //单个指令数组。被“=”分成两部分，或者没有等号的一部分。

            //读取字符串
            for (int i = 0; i < _keywordList.Count; i++)
            {
                sb.Append(_keywordList[i]);
            }
            str = sb.ToString();

            //分割所有的关键词
            allKeyWordAndPara = Regex.Split(str.Trim(), "\\s+", RegexOptions.IgnoreCase);

            for (int i = 0; i < allKeyWordAndPara.Length; i++)
            {
                try
                {
                    indexOfSplit = allKeyWordAndPara[i].IndexOf('=');
                    if(indexOfSplit>0)
                    {
                        inputKeyWord[0] = allKeyWordAndPara[i].Substring(0, indexOfSplit);
                        inputKeyWord[1] = allKeyWordAndPara[i].Substring(++indexOfSplit);
                    }
                    else
                    {
                        inputKeyWord[0] = allKeyWordAndPara[i];
                    }
                }
                catch
                {
                    throw new Input_Exception("Input Error" + "\n" + inputKeyWord.ToString() + "\n");
                }

                if (inputKeyWord.Length >= 2)
                {
                    //根据输入文件的关键词初始化指令
                    switch (inputKeyWord[0].ToLower())
                    {
                        case "cmd":
                            keyword_.cmd = GetCmd(inputKeyWord[1].ToLower());
                            break;
                        case "task":
                            keyword_.task = GetTask(inputKeyWord[1].ToLower());
                            break;
                        case "min":
                            keyword_.min=GetMinType(inputKeyWord[1].ToLower());
                            break;
                        case "mecp":
                            keyword_.mecp = GetMecpType(inputKeyWord[1].ToLower());
                            break;
                        case "coordinatetype":
                            keyword_.coordinateType = GetCoordinateType(inputKeyWord[1].ToLower());
                            break;
                        case "method":
                            keyword_.strMethods = GetStrMethods(inputKeyWord[1].ToLower());
                            break;
                        case "optcyc":
                            keyword_.optCyc = Convert.ToInt32(inputKeyWord[1]);
                            break;
                        case "stepsize":
                            keyword_.stepSize = Convert.ToDouble(inputKeyWord[1]);
                            break;
                        case "guesshessian":
                            keyword_.guessHessian = GetGuessHessianType(inputKeyWord[1].ToLower());
                            break;
                        case "gradientn":
                            keyword_.gradientN = Convert.ToInt32(inputKeyWord[1]);
                            break;
                        case "hessiann":
                            keyword_.hessianN = Convert.ToInt32(inputKeyWord[1]);
                            break;
                        case "convergence":
                            keyword_.convergence = GetConvergence(inputKeyWord[1]);
                            break;
                        case "energycon":
                            keyword_.energyCon = Convert.ToDouble(inputKeyWord[1]);
                            break;
                        case "maxcon":
                            keyword_.maxCon = Convert.ToDouble(inputKeyWord[1]);
                            break;
                        case "rmscon":
                            keyword_.rmsCon = Convert.ToDouble(inputKeyWord[1]);
                            break;
                        case "maxdisplace":
                            keyword_.maxDisplace = Convert.ToDouble(inputKeyWord[1]);
                            break;
                        case "rmsdisplace":
                            keyword_.rmsDisplace = Convert.ToDouble(inputKeyWord[1]);
                            break;
                        case "lambda":
                            keyword_.lambda = Convert.ToDouble(inputKeyWord[1]);
                            break;
                        case "isreadfirst":
                            keyword_.isReadFirst = GetBoolType(inputKeyWord[1]);
                            break;
                        case "showgradratiocriterionn":
                            keyword_.showGradRatioCriterionN = Convert.ToDouble(inputKeyWord[1]);
                            break;
                        case "showgradratiocriterion":
                            keyword_.showGradRatioCriterion = Convert.ToDouble(inputKeyWord[1]);
                            break;
                        case "judgement":
                            keyword_.judgement = GetJudgement(inputKeyWord[1]);
                            break;
                        case "freq":
                            keyword_.freq = GetFreq(inputKeyWord[1]);
                            break;
                        case "td":
                            keyword_.td = GetTD(inputKeyWord[1]);
                            break;
                        default:
                            throw new Input_Exception("Input Error" + "\n" + inputKeyWord[0].ToString() + "\n");
                    }
                }
            }
        }
    }
}
