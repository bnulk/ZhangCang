

namespace ZhangCang
{
    /// <summary>
    /// 控制关键词
    /// </summary>
    public struct Control
    {
        /// <summary>
        /// 操作系统
        /// </summary>
        public OS os;
        /// <summary>
        /// 输入文件物理路径
        /// </summary>
        public string inputFileFullPath;
        /// <summary>
        /// 输出文件物理路径
        /// </summary>
        public string outputFileFullPath;
        /// <summary>
        /// 输入文件所在目录
        /// </summary>
        public string inputFileDirectory;
        /// <summary>
        /// 当前所在目录
        /// </summary>
        public string currentDirectory;
        /// <summary>
        /// 输入文件类型
        /// </summary>
        public InputFileType inputFileType;

        public Control()
        {
            os = OS.unknown;
            inputFileFullPath = "";
            inputFileDirectory = "";
            outputFileFullPath = "";
            inputFileDirectory = "";
            currentDirectory = "";
            inputFileType = InputFileType.unknown;
        }
    }

    public struct Keyword
    {
        public Task task;                                    //计算任务
        public Cmd cmd;                                      //计算程序命令行
        public Method[] methods;                             //计算方法
        public string[] strMethods;                          //字符串型计算方法
        public Min min;                                      //极小点优化方法
        public MECP mecp;                                    //极小势能面交叉点优化方法
        public CoordinateType coordinateType;                //坐标类型，包括"z-matrix"和"cartesian"
        public int optCyc;                                   //大循环最大循环次数
        public double stepSize;                              //步长
        public GuessHessian guessHessian;                    //估计Hessian阵的方式，包括两种方式，默认为1、"BFGS"，即BFGS方法； 另一种是2、"Powell"，即Powell方法
        public int gradientN;                                //计算Gradient阵的间隔步，即每隔gradientStep步计算一次力常数矩阵
        public int hessianN;                                 //计算Hessian阵的间隔步，即每隔hessianStep步计算一次力常数矩阵
        public Convergence convergence;                      //收敛标准
        public double energyCon;                             //收敛限能量
        public double maxCon;                                //最大力
        public double rmsCon;                                //均方根力
        public double maxDisplace;                           //最大位移
        public double rmsDisplace;                           //均方根位移
        public Judgement judgement;                          //判据。可以是能量"energy"或者综合"global".
        public Freq freq;                                    //振动分析
        public TD td;

        public double lambda;                                //计算极小势能面交叉点，所用拉格朗日参量λ
        public bool isReadFirst;                             //计算极小势能面交叉点，是否读第零步Labuta、能量、梯度和Hessian阵，第一步的构型；"true"表示读，"false"表示不读 
        public double showGradRatioCriterionN;               //计算极小势能面交叉点，最终显示梯度比的梯度阚值，10^-N
        public double showGradRatioCriterion;                //计算极小势能面交叉点，最终显示梯度比的梯度阚值

        public Keyword()
        {
            task = Task.sp;
            cmd = Cmd.zhangcang;
            min = Min.steep;
            mecp = MECP.ln;
            coordinateType = CoordinateType.zMatrix;

            methods= new Method[1];
            strMethods= new string[1];

            optCyc = 100;
            stepSize = 0.1;
            guessHessian = GuessHessian.BFGS;
            gradientN = 1;
            hessianN = optCyc;
            convergence = Convergence.normal;
            energyCon = 0.00001;
            maxCon = 0.001;
            rmsCon = 0.0005;
            maxDisplace = 0.005;
            rmsDisplace = 0.003;
            judgement = Judgement.global;
            freq = Freq.none;

            td = new TD();

            lambda = 1;
            isReadFirst = false;
            showGradRatioCriterionN = 4;
            showGradRatioCriterion = 1E-4;;
        }
    }

    /// <summary>
    /// Min关键词
    /// </summary>
    public struct Keyword_Min
    {
        public string opt;                                   //优化方法
        public string coordinateType;                        //坐标类型，包括"z-matrix"和"cartesian"
        public string scfTyp;                                //自洽场类型
        public int optCyc;                                   //最大循环次数
        public double stepSize;                              //步长
        public string guessHessian;                          //估计Hessian阵的方式，包括两种方式，默认为1、"BFGS"，即BFGS方法； 另一种是2、"Powell"，即Powell方法
        public int gradientN;                                //计算Gradient阵的间隔步，即每隔gradientStep步计算一次力常数矩阵
        public int hessianN;                                 //计算Hessian阵的间隔步，即每隔hessianStep步计算一次力常数矩阵
        public double detEnergyCon;                          //能量差收敛限
        public double maxCon;                                //最大力
        public double rmsCon;                                //均方根力
        public double maxDirection;                          //最大搜索方向
        public double rmsDirection;                          //均方根搜索方向
        public bool isReadFirst;                             //是否读第零步能量、梯度和Hessian阵，第一步的构型；"true"表示读，"false"表示不读 
        public string judgement;                             //判据。可以是能量"energy"或者综合"global".
        public string freq;                                  //振动分析
    }

    /// <summary>
    /// TD计算关键词
    /// </summary>
    public struct TD
    {
        public bool isTD;
        public int[] root;
        public int nstates;
        public TD()
        {
            isTD = false;
            root = new int[0];
            nstates = 0;
        }
    }

    /// <summary>
    /// TDA计算关键词
    /// </summary>
    public struct TDA
    {
        public bool isTDA;
        public string[] root;
        public int nstates;
    }

    // <summary>
    /// ZMatrix信息
    /// </summary>
    public struct ZMatrix
    {
        /// <summary>
        /// 是否存在ZMatrix信息
        /// </summary>
        public bool isExist;
        /// <summary>
        /// 原子序号（核电荷数）数组
        /// </summary>
        public int[]? atomicNumbers;
        /// <summary>
        /// 内坐标的连接信息
        /// </summary>
        public int[,]? connectionInfo;
        /// <summary>
        /// 内坐标的连接信息的值
        /// </summary>
        public double[,]? connectionInfoValue;
        /// <summary>
        /// 内坐标的参数数组
        /// </summary>
        public string[]? paraName;
        /// <summary>
        /// 内坐标的坐标数组
        /// </summary>
        public double[]? paraValue;

        public ZMatrix()
        {
            isExist = false;
            atomicNumbers = null;
            connectionInfo = null;
            connectionInfoValue = null;
            paraName = null;
            paraValue = null;
        }
    }

    public struct RedundantCoordinate
    {

    }


    /// <summary>
    /// 优化收敛标准
    /// </summary>
    public struct OptConvergenceCriteria_Value
    {
        public double energyCon;
        public double maxCon;
        public double rmsCon;
        public double maxDisplace;
        public double rmsDisplace;

        public void Initial_Loose()
        {
            energyCon = 0.0001;
            maxCon = 0.01;
            rmsCon = 0.005;
            maxDisplace = 0.05;
            rmsDisplace = 0.03;
        }

        public OptConvergenceCriteria_Value()
        {
            energyCon = 0.00001;
            maxCon = 0.001;
            rmsCon = 0.0005;
            maxDisplace = 0.005;
            rmsDisplace = 0.003;
        }

    }

}
