using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhangCang.FundamentalPara.BasisSet;

namespace ZhangCang.Data.MolecularOrbitalTheoryData
{
    /// <summary>
    /// 分子轨道
    /// </summary>
    struct MolecularOrbital
    {
        public BasicInfo basicInfo;
        //电子排斥积分
        public double[] repulsionIntegrals;                            //电子排斥积分

        //Matrix部分
        public double[,] matrixS;     //STO基重叠积分矩阵

        public double[,] matrixH;     //单电子Hamilton矩阵

        public double[,] matrixEkh;   //单电子动能积分

        public double[,] matrixPe;    //单电子势能积分

        public double[,] matrixF;     //Fock矩阵

        public double[,] matrixP;     //单电子密度矩阵

        public double[,] matrixC;     //分子轨道系数矩阵

        //Info部分
        public string infoMethod;          //计算方法
        public string infoBasisSet;        //基组名字
        public int infoCharge;             //电荷
        public int infoMultiple;           //多重度
        public int infoOcc;                //闭壳体系被占据分子轨道数

        //Oper部分
        public int operMethod;             //计算方法
        public double operEpslon;          //收敛限
        public int oper_IT;    //打印电子排斥积分选择指标
        public int oper_JT;    //文件打印份数控制指标
        public int oper_MID;   //自洽迭代的各次中间迭代结果打印选择指标
        public int oper_NVEC;  //中间迭代打印轨道波函数的选择指标
        public int oper_NVV;   //中间迭代打印虚轨道波函数的选择指标(NVEC=0,本指标不起作用)
        public int oper_NVP;   //中间迭代打印密度矩阵的选择指标
        public int oper_IPOP;  //Mulliken集居数分析的选择指标
        public int oper_IDIP;  //分子偶极矩计算的选择指标

        //Ite部分
        public int iteMaxCyc;          //迭代次数
        public double iteAnin;         //诱导收敛因子初值
        public double iteAdd;          //诱导收敛因子的步长
        public double[] iteCov;        //记录每次迭代所使用的诱导收敛因子数值
        public int iteIke;             //自洽迭代收敛程度的指示指标.程序开始时初值为0.若迭代结束时分子总能量收敛精度
                                       //没有达到10E-7hartree,则程序将其赋值IKE=1;此时程序自动终止随后的计算,
                                       //并将单电子矩阵S,H,EKH和电子排斥积分V记入外存磁盘
                                       //Eig部分
        public double[] eigEig;    //记录各自洽分子轨道的能级数值

        //Excite部分
        public int exciteNumberOfOccs;                        //激发系列涉及的最高占据分子轨道数目
        public int exciteNumberOfVirs;                        //激发系列涉及的最低虚分子轨道数目

        //四个控制变量
        public int BasisSet;         //原子轨道基组选择指标
        public int numberOfZeta;     //需要修改的原子轨道ζ指数的个数
        public int IKC;     //积分文件读入控制因子
        public int IKD;     //文件记入外存控制因子
    }


    /// <summary>
    /// 非限制性分子轨道
    /// </summary>
    struct UnrestrictedMolecularOrbital
    {
        //Para部分
        
        public int paraNumberOfSto;                                    //STO基包含的STO总数
        public int paraNumberOfSymmetryElement;                        //STO基对称操作元素的总数
        public int paraNumberOfRepulsionIntegrals;                     //STO基电子排斥积分的总个数
        public int paraNumberOfGto;                                    //GTO基总个数       


        //Array部分
        public string[,] arrayAtom;                                    //存储个原子的特性参数,每行对应一个原子
        public string[,] arrayRSG;                                     //储存STO基特性参数，每行对应一条STO
        public int[,] arraySymmetryElement;                            //储存STO基的对称操作表,每列对应一个对称操作元素
        public string[,] arrayGto;                                     //储存GTO参数,每行代表一个GTO

        //电子排斥积分
        public double[] repulsionIntegrals;                            //电子排斥积分

        //Matrix部分
        public double[,] matrixS;     //STO基重叠积分矩阵

        public double[,] matrixH;     //单电子Hamilton矩阵

        public double[,] matrixEkh;   //单电子动能积分

        public double[,] matrixPe;    //单电子势能积分

        public double[,] matrixF;     //Fock矩阵

        public double[,] matrixFA;    //Fock矩阵； A代表α电子,B代表β电子。闭壳体系不区分α电子和β电子,F和FA同址

        public double[,] matrixFB;    //Fock矩阵； A代表α电子,B代表β电子。闭壳体系不区分α电子和β电子,F和FA同址

        public double[,] matrixP;     //单电子密度矩阵

        public double[,] matrixPA;    //α电子单电子密度矩阵

        public double[,] matrixPB;    //β电子单电子密度矩阵

        public double[,] matrixC;     //分子轨道系数矩阵.

        public double[,] matrixCA;    //每一列表示一条分子轨道

        public double[,] matrixCB;    //闭壳体系不区分α电子和β电子,T和TA等价

        //Info部分
        public string infoMethod;          //计算方法
        public string infoBasisSet;        //基组名字
        public int infoCharge;             //电荷
        public int infoMultiple;           //多重度
        public int infoOcc;                //闭壳体系被占据分子轨道数
        public int infoOccA;               //开壳体系α电子占据的分子轨道数
        public int infoOccB;               //开壳体系β电子占据的分子轨道数
        public int[] infoKOccA;            //存放开壳体系被α电子占据的分子轨道号码
        public int[] infoKOccB;            //存放开壳体系被β电子占据的分子轨道号码

        //Oper部分
        public int operMethod;             //计算方法
        public double operEpslon;          //收敛限
        public int oper_IT;    //打印电子排斥积分选择指标
        public int oper_JT;    //文件打印份数控制指标
        public int oper_MID;   //自洽迭代的各次中间迭代结果打印选择指标
        public int oper_NVEC;  //中间迭代打印轨道波函数的选择指标
        public int oper_NVV;   //中间迭代打印虚轨道波函数的选择指标(NVEC=0,本指标不起作用)
        public int oper_NVP;   //中间迭代打印密度矩阵的选择指标
        public int oper_IPOP;  //Mulliken集居数分析的选择指标
        public int oper_IDIP;  //分子偶极矩计算的选择指标

        //Ite部分
        public int iteMaxCyc;          //迭代次数
        public double iteAnin;         //诱导收敛因子初值
        public double iteAdd;          //诱导收敛因子的步长
        public double[] iteCov;        //记录每次迭代所使用的诱导收敛因子数值
        public int iteIke;             //自洽迭代收敛程度的指示指标.程序开始时初值为0.若迭代结束时分子总能量收敛精度
                                       //没有达到10E-7hartree,则程序将其赋值IKE=1;此时程序自动终止随后的计算,
                                       //并将单电子矩阵S,H,EKH和电子排斥积分V记入外存磁盘
                                       //Eig部分
        public double[] eigEig;    //记录各自洽分子轨道的能级数值

        //Excite部分
        public int exciteNumberOfOccs;                        //激发系列涉及的最高占据分子轨道数目
        public int exciteNumberOfVirs;                        //激发系列涉及的最低虚分子轨道数目

        //四个控制变量
        public int BasisSet;         //原子轨道基组选择指标
        public int numberOfZeta;     //需要修改的原子轨道ζ指数的个数
        public int IKC;     //积分文件读入控制因子
        public int IKD;     //文件记入外存控制因子
    }


    /// <summary>
    /// 基本信息
    /// </summary>
    struct BasicInfo
    {
        /// <summary>
        /// 电子数目
        /// </summary>
        public int numberOfElectrons;
        /// <summary>
        /// 分子中原子核的总个数
        /// </summary>
        public int numberOfNucleus;
        /// <summary>
        /// STO总数
        /// </summary>
        public int numberOfSto;
        /// <summary>
        /// STO基对称操作元素的总数
        /// </summary>
        public int numberOfSymmetryElement;
        /// <summary>
        /// 电子排斥积分的总个数
        /// </summary>
        public int numberOfRepulsionIntegrals;
        /// <summary>
        /// GTO基总个数 
        /// </summary>
        public int numberOfGto;
        /// <summary>
        /// 原子的特性参数
        /// </summary>
        public List<Atom> listAtom;
        /// <summary>
        /// STO基特性参数
        /// </summary>
        public List<Sto> listSto;
        /// <summary>
        /// GTO参数
        /// </summary>
        public List<Gto> listGto;
        /// <summary>
        /// 储存STO基的对称操作表,每列对应一个对称操作元素
        /// </summary>
        public int[,] symmetryElement;        
    }

    /// <summary>
    /// 原子信息
    /// </summary>
    struct Atom
    {
        /// <summary>
        /// 原子标号
        /// </summary>
        public int atomLabel;
        /// <summary>
        /// 原子序数
        /// </summary>
        public int atomicNumber;
        /// <summary>
        /// 基组名字
        /// </summary>
        public BasisSetName basisSetName;
        /// <summary>
        /// 原子包含的STO数
        /// </summary>
        public int numberOfSto;
        /// <summary>
        /// 坐标x
        /// </summary>
        public double x;
        /// <summary>
        /// 坐标y
        /// </summary>
        public double y;
        /// <summary>
        /// 坐标z
        /// </summary>
        public double z;
    }

    /// <summary>
    /// STO信息
    /// </summary>
    struct Sto
    {
        /// <summary>
        /// 所属原子标号
        /// </summary>
        public int atomLabel;
        /// <summary>
        /// STO标号
        /// </summary>
        public int stoLabel;
        /// <summary>
        /// STO轨道类型
        /// </summary>
        public StoType stoType;
        /// <summary>
        /// STO的ζ值
        /// </summary>
        public double zeta;
        /// <summary>
        /// 本STO包含的GTO个数
        /// </summary>
        public int numberOfGto;
        /// <summary>
        /// GTO累加数
        /// </summary>
        public int accumulatedNumberOfGto;
    }

    /// <summary>
    /// GTO信息
    /// </summary>
    struct Gto
    {
        /// <summary>
        /// 所属原子标号
        /// </summary>
        public int atomLabel;
        /// <summary>
        /// 所属STO标号
        /// </summary>
        public int stoLabel;
        /// <summary>
        /// GTO标号
        /// </summary>
        public int gtoLabel;
        /// <summary>
        /// GTO轨道类型
        /// </summary>
        public StoType stoType;
        /// <summary>
        /// 坐标x
        /// </summary>
        public double x;
        /// <summary>
        /// 坐标y
        /// </summary>
        public double y;
        /// <summary>
        /// 坐标z
        /// </summary>
        public double z;
        /// <summary>
        /// 指数α
        /// </summary>
        public double alpha;
        /// <summary>
        /// 量子数l
        /// </summary>
        public int l;
        /// <summary>
        /// 量子数m
        /// </summary>
        public int m;
        /// <summary>
        /// 量子数n
        /// </summary>
        public int n;
        /// <summary>
        /// 压缩系数
        /// </summary>
        public double coefficient;
        /// <summary>
        /// 归一化系数Norm
        /// </summary>
        public double norm;

    }
}
