using System;

namespace KBSOnonlinear2
{
    public class Nonlinear
    {
        #region nonlinear equations f01 
        public static double F01(ref double[] solution)
        {
            double result = 0.0;
            foreach (double val in solution)
            {
                if (val > 1.0 || val < -1.0)
                {
                    Console.WriteLine("f01 input error");
                    Console.ReadKey();
                }
            }

            double sum0 = 0.0;
            double sum1 = 0.0;

            // function 1
            foreach (double val in solution)
            {
                sum0 += val * val;
            }
            result += Math.Abs(sum0 - 1.0);

            // function 2
            for (int dim = 2; dim < Parameter.Dimension; ++dim)
            {
                sum1 += solution[dim] * solution[dim];
            }

            result += Math.Abs(Math.Abs(solution[0] - solution[1]) + sum1);
            return result;
        }
        #endregion

        #region nonlinear equations f02
        public static double F02(ref double[] solution)
        {
            double result = 0.0;
            foreach (double val in solution)
            {
                if (val > 1.0 || val < -1.0)
                {
                    Console.WriteLine("f02 input error");
                    Console.ReadKey();
                }
            }

            // function 1
            result += Math.Abs(solution[0] - Math.Sin(5 * Math.PI * solution[1]));

            // function 2
            result += Math.Abs(solution[0] - solution[1]);

            return result;
        }
        #endregion

        #region nonlinear equations f03
        public static double F03(ref double[] solution)
        {
            double result = 0.0;
            foreach (double val in solution)
            {
                if (val > 1.0 || val < -1.0)
                {
                    Console.WriteLine("f03 input error");
                    Console.ReadKey();
                }
            }

            // function 1
            result += Math.Abs(solution[0] - Math.Cos(4 * Math.PI * solution[1]));

            // function 2
            result += Math.Abs(solution[0] * solution[0] + solution[1] * solution[1] - 1.0);

            return result;
        }
        #endregion

        #region nonlinear equations f04
        public static double F04(ref double[] solution)
        {
            double result = 0.0;
            foreach (double val in solution)
            {
                // -10 <= x <= 10
                if (val > 10.0 || val < -10.0)
                {
                    Console.WriteLine("f04 input error");
                    Console.ReadKey();
                }
            }

            // function 1
            result += Math.Abs(Math.Cos(2 * solution[0]) - Math.Cos(2 * solution[1]) - 0.4);

            // function 2
            result += Math.Abs(2 * (solution[1] - solution[0]) + Math.Sin(2 * solution[1]) - Math.Sin(2 * solution[0]) - 1.2);

            return result;
        }
        #endregion

        #region nonlinear equations f05
        public static double F05(ref double[] solution)
        {
            double result = 0.0;
            foreach (double val in solution)
            {
                if (val > 2.0 || val < -2.0)
                {
                    Console.WriteLine("f05 input error");
                    Console.ReadKey();
                }
            }

            // function 1
            result += Math.Abs(solution[0] - 0.25428722 - 0.18324757 * solution[3] * solution[2] * solution[8]);

            // function 2
            result += Math.Abs(solution[1] - 0.37842197 - 0.16275449 * solution[0] * solution[9] * solution[5]);

            // function 3
            result += Math.Abs(solution[2] - 0.27162577 - 0.16955071 * solution[0] * solution[1] * solution[9]);

            // function 4
            result += Math.Abs(solution[3] - 0.19807914 - 0.15585316 * solution[6] * solution[0] * solution[5]);

            // function 5
            result += Math.Abs(solution[4] - 0.44166728 - 0.19950920 * solution[6] * solution[5] * solution[2]);

            // function 6
            result += Math.Abs(solution[5] - 0.14654113 - 0.18922793 * solution[7] * solution[4] * solution[9]);

            // function 7
            result += Math.Abs(solution[6] - 0.42937161 - 0.21180486 * solution[1] * solution[4] * solution[7]);

            // function 8
            result += Math.Abs(solution[7] - 0.07056438 - 0.17081208 * solution[0] * solution[6] * solution[5]);

            // function 9
            result += Math.Abs(solution[8] - 0.34504906 - 0.19612740 * solution[9] * solution[5] * solution[7]);

            // function 10
            result += Math.Abs(solution[9] - 0.42651102 - 0.21466544 * solution[3] * solution[7] * solution[0]);

            return result;
        }
        #endregion

        #region nonlinear equations f06
        public static double F06(ref double[] solution)
        {
            double result = 0.0;
            foreach (double val in solution)
            {
                if (val > 1.0 || val < -1.0)
                {
                    Console.WriteLine("f06 input error");
                    Console.ReadKey();
                }
            }

            // function 1
            result += Math.Abs(solution[0] - 0.25);

            // function 2
            result += Math.Abs(solution[0] * Math.Sin(4 * Math.PI * solution[1] * solution[1]) + 0.75 * solution[0] - 0.25);

            return result;
        }
        #endregion

        #region nonlinear equations f07
        public static double F07(ref double[] solution)
        {
            double result = 0.0;
            if (solution[0] > 1.0 || solution[0] < 0.0)
            {
                // x1 \in [0, 1]
                Console.WriteLine("f07 input error (x1 error)");
                Console.ReadKey();
            }
            if (solution[1] > 0.0 || solution[1] < -10.0)
            {
                // x2 \in [-10, 0]
                Console.WriteLine("f07 input error (x2 error)");
                Console.ReadKey();
            }

            // function 1
            result += Math.Abs(solution[0] * solution[0] - solution[1] - 2.0);

            // function 2
            result += Math.Abs(solution[0] + Math.Sin(0.5 * Math.PI * solution[1]));

            return result;
        }
        #endregion

        #region nonlinear equations f08 
        public static double F08(ref double[] solution)
        {
            double result = 0.0;
            foreach (double val in solution)
            {
                if (val > 1.0 || val < 0.0)
                {
                    Console.WriteLine("f08 input error");
                    Console.ReadKey();
                }
            }

            // function 1
            result += Math.Abs(0.04 * (((11.0 / 15.0) - solution[0])
                * Math.Exp((10.0 * solution[0]) / (1.0 + 0.01 * solution[0])))
                - solution[0]);

            // function 2
            result += Math.Abs(0.04 * ((2.2 - 2.0 * solution[0] - 3.0 * solution[1])
                * Math.Exp((10.0 * solution[1]) / (1.0 + 0.01 * solution[1])))
                + solution[0] - 3.0 * solution[1]);

            return result;
        }
        #endregion

        #region nonlinear equations f09
        public static double F09(ref double[] solution)
        {
            double result = 0.0;
            foreach (double val in solution)
            {
                if (val > 10.0 || val < -10.0)
                {
                    Console.WriteLine("f09 input error");
                    Console.ReadKey();
                }
            }

            // function 1
            result += Math.Abs(2 * solution[0] + solution[1] + solution[2] + solution[3] + solution[4] - 6.0);

            // function 2
            result += Math.Abs(solution[0] + 2 * solution[1] + solution[2] + solution[3] + solution[4] - 6.0);

            // function 3
            result += Math.Abs(solution[0] + solution[1] + 2 * solution[2] + solution[3] + solution[4] - 6.0);

            // function 4
            result += Math.Abs(solution[0] + solution[1] + solution[2] + 2 * solution[3] + solution[4] - 6.0);

            // function 5
            result += Math.Abs(solution[0] * solution[1] * solution[2] * solution[3] * solution[4] - 1.0);

            return result;
        }
        #endregion

        #region nonlinear equations f10
        public static double F10(ref double[] solution)
        {
            double result = 0.0;
            foreach (double val in solution)
            {
                if (val < -5.0 || val > 5.0)
                {
                    Console.WriteLine("f10 input error");
                    Console.ReadKey();
                }
            }
            if (solution[1] < -1.0 || solution[1] > 3.0)
            {
                // x2 \in [-1, 3]
                Console.WriteLine("f10 input error (x2 error)");
                Console.ReadKey();
            }

            // function 1
            result += Math.Abs(3 * solution[0] * solution[0] + Math.Sin(solution[0] * solution[1])
                - solution[2] * solution[2] + 2.0);

            // function 2
            result += Math.Abs(2 * solution[0] * solution[0] * solution[0] - solution[1] * solution[1]
                - solution[2] + 3.0);

            // function 3
            result += Math.Abs(Math.Sin(2 * solution[0]) + Math.Cos(solution[1] * solution[2])
                + solution[1] - 1.0);

            return result;
        }
        #endregion

        #region nonlinear equations f11
        public static double F11(ref double[] solution)
        {
            double result = 0.0;
            if (solution[0] > 1.0 || solution[0] < -1.0)
            {
                // x1 \in [-1, 1]
                Console.WriteLine("f11 input error (x1 error)");
                Console.ReadKey();
            }
            if (solution[1] > 10.0 || solution[1] < -10.0)
            {
                // x2 \in [-10, 10]
                Console.WriteLine("f11 input error (x2 error)");
                Console.ReadKey();
            }

            // function 1
            result += Math.Abs(solution[0] * solution[0] - Math.Abs(solution[1])
                + 1.0 + (Math.Abs(solution[0] - 1.0) / 9.0));

            // function 2
            result += Math.Abs(solution[1] * solution[1] + 5 * solution[0] * solution[0]
                - 7.0 + Math.Abs(solution[1] / 9.0));

            return result;
        }
        #endregion

        #region nonlinear equations f12
        public static double F12(ref double[] solution)
        {
            double result = 0.0;
            foreach (double val in solution)
            {
                if (val > 2.0 || val < -2.0)
                {
                    Console.WriteLine("f12 input error");
                    Console.ReadKey();
                }
            }

            // function 1
            result += Math.Abs(Math.Sin(solution[0] * solution[0] * solution[0])
                - 3.0 * solution[0] * solution[1] * solution[1] - 1.0);

            // function 2
            result += Math.Abs(Math.Cos(3.0 * solution[0] * solution[0] * solution[1])
                - Math.Abs(solution[1] * solution[1] * solution[1]) + 1.0);

            return result;
        }
        #endregion

        #region nonlinear equations f13
        public static double F13(ref double[] solution)
        {
            double result = 0.0;
            if (solution[0] > 6.0 || solution[0] < -0.6)
            {
                // x1 \in [-1, 1]
                Console.WriteLine("f13 input error (x1 error)");
                Console.ReadKey();
            }
            if (solution[1] > 0.6 || solution[1] < -0.6)
            {
                // x2 \in [-10, 10]
                Console.WriteLine("f13 input error (x2 error)");
                Console.ReadKey();
            }
            if (solution[2] > 5.0 || solution[2] < -5.0)
            {
                // x2 \in [-10, 10]
                Console.WriteLine("f13 input error (x3 error)");
                Console.ReadKey();
            }

            // function 1
            result += Math.Abs(5.0 * Math.Pow(solution[0], 9.0)
                - 6.0 * Math.Pow(solution[0], 5.0) * solution[1] * solution[1]
                + solution[0] * Math.Pow(solution[1], 4.0)
                + 2.0 * solution[0] * solution[2]);

            // function 2
            result += Math.Abs(2.0 * solution[0] * solution[0] * Math.Pow(solution[1], 3.0)
                - 2.0 * Math.Pow(solution[0], 6.0) * solution[1]
                + 2.0 * solution[1] * solution[2]);

            // function 3
            result += Math.Abs(solution[0] * solution[0] + solution[1] * solution[1] - 0.265625);
            return result;
        }
        #endregion

        #region nonlinear equations f14
        public static double F14(ref double[] solution)
        {
            double result = 0.0;
            foreach (double val in solution)
            {
                if (val > 5.0 || val < -5.0)
                {
                    Console.WriteLine("f14 input error");
                    Console.ReadKey();
                }
            }

            // function 1
            result += Math.Abs(4.0 * solution[0] * solution[0] * solution[0]
                + 4.0 * solution[0] * solution[1] + 2.0 * solution[1] * solution[1]
                - 42.0 * solution[0] - 14.0);

            // function 2
            result += Math.Abs(4.0 * solution[1] * solution[1] * solution[1]
                + 2.0 * solution[0] * solution[0] + 4.0 * solution[0] * solution[1]
                - 26.0 * solution[1] - 22.0);

            return result;
        }
        #endregion

        #region nonlinear equations f15 
        public static double F15(ref double[] solution)
        {
            double result = 0.0;
            if (solution[0] > 1.0 || solution[0] < 0.25)
            {
                // x1 \in [0.25, 1.0]
                Console.WriteLine("f15 input error (x1 error)");
                Console.ReadKey();
            }
            if (solution[1] > 2.0 * Math.PI || solution[1] < 1.5)
            {
                // x2 \in [1.5, 2 * PI]
                Console.WriteLine("f15 input error (x2 error)");
                Console.ReadKey();
            }

            // function 1
            result += Math.Abs(0.5 * Math.Sin(solution[0] * solution[1])
                - 0.25 / Math.PI * solution[1] - 0.5 * solution[0]);

            // function 2
            result += Math.Abs((1 - (0.25 / Math.PI)) * (Math.Exp(2.0 * solution[0]) - Math.E)
                + (Math.E / Math.PI) * solution[1] - 2.0 * Math.E * solution[0]);

            return result;
        }
        #endregion

        #region nonlinear equations f16
        public static double F16(ref double[] solution)
        {
            double result = 0.0;
            foreach (double val in solution)
            {
                if (val > 2.0 * Math.PI || val < 0.0)
                {
                    Console.WriteLine("f16 input error");
                    Console.ReadKey();
                }
            }

            // function 1
            result += Math.Abs(-Math.Sin(solution[0]) * Math.Cos(solution[1])
                - 2.0 * Math.Cos(solution[0]) * Math.Sin(solution[1]));

            // function 2
            result += Math.Abs(-Math.Cos(solution[0]) * Math.Sin(solution[1])
                - 2.0 * Math.Sin(solution[0]) * Math.Cos(solution[1]));

            return result;
        }
        #endregion

        #region nonlinear equations f17
        public static double F17(ref double[] solution)
        {
            double result = 0.0;
            foreach (double val in solution)
            {
                if (val > 1.0 || val < -1.0)
                {
                    Console.WriteLine("f17 input error");
                    Console.ReadKey();
                }
            }

            // function 1
            result += Math.Abs(solution[0] * solution[0] + solution[1] * solution[1] - 1.0);

            // function 2
            result += Math.Abs(solution[2] * solution[2] + solution[3] * solution[3] - 1.0);

            // function 3
            result += Math.Abs(solution[4] * solution[4] + solution[5] * solution[5] - 1.0);

            // function 4
            result += Math.Abs(solution[6] * solution[6] + solution[7] * solution[7] - 1.0);

            // function 5
            result += Math.Abs(4.731 * 0.001 * solution[0] * solution[2] - 0.3578 * solution[1] * solution[2]
                - 0.1238 * solution[0] + solution[6] - 1.637 * 0.001 * solution[1]
                - 0.9338 * solution[3] - 0.3571);

            // function 6
            result += Math.Abs(0.2238 * solution[0] * solution[2] + 0.7623 * solution[1] * solution[2]
                + 0.2638 * solution[0] - solution[6] - 0.07745 * solution[1]
                - 0.6734 * solution[3] - 0.6022);

            // function 7
            result += Math.Abs(solution[5] * solution[7] + 0.3578 * solution[0]
               + 4.731 * 0.001 * solution[1]);

            // function 8
            result += Math.Abs(-0.7623 * solution[0] + 0.2238 * solution[1] + 0.3461);

            return result;
        }
        #endregion

        #region nonlinear equations f18
        public static double F18(ref double[] solution)
        {
            double result = 0.0;
            foreach (double val in solution)
            {
                if (val > 2.0 || val < -2.0)
                {
                    Console.WriteLine("f18 input error");
                    Console.ReadKey();
                }
            }

            // function 1
            result += Math.Abs(4.0 * solution[0] * solution[0] * solution[0]
                - 3.0 * solution[0] - Math.Cos(solution[1]));

            // function 2
            result += Math.Abs(Math.Sin(solution[0] * solution[0]) - Math.Abs(solution[1]));

            return result;
        }
        #endregion


        #region nonlinear equations f19
        public static double F19(ref double[] solution)
        {
            double result = 0.0;
            foreach (double val in solution)
            {
                if (val > 2.0 || val < -2.0)
                {
                    Console.WriteLine("f19 input error");
                    Console.ReadKey();
                }
            }

            double sum = 0.0;
            double product = 1.0;

            foreach (double val in solution)
            {
                sum += val;
                product *= val;
            }

            // function 1~19
            for (int dim = 0; dim < Parameter.Dimension - 1; ++dim)
            {
                result += Math.Abs(solution[dim] + sum - 21.0);
            }

            // function 20
            result += Math.Abs(product - 1.0);

            return result;            
        }
        #endregion

        #region nonlinear equations f20
        public static double F20(ref double[] solution)
        {
            double result = 0.0;
            foreach (double val in solution)
            {
                if (val > 1.0 || val < -1.0)
                {
                    Console.WriteLine("f20 input error");
                    Console.ReadKey();
                }
            }

            // function 1
            result += Math.Abs(solution[0] - Math.Cos(solution[0] - solution[1] - solution[2]));

            // function 2
            result += Math.Abs(solution[1] - Math.Cos(solution[1] - solution[0] - solution[2]));

            // function 3
            result += Math.Abs(solution[2] - Math.Cos(solution[2] - solution[0] - solution[1]));

            return result;
        }
        #endregion

        #region nonlinear equations f21
        public static double F21(ref double[] solution)
        {
            double result = 0.0;
            foreach (double val in solution)
            {
                if (val > 2.0 || val < -2.0)
                {
                    Console.WriteLine("f21 input error");
                    Console.ReadKey();
                }
            }
            // function 1
            result += Math.Abs(solution[0] * solution[0] + solution[1] * solution[1] - 2.0);

            // function 2
            result += Math.Abs(solution[0] * solution[0] + 0.25 * solution[1] * solution[1] - 1.0);

            return result;
        }
        #endregion

        #region nonlinear equations f22 
        public static double F22(ref double[] solution)
        {
            double result = 0.0;
            foreach (double val in solution)
            {
                if (val > 2.0 || val < -2.0)
                {
                    Console.WriteLine("f22 input error");
                    Console.ReadKey();
                }
            }

            // function 1
            result += Math.Abs(Math.Exp(solution[0] * solution[0] + solution[1] * solution[1]) - 3.0);

            // function 2
            result += Math.Abs(Math.Abs(solution[1]) + solution[0]
                - Math.Sin(3.0 * (Math.Abs(solution[1]) + solution[0])));

            return result;
        }
        #endregion

        #region nonlinear equations f23
        public static double F23(ref double[] solution)
        {
            double result = 0.0;
            foreach (double val in solution)
            {
                if (val > 20.0 || val < -20.0)
                {
                    Console.WriteLine("f23 input error");
                    Console.ReadKey();
                }
            }

            // function 1
            result += Math.Abs(-13.0 - solution[1] * solution[1] - solution[2] * solution[2]
                + 24.0 * solution[1] * solution[2]
                - solution[1] * solution[1] * solution[2] * solution[2]);

            // function 2
            result += Math.Abs(-13.0 - solution[2] * solution[2] - solution[0] * solution[0]
                + 24.0 * solution[2] * solution[0]
                - solution[2] * solution[2] * solution[0] * solution[0]);

            // function 3
            result += Math.Abs(-13.0 - solution[0] * solution[0] - solution[1] * solution[1]
                + 24.0 * solution[0] * solution[1]
                - solution[0] * solution[0] * solution[1] * solution[1]);

            return result;
        }
        #endregion

        #region nonlinear equations f24
        public static double F24(ref double[] solution)
        {
            double result = 0.0;
            foreach (double val in solution)
            {
                if (val > 1.0 || val < 0.0)
                {
                    Console.WriteLine("f24 input error");
                    Console.ReadKey();
                }
            }

            // function 1
            result += Math.Abs(-3.84 * solution[0] * solution[0]
                + 3.84 * solution[0] - solution[1]);

            // function 2
            result += Math.Abs(-3.84 * solution[1] * solution[1]
                + 3.84 * solution[1] - solution[2]);

            // function 3
            result += Math.Abs(-3.84 * solution[2] * solution[2]
                + 3.84 * solution[2] - solution[0]);

            return result;
        }
        #endregion

        #region nonlinear equations f25
        public static double F25(ref double[] solution)
        {
            double result = 0.0;
            foreach (double val in solution)
            {
                if (val > 3.0 || val < -3.0)
                {
                    Console.WriteLine("f25 input error");
                    Console.ReadKey();
                }
            }

            double u = 3 * solution[0] + solution[1] - solution[2];
            double v = solution[0] * solution[0] - solution[1] + solution[2];
            // function 1
            result += Math.Abs(3.0 * u * u + 2.0 * v - 3.0 * solution[0]
                + solution[0] * solution[1] + solution[2] * solution[2] - 24.0);

            // function 2
            result += Math.Abs(u - 3.0 * v * v - solution[0]
                + 2 * solution[1] - solution[0] * solution[2] + 10.00);

            // function 3
            result += Math.Abs(2.0 * u - v + solution[0]
                - solution[1] * solution[1] + 2.0 * solution[2] - 5.0);

            return result;
        }
        #endregion

        #region nonlinear equations f26
        public static double F26(ref double[] solution)
        {
            double result = 0.0;
            if (solution[0] > -0.1 || solution[0] < -1.0)
            {
                Console.WriteLine("f26 input error (x1 error)");
                Console.ReadKey();
            }
            if (solution[1] > 2.0 || solution[1] < -2.0)
            {
                Console.WriteLine("f26 input error (x2 error)");
                Console.ReadKey();
            }

            // function 1
            result += Math.Abs(solution[0] * solution[0] * solution[0]
                - 3.0 * solution[0] * solution[1] * solution[1] - 1.0);

            // function 2
            result += Math.Abs(3.0 * solution[0] * solution[0] * solution[1]
                - solution[1] * solution[1] * solution[1] + 1.0);

            return result;
        }
        #endregion

        #region nonlinear equations f27
        public static double F27(ref double[] solution)
        {
            double result = 0.0;
            if (solution[0] > 1.5 || solution[0] < -5.0)
            {
                Console.WriteLine("f27 input error (x1 error)");
                Console.ReadKey();
            }
            if (solution[1] > 5.0 || solution[1] < 0.0)
            {
                Console.WriteLine("f27 input error (x2 error)");
                Console.ReadKey();
            }

            // function 1
            result += Math.Abs(4.0 * solution[0] * solution[0] * solution[0]
                - 3.0 * solution[0] - solution[1]);

            // function 2
            result += Math.Abs(solution[0] * solution[0] - solution[1]);

            return result;
        }
        #endregion

        #region nonlinear equations f28
        public static double F28(ref double[] solution)
        {
            double result = 0.0;
            if (solution[0] > 2.0 || solution[0] < 0.0)
            {
                Console.WriteLine("f28 input error (x1 error)");
                Console.ReadKey();
            }
            if (solution[1] > 30.0 || solution[1] < 10.0)
            {
                Console.WriteLine("f28 input error (x2 error)");
                Console.ReadKey();
            }

            // function 1
            result += Math.Abs(solution[0] * solution[0] * solution[0]
                - 3.0 * solution[0] * solution[1] * solution[1]
                + 25.0 * (2.0 * solution[0] * solution[0] + solution[0] * solution[1])
                + solution[1] * solution[1] + 2.0 * solution[0] + 3.0 * solution[1]);

            // function 2
            result += Math.Abs(3.0 * solution[0] * solution[0] * solution[1]
                - solution[1] * solution[1] * solution[1]
                - 25.0 * (4.0 * solution[0] * solution[1] - solution[1] * solution[1])
                + 4.0 * solution[0] * solution[0] + 5.0);

            return result;
        }
        #endregion

        #region nonlinear equations f29 
        public static double F29(ref double[] solution)
        {
            double result = 0.0;
            if (solution[0] > 2.0 || solution[0] < 0.0)
            {
                Console.WriteLine("f29 input error (x1 error)");
                Console.ReadKey();
            }
            if (solution[1] > 10.0 || solution[1] < -10.0)
            {
                Console.WriteLine("f29 input error (x2 error)");
                Console.ReadKey();
            }
            if (solution[2] > 1.0 || solution[2] < -1.0)
            {
                Console.WriteLine("f29 input error (x3 error)");
                Console.ReadKey();
            }

            // function 1
            result += Math.Abs(solution[0] * solution[0] - solution[0] - solution[1] * solution[1] - solution[1]
                + solution[2] * solution[2]);

            // function 2
            result += Math.Abs(Math.Sin(solution[1] - Math.Exp(solution[0])));

            // function 3
            result += Math.Abs(solution[2] - Math.Log(Math.Abs(solution[1])));

            return result;
        }
        #endregion

        #region nonlinear equations f30
        public static double F30(ref double[] solution)
        {
            double result = 0.0;
            if (solution[0] > 2.0 || solution[0] < -2.0)
            {
                Console.WriteLine("f30 input error (x1 error)");
                Console.ReadKey();
            }
            if (solution[1] > 1.1 || solution[1] < 0.0)
            {
                Console.WriteLine("f30 input error (x2 error)");
                Console.ReadKey();
            }


            // function 1
            result += Math.Abs(Math.Pow(solution[0], 4.0) + 4 * Math.Pow(solution[1], 4.0) - 6.0);

            // function 2
            result += Math.Abs(solution[0] * solution[0] * solution[1] - 0.6787);

            return result;
        }
        #endregion
    }
}