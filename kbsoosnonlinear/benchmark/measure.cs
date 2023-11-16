using System;

namespace KBSOnonlinear2
{
    public class Measure
    {
        static int global = 0;
        public static bool flag = false;

        static int count = 0;
        static double epsilon = 1.0E-06; // dim <= 5
        static double epsilon5 = 1.0E-04; // others

        static double radius = 0.001; // dim <= 5
        static double radius5 = 0.01; // others

        // 解的个数 number of solutions
        public const int n01 = 2; // f01
        public const int n02 = 11; // f02
        public const int n03 = 15; // f03
        public const int n04 = 13; // f04
        public const int n05 = 1; // f05
        public const int n06 = 8; // f06
        public const int n07 = 3; // f07
        public const int n08 = 7; // f08
        public const int n09 = 3; // f09
        public const int n10 = 2; // f10
        public const int n11 = 4; // f11
        public const int n12 = 10; // f12
        public const int n13 = 12; // f13
        public const int n14 = 9; // f14
        public const int n15 = 2; // f15
        public const int n16 = 13; // f16
        public const int n17 = 16; // f17
        public const int n18 = 6; // f18
        public const int n19 = 2; // f19
        public const int n20 = 7; // f20
        public const int n21 = 4; // f21
        public const int n22 = 6; // f22
        public const int n23 = 16; // f23
        public const int n24 = 8; // f24
        public const int n25 = 2; // f25
        public const int n26 = 2; // f26
        public const int n27 = 3; // f27
        public const int n28 = 2; // f28
        public const int n29 = 5; // f29
        public const int n30 = 4; // f30

        public static double diversity = 0.0; // diversity 指标，判断解集合的分布

        #region f01: nonlinear function f01
        public static int F01(ref double[,] archive)
        {
            global = n01;
            double radius = radius5; // 20
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            count = 0;
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;


            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    real[ind, dim] = 0.0;
                }
                real[0, 0] = -0.707107;
                real[0, 1] = -0.707107;

