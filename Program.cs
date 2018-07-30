using System;

namespace QuantFinance
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double result = BlackScholes("Put", 100, 80, 0, 0.05, 2, 0.3);
            Console.Write(result);

        }

        protected static double BlackScholes(String CallOrPut, double S, double K, double div, double r, double T, double sigma)
        {
            int sign;
            double d1 = 0.0;
            double d2 = 0.0;
            CallOrPut = CallOrPut.ToLower();
            sign = CallOrPut.Equals("call") ? 1 : -1 ;

            d1 = (Math.Log(S / K) + (r - div + sigma * sigma / 2) * T) / (sigma * Math.Sqrt(T));
            d2 = d1 - sigma * Math.Sqrt(T);

            return sign * S * Math.Exp(-div * T) * StandardNormalCDF(sign * d1) - sign * K * Math.Exp(-r * T) * StandardNormalCDF(sign * d2);

        }

        protected static double StandardNormalCDF(double x)
        {
            // calculate Standard Normal CDF
            // Using the computation method from 
            // https://www.johndcook.com/blog/python_phi/

            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;
            double t;
            double y;
            int sign = (x < 0) ? -1 : 1;

            x = Math.Abs(x) / Math.Sqrt(2.0);
            t = 1.0 / (1.0 + p * x);
            y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2)*t +a1) * t * Math.Exp(-x * x);

            return 0.5 * (1.0 + sign * y);
        }



    }




}
