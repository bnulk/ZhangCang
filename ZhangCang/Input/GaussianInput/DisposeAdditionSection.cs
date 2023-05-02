using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhangCang.Input.GaussianInput
{
    internal class DisposeAdditionSection
    {
        private Keyword _keyword;
        private List<List<string>> listPartsOfAdditionSection;

        private List<string> listGenBasisSet = new List<string>();
        public List<string> ListGenBasisSet { get => listGenBasisSet; set => listGenBasisSet = value; }

        public DisposeAdditionSection(Keyword keyword, List<string> additionSection) 
        { 
            this._keyword = keyword;
            this.listPartsOfAdditionSection = GetListPartsOfAdditionSection(additionSection);
        }



        public void Run()
        {
            int i = 0;
            string str;
            bool isEnd = false;

            if(_keyword.coordinateType==CoordinateType.Modredundant) { }

        }

        private List<List<string>> GetListPartsOfAdditionSection(List<string> additionSection)
        {
            int cycle = additionSection.Count - 3;
            List<List<string>> result= new List<List<string>>();
            List<string> part= new List<string>();
            bool isEnd = false;

            for(int i = 1; i < cycle; i++)
            {
                part.Add(additionSection[0]);

                if (additionSection[i].Trim() != "")
                {
                    part.Add(additionSection[i]);
                }
                else
                {
                    if(additionSection[i-1].Trim() == "****")                          //赝势基组
                    {
                        part.Add(additionSection[i]);
                    }
                    else                                                               //读完一部分后，纳入list
                    {
                        result.Add(part);
                        part= new List<string>();
                    }


                    if(additionSection[i + 1].Trim() =="" && additionSection[i + 2].Trim() == "")    //终止标识
                    {
                        isEnd = true;
                    }
                }

                if(isEnd==true)
                {
                    i = cycle;
                }
            }

            return result;
        }


    }
}
