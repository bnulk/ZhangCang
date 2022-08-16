using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhangCang.LinearAlgebra
{
    public class LineEquation
    {
        public LineEquation(double[] a, int n, double[] b)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// a是输入矩阵。b为包含m个右端向量的输入矩阵。n为维数。输出时，a被其逆矩阵代替，b为相应的解向量代替
        /// </summary>
        /// <param name="a"></param>
        /// <param name="n"></param>
        /// <param name="b"></param>
		public static void gaussj(ref double[] a, int n, ref double[] b)
        {
            int i, j, k, l, ll, irow = 0, icol = 0;
            double big, pivinv, dum;
            int[] ipiv = new int[n + 50];
            int[] indxr = new int[n + 50];
            int[] indxc = new int[n + 50];
            for (j = 0; j <= n - 1; j++)
            {
                ipiv[j] = 0;
            }
            for (i = 0; i <= n - 1; i++)
            {
                big = 0.0;
                for (j = 0; j <= n - 1; j++)
                {
                    if (ipiv[j] != 1)
                    {
                        for (k = 0; k <= n - 1; k++)
                        {
                            if (ipiv[k] == 0)
                            {
                                if (Math.Abs(a[j * n + k]) >= big)
                                {
                                    big = Math.Abs(a[j * n + k]);
                                    irow = j;
                                    icol = k;
                                }
                                else if (ipiv[k] > 1)
                                {
                                    Console.WriteLine("ChemKun.MECP.Opter.LagrangeNewton_Zmatrix.CalGaussJordan died. Error. singular matrix in gaussj process. :: Site 1");
                                }
                            }
                        }
                    }
                }
                ipiv[icol] = ipiv[icol] + 1;
                if (irow != icol)
                {
                    for (l = 0; l <= n - 1; l++)
                    {
                        dum = (a[irow * n + l]);
                        a[irow * n + l] = a[icol * n + l];
                        a[icol * n + l] = dum;
                    }
                    dum = b[irow];
                    b[irow] = b[icol];
                    b[icol] = dum;
                }
                indxr[i] = irow;
                indxc[i] = icol;
                if (a[icol * n + icol] == 0.0)
                {
                    Console.WriteLine("ChemKun.MECP.Opter.LagrangeNewton_Zmatrix.CalGaussJordan died. Error. singular matrix in gaussj process. :: Site 2" + "/n");
                }
                pivinv = 1.0 / (a[icol * n + icol]);
                a[icol * n + icol] = 1.0;
                for (l = 0; l <= n - 1; l++)
                {
                    a[icol * n + l] = a[icol * n + l] * pivinv;
                }
                b[icol] = b[icol] * pivinv;
                for (ll = 0; ll <= n - 1; ll++)
                {
                    if (ll != icol)
                    {
                        dum = a[ll * n + icol];
                        a[ll * n + icol] = 0.0;
                        for (l = 0; l <= n - 1; l++)
                        {
                            a[ll * n + l] = a[ll * n + l] - a[icol * n + l] * dum;
                        }
                        b[ll] = b[ll] - b[icol] * dum;
                    }
                }
            }
            for (l = n - 1; l >= 0; l--)
            {
                if (indxr[l] != indxc[l])
                {
                    for (k = 0; k <= n - 1; k++)
                    {
                        dum = a[k * n + indxr[l]];
                        a[k * n + indxr[l]] = a[k * n + indxc[l]];
                        a[k * n + indxc[l]] = dum;
                    }
                }
            }
        }


    }
}
