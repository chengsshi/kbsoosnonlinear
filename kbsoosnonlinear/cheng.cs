using KBSOnonlinear2;
using System;

namespace KBSOnonlinear2
{
    public class Cheng
    {
        public static void Main()
        {
            Console.WriteLine("KBSOOS Start");
            string beginTime = DateTime.Now.ToString();
            Console.WriteLine("begin time: {0}", beginTime);
            Parameter.Display();
            Process();

            string endTime = DateTime.Now.ToString();
            Console.WriteLine("end time: {0}", endTime);
            Console.WriteLine("KBSOOS Done");
            Console.ReadKey();
        }

        public static void Process()
        {
            double low0 = -1.0;
            double up0 = 1.0;

            double low1 = -1.0;
            double up1 = 1.0;

            double low2 = -1.0;
            double up2 = 1.0;

            int ite = 500;
            int popu = 100;
            Parameter.UpdateBoundary(low0, up0);

            #region n = 2
            Parameter.Dimension = 2;

            // f02
            low0 = -1.0; up0 = 1.0;
            ite = 500; popu = 100;
            Parameter.UpdateParameter(low0, up0, ite, popu);
            KBSOOS.Process(Function.f02);

            // f03
            low0 = -1.0; up0 = 1.0;
            ite = 500; popu = 100;
            Parameter.UpdateParameter(low0, up0, ite, popu);
            KBSOOS.Process(Function.f03);

            // f04
            low0 = -10.0; up0 = 10.0;
            ite = 500; popu = 100;
            Parameter.UpdateParameter(low0, up0, ite, popu);
            KBSOOS.Process(Function.f04);

            // f06
            low0 = -1.0; up0 = 1.0;
            ite = 500; popu = 100;
            Parameter.UpdateParameter(low0, up0, ite, popu);
            KBSOOS.Process(Function.f06);

            // f07
            low0 = 0.0; up0 = 1.0;
            low1 = -10.0; up1 = 0.0;
            ite = 500; popu = 100;

            Parameter.UpdateParameter(low0, up0, low1, up1, ite, popu);
            KBSOOS.Process(Function.f07);

            // f08
            low0 = 0.0; up0 = 1.0;
            ite = 500; popu = 100;
            Parameter.UpdateParameter(low0, up0, ite, popu);
            KBSOOS.Process(Function.f08);

            // f11
            low0 = -1.0; up0 = 1.0;
            low1 = -10.0; up1 = 10.0;
            ite = 500; popu = 100;
            Parameter.UpdateParameter(low0, up0, low1, up1, ite, popu);
            KBSOOS.Process(Function.f11);

            // f12
            low0 = -2.0; up0 = 2.0;
            ite = 500; popu = 100;
            Parameter.UpdateParameter(low0, up0, ite, popu);
            KBSOOS.Process(Function.f12);

            // f14
            low0 = -5.0; up0 = 5.0;
            ite = 500; popu = 100;
            Parameter.UpdateParameter(low0, up0, ite, popu);
            KBSOOS.Process(Function.f14);

            // f15
            low0 = 0.25; up0 = 1.0;
            low1 = 1.5; up1 = 2.0 * Math.PI;
            ite = 500; popu = 100;
            Parameter.UpdateParameter(low0, up0, low1, up1, ite, popu);
            KBSOOS.Process(Function.f15);

            // f16
            low0 = 0.0; up0 = 2.0 * Math.PI;
            ite = 500; popu = 100;
            Parameter.UpdateParameter(low0, up0, ite, popu);
            KBSOOS.Process(Function.f16);

            // f18
            low0 = -2.0; up0 = 2.0;
            ite = 500; popu = 100;
            Parameter.UpdateParameter(low0, up0, ite, popu);
            KBSOOS.Process(Function.f18);

            // f21
            low0 = -2.0; up0 = 2.0;
            ite = 500; popu = 100;
            Parameter.UpdateParameter(low0, up0, ite, popu);
            KBSOOS.Process(Function.f21);

            // f22
            low0 = -2.0; up0 = 2.0;
            //low0 = -2.0; up0 = 2.0;
            ite = 500; popu = 100;
            double[] solution = new double[2];
            solution[0] = -0.741152;
            solution[1] = -0.741152;

            Nonlinear.F22(ref solution);

            solution[0] = -0.741152;
            solution[1] = 0.741152;
            Nonlinear.F22(ref solution);

            solution[0] = -0.256625;
            solution[1] = 1.016246;
            Nonlinear.F22(ref solution);

            solution[0] = -0.256625;
            solution[1] = -1.016246;
            Nonlinear.F22(ref solution);

            solution[0] = -1.016246;
            solution[1] = -0.256625;
            Nonlinear.F22(ref solution);

            solution[0] = -1.016246;
            solution[1] = 0.256625;
            Nonlinear.F22(ref solution);

            Parameter.UpdateParameter(low0, up0, ite, popu);
            KBSOOS.Process(Function.f22);

            // f26
            low0 = -1.0; up0 = -0.1;
            low1 = -2; up1 = 2.0;
            ite = 500; popu = 100;
            Parameter.UpdateParameter(low0, up0, low1, up1, ite, popu);
            KBSOOS.Process(Function.f26);

            // f27
            low0 = -5.0; up0 = 1.5;
            low1 = 0; up1 = 5.0;
            ite = 500; popu = 100;
            Parameter.UpdateParameter(low0, up0, low1, up1, ite, popu);
            KBSOOS.Process(Function.f27);

            // f28
            low0 = 0.0; up0 = 2.0;
            low1 = 10; up1 = 30.0;
            ite = 500; popu = 100;
            Parameter.UpdateParameter(low0, up0, low1, up1, ite, popu);
            KBSOOS.Process(Function.f28);

            // f30
            low0 = -2.0; up0 = 2.0;
            low1 = 0; up1 = 1.1;
            ite = 500; popu = 100;
            Parameter.UpdateParameter(low0, up0, low1, up1, ite, popu);
            KBSOOS.Process(Function.f30);
            #endregion

            #region n = 3
            //Parameter.Dimension = 3;
            // f10
            //low0 = -5.0; up0 = 5.0;
            //low1 = -1.0; up1 = 3.0;
            //low2 = -5.0; up2 = 5.0;
            //ite = 500; popu = 100;
            //Parameter.UpdateParameter(low0, up0, low1, up1, low2, up2, ite, popu);
            //KBSOOS.Process(Function.f10);

            //// f13
            //low0 = -0.6; up0 = 6.0;
            //low1 = -0.6; up1 = 0.6;
            //low2 = -5.0; up2 = 5.0;
            //ite = 500; popu = 100;
            //Parameter.UpdateParameter(low0, up0, low1, up1, low2, up2, ite, popu);
            //KBSOOS.Process(Function.f13);

            //// f20
            //low0 = -1.0; up0 = 1.0;
            //ite = 500; popu = 100;
            //Parameter.UpdateParameter(low0, up0, ite, popu);
            //KBSOOS.Process(Function.f20);

            //// f23 // 500,000
            //low0 = -20.0; up0 = 20.0;
            //ite = 2500; popu = 200;
            //Parameter.UpdateParameter(low0, up0, ite, popu);
            //KBSOOS.Process(Function.f23);

            // f24 // 100,000
            //low0 = 0.0; up0 = 1.0;
            //ite = 500; popu = 200;
            //Parameter.UpdateParameter(low0, up0, ite, popu);
            //KBSOOS.Process(Function.f24);

            //// f25 // 100,000
            //low0 = -3.0; up0 = 3.0;
            //ite = 1000; popu = 100;
            //Parameter.UpdateParameter(low0, up0, ite, popu);
            //KBSOOS.Process(Function.f25);

            // f29
            //low0 = 0.0; up0 = 2.0;
            //low1 = -10.0; up1 = 10.0;
            //low2 = -1.0; up2 = 1.0;
            //ite = 500; popu = 100;
            //Parameter.UpdateParameter(low0, up0, low1, up1, low2, up2, ite, popu);
            //KBSOOS.Process(Function.f29);
            #endregion

            #region n = 5
            //Parameter.Dimension = 5;
            //// f09 // 100,000
            //low0 = -10.0; up0 = 10.0;
            //ite = 1000; popu = 100;
            //Parameter.UpdateParameter(low0, up0, ite, popu);
            //KBSOOS.Process(Function.f09);
            #endregion

            #region n = 8
            //Parameter.Dimension = 8;
            //// f17 // 100,000
            //low0 = -1.0; up0 = 1.0;
            //ite = 1000; popu = 100;
            //Parameter.UpdateParameter(low0, up0, ite, popu);
            //KBSOOS.Process(Function.f17);
            #endregion

            #region n = 10
            //Parameter.Dimension = 10;
            //// f05
            //low0 = -2.0; up0 = 2.0;
            //ite = 500; popu = 100;
            //Parameter.UpdateParameter(low0, up0, ite, popu);
            //KBSOOS.Process(Function.f05);
            #endregion

            #region n = 20
            //Parameter.Dimension = 20;
            //// f01
            //low0 = -1.0; up0 = 1.0;
            //ite = 500; popu = 100;
            //Parameter.UpdateParameter(low0, up0, ite, popu);
            //KBSOOS.Process(Function.f01);

            // f19 // 200,000
            //low0 = -2.0; up0 = 2.0;
            //ite = 2000; popu = 100;
            //Parameter.UpdateParameter(low0, up0, ite, popu);
            //KBSOOS.Process(Function.f19);
            #endregion
        }
    }
}
