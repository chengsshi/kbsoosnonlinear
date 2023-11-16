using System;
using System.Collections.Generic;

namespace KBSOnonlinear2
{
    class Distance
    {
        public static double distanceMinimum = double.MaxValue;
        public static double distanceMaximum = double.MinValue;

        public static double[] distanceValue = new double[Archive.Number];

        public static double euclidean(ref double[] solution, ref double[] cluster)
        {
            double distance = 0.0;
            for (int dim = 0; dim < Parameter.Dimension; ++dim)
            {
                distance += (solution[dim] - cluster[dim]) * (solution[dim] - cluster[dim]);
            }
            distance = Math.Sqrt(distance);

            return distance;
        }

        public static void DistanceCalculation(ref double[] solution, ref double[,] enough)
        {
            // int idx = 0;
            //double[] distanceValueAll = new double[Archive.Number];

            // List<double> individualSort = new List<double>();

            //double distance = double.MaxValue;
            for (int num = 0; num < Archive.Number; num++)
            {
                for (int dim = 0; dim < Parameter.Dimension; dim++)
                {
                    distanceValue[num] += (solution[dim] - enough[num, dim]) * (solution[dim] - enough[num, dim]);
                }

                distanceValue[num] = Math.Sqrt(distanceValue[num]);

                //if (distanceValueAll[num] < distanceMinimum)
                //{
                //    distanceMinimum = distanceValueAll[num];
                //    idx = num;
                //}
            }

            return;
        }

        public static int minimumIndex(ref double[] solution, ref double[,] enough)
        {
            int idx = 0;
            double[] distanceValueAll = new double[Archive.Number];
            distanceMinimum = double.MaxValue;

            // List<double> individualSort = new List<double>();

            //double distance = double.MaxValue;
            for (int num = 0; num < Archive.Number; num++)
            {
                for (int dim = 0; dim < Parameter.Dimension; dim++)
                {
                    distanceValueAll[num] += (solution[dim] - enough[num, dim]) * (solution[dim] - enough[num, dim]);
                }

                distanceValueAll[num] = Math.Sqrt(distanceValueAll[num]);

                if (distanceValueAll[num] < distanceMinimum)
                {
                    distanceMinimum = distanceValueAll[num];
                    idx = num;
                }
            }

            return idx;
        }

        public static int MinimumIndexNonSelf(int selfNumber, ref double[] solution, ref double[,] enough)
        {
            int idx = 0;
            double[] distanceValueAll = new double[Archive.Number];
            distanceMinimum = double.MaxValue;
            // List<double> individualSort = new List<double>();

            //double distance = double.MaxValue;
            for (int num = 0; num < Archive.Number; num++)
            {
                for (int dim = 0; dim < Parameter.Dimension; dim++)
                {
                    distanceValueAll[num] += (solution[dim] - enough[num, dim]) * (solution[dim] - enough[num, dim]);
                }

                distanceValueAll[num] = Math.Sqrt(distanceValueAll[num]);

                distanceValueAll[selfNumber] = double.MaxValue;
                if (distanceValueAll[num] < distanceMinimum)
                {
                    distanceMinimum = distanceValueAll[num];
                    idx = num;
                }
            }

            return idx;
        }

        public static int maximumIndex(ref double[] solution, ref double[,] enough)
        {
            int idx = 0;
            double[] distanceValueAll = new double[Archive.Number];

            // List<double> individualSort = new List<double>();

            //double distance = double.MaxValue;
            for (int num = 0; num < Archive.Number; num++)
            {
                for (int dim = 0; dim < Parameter.Dimension; dim++)
                {
                    distanceValueAll[num] += (solution[dim] - enough[num, dim]) * (solution[dim] - enough[num, dim]);
                }

                distanceValueAll[num] = Math.Sqrt(distanceValueAll[num]);

                if (distanceValueAll[num] > distanceMaximum)
                {
                    distanceMaximum = distanceValueAll[num];
                    idx = num;
                }
            }

            return idx;
        }

        public static double manhattan(ref double[] solution, ref double[] cluster)
        {
            double distance = 0.0;

            for (int dim = 0; dim < Parameter.Dimension; ++dim)
            {
                distance += Math.Abs(solution[dim] - cluster[dim]);
            }

            return distance;
        }
    }
}