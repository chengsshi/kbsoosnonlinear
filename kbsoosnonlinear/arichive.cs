using System;

namespace KBSOnonlinear2
{
    public class Archive
    {
        public static int Number = Parameter.Population;

        public static double metric = 1.0E-2;
        public static int num = 0;
        // public static double repara = 0.1;
        // int num = 0;
        static bool flagEmpty = true;
        static bool flagFull = false;

        double distance = double.MaxValue;
        int index = 0;

        public static void ArchiveInitialization(ref double[,] enough, ref double[] enoughValue)
        {
            flagEmpty = true;
            flagFull = false;

            for (int idx = 0; idx < Number; ++idx)
            {
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    enough[idx, dim] = 0.0;
                }
                enoughValue[idx] = double.MaxValue;
            }
            return;
        }

        public static void ArchiveUpdate(ref double[,] swarm, ref double[] fitness,
            ref double[,] enough, ref double[] enoughValue)
        {
            double[] solution = new double[Parameter.Dimension];

            int minIdx = 0;
            int maxIdx = 0;

            int result = 0;

            for (int idx = 0; idx < Parameter.Population; ++idx)
            {
                if (flagEmpty)
                {
                    // Console.WriteLine("empty");
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        enough[0, dim] = swarm[0, dim];
                    }
                    enoughValue[0] = fitness[0];
                    flagEmpty = false;
                    num = 1;
                }
                else if (flagFull) // full 
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        solution[dim] = swarm[idx, dim];
                    }
                    // minIdx = Distance.minimumIndex(ref solution, ref enough);
                    // Console.WriteLine(Distance.distanceMinimum.ToString());
                    // maxIdx = Distance.maximumIndex(ref solution, ref enough);
                    // Console.WriteLine(Distance.distanceMaximum.ToString());
                    //if (Distance.distanceMaximum > 0.1)
                    //{
                    //if ((enoughValue[minIdx] > fitness[idx]) && (Distance.distanceMinimum < 1E-5))
                    //    if ((enoughValue[minIdx] > fitness[idx]) && (Distance.distanceMinimum < 1E-5))
                    //    {
                    result = ArchiveAnalysis2(ref enough, ref enoughValue);
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        enough[result, dim] = solution[dim];
                    }
                    enoughValue[result] = fitness[idx];
                    //}
                    //}
                }
                else
                {
                    //for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    //{
                    //    solution[dim] = swarm[idx, dim];
                    //}
                    //minIdx = Distance.minimumIndex(ref solution, ref enough);
                    //// Console.WriteLine(Distance.distanceMinimum.ToString());
                    //maxIdx = Distance.maximumIndex(ref solution, ref enough);
                    //// Console.WriteLine(Distance.distanceMaximum.ToString());
                    ////if (Distance.distanceMaximum > 0.1)
                    ////{
                    //if ((Distance.distanceMaximum > 0.1) ||
                    //    ((enoughValue[minIdx] > fitness[idx]) && (Distance.distanceMinimum < 1E-5)))
                    //{

                    if (fitness[idx] < metric)
                    {
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            enough[num, dim] = swarm[idx, dim];
                        }
                        enoughValue[num] = fitness[idx];
                    }
                    num++;

                    if (num == Number)
                    {
                        flagFull = true;
                    }
                }
            }
            return;
        }


        //Random rand = new Random();

        //if (flagEmpty)
        //{
        //    for (int dim = 0; dim < Parameter.Dimension; ++dim)
        //    {
        //        enough[0, dim] = swarm[0, dim];
        //    }
        //    flagEmpty = false;
        //    num = 1;
        //}
        //else
        //{
        //    if (flagFull)
        //    {
        //        for (int dim = 0; dim < Parameter.Dimension; ++dim)
        //        {
        //            solution[dim] = swarm[idx, dim];
        //        }
        //        minIdx = Distance.minimumIndex(ref solution, ref enough);

        //    }
        //    else
        //    {
        //        for (int idx = 0; idx < Parameter.Population; ++idx)
        //        {
        //            if (fitness[idx] < metric)
        //            {
        //                for (int dim = 0; dim < Parameter.Dimension; ++dim)
        //                {
        //                    enough[num, dim] = swarm[idx, dim];
        //                }
        //            }
        //            num++;
        //        }

        //    }
        //}


        //for (int idx = 0; idx < Parameter.Population; ++idx)
        //{
        //    if (fitness[idx] < metric)
        //    {
        //        if (num < Number)
        //        {
        //            for (int dim = 0; dim < Parameter.Dimension; ++dim)
        //            {
        //                enough[num, dim] = swarm[idx, dim];
        //            }
        //            enoughValue[idx] = fitness[idx];
        //            num++;
        //        }
        //        else
        //        {
        //            for (int dim = 0; dim < Parameter.Dimension; ++dim)
        //            {
        //                solution[dim] = swarm[idx, dim];
        //            }
        //            minIdx = Distance.minimumIndex(ref solution, ref enough);

        //if ((Distance.distanceMinimum < 0.1) && fitness[idx] < enoughValue[minIdx])
        //            //if (fitness[idx] < enoughValue[minIdx])
        //            //{
        //            for (int dim = 0; dim < Parameter.Dimension; ++dim)
        //            {
        //                enough[minIdx, dim] = solution[dim];
        //            }
        //            //}
        //            //if (rand.NextDouble() < repara)
        //            //{
        //            //    for (int dim = 0; dim < Parameter.Dimension; ++dim)
        //            //    {
        //            //        population[idx, dim] = Parameter.Lower + (Parameter.Upper - Parameter.Lower) * rand.NextDouble();
        //            //    }
        //            //}
        //        }
        //    }
        //}


        public static void ArchiveReduction(ref double[,] enough, ref double[] enoughValue)
        {
            // bool flag = false;
            double[] solution = new double[Parameter.Dimension];
            int eliminate = 0;

            int half = Number / 2;
            for (int idx = Number - 1; idx > half; idx--)
            {
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    solution[dim] = enough[idx, dim];
                }
                Distance.DistanceCalculation(ref solution, ref enough);

                for (int num = 0; num < Archive.Number; num++)
                {
                    if (Distance.distanceValue[num] < 1E-5)
                    {
                        if (enoughValue[num] < enoughValue[idx])
                        {
                            eliminate = idx;
                        }
                        else
                        {
                            eliminate = num;
                        }
                        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        {
                            enough[eliminate, dim] = 0.0;
                        }

                        // flagFull = false;
                    }
                }
            }

            return;
        }

        public static int ArchiveAnalysis(ref double[,] enough, ref double[] enoughValue)
        {
            // bool flag = false;
            int result = 0;
            int minIdx = 0;
            double[] solution = new double[Parameter.Dimension];
            int selfNumber = 0;

            for (int dim = 0; dim < Parameter.Dimension; ++dim)
            {
                solution[dim] = enough[selfNumber, dim];
            }

            minIdx = Distance.MinimumIndexNonSelf(selfNumber, ref solution, ref enough);

            if (enoughValue[minIdx] < enoughValue[selfNumber])
            {
                result = selfNumber;
            }
            else
            {
                result = minIdx;
            }

            return result;
        }

        public static int ArchiveAnalysis2(ref double[,] enough, ref double[] enoughValue)
        {
            // bool flag = false;
            int result = 0;
            int minIdx = 0;
            double[] solution = new double[Parameter.Dimension];
            // int selfNumber = 0;
            double distancemin = double.MaxValue;

            int half = Convert.ToInt32(Math.Floor(Number * 0.5));
            for (int selfNumber = Number - 1; selfNumber > half; selfNumber--)
            {
                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                {
                    solution[dim] = enough[selfNumber, dim];
                }

                minIdx = Distance.MinimumIndexNonSelf(selfNumber, ref solution, ref enough);
                if (Distance.distanceMinimum < distancemin)
                {
                    distancemin = Distance.distanceMinimum;
                    if (enoughValue[minIdx] < enoughValue[selfNumber])
                    {
                        result = selfNumber;
                    }
                    else
                    {
                        result = minIdx;
                    }
                }
                else
                {
                    // do nothing
                }
            }           

            return result;
        }

        public static void AchiveMeasure(Function type, ref int orCount, ref int srCount, ref double[,] enough)
        {
            switch (type)
            {
                case Function.f01:
                    orCount += Measure.F01(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f02:
                    orCount += Measure.F02(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f03:
                    orCount += Measure.F03(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f04:
                    orCount += Measure.F04(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f05:
                    orCount += Measure.F05(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f06:
                    orCount += Measure.F06(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f07:
                    orCount += Measure.F07(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f08:
                    orCount += Measure.F08(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f09:
                    orCount += Measure.F09(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f10:
                    orCount += Measure.F10(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f11:
                    orCount += Measure.F11(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f12:
                    orCount += Measure.F12(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f13:
                    orCount += Measure.F13(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f14:
                    orCount += Measure.F14(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f15:
                    orCount += Measure.F15(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f16:
                    orCount += Measure.F16(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f17:
                    orCount += Measure.F17(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f18:
                    orCount += Measure.F18(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f19:
                    orCount += Measure.F19(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f20:
                    orCount += Measure.F20(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f21:
                    orCount += Measure.F21(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f22:
                    orCount += Measure.F22(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f23:
                    orCount += Measure.F23(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f24:
                    orCount += Measure.F24(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f25:
                    orCount += Measure.F25(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f26:
                    orCount += Measure.F26(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f27:
                    orCount += Measure.F27(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f28:
                    orCount += Measure.F28(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f29:
                    orCount += Measure.F29(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                case Function.f30:
                    orCount += Measure.F30(ref enough);
                    if (Measure.flag) ++srCount;
                    break;

                default:
                    Console.WriteLine("Not a valid function type");
                    Console.ReadKey();
                    break;
            }
        }
    }
}

