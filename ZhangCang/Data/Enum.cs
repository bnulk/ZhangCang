

namespace ZhangCang
{
    /// <summary>
    /// 操作系统
    /// </summary>
    public enum OS
    {
        Linux,
        Windows,
        unknown
    }

    /// <summary>
    /// 输入文件类型
    /// </summary>
    public enum InputFileType
    {
        ZhangCang,
        Gaussian,
        unknown
    }

    /// <summary>
    /// 计算任务类型
    /// </summary>
    public enum Task
    {
        sp,
        min,
        mecp,
        ts,
        unknown
    }

    /// <summary>
    /// 坐标类型
    /// </summary>
    public enum CoordinateType
    {
        zMatrix,
        Cartesian,
        noInfo,
        unknown
    }

    /// <summary>
    /// 极小点优化方法
    /// </summary>
    public enum Min
    {
        steep
    }

    /// <summary>
    /// 极小势能面交叉的优化方法
    /// </summary>
    public enum MECP
    {
        ln
    }

    /// <summary>
    /// 自洽场类型
    /// </summary>
    public enum ScfTyp
    {
        hf,
        cis,
        td,
        tda
    }

    /// <summary>
    /// 猜测Hessian矩阵的方法
    /// </summary>
    public enum GuessHessian
    {
        None,
        Normal,
        BFGS,
        RBFGS,                                            //马昌凤，P195
        Powell
    }

    /// <summary>
    /// 计算收敛判据
    /// </summary>
    public enum Judgement
    {
        global,
        energy
    }

    /// <summary>
    /// 收敛标准
    /// </summary>
    public enum Convergence
    {
        normal,
        loose,
        tight
    }

    /// <summary>
    /// 振动分析类型
    /// </summary>
    public enum Freq
    {
        none,
        gaussianFreq,
        liuMecp,
        simpleMecp
    }

    /// <summary>
    /// 自洽场方法
    /// </summary>
    public enum Method
    {
        HF,
        unknown
    }

    /// <summary>
    /// 命令行
    /// </summary>
    public enum Cmd
    {
        zhangcang,
        g16,
        g09,
        unknown
    }


}
