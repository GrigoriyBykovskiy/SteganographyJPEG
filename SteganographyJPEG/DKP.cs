using System;

namespace SteganographyJPEG
{
    public static class DKP
    {
        public static double[,] Dkp(byte[,] one)
        {
            int n = one.GetLength(0);
            double[,] two = new double[n, n];
            double U;
            double V;
            double temp;
            for (int v = 0; v < n; v++)
            {
                for (int u = 0; u < n; u++)
                {
                    if (v == 0) V = 1.0 / Math.Sqrt(2);
                    else V = 1;
                    if (u == 0) U = 1.0 / Math.Sqrt(2);
                    else U = 1;
                    temp = 0;
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            temp += one[i, j] * Math.Cos(Math.PI * v * (2 * i + 1) / (2 * n)) *
                                Math.Cos(Math.PI * u * (2 * j + 1) / (2 * n));
                        }
                    }
                    two[v, u] = U * V * temp / (Math.Sqrt(2 * n));
                }
            }
            return two;
        }
        public static double[,] Odkp(double[,] one)
        {
            int n = one.GetLength(0);
            double[,] two = new double[n, n];
            double U;
            double V; 
            double temp;
            for (int v = 0; v < n; v++)
            {
                for (int u = 0; u < n; u++)
                {
                    temp = 0;
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (i == 0) V = 1.0 / Math.Sqrt(2);
                            else V = 1;
                            if (j == 0) U = 1.0 / Math.Sqrt(2);
                            else U = 1;
                            temp += U * V * one[i, j] * Math.Cos(Math.PI * i * (2 * v + 1) / (2 * n)) *
                                Math.Cos(Math.PI * j * (2 * u + 1) / (2 * n));
                        }
                    }
                    two[v, u] = temp / (Math.Sqrt(2 * n));
                }
            }
            return two;
        }


        public static double[,] CoefficientChange(double[,] temp, char/*int*/ i, int u1, int v1, int u2, int v2, int P)
        {
            /*
             double - матрица коэффициентов
             i - бит нашего сообщения (0 или 1)
             u,v - координаты коэффициентов
             */


            //double[,] two = new double[one.GetLength(0), one.GetLength(1)];
            //for (int k = 0; k < two.GetLength(0); k++)
            //    for (int l = 0; l < two.GetLength(1); l++)
            //        two[k, l] = one[k, l];
            double Abs1, Abs2;
            double z1 = 0, z2 = 0;
            Abs1 = Math.Abs(temp[u1, v1]);
            Abs2 = Math.Abs(temp[u2, v2]);
            if (temp[u1, v1] >= 0) z1 = 1;
            else z1 = -1;
            if (temp[u2, v2] >= 0) z2 = 1;
            else z2 = -1;
 
            if (i == '0')//if (i == 0)
            {
                if (Abs1 - Abs2 <= P)
                    Abs1 = P + Abs2 + 1;
            }
            if (i == '1')//if (i == 1)
            {
                if (Abs1 - Abs2 >= -P)
                    Abs2 = P + Abs1 + 1;
            }
            temp[u1, v1] = z1 * Abs1;
            temp[u2, v2] = z2 * Abs2;
            return temp;
        }
    }
}
