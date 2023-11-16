using System;

namespace KBSOnonlinear2
{
    public class Parameter
    {
        public static int Population = 100;
        public static int Dimension = 2;

        public static double[] Vmax = new double[Dimension];
        public static double[] Upper = new double[Dimension];
        public static double[] Lower = new double[Dimension];
        public static int Run = 50;
        // reciprocalRunNumber = 1.0 / Run

        public static int Iteration = 500;
        //public static double slope = 25;
        public static double Perce = 0.2;
        public static double size = 500.0;
        //public static double pe = 0.2;
        //public static double pone = 0.8;     

        public static void Display()
        {
            Console.WriteLine("population{0}", Population);
            //Console.WriteLine("Velocity {0}", Vmax);
            //Console.WriteLine("Position {0}", Upper);
            Console.WriteLine("Iteration {0}", Iteration);
            Console.WriteLine("dimension {0}", Dimension);
            Console.WriteLine("run {0}", Run);
        }

        public static void UpdateBoundary(double low, double up)
        {
            for (int dim = 0; dim < Parameter.Dimension; ++dim)
            {
                Parameter.Lower[dim] = low;
                Parameter.Upper[dim] = up;
            }
            Console.WriteLine("Boundary setting");
        }

        public static void UpdateParameter(double low, double up, int ite, int popu)
        {
            for (int dim = 0; dim < Parameter.Dimension; ++dim)
            {
                Parameter.Lower[dim] = low;
                Parameter.Upper[dim] = up;
                Parameter.Vmax[dim] = 0.1 * (up - low);
            }

            Parameter.Iteration = ite;
            Parameter.Population = popu;
            Console.WriteLine("Parameter setting");
        }

        public static void UpdateParameter(double low0, double up0, double low1, double up1, int ite, int popu)
        {
            Parameter.Lower[0] = low0;
            Parameter.Upper[0] = up0;
            Parameter.Vmax[0] = 0.1 * (up0 - low0);
            Parameter.Lower[1] = low1;
            Parameter.Upper[1] = up1;
            Parameter.Vmax[1] = 0.1 * (up1 - low1);

            Parameter.Iteration = ite;
            Parameter.Population = popu;
            Console.WriteLine("Parameter setting");
        }

        public static void UpdateParameter(double low0, double up0, double low1,
            double up1, double low2, double up2, int ite, int popu)
        {
            Parameter.Lower[0] = low0;
            Parameter.Upper[0] = up0;
            Parameter.Vmax[0] = 0.1 * (up0 - low0);

            Parameter.Lower[1] = low1;
            Parameter.Upper[1] = up1;
            Parameter.Vmax[1] = 0.1 * (up1 - low1);

            Parameter.Lower[2] = low2;
            Parameter.Upper[2] = up2;
            Parameter.Vmax[2] = 0.1 * (up2 - low2);

            Parameter.Iteration = ite;
            Parameter.Population = popu;
            Console.WriteLine("Parameter setting");
        }
    }
}
