using System;
using System.Collections.Generic;
using System.Text;
using ZhangCang.LinearAlgebra;

namespace ZhangCang.NumericalRecipes
{
    class Sorting
    {
        /*
        ----------------------------------------------------  类注释  开始----------------------------------------------------
        版本：  V1.0
        作者：  刘鲲
        日期：  2018-08-11

        描述：
            * 排序算法；来自于"Numerical Recipes in C++" P246
        方法：
            * piksrt --- 直接插入法，N^2运算量。适用范围，N<20。
            * sort2 --- 快速排序法，在排序的同时，重排其它任何数组
        ----------------------------------------------------  类注释  结束----------------------------------------------------
        */



        private static void SWAP(ref double a, ref double b)
        {
            double tmp;
            tmp = a;
            a = b;
            b = tmp;
            return;
        }

        /// <summary>
        /// 直接插入法，N<20时适用。
        /// </summary>
        /// <param name="vec">向量</param>
        /// <returns>按递增顺序排列的向量</returns>
        public static Vector Piksrt(Vector vec)
        {
            Vector tmpVec = vec;
            int i, j;
            double a;

            int n = tmpVec.dim;
            for (j = 1; j < n; j++)                                    //依次挑出每个元素
            {
                a = tmpVec[j];
                i = j;
                while (i > 0 && tmpVec[i - 1] > a)                       //寻找插入的元素
                {
                    tmpVec[i] = tmpVec[i - 1];
                    i--;
                }
                tmpVec[i] = a;                                  //将其插入
            }

            return tmpVec;
        }


        public static void sort(ref Vector arr)
        {
            const int M = 7, NSTACK = 50;
            int i, ir, j, k, jstack = -1, l = 0;
            double a;
            int[] istack = new int[NSTACK];

            int n = arr.dim;
            ir = n - 1;
            for (; ; )                                                                 //当子数组足够小时插入排序
            {
                if (ir - l < M)
                {
                    for (j = l + 1; j <= ir; j++)
                    {
                        a = arr[j];
                        for (i = j - 1; i >= l; i--)
                        {
                            if (arr[i] <= a)
                            {
                                break;
                            }
                            arr[i + 1] = arr[i];
                        }
                        arr[i + 1] = a;
                    }
                    if (jstack < 0)
                    {
                        break;
                    }
                    ir = istack[jstack--];                                                //弹出堆栈并开始新一轮划分
                    l = istack[jstack--];
                }
                else
                {
                    k = (l + ir) >> 1;                                                    //挑选左、中、右三元素的中值作为划分元素a
                    SWAP(ref arr.ele[k], ref arr.ele[l + 1]);                             //同时重新排列以使a[l]<=a[l+1]<=a[ir]
                    if (arr[l] > arr[ir])
                    {
                        SWAP(ref arr.ele[l], ref arr.ele[ir]);
                    }
                    if (arr[l + 1] > arr[ir])
                    {
                        SWAP(ref arr.ele[l + 1], ref arr.ele[ir]);
                    }
                    if (arr[l] > arr[l + 1])
                    {
                        SWAP(ref arr.ele[l], ref arr.ele[l + 1]);
                    }
                    i = l + 1;                                                              //为划分初始化指针
                    j = ir;
                    a = arr[l + 1];                                                         //划分元素
                    for (; ; )                                                               //开始内循环。
                    {
                        do i++; while (arr[i] < a);                                         //从数组首部向下扫描寻找元素>a
                        do j--; while (arr[j] > a);                                         //从数组尾部向上扫描寻找元素<a
                        if (j < i)                                                             //指针交汇，划分结束。
                        {
                            break;
                        }
                        SWAP(ref arr.ele[i], ref arr.ele[j]);                               //交换两个数组的元素
                    }                                                                       //结束内循环。
                    arr[l + 1] = arr[j];                                                    //在两个数组中插入划分元素
                    arr[j] = a;
                    jstack += 2;
                    //将指针压入堆栈中更大的子数组，立刻处理较小的子数组
                    if (jstack >= NSTACK)
                    {
                        Console.WriteLine("NSTACK too small in sort2.");
                    }
                    if (ir - i + 1 >= j - 1)
                    {
                        istack[jstack] = ir;
                        istack[jstack - 1] = i;
                        ir = j - 1;
                    }
                    else
                    {
                        istack[jstack] = j - 1;
                        istack[jstack - 1] = l;
                        l = i;
                    }
                }
            }
        }

        /// <summary>
        /// 快速排序法使向量arr[0.. n-1]按递增排列，而同时相应地重排数组brr[0.. n-1]。
        /// </summary>
        /// <param name="arr">向量a</param>
        /// <param name="brr">向量b</param>
        public static void sort2(ref Vector arr, ref Vector brr)
        {
            const int M = 7, NSTACK = 50;
            int i, ir, j, k, jstack = -1, l = 0;
            double a, b;
            int[] istack = new int[NSTACK];

            int n = arr.dim;
            ir = n - 1;
            for (; ; )                                                                 //当子数组足够小时插入排序
            {
                if (ir - l < M)
                {
                    for (j = l + 1; j <= ir; j++)
                    {
                        a = arr[j];
                        b = brr[j];
                        for (i = j - 1; i >= l; i--)
                        {
                            if (arr[i] <= a)
                            {
                                break;
                            }
                            arr[i + 1] = arr[i];
                            brr[i + 1] = brr[i];
                        }
                        arr[i + 1] = a;
                        brr[i + 1] = b;
                    }
                    if (jstack < 0)
                    {
                        break;
                    }
                    ir = istack[jstack--];                                                //弹出堆栈并开始新一轮划分
                    l = istack[jstack--];
                }
                else
                {
                    k = (l + ir) >> 1;                                                    //挑选左、中、右三元素的中值作为划分元素a
                    SWAP(ref arr.ele[k], ref arr.ele[l + 1]);                             //同时重新排列以使a[l]<=a[l+1]<=a[ir]
                    SWAP(ref brr.ele[k], ref brr.ele[l + 1]);
                    if (arr[l] > arr[ir])
                    {
                        SWAP(ref arr.ele[l], ref arr.ele[ir]);
                        SWAP(ref brr.ele[l], ref brr.ele[ir]);
                    }
                    if (arr[l + 1] > arr[ir])
                    {
                        SWAP(ref arr.ele[l + 1], ref arr.ele[ir]);
                        SWAP(ref brr.ele[l + 1], ref brr.ele[ir]);
                    }
                    if (arr[l] > arr[l + 1])
                    {
                        SWAP(ref arr.ele[l], ref arr.ele[l + 1]);
                        SWAP(ref brr.ele[l], ref brr.ele[l + 1]);
                    }
                    i = l + 1;                                                              //为划分初始化指针
                    j = ir;
                    a = arr[l + 1];                                                         //划分元素
                    b = brr[l + 1];
                    for (; ; )                                                               //开始内循环。
                    {
                        do i++; while (arr[i] < a);                                         //从数组首部向下扫描寻找元素>a
                        do j--; while (arr[j] > a);                                         //从数组尾部向上扫描寻找元素<a
                        if (j < i)                                                             //指针交汇，划分结束。
                        {
                            break;
                        }
                        SWAP(ref arr.ele[i], ref arr.ele[j]);                               //交换两个数组的元素
                        SWAP(ref brr.ele[i], ref brr.ele[j]);
                    }                                                                       //结束内循环。
                    arr[l + 1] = arr[j];                                                    //在两个数组中插入划分元素
                    arr[j] = a;
                    brr[l + 1] = brr[j];
                    brr[j] = b;
                    jstack += 2;
                    //将指针压入堆栈中更大的子数组，立刻处理较小的子数组
                    if (jstack >= NSTACK)
                    {
                        Console.WriteLine("NSTACK too small in sort2.");
                    }
                    if (ir - i + 1 >= j - 1)
                    {
                        istack[jstack] = ir;
                        istack[jstack - 1] = i;
                        ir = j - 1;
                    }
                    else
                    {
                        istack[jstack] = j - 1;
                        istack[jstack - 1] = l;
                        l = i;
                    }
                }
            }
        }



    }
}
