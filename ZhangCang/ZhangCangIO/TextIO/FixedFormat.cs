using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhangCang.LinearAlgebra;

namespace ZhangCang.ZhangCangIO.TextIO
{
    public static class FixedFormat
    {
        public static void Matrix2TextO(double[,] matrix, ref StringBuilder sb)
        {
            int row=matrix.GetLength(0);
            int col=matrix.GetLength(1);

            int block = (int)Math.Floor(Convert.ToDouble(row) / 5);
            int remainder = row % 5;
            int column = col;

            int i, j, k;

            for(i=0; i <= block; i++)
            {
                if(i!=block)
                {
                    sb.Append((i * 5 + 1).ToString().PadLeft(21) + (i * 5 + 2).ToString().PadLeft(11)
                        + (i * 5 + 3).ToString().PadLeft(11) + (i * 5 + 4).ToString().PadLeft(11) + (i * 5 + 5).ToString().PadLeft(11) + "\n");
                    for (j = i*5; j <column; j++)
                    {
                        sb.Append((j + 1).ToString().PadLeft(6) + matrix[i * 5, j].ToString("f6").PadLeft(15));
                        for(k= i * 5 + 1; k < i * 5 + 5; k++)
                        {
                            if(k<=j)
                            {
                                sb.Append(matrix[k, j].ToString("f6").PadLeft(11));
                            }                            
                        }
                        sb.Append("\n");
                    }
                }
                else
                {
                    if(remainder!=0)
                    {
                        sb.Append((5 * block + 1).ToString().PadLeft(21));
                        for (int ii = 5 * block + 1; ii < row; ii++)
                        {
                            sb.Append((ii+1).ToString().PadLeft(11));
                        }
                        sb.Append("\n");

                        
                        for (j = 5 * block; j < row; j++)
                        {
                            sb.Append((j+1).ToString().PadLeft(6) + matrix[5 * block, j].ToString("f6").PadLeft(15));
                            for(k= 5 * block+1; k < row; k++)
                            {
                                if(k<=j)
                                {
                                    sb.Append(matrix[k, j].ToString("f6").PadLeft(11));
                                }                                                             
                            }
                            sb.Append("\n");
                        }                        
                    }
                    
                }
            }
            
        }
    }
}