                real[1, 0] = 0.707107;
                real[1, 1] = 0.707107;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    //Console.WriteLine(archive[j, i]);
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReachF01(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }

                }
                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }
                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }

            #endregion

            if (count == global) flag = true;

            // Console.WriteLine("count is {0}", count);
            return count;
        }
        #endregion

        #region f02: nonlinear function f02
        public static int F02(ref double[,] archive)
        {
            global = n02;
            double radius = Measure.radius; // 2
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = -0.924840;
                real[0, 1] = -0.924840;

                real[1, 0] = -0.866760;
                real[1, 1] = -0.866760;

                real[2, 0] = -0.562010;
                real[2, 1] = -0.562010;

                real[3, 0] = -0.428168;
                real[3, 1] = -0.428168;

                real[4, 0] = -0.187960;
                real[4, 1] = -0.187960;

                real[5, 0] = 0.000000;
                real[5, 1] = 0.000000;

                real[6, 0] = 0.187960;
                real[6, 1] = 0.187960;

                real[7, 0] = 0.428168;
                real[7, 1] = 0.428168;

                real[8, 0] = 0.562010;
                real[8, 1] = 0.562010;

                real[9, 0] = 0.866760;
                real[9, 1] = 0.866760;

                real[10, 0] = 0.924840;
                real[10, 1] = 0.924840;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    //Console.WriteLine(archive[j, i]);
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion

            if (count == global)
            {
                flag = true;
                // Console.WriteLine("%% All solutions, success rate true %%");
            }

            return count;
        }
        #endregion

        #region f03: nonlinear function f03
        public static int F03(ref double[,] archive)
        {
            global = n03;
            double radius = Measure.radius; // 2
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = 0.416408;
                real[0, 1] = -0.909178;

                real[1, 0] = -0.561364;
                real[1, 1] = -0.827569;

                real[2, 0] = -0.724322;
                real[2, 1] = -0.689462;

                real[3, 0] = 0.837812;
                real[3, 1] = -0.545959;

                real[4, 0] = 0.886984;
                real[4, 1] = -0.461799;

                real[5, 0] = -0.962322;
                real[5, 1] = -0.271914;

                real[6, 0] = -0.972855;
                real[6, 1] = -0.231415;

                real[7, 0] = 1.000000;
                real[7, 1] = 0.000000;

                real[8, 0] = -0.972855;
                real[8, 1] = 0.231416;

                real[9, 0] = -0.962322;
                real[9, 1] = 0.271914;

                real[10, 0] = 0.886984;
                real[10, 1] = 0.461799;

                real[11, 0] = 0.837812;
                real[11, 1] = 0.545959;

                real[12, 0] = -0.724322;
                real[12, 1] = 0.689462;

                real[13, 0] = -0.561364;
                real[13, 1] = 0.827569;

                real[14, 0] = 0.416408;
                real[14, 1] = 0.909178;


                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    //Console.WriteLine(archive[j, i]);
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion

            if (count == global)
            {
                flag = true;
                // Console.WriteLine("success rate true");
            }

            return count;
        }
        #endregion

        #region f04: nonlinear function f04
        public static int F04(ref double[,] archive)
        {
            global = n04;
            double radius = Measure.radius; // 2
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = -9.268258;
                real[0, 1] = -8.931402;

                real[1, 0] = -8.744542;
                real[1, 1] = -7.164787;

                real[2, 0] = -6.126665;
                real[2, 1] = -5.789809;

                real[3, 0] = -5.602950;
                real[3, 1] = -4.023195;

                real[4, 0] = -2.985073;
                real[4, 1] = -2.648216;

                real[5, 0] = -2.461357;
                real[5, 1] = -0.881602;

                real[6, 0] = 0.156520;
                real[6, 1] = 0.493376;

                real[7, 0] = 0.680236;
                real[7, 1] = 2.259991;

                real[8, 0] = 3.298113;
                real[8, 1] = 3.634969;

                real[9, 0] = 3.821828;
                real[9, 1] = 5.401583;

                real[10, 0] = 6.439705;
                real[10, 1] = 6.776562;

                real[11, 0] = 6.963421;
                real[11, 1] = 8.543176;

                real[12, 0] = 9.581298;
                real[12, 1] = 9.918154;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    //Console.WriteLine(archive[j, i]);
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion

            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f05: nonlinear function f05
        public static int F05(ref double[,] archive)
        {
            global = n05; // n05 =1
            double radius = Measure.radius; // 2
            double[] solution = new double[Parameter.Dimension];
            double[] real = new double[Parameter.Dimension];
            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            int number = 0;

            flag = false;
            count = 0;

            // 初始化 real
            real[0] = 0.257833;
            real[1] = 0.381097;
            real[2] = 0.278745;
            real[3] = 0.200669;
            real[4] = 0.445251;
            real[5] = 0.149184;
            real[6] = 0.432010;
            real[7] = 0.073403;
            real[8] = 0.345967;
            real[9] = 0.427326;

            // 判断 第 ind 个解是否找到
            for (int atom = 0; atom < Parameter.Population; ++atom)
            {
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    solution[dim] = archive[atom, dim];
                }

                if (SolutionReach(ref real, ref solution, ref radius))
                {
                    number = 1;
                    break;
                }
            }

            count += number;

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                Console.WriteLine("error: f05 only have one solution");
                Console.ReadKey();
            }
            #endregion

            if (count == global)
            {
                flag = true;
                // Console.WriteLine("success rate true");
            }

            return count;
        }
        #endregion

        #region f06: nonlinear function f06
        public static int F06(ref double[,] archive)
        {
            global = n06; // 8
            double radius = Measure.radius; // 2
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = 0.250000;
                real[0, 1] = -0.854337;

                real[1, 0] = 0.250000;
                real[1, 1] = -0.721185;

                real[2, 0] = 0.250000;
                real[2, 1] = -0.479471;

                real[3, 0] = 0.250000;
                real[3, 1] = -0.141801;

                real[4, 0] = 0.250000;
                real[4, 1] = 0.141801;

                real[5, 0] = 0.250000;
                real[5, 1] = 0.479471;

                real[6, 0] = 0.250000;
                real[6, 1] = 0.721185;

                real[7, 0] = 0.250000;
                real[7, 1] = 0.854337;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    //Console.WriteLine(archive[j, i]);
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion

            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f07: nonlinear function f07
        public static int F07(ref double[,] archive)
        {
            global = n07; // 2
            double radius = Measure.radius; // 2
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = 0.0;
                real[0, 1] = -2.0;

                real[1, 0] = Math.Sqrt(2) / 2.0;
                real[1, 1] = -1.5;

                real[2, 0] = 1.0;
                real[2, 1] = -1.0;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        // Console.WriteLine("got 1");
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion

            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f08: nonlinear function f08
        public static int F08(ref double[,] archive)
        {
            global = n08; // 7
            double radius = Measure.radius; // 2
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = 0.042100;
                real[0, 1] = 0.061813;

                real[1, 0] = 0.042100;
                real[1, 1] = 0.268723;

                real[2, 0] = 0.266600;
                real[2, 1] = 0.178430;

                real[3, 0] = 0.266600;
                real[3, 1] = 0.327267;

                real[4, 0] = 0.266600;
                real[4, 1] = 0.461111;

                real[5, 0] = 0.042318;
                real[5, 1] = 0.686779;

                real[6, 0] = 0.719074;
                real[6, 1] = 0.244197;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion

            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f09: nonlinear function f09
        public static int F09(ref double[,] archive)
        {
            global = n09; // 3
            double radius = Measure.radius; // 5
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = 1.0;
                real[0, 1] = 1.0;
                real[0, 2] = 1.0;
                real[0, 3] = 1.0;
                real[0, 4] = 1.0;

                real[1, 0] = 0.916355;
                real[1, 1] = 0.916355;
                real[1, 2] = 0.916355;
                real[1, 3] = 0.916355;
                real[1, 4] = 1.418227;

                real[2, 0] = -0.579043;
                real[2, 1] = -0.579043;
                real[2, 2] = -0.579043;
                real[2, 3] = -0.579043;
                real[2, 4] = 8.895215;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion

            if (count == global) flag = true;
            return count;
        }
        #endregion

        #region f10: nonlinear function f10
        public static int F10(ref double[,] archive)
        {
            global = n10; // 2
            double radius = 0.1; // Measure.radius; // 3
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = -0.064417;
                real[0, 1] = 2.090440;
                real[0, 2] = -1.370473;

                real[1, 0] = -0.032759;
                real[1, 1] = 1.264629;
                real[1, 2] = 1.400644;

                // Console.WriteLine("ind is {0}", ind);

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];

                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    //if ((Nonlinear.F10(ref solution) < 1E-5) && (number[0] == 0) && (number[1] == 0))
                    //{
                    //    Console.WriteLine("here");
                    //}

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion

            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f11: nonlinear function f11
        public static int F11(ref double[,] archive)
        {
            global = n11; // 4
            double radius = Measure.radius; // 3
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = -0.814326;
                real[0, 1] = -1.864719;

                real[1, 0] = 0.861828;
                real[1, 1] = -1.758100;

                real[2, 0] = -0.814326;
                real[2, 1] = 1.864719;

                real[3, 0] = 0.861828;
                real[3, 1] = 1.758100;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion

            if (count == global) flag = true;
            return count;
        }
        #endregion

        #region f12: nonlinear function f12
        public static int F12(ref double[,] archive)
        {
            global = n12; // 9
            double radius = Measure.radius; // 3
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = -1.810885;
                real[0, 1] = -0.349092;

                real[1, 0] = -1.810885;
                real[1, 1] = 0.349092;

                real[2, 0] = -1.502221;
                real[2, 1] = -0.409077;

                real[3, 0] = -1.502221;
                real[3, 1] = 0.409077;

                real[4, 0] = -1.791302;
                real[4, 1] = 0.301926;

                real[5, 0] = -1.791302;
                real[5, 1] = -0.301926;

                real[6, 0] = -0.947268;
                real[6, 1] = 0.785020;

                real[7, 0] = -0.947268;
                real[7, 1] = -0.785020;

                real[8, 0] = -0.213057;
                real[8, 1] = 1.256845;

                real[9, 0] = -0.213057;
                real[9, 1] = -1.256845;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion

            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f13: nonlinear function f13
        public static int F13(ref double[,] archive)
        {
            global = n13; // 12
            double radius = Measure.radius; // 3
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            // 初始化 real
            real[0, 0] = 0.279855;
            real[0, 1] = 0.432789;
            real[0, 2] = -0.014189;

            real[1, 0] = 0.279855;
            real[1, 1] = -0.432789;
            real[1, 2] = -0.014189;

            real[2, 0] = -0.279855;
            real[2, 1] = 0.432789;
            real[2, 2] = -0.014189;

            real[3, 0] = -0.279855;
            real[3, 1] = -0.432789;
            real[3, 2] = -0.014189;

            real[4, 0] = 0.466980;
            real[4, 1] = 0.218070;
            real[4, 2] = 0.0;

            real[5, 0] = -0.466980;
            real[5, 1] = 0.218070;
            real[5, 2] = 0.0;

            real[6, 0] = 0.466980;
            real[6, 1] = -0.218070;
            real[6, 2] = 0.0;

            real[7, 0] = -0.466980;
            real[7, 1] = -0.218070;
            real[7, 2] = 0.0;

            real[8, 0] = 0.000000;
            real[8, 1] = 0.515388;
            real[8, 2] = 0.0;

            real[9, 0] = 0.000000;
            real[9, 1] = -0.515388;
            real[9, 2] = 0.0;

            real[10, 0] = 0.515388;
            real[10, 1] = 0.0;
            real[10, 2] = -0.012446;

            real[11, 0] = -0.515388;
            real[11, 1] = 0.0;
            real[11, 2] = -0.012446;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion

            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f14: nonlinear function f14
        public static int F14(ref double[,] archive)
        {
            global = n14; // 2
            double radius = Measure.radius; // 3
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = -0.127961;
                real[0, 1] = -1.953715;

                real[1, 0] = -0.270845;
                real[1, 1] = -0.923039;

                real[2, 0] = 0.086678;
                real[2, 1] = 2.884255;

                real[3, 0] = 3.385154;
                real[3, 1] = 0.073852;

                real[4, 0] = 3.584428;
                real[4, 1] = -1.848127;

                real[5, 0] = 3.000000;
                real[5, 1] = 2.000000;

                real[6, 0] = -3.779310;
                real[6, 1] = -3.283186;

                real[7, 0] = -3.073026;
                real[7, 1] = -0.081353;

                real[8, 0] = -2.805118;
                real[8, 1] = 3.131313;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion
            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f15: nonlinear function f15
        public static int F15(ref double[,] archive)
        {
            global = n15; // 2

            double radius = Measure.radius; // 3
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = 0.299465;
                real[0, 1] = 2.836948;

                real[1, 0] = 0.499966;
                real[1, 1] = 3.141589;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion

            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f16: nonlinear function f16
        public static int F16(ref double[,] archive)
        {
            global = n16; // 13
            double radius = Measure.radius; // 2
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = 0.000000;
                real[0, 1] = 0.000000;

                real[1, 0] = 3.141593;
                real[1, 1] = 0.000000;

                real[2, 0] = 1.570796;
                real[2, 1] = 1.570796;

                real[3, 0] = 6.283185;
                real[3, 1] = 0.000000;

                real[4, 0] = 0.000000;
                real[4, 1] = 3.141593;

                real[5, 0] = 4.712389;
                real[5, 1] = 1.570796;

                real[6, 0] = 3.141593;
                real[6, 1] = 3.141593;

                real[7, 0] = 1.570796;
                real[7, 1] = 4.712389;

                real[8, 0] = 6.283185;
                real[8, 1] = 3.141593;

                real[9, 0] = 0.000000;
                real[9, 1] = 6.283185;

                real[10, 0] = 4.712389;
                real[10, 1] = 4.712389;

                real[11, 0] = 3.141593;
                real[11, 1] = 6.283185;

                real[12, 0] = 6.283185;
                real[12, 1] = 6.283185;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion
            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f17: nonlinear function f17
        public static int F17(ref double[,] archive)
        {
            global = n17; // 16
            double radius = Measure.radius5; // 8
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = 0.1644;
                real[0, 1] = -0.9864;
                real[0, 2] = -0.9471;
                real[0, 3] = -0.3210;
                real[0, 4] = -0.9982;
                real[0, 5] = -0.0594;
                real[0, 6] = 0.4110;
                real[0, 7] = 0.9116;

                real[1, 0] = 0.1644;
                real[1, 1] = -0.9864;
                real[1, 2] = -0.9471;
                real[1, 3] = -0.3210;
                real[1, 4] = -0.9982;
                real[1, 5] = 0.0594;
                real[1, 6] = 0.4110;
                real[1, 7] = -0.9116;

                real[2, 0] = 0.1644;
                real[2, 1] = -0.9864;
                real[2, 2] = -0.9471;
                real[2, 3] = -0.3210;
                real[2, 4] = 0.9982;
                real[2, 5] = -0.0594;
                real[2, 6] = 0.4110;
                real[2, 7] = 0.9116;

                real[3, 0] = 0.1644;
                real[3, 1] = -0.9864;
                real[3, 2] = -0.9471;
                real[3, 3] = -0.3210;
                real[3, 4] = 0.9982;
                real[3, 5] = 0.0594;
                real[3, 6] = 0.4110;
                real[3, 7] = -0.9116;

                real[4, 0] = 0.1644;
                real[4, 1] = -0.9864;
                real[4, 2] = 0.7185;
                real[4, 3] = -0.6956;
                real[4, 4] = -0.9980;
                real[4, 5] = -0.0638;
                real[4, 6] = -0.5278;
                real[4, 7] = 0.8494;

                real[5, 0] = 0.1644;
                real[5, 1] = -0.9864;
                real[5, 2] = 0.7185;
                real[5, 3] = -0.6956;
                real[5, 4] = -0.9980;
                real[5, 5] = 0.0638;
                real[5, 6] = -0.5278;
                real[5, 7] = -0.8494;

                real[6, 0] = 0.1644;
                real[6, 1] = -0.9864;
                real[6, 2] = 0.7185;
                real[6, 3] = -0.6956;
                real[6, 4] = 0.9980;
                real[6, 5] = -0.0638;
                real[6, 6] = -0.5278;
                real[6, 7] = 0.8494;

                real[7, 0] = 0.1644;
                real[7, 1] = -0.9864;
                real[7, 2] = 0.7185;
                real[7, 3] = -0.6956;
                real[7, 4] = 0.9980;
                real[7, 5] = 0.0638;
                real[7, 6] = -0.5278;
                real[7, 7] = -0.8494;

                real[8, 0] = 0.6716;
                real[8, 1] = 0.7410;
                real[8, 2] = -0.6516;
                real[8, 3] = -0.7586;
                real[8, 4] = -0.9625;
                real[8, 5] = -0.2711;
                real[8, 6] = -0.4376;
                real[8, 7] = 0.8992;

                real[9, 0] = 0.6716;
                real[9, 1] = 0.7410;
                real[9, 2] = -0.6516;
                real[9, 3] = -0.7586;
                real[9, 4] = -0.9625;
                real[9, 5] = 0.2711;
                real[9, 6] = -0.4376;
                real[9, 7] = -0.8992;

                real[10, 0] = 0.6716;
                real[10, 1] = 0.7410;
                real[10, 2] = -0.6516;
                real[10, 3] = -0.7586;
                real[10, 4] = 0.9625;
                real[10, 5] = -0.2711;
                real[10, 6] = -0.4376;
                real[10, 7] = 0.8992;

                real[11, 0] = 0.6716;
                real[11, 1] = 0.7410;
                real[11, 2] = -0.6516;
                real[11, 3] = -0.7586;
                real[11, 4] = 0.9625;
                real[11, 5] = 0.2711;
                real[11, 6] = -0.4376;
                real[11, 7] = -0.8992;

                real[12, 0] = 0.6716;
                real[12, 1] = 0.7410;
                real[12, 2] = 0.9519;
                real[12, 3] = -0.3064;
                real[12, 4] = -0.9638;
                real[12, 5] = -0.2666;
                real[12, 6] = 0.4046;
                real[12, 7] = 0.9145;

                real[13, 0] = 0.6716;
                real[13, 1] = 0.7410;
                real[13, 2] = 0.9519;
                real[13, 3] = -0.3064;
                real[13, 4] = -0.9638;
                real[13, 5] = 0.2666;
                real[13, 6] = 0.4046;
                real[13, 7] = -0.9145;

                real[14, 0] = 0.6716;
                real[14, 1] = 0.7410;
                real[14, 2] = 0.9519;
                real[14, 3] = -0.3064;
                real[14, 4] = 0.9638;
                real[14, 5] = 0.2666;
                real[14, 6] = 0.4046;
                real[14, 7] = -0.9145;

                real[15, 0] = 0.6716;
                real[15, 1] = 0.7410;
                real[15, 2] = 0.9519;
                real[15, 3] = -0.3064;
                real[15, 4] = 0.9638;
                real[15, 5] = -0.2666;
                real[15, 6] = 0.4046;
                real[15, 7] = 0.9145;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion
            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f18: nonlinear function f18
        public static int F18(ref double[,] archive)
        {
            global = n18; // 2
            double radius = Measure.radius; // 3
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = -0.597167;
                real[0, 1] = -0.349098;

                real[1, 0] = -0.442758;
                real[1, 1] = -0.194781;

                real[2, 0] = -0.442758;
                real[2, 1] = 0.194781;

                real[3, 0] = -0.597167;
                real[3, 1] = 0.349098;

                real[4, 0] = 0.964499;
                real[4, 1] = -0.801774;

                real[5, 0] = 0.964499;
                real[5, 1] = 0.801774;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion
            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f19: nonlinear function f19
        public static int F19(ref double[,] archive)
        {
            global = n19; // 2
            double radius = Measure.radius5; // 3
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    real[0, dim] = 1.0;
                    real[1, dim] = 0.994922;
                }
                real[1, Parameter.Dimension - 1] = 1.101551;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion
            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f20: nonlinear function f20
        public static int F20(ref double[,] archive)
        {
            global = n20; // 2
            double radius = Measure.radius; // 3
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = 0.810561;
                real[0, 1] = 0.810561;
                real[0, 2] = -0.625687;

                real[1, 0] = 0.810561;
                real[1, 1] = -0.625687;
                real[1, 2] = 0.810561;

                real[2, 0] = -0.625687;
                real[2, 1] = 0.810561;
                real[2, 2] = 0.810561;

                real[3, 0] = 0.543850;
                real[3, 1] = 0.995778;
                real[3, 2] = 0.543850;

                real[4, 0] = 0.543850;
                real[4, 1] = 0.543850;
                real[4, 2] = 0.995778;

                real[5, 0] = 0.995778;
                real[5, 1] = 0.543850;
                real[5, 2] = 0.543850;

                real[6, 0] = 0.739086;
                real[6, 1] = 0.739086;
                real[6, 2] = 0.739086;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion
            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f21: nonlinear function f21
        public static int F21(ref double[,] archive)
        {
            global = n21; // 4
            double radius = Measure.radius; // 2
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = -0.816497;
                real[0, 1] = -1.154701;

                real[1, 0] = 0.816497;
                real[1, 1] = -1.154701;

                real[2, 0] = -0.816497;
                real[2, 1] = 1.154701;

                real[3, 0] = 0.816497;
                real[3, 1] = 1.154701;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion
            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f22: nonlinear function f22
        public static int F22(ref double[,] archive)
        {
            global = n22; // 6
            double radius = Measure.radius; // 3
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = -0.741152;
                real[0, 1] = -0.741152;

                real[1, 0] = -0.741152;
                real[1, 1] = 0.741152;

                real[2, 0] = -0.256625;
                real[2, 1] = 1.016246;

                real[3, 0] = -0.256625;
                real[3, 1] = -1.016246;

                real[4, 0] = -1.016246;
                real[4, 1] = -0.256625;

                real[5, 0] = -1.016246;
                real[5, 1] = 0.256625;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion
            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f23: nonlinear function f23
        public static int F23(ref double[,] archive)
        {
            global = n23; // 2
            double radius = Measure.radius; // 3
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = 10.857703600;
                real[0, 1] = 0.7795480449;
                real[0, 2] = 0.7795480451;

                real[1, 0] = -10.857703600;
                real[1, 1] = -0.7795480449;
                real[1, 2] = -0.7795480451;

                real[2, 0] = 0.3320730984;
                real[2, 1] = 4.6251816010;
                real[2, 2] = 4.6251816010;

                real[3, 0] = -0.3320730984;
                real[3, 1] = -4.6251816010;
                real[3, 2] = -4.6251816010;

                real[4, 0] = 0.7795480449;
                real[4, 1] = 0.7795480449;
                real[4, 2] = 0.7795480451;

                real[5, 0] = -0.7795480449;
                real[5, 1] = -0.7795480449;
                real[5, 2] = -0.7795480451;

                real[6, 0] = 0.7795480449;
                real[6, 1] = 10.857703600;
                real[6, 2] = 0.7795480451;

                real[7, 0] = -0.7795480449;
                real[7, 1] = -10.857703600;
                real[7, 2] = -0.7795480451;

                real[8, 0] = 0.7795480440;
                real[8, 1] = 0.7795480457;
                real[8, 2] = 10.857703600;

                real[9, 0] = -0.7795480440;
                real[9, 1] = -0.7795480457;
                real[9, 2] = -10.857703600;

                real[10, 0] = 4.6251816010;
                real[10, 1] = 4.6251816010;
                real[10, 2] = 4.6251816010;

                real[11, 0] = -4.6251816010;
                real[11, 1] = -4.6251816010;
                real[11, 2] = -4.6251816010;

                real[12, 0] = 4.6251816010;
                real[12, 1] = 0.3320730984;
                real[12, 2] = 4.6251816010;

                real[13, 0] = -4.6251816010;
                real[13, 1] = -0.3320730984;
                real[13, 2] = -4.6251816010;

                real[14, 0] = 4.6251816010;
                real[14, 1] = 4.6251816010;
                real[14, 2] = 0.3320730984;

                real[15, 0] = -4.6251816010;
                real[15, 1] = -4.6251816010;
                real[15, 2] = -0.3320730984;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;

                        //if (number[global - 1] == 1)
                        //{
                        //    Console.WriteLine("here, why?");
                        //    Console.ReadKey();
                        //}
                        break;
                    }
                }

                count += number[ind];
            }

            //double test = Nonlinear.F23(ref solution);

            //if ((test < 1E-6) && (count < 1))
            //{
            //    Console.WriteLine("here, why?");
            //    Console.ReadKey();
            //}

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion
            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f24: nonlinear function f24
        public static int F24(ref double[,] archive)
        {
            global = n24; // 8
            double radius = Measure.radius; // 3
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = 0.000000;
                real[0, 1] = 0.000000;
                real[0, 2] = 0.000000;

                real[1, 0] = 0.488122;
                real[1, 1] = 0.959435;
                real[1, 2] = 0.149452;

                real[2, 0] = 0.540304;
                real[2, 1] = 0.953754;
                real[2, 2] = 0.169399;

                real[3, 0] = 0.959447;
                real[3, 1] = 0.149373;
                real[3, 2] = 0.487917;

                real[4, 0] = 0.149440;
                real[4, 1] = 0.488092;
                real[4, 2] = 0.959440;

                real[5, 0] = 0.953781;
                real[5, 1] = 0.169343;
                real[5, 2] = 0.540157;

                real[6, 0] = 0.169254;
                real[6, 1] = 0.539937;
                real[6, 2] = 0.953788;

                real[7, 0] = 0.739584;
                real[7, 1] = 0.739584;
                real[7, 2] = 0.739574;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion
            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f25: nonlinear function f25
        public static int F25(ref double[,] archive)
        {
            global = n25; // 2
            double radius = Measure.radius; // 3
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = 1.140226;
                real[0, 1] = -0.448382;
                real[0, 2] = 0.135274;

                real[1, 0] = 1.0;
                real[1, 1] = 2.0;
                real[1, 2] = 3.0;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion
            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f26: nonlinear function f26
        public static int F26(ref double[,] archive)
        {
            global = n26; // 2
            double radius = Measure.radius; // 3
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = -0.793701;
                real[0, 1] = -0.793701;

                real[1, 0] = -0.290515;
                real[1, 1] = 1.084215;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }
            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion

            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f27: nonlinear function f27
        public static int F27(ref double[,] archive)
        {
            global = n27; // 3
            double radius = Measure.radius; // 2
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = -0.75;
                real[0, 1] = 0.5625;

                real[1, 0] = 0.0;
                real[1, 1] = 0.0;

                real[2, 0] = 1.0;
                real[2, 1] = 1.0;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion

            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f28: nonlinear function f28
        public static int F28(ref double[,] archive)
        {
            global = n28; // 2

            double radius = Measure.radius; // 2
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = 1.6359718;
                real[0, 1] = 13.8476653;

                real[1, 0] = 0.6277425;
                real[1, 1] = 22.2444123;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion

            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f29: nonlinear function f29
        public static int F29(ref double[,] archive)
        {
            global = n29; // 2
            double radius = Measure.radius; // 3
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = 0.825297;
                real[0, 1] = -0.859034;
                real[0, 2] = -0.151946;

                real[1, 0] = 1.299490;
                real[1, 1] = 0.525835;
                real[1, 2] = -0.642769;

                real[2, 0] = 1.533662;
                real[2, 1] = -1.648068;
                real[2, 2] = 0.499604;

                real[3, 0] = 1.981360;
                real[3, 1] = -2.172180;
                real[3, 2] = 0.775731;

                real[4, 0] = 1.983283;
                real[4, 1] = 0.983378;
                real[4, 2] = -0.016762;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion
            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region f30: nonlinear function f30
        public static int F30(ref double[,] archive)
        {
            global = n30; // 4
            double radius = Measure.radius; // 3
            double[] solution = new double[Parameter.Dimension];
            double[,] real = new double[global, Parameter.Dimension];
            int[] number = new int[global];

            // diversity measure
            diversity = 0.0;
            double[] center = new double[Parameter.Dimension];
            double[] diversityDifference = new double[Parameter.Dimension];

            double[] source = new double[Parameter.Dimension];

            flag = false;
            count = 0;

            for (int ind = 0; ind < global; ++ind)
            {
                // 初始化 real
                real[0, 0] = -1.563533;
                real[0, 1] = 0.277628;

                real[1, 0] = -0.789706;
                real[1, 1] = 1.088295;

                real[2, 0] = 1.563533;
                real[2, 1] = 0.277628;

                real[3, 0] = 0.789706;
                real[3, 1] = 1.088295;

                // 初始化 第 ind 个真实解
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    source[dim] = real[ind, dim];
                }

                // 判断 第 ind 个解是否找到
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = archive[atom, dim];
                    }

                    if (SolutionReach(ref source, ref solution, ref radius))
                    {
                        number[ind] = 1;
                        break;
                    }
                }

                count += number[ind];
            }

            #region diversity measure 多样性指标
            if (count < 2)
            {
                diversity = 0.0;
                // Console.WriteLine("Diversity is 0");
            }
            else
            {
                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            center[dim] += real[ind, dim];
                        }
                    }
                }

                // 计算找到解的中心位置
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    center[dim] /= count;
                }

                for (int ind = 0; ind < global; ++ind)
                {
                    if (number[ind] > 0)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            diversityDifference[dim] += Math.Abs(real[ind, dim] - center[dim]);
                        }
                    }
                }

                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    diversity += diversityDifference[dim];
                }

                diversity /= Parameter.Dimension;

                // Console.WriteLine("Diversity is {0}", diversity);
            }
            #endregion

            if (count == global) flag = true;

            return count;
        }
        #endregion

        #region distance
        // 计算两个数组（真实解与目标解）间的距离
        public static double Distance(ref double[] source, ref double[] destination)
        {
            double result = 0.0;

            for (int i = 0; i < Parameter.Dimension; ++i)
            {
                result += (source[i] - destination[i]) * (source[i] - destination[i]);
            }

            return Math.Sqrt(result);
        }
        #endregion

        #region SolutionReach
        // 计算真实解是否找到
        public static bool SolutionReach(ref double[] source, ref double[] destination, ref double radius)
        {
            bool flag = true;

            for (int i = 0; i < Parameter.Dimension; ++i)
            {
                if (Math.Abs(source[i] - destination[i]) > radius)
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }

        public static bool SolutionReachF01(ref double[] source, ref double[] destination, ref double radius)
        {
            bool flag = true;

            double accuracy = 0.0001;
            double radius10 = radius * 10.0;            

            if (Nonlinear.F01(ref destination) < accuracy)
            {
                for (int i = 0; i < Parameter.Dimension; ++i)
                {
                    if (Math.Abs(source[i] - destination[i]) > radius10)
                    {
                        flag = false;
                        break;
                    }
                }
            }
            else
            {
                flag = false;
                //for (int i = 0; i < Parameter.Dimension; ++i)
                //{
                //    if (Math.Abs(source[i] - solution[i]) > radius)
                //    {
                //        flagEmpty = false;
                //        break;
                //    }
                //}

            }

            //if (flag)
            //{
            //    Console.WriteLine(Nonlinear.F01(ref destination));
            //}

            return flag;
        }

        //public static bool SolutionReachF10(ref double[] source, ref double[] solution, ref double radius)
        //{
        //    bool flagEmpty = true;

        //    double accuracy = 0.00001;
        //    double radius10 = radius * 50.0;

        //    double value = Nonlinear.F10(ref solution);

        //    if (value < accuracy)
        //    {
        //        for (int i = 0; i < Parameter.Dimension; ++i)
        //        {
        //            if (Math.Abs(source[i] - solution[i]) > radius10)
        //            {
        //                flagEmpty = false;
        //                break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        flagEmpty = false;
        //        //for (int i = 0; i < Parameter.Dimension; ++i)
        //        //{
        //        //    if (Math.Abs(source[i] - solution[i]) > radius)
        //        //    {
        //        //        flagEmpty = false;
        //        //        break;
        //        //    }
        //        //}

        //    }

        //    //if ((!flagEmpty)&& value < accuracy)
        //    //{
        //    //    Console.WriteLine("value is {0}", value);
        //    //}

        //    //if (flagEmpty)
        //    //{
        //    //    Console.WriteLine("value is {0}", value);
        //    //}

        //    return flagEmpty;
        //}
        #endregion
    }
}