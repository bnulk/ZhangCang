using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZhangCang.Input.ZhangCangInput
{
    internal partial class KeywordList2Keyword
    {
        List<string> keywordList = new List<string>();

        Keyword keyword;

        public Keyword Keyword { get => keyword; set => keyword = value; }

        public KeywordList2Keyword(List<string> keywordList)
        {
            this.keywordList = keywordList;
        }

        public void Run()
        {
            ReadKeyword.ReadGeneralKeyword readGeneralKeyword = new ReadKeyword.ReadGeneralKeyword(keywordList);
            readGeneralKeyword.Run();
            keyword = readGeneralKeyword.Keyword;
        }

    }
}
