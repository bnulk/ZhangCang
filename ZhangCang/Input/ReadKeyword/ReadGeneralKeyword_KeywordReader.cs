

namespace ZhangCang.Input.ReadKeyword
{
    internal partial class ReadGeneralKeyword
    {
        /// <summary>
        /// 获取布尔型变量
        /// </summary>
        /// <param name="strTask">字符串布尔变量</param>
        /// <returns>布尔变量</returns>
        public bool GetBoolType(string strBool)
        {
            bool result;
            switch (strBool)
            {
                case "true":
                    result = true;
                    break;
                case "false":
                    result = false;
                    break;
                default:
                    result = false;
                    break;
            }
            return result;
        }

        /// <summary>
        /// 获取任务类型
        /// </summary>
        /// <param name="strTask">字符串任务类型</param>
        /// <returns>任务类型</returns>
        public Task GetTask(string strTask)
        {
            Task task;
            switch (strTask)
            {
                case "sp":
                    task = Task.sp;
                    break;
                case "min":
                    task = Task.min;
                    break;
                case "ts":
                    task = Task.ts;
                    break;
                case "mecp":
                    task = Task.mecp;
                    break;
                default:
                    task = Task.unknown;
                    break;
            }
            return task;
        }

        /// <summary>
        /// 获取计算程序的命令行
        /// </summary>
        /// <param name="strCmd">字符串形式的计算程序命令行</param>
        /// <returns>计算程序的命令行</returns>
        public Cmd GetCmd(string strCmd)
        {
            Cmd cmd;
            switch (strCmd)
            {
                case "zhangcang":
                    cmd = Cmd.zhangcang;
                    break;
                case "g16":
                    cmd = Cmd.g16;
                    break;
                case "g09":
                    cmd = Cmd.g09;
                    break;
                default:
                    cmd = Cmd.zhangcang;
                    break;
            }
            return cmd;
        }        

        /// <summary>
        /// 获取字符串型计算方法
        /// </summary>
        /// <param name="strMethod">字符串型计算方法</param>
        /// <returns>字符串型计算方法</returns>
        public string[] GetStrMethods(string strMethod)
        {
            string[] strMethods;

            strMethods=strMethod.Split(':');
            return strMethods;
        }

        /// <summary>
        /// 获取坐标类型
        /// </summary>
        /// <param name="strCoordinateType">字符串型坐标类型</param>
        /// <returns>坐标类型</returns>
        public CoordinateType GetCoordinateType(string strCoordinateType)
        {
            CoordinateType coordinateType;
            switch (strCoordinateType)
            {
                case "zmatrix":
                    coordinateType = CoordinateType.zMatrix;
                    break;
                case "cartesian":
                    coordinateType = CoordinateType.Cartesian;
                    break;
                default:
                    coordinateType = CoordinateType.zMatrix;
                    break;
            }
            return coordinateType;
        }

        /// <summary>
        /// 获取极小势能面交叉点优化类型
        /// </summary>
        /// <param name="strMecp">字符串型优化类型</param>
        /// <returns>极小势能面交叉点优化类型</returns>
        public MECP GetMecpType(string strMecp)
        {
            MECP mecp;
            switch (strMecp)
            {
                case "ln":
                    mecp = MECP.ln;
                    break;
                default:
                    mecp = MECP.ln;
                    break;
            }
            return mecp;
        }

        /// <summary>
        /// 获取极小点优化类型
        /// </summary>
        /// <param name="strMin">字符串型优化类型</param>
        /// <returns>极小点优化类型</returns>
        public Min GetMinType(string strMin)
        {
            Min min;
            switch (strMin)
            {
                case "ln":
                    min = Min.steep;
                    break;
                default:
                    min = Min.steep;
                    break;
            }
            return min;
        }
        /// <summary>
        /// 获取自洽场类型
        /// </summary>
        /// <param name="strCoordinateType">字符串型自洽场类型</param>
        /// <returns>自洽场类型</returns>
        public ScfTyp GetScfType(string strScfTyp)
        {
            ScfTyp scfType;
            switch (strScfTyp)
            {
                case "hftyp":
                    scfType = ScfTyp.hf;
                    break;
                case "cistyp":
                    scfType = ScfTyp.cis;
                    break;
                case "tdtyp":
                    scfType = ScfTyp.td;
                    break;
                default:
                    scfType = ScfTyp.hf;
                    break;
            }
            return scfType;
        }

        /// <summary>
        /// 获取基组
        /// </summary>
        /// <param name="strBasisSet">字符串型基组</param>
        /// <returns></returns>
        public BasisSetName GetBasisSet(string strBasisSet)
        {
            BasisSetName basisSetName;
            switch (strBasisSet)
            {
                case "sto-3g":
                    basisSetName = BasisSetName.cgSto3g; 
                    break;
                case "3-21g":
                    basisSetName = BasisSetName.cg321g;
                    break;
                default:
                    basisSetName = BasisSetName.unknown;
                    break;
            }
            return basisSetName;
        }

        /// <summary>
        /// 获取猜测Hessian的方法
        /// </summary>
        /// <param name="strCoordinateType">字符串型猜测Hessian的方法</param>
        /// <returns>猜测Hessian的方法</returns>
        public GuessHessian GetGuessHessianType(string strGuessHessian)
        {
            GuessHessian guessHessian;
            switch (strGuessHessian)
            {
                case "bfgs":
                    guessHessian = GuessHessian.BFGS;
                    break;
                case "powell":
                    guessHessian = GuessHessian.Powell;
                    break;
                case "rbfgs":
                    guessHessian = GuessHessian.RBFGS;
                    break;
                default:
                    guessHessian = GuessHessian.RBFGS;
                    break;
            }
            return guessHessian;
        }

        public Cmd GetCmdType(string strCmd)
        {
            Cmd cmdType;
            switch (strCmd)
            {
                case "g16":
                    cmdType = Cmd.g16;
                    break;
                case "g09":
                    cmdType = Cmd.g09;
                    break;
                default:
                    cmdType = Cmd.g16;
                    break;
            }
            return cmdType;
        }

        /// <summary>
        /// 获取收敛判据的方法
        /// </summary>
        /// <param name="strJudgement">字符串型收敛判据</param>
        /// <returns>收敛判据</returns>
        public Judgement GetJudgement(string strJudgement)
        {
            Judgement judgement;
            switch (strJudgement)
            {
                case "energy":
                    judgement = Judgement.energy;
                    break;
                case "global":
                    judgement = Judgement.global;
                    break;
                default:
                    judgement = Judgement.global;
                    break;
            }
            return judgement;
        }

        /// <summary>
        /// 获取振动分析类型
        /// </summary>
        /// <param name="strJudgement">字符串型振动分析类型</param>
        /// <returns>振动分析类型</returns>
        public Freq GetFreq(string strFreq)
        {
            Freq freq;
            switch (strFreq)
            {
                case "liu":
                    freq = Freq.liuMecp;
                    break;
                case "mecpsimple":
                    freq = Freq.simpleMecp;
                    break;
                default:
                    freq = Freq.liuMecp;
                    break;
            }
            return freq;
        }

        /// <summary>
        /// 获取收敛标准
        /// </summary>
        /// <param name="strJudgement">字符串型收敛标准</param>
        /// <returns>收敛标准</returns>
        public Convergence GetConvergence(string strConvergence)
        {
            Convergence convergence;
            switch (strConvergence)
            {
                case "normal":
                    convergence = Convergence.normal;
                    break;
                case "loose":
                    convergence = Convergence.loose;
                    break;
                case "tight":
                    convergence = Convergence.tight;
                    break;
                default:
                    convergence = Convergence.normal;
                    break;
            }
            return convergence;
        }


    }
}
