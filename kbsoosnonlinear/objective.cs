﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace KBSOnonlinear2
{
    class KBSOOS
    {
        // fun = fitness_function
        // population_size; populationlation size
        // number_dimension; number of dimension
        // cluster_number: number of clusters;  
        // percentage_elitist ==  cluster_number
        // range_left; left boundary of the dynamic range
        // range_right; right boundary of the dynamic range            

        public static void Process(Function type)
        {
            #region time variable
            double diffTime = 0.0;
            TimeSpan diff = TimeSpan.Zero;
            DateTime start = DateTime.Now;
            Console.WriteLine("Hour: {0}, Minute: {1}, Second:{2}", start.Hour, start.Minute, start.Second);
            DateTime end = DateTime.Now;
            #endregion // time variable

            #region variable definition
            Random rand = new Random();

            int orCount = 0;
            int srCount = 0;
            double successRate = 0.0;
            double diverityMeasure = 0.0;
            double diversityR = 0.0;

            int worstCount = 0;
            int worstCount2 = 0;
            double[,] population = new double[Parameter.Population, Parameter.Dimension];
            double[,] enough = new double[Archive.Number, Parameter.Dimension];
            double[] enoughValue = new double[Archive.Number];
            // double[,] pbest = new double[Parameter.Population, Parameter.Dimension];
            double[] trajectory = new double[Parameter.Iteration];
            double[] solution = new double[Parameter.Dimension];
            double[] fitness = new double[Parameter.Population];
            double stepSize = 1.0;
            double[] initializeSolution = new double[Parameter.Dimension];

            int globalindex = 0;
            int worstindex = 0;
            // int worstindex2 = 0;
            double globalValue = double.MaxValue;

            int[] indexOriginal = new int[Parameter.Population];
            // int[] fitness_population_sorted = new int[Parameter.Population];
            List<double> individualSort = new List<double>();
            List<double> bestFitness = new List<double>();
            List<string> log = new List<string>(); // write log
            string logSentence = String.Empty;
            string logName = String.Empty; // log file Name 
            #endregion
            // modify based on IJSIR BSO-I BSO in objective space

            //% ranking individuals according to fitness value
            //% take top k percentage as elitists, remaining 100-k percentage as normals
            //% randomly select one elitist to be disrupted, if better, replace, otherwise, do nothing 
            //% if rand < probability_elitist, 
            //%    generate new individuals based on elitists
            //%    if rand < probability_one, 
            //%       generate a new individual based on one randomly selected elitist
            //%    else 
            //%       generate a new individual based on two randomly selected elitists
            //%    endif
            //% else 
            //%    generate new individuals based on normals
            //%    if rand < probability_one, 
            //%       generate a new individual based on one randomly selected normal
            //%    else 
            //%       generate a new individual based on two randomly selected normals
            //%    endif
            //% endif

            // probability to determine whether a dimension is disrupted or not
            // probability_dimension_disruption = 0.2;
            // probability for disrupting elitists. one elitis every 5 generations, and only one dimension;
            // probability Disrupt
            double probabilityDisrupt = 1.0;
            // probability for select elitist, not normals, to generate new individual; 
            double probabilityElitist = 0.2;
            double probabilityHybrid = 0.8;

            // probability for select one individual, not two, to generate new individual; 
            double probabilityOne = 0.5;
            // slope of the s-shape function
            // double logsig_slope = 500;

            // effecting the step size of generating new individuals by adding random values
            stepSize = 1.0;

            Archive.ArchiveInitialization(ref enough, ref enoughValue);

            for (int run = 0; run < Parameter.Run; ++run)
            {
                for (int num = 0; num < Parameter.Population; ++num)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        // initialize the populationlation of individuals
                        population[num, dim] = Parameter.Lower[dim]
                            + (Parameter.Upper[dim] - Parameter.Lower[dim]) * rand.NextDouble();

                        // initialize the temporary populationlation of individuals 
                        // pbest[num, dim] = population[num, dim];
                    }
                }

                // initialize current iterantion  number
                // int current_iteration_number = 1;

                // number of elitists
                // Parameter.perce == percentage_elitist 
                int numberElitist = Convert.ToInt32(Math.Floor(Parameter.Population * Parameter.Perce));
                // number of normals
                int numberNormal = Parameter.Population - numberElitist;

                // initialize corresponding original indexs in the population of sorted fitness values 
                for (int atom = 0; atom < Parameter.Population; ++atom)
                {
                    indexOriginal[atom] = Parameter.Population + 1;
                }
                // store best fitness value for each iteration
                //% best_fitness = ones(max_iteration,1); 

                // store fitness value for each individual in each population
                // fitness_population = ones(population_size,1);  
                // store sorted fitness values
                //for (int num = 0; num < Parameter.Population; ++num)
                //{
                //    fitness_population_sorted[num] = 1;
                //}
                // store a temporary individual
                //individual_temporary = zeros(1,number_dimension);  

                // calculate fitness for each individual in the initialized populationlation
                for (int num = 0; num < Parameter.Population; ++num)
                {
                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    {
                        initializeSolution[dim] = population[num, dim];
                    }
                    fitness[num] = function(type, ref initializeSolution);
                }

                // start the main loop of the BSO algorithm       
                // compensate the fitness evaulation due to disruption
                // int max_iteration_comp = Convert.ToInt32(Parameter.Iteration - (Parameter.Iteration * probabilityDisrupt) / Parameter.Population);
                // max_iteration_comp = max_iteration - (max_iteration/population_size); 
                // compensate the fitness evaulation due to disruption

                // store best fitness value for each iteration
                //best_fitness = ones(max_iteration_comp,1); 

                // use the compesented maximum iteration
                for (int ite = 0; ite < Parameter.Iteration; ++ite) //while current_iteration_number <= max_iteration_comp 
                {

                    if ((ite + 1) % 100 == 0)
                    {
                        Archive.ArchiveUpdate(ref population, ref fitness, ref enough, ref enoughValue);
                        //Archive.ArchiveReduction(ref enough, ref enoughValue);
                    }

                    #region sort individuals
                    for (int pop = 0; pop < Parameter.Population; ++pop)
                    {
                        individualSort.Add(fitness[pop]);
                    }
                    individualSort.Sort();

                    globalValue = individualSort[0];
                    for (int i = 0; i < Parameter.Population; ++i)
                    {
                        for (int pop = 0; pop < Parameter.Population; ++pop)
                        {
                            if (fitness[pop] == individualSort[i])
                            {
                                indexOriginal[i] = pop;
                            }
                        }
                    }
                    globalindex = indexOriginal[0];
                    worstindex = indexOriginal[Parameter.Population - 1];
                    // worstindex2 = indexOriginal[Parameter.Population - 2];

                    // Console.WriteLine(globalValue.ToString());
                    // Console.WriteLine(fitness[globalindex].ToString());
                    // sort individuals in a population based on their fitness values
                    //[fitness_population_sorted,index_original] = sort(fitness_population,'ascend');

                    #endregion // end sort
                    // record the best fitness in each iteration
                    trajectory[ite] = globalValue;

                    individualSort.Clear();
                    // generate population_size new individuals by adding Gaussian random values            
                    for (int idx = 0; idx < Parameter.Population; ++idx)
                    {
                        // form the seed individual 
                        // generate a randon value
                        double rone = rand.NextDouble();
                        //if (idx == worstindex)
                        //{
                        //    int randidx1 = Convert.ToInt32(Math.Floor(Parameter.Population * rand.NextDouble()));

                        //    double randnum1 = rand.NextDouble();
                        //    double randnum2 = rand.NextDouble();
                        //    double randnum3 = rand.NextDouble();

                        //    if (randidx1 == worstindex)
                        //    {
                        //        randidx1 = Convert.ToInt32(Math.Floor((globalindex + worstindex) / 2.0));
                        //    }


                        //    // temporary individual = selected individual
                        //    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        //    {
                        //        solution[dim] = population[idx, dim];
                        //        solution[dim] = 0.72984 * solution[dim] + 1.496172 * randnum1 * (population[globalindex, dim] - population[idx, dim])
                        //            + 1.496172 * randnum2 * (population[randidx1, dim] - population[idx, dim]);

                        //        if (solution[dim] > Parameter.Upper)
                        //        {
                        //            solution[dim] = Parameter.Upper - 0.001 * randnum1;
                        //        }
                        //        else if (solution[dim] < Parameter.Lower)
                        //        {
                        //            solution[dim] = Parameter.Lower + 0.001 * randnum2;
                        //        }

                        //        //if (randnum3 > 0.9)
                        //        //{
                        //        //    solution[dim] = population[idx, dim];
                        //        //}
                        //    }

                        //    // evaluate the disrupted individual
                        //    double fv = function(type, ref solution);
                        //    if (fv < fitness[idx])// if better
                        //    {
                        //        for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        //        {
                        //            // replace the selected individual with the disrupted one
                        //            population[idx, dim] = solution[dim];
                        //            // pbest[idx, dim] = solution[dim];
                        //        }

                        //        // assign the fitness value to the disrupted individual
                        //        fitness[idx] = fv;

                        //        worstCount++;

                        //        //  }
                        //        //if (fv < globalValue)
                        //        //{
                        //        //    globalValue = fv;
                        //        //    globalindex = worstindex;
                        //        //}
                        //    }
                        //    //else
                        //    //{
                        //    //    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                        //    //    {
                        //    //        // replace the selected individual
                        //    //        population[idx, dim] = solution[dim];
                        //    //    }
                        //    //}


                        //}
                        //else 
                        if (idx == worstindex)
                        {
                            worstCount++;
                            int randidx2 = Convert.ToInt32(Math.Floor(Parameter.Population * rand.NextDouble()));

                            double randnum1 = rand.NextDouble();
                            double randnum2 = rand.NextDouble();
                            double randnum3 = rand.NextDouble();

                            if (randidx2 == worstindex)
                            {
                                randidx2 = Convert.ToInt32(Math.Floor((globalindex + worstindex) / 2.0));
                            }

                            // temporary individual = selected individual
                            for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            {
                                solution[dim] = population[idx, dim];
                                solution[dim] = solution[dim] + 0.5 * (population[globalindex, dim] - population[randidx2, dim]);

                                if (solution[dim] > Parameter.Upper[dim])
                                {
                                    solution[dim] = Parameter.Upper[dim] - 0.001 * randnum1;
                                }
                                else if (solution[dim] < Parameter.Lower[dim])
                                {
                                    solution[dim] = Parameter.Lower[dim] + 0.001 * randnum2;
                                }

                                if (randnum3 > 0.9)
                                {
                                    solution[dim] = population[idx, dim];
                                }
                            }

                            // evaluate the disrupted individual
                            double fv = function(type, ref solution);
                            if (fitness[idx] > fv)// if better
                            {
                                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                {
                                    // replace the selected individual with the disrupted one
                                    population[idx, dim] = solution[dim];
                                    // pbest[idx, dim] = solution[dim];
                                }

                                // assign the fitness value to the disrupted individual
                                fitness[idx] = fv;

                                worstCount2++;

                                //  }
                                //if (fv < globalValue)
                                //{
                                //    globalValue = fv;
                                //    globalindex = worstindex;
                                //}
                            }
                        }
                        else
                        {
                            if (rone < probabilityElitist) // select elitists to generate a new individual
                            {
                                // double r = rand.NextDouble(); // generate a random number
                                int indexOne = rand.Next(numberElitist);// 
                                int indexTwo = rand.Next(numberElitist); // Convert.ToInt32(Math.Floor(number_elitist * rand.NextDouble()));
                                if (indexOne == indexTwo) // avoid same index
                                {
                                    indexTwo = numberElitist - indexOne - 1;
                                }
                                if (rand.NextDouble() < probabilityOne)
                                {
                                    // use one elitist to generate a new individual
                                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                    {
                                        solution[dim] = population[indexOriginal[indexOne], dim];
                                    }
                                }
                                else // use two elitists to generate a new individual
                                {
                                    double tem = rand.NextDouble(); // combine from two individuals
                                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                    {
                                        solution[dim] = tem * population[indexOriginal[indexOne], dim]
                                            + (1.0 - tem) * population[indexOriginal[indexTwo], dim];
                                    }
                                }
                            }
                            else if (rone > probabilityHybrid) // hybrid mode
                            {
                                int indexOne = rand.Next(numberElitist);
                                int indexTwo = numberElitist + rand.Next(numberNormal);
                                double tem = rand.NextDouble(); // combine from two individuals
                                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                {
                                    solution[dim] = tem * population[indexOriginal[indexOne], dim]
                                        + (1.0 - tem) * population[indexOriginal[indexTwo], dim];
                                }
                            }
                            else
                            {
                                // select normals to generate a new individual
                                double r = rand.NextDouble(); // generate a random number
                                int indexOne = numberElitist + rand.Next(numberNormal); // Convert.ToInt32(Math.Floor(number_normal * rand.NextDouble()));
                                int indexTwo = numberElitist + rand.Next(numberNormal); // Convert.ToInt32(Math.Floor(number_normal * rand.NextDouble()));
                                if (indexOne == indexTwo) // avoid same index
                                {
                                    // inx_selected_two = number_elitist + number_normal - (inx_selected_one - number_elitist) - 1;
                                    indexTwo = numberElitist + Parameter.Population - indexOne - 1;
                                }

                                if (r < probabilityOne) // use one normal to generate a new individual
                                {
                                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                    {
                                        solution[dim] = population[indexOriginal[indexOne], dim];
                                    }
                                }
                                else // use two elitists to generate a new individual
                                {
                                    double tem = rand.NextDouble();
                                    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                    {
                                        solution[dim] = tem * population[indexOriginal[indexOne], dim]
                                            + (1 - tem) * population[indexOriginal[indexTwo], dim];
                                    }
                                }
                            }

                            for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            {
                                stepSize = 0.15 * rand.NextDouble() * Math.Pow(10.0, Math.Exp((-1.0 * ite) / (Parameter.Iteration - ite)));
                                // solution[dim] = solution[dim] + stepSize * rand.NextDouble() * Probability.Gaussian(0.0, 1.0);
                                solution[dim] += stepSize * Probability.gaussian(rand.NextDouble()
                                * (ite / Parameter.size + 5)) * (rand.NextDouble() - 0.5);

                                if (solution[dim] > Parameter.Upper[dim])
                                {
                                    solution[dim] = Parameter.Upper[dim];
                                }
                                else if (solution[dim] < Parameter.Lower[dim])
                                {
                                    solution[dim] = Parameter.Lower[dim];
                                }
                            }

                            // selection between new one and the old one with the same index
                            double fv = function(type, ref solution); // calculate

                            if (fv < fitness[idx])  // better than the previous one, replace
                            {
                                fitness[idx] = fv;
                                for (int dim = 0; dim < Parameter.Dimension; ++dim)
                                {
                                    population[idx, dim] = solution[dim];
                                    // pbest[idx, dim] = solution[dim];
                                }
                            }
                            //else
                            //{
                            //    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            //    {
                            //        // replace the selected individual
                            //        population[idx, dim] = solution[dim];
                            //    }
                            //}
                            //else
                            //{
                            //    // keep the previous one 
                            //    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                            //    {
                            //        population_temporary[idx, dim] = population[idx, dim];
                            //    }
                            //}
                        }
                    }

                    // copy temporary population to population to start next iteration
                    //for (int num = 0; num < Parameter.Population; ++num)
                    //{
                    //    for (int dim = 0; dim < Parameter.Dimension; ++dim)
                    //    {
                    //        population[num, dim] = population_temporary[num, dim];
                    //    }
                    //}

                    //#region disrupt individual
                    //// don't do disruption for the first generation
                    //// if (ite > 0) // not the first iteration
                    //// {
                    //// disrupt every genration but for one dimension of one individual
                    //double rDisrupt = rand.NextDouble();  // generate a randon value
                    //                                      // decide whether to select one individual to be disrupted
                    //if (rDisrupt < probabilityDisrupt)
                    //{

                    //}
                    //#endregion // disrupt individual
                }

                #region measurement
                //switch (type)
                //{
                //    case Function.n1:
                //        count2 += Measure2.N1measure(ref population);
                //        count4 += Measure4.N1measure(ref population);
                //        break;

                //    case Function.n2:
                //        count2 += Measure2.N2measure(ref population);
                //        count4 += Measure4.N2measure(ref population);
                //        break;

                //    case Function.n3:
                //        count2 += Measure2.N3measure(ref population);
                //        count4 += Measure4.N3measure(ref population);
                //        break;

                //    case Function.n4:
                //        count2 += Measure2.N4measure(ref population);
                //        count4 += Measure4.N4measure(ref population);
                //        break;

                //    case Function.n5:
                //        count2 += Measure2.N5measure(ref population);
                //        count4 += Measure4.N5measure(ref population);
                //        break;

                //    case Function.n6:
                //        count2 += Measure2.N6measure(ref population);
                //        count4 += Measure4.N6measure(ref population);
                //        break;

                //    case Function.n7:
                //        count2 += Measure2.N7measure(ref population);
                //        count4 += Measure4.N7measure(ref population);
                //        break;

                //    default:
                //        Console.WriteLine("Not a valid function type");
                //        Console.ReadKey();
                //        break;
                //}

                Archive.AchiveMeasure(type, ref orCount, ref srCount, ref enough);
                //logSentence = type.ToString() + " kbso optima Count " + orCount.ToString();
                //Console.WriteLine(logSentence);
                #endregion

                // Console.WriteLine("function {0}, run {1}, result is {2}", type, run, trajectory[max_iteration_comp - 1]);

                //logSentence = type.ToString() + " fitness [kbso] " + trajectory[Parameter.Iteration - 1].ToString() + " run "
                //    + run.ToString();
                //Console.WriteLine(logSentence);
                diverityMeasure += Measure.diversity;
                logSentence = type.ToString() + " fitness [kbsoos] " + globalValue.ToString()
                    + " run " + run.ToString() + " optima " + orCount.ToString() + ", diversity " + Measure.diversity.ToString();
                Console.WriteLine(logSentence);
                log.Add(logSentence);

                bestFitness.Add(globalValue);
                string trajectoryName = type.ToString() + "."
                    + Parameter.Dimension.ToString() + "." + run.ToString() + ".txt";
                Write.writeTrajectory(trajectoryName, ref trajectory);
            }

            #region time cost
            end = DateTime.Now;
            Console.WriteLine("Hour: {0}, Minute: {1}, Second:{2}", end.Hour, end.Minute, end.Second);

            diff = end - start;

            //Console.WriteLine($"{diff.TotalSeconds} seconds have passed since the start.");

            diffTime = diff.TotalSeconds;

            Console.WriteLine("{0} seconds have passed since the start.", diffTime);
            #endregion

            logName = "_" + type.ToString() + ".kbsoos." + Parameter.Dimension.ToString() + ".txt";

            logSentence = type.ToString() + " kbsoos start time: Hour:" + start.Hour
           + " Minute: " + start.Minute + " Second: " + start.Second;
            log.Add(logSentence);

            logSentence = type.ToString() + " kbsoos end time: Hour:" + end.Hour
                + " Minute: " + end.Minute + " Second: " + end.Second;
            log.Add(logSentence);

            logSentence = type.ToString() + " kbsoos " + diffTime + " seconds for " + Parameter.Run.ToString() + " runs";
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            logSentence = type.ToString() + " worstcount " + worstCount.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            logSentence = type.ToString() + " worstcount2 " + worstCount2.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // global count
            logSentence = type.ToString() + " kbsoos optima count " + orCount.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            logSentence = type.ToString() + " kbsoos success count " + srCount.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            successRate = Convert.ToDouble(srCount) / Parameter.Run;
            logSentence = type.ToString() + " kbsoos success rate (SR) " + successRate.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // diversity measure
            diverityMeasure /= Parameter.Run;
            logSentence = type.ToString() + " diversity measure " + diverityMeasure.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // diversity rate
            diversityR = DiversityRate.RateDiversity(type, diverityMeasure);

            logSentence = type.ToString() + " diversity all " + DiversityRate.diversityAll.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            if (!(DiversityRate.diversityAll > 0))
            {
                diversityR = successRate;
            }

            logSentence = type.ToString() + " diversity rate " + diversityR.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            #region statistical indicator
            // best of local ring best fitness
            bestFitness.Sort();
            logSentence = type.ToString() + " kbso best fitness "
                + bestFitness[0].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // middle of local ring best fitness
            logSentence = type.ToString() + " kbso middle fitness "
                + bestFitness[Parameter.Run / 2].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // worst of local ring best fitness
            logSentence = type.ToString() + " kbso worst fitness "
                + bestFitness[Parameter.Run - 1].ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // calculate mean of the best particle fitness in each round
            double mean = 0.0;
            foreach (double number in bestFitness)
            {
                mean += number;
            }
            mean /= Parameter.Run;
            logSentence = type.ToString() + " kbso best mean "
                + mean.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // variance
            double variance = 0.0;
            foreach (double number in bestFitness)
            {
                variance += (number - mean) * (number - mean);
            }
            variance /= Parameter.Run;
            logSentence = type.ToString() + " " + Parameter.Run.ToString()
                + " runs, variance " + variance.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);

            // standard deviation
            double deviation = 0.0;
            deviation = Math.Sqrt(variance);
            logSentence = type.ToString() + " " + Parameter.Run.ToString()
                + " runs, standard deviation " + deviation.ToString();
            Console.WriteLine(logSentence);
            log.Add(logSentence);
            bestFitness.Clear();

            Write.writeLog(logName, ref log);
            #endregion
            log.Clear();

        }

        public static double function(Function type, ref double[] solution)
        {
            double minimum = double.MaxValue;

            switch (type)
            {
                case Function.f01:
                    minimum = Nonlinear.F01(ref solution);
                    break;

                case Function.f02:
                    minimum = Nonlinear.F02(ref solution);
                    break;

                case Function.f03:
                    minimum = Nonlinear.F03(ref solution);
                    break;

                case Function.f04:
                    minimum = Nonlinear.F04(ref solution);
                    break;

                case Function.f05:
                    minimum = Nonlinear.F05(ref solution);
                    break;

                case Function.f06:
                    minimum = Nonlinear.F06(ref solution);
                    break;

                case Function.f07:
                    minimum = Nonlinear.F07(ref solution);
                    break;

                case Function.f08:
                    minimum = Nonlinear.F08(ref solution);
                    break;

                case Function.f09:
                    minimum = Nonlinear.F09(ref solution);
                    break;

                case Function.f10:
                    minimum = Nonlinear.F10(ref solution);
                    break;

                case Function.f11:
                    minimum = Nonlinear.F11(ref solution);
                    break;

                case Function.f12:
                    minimum = Nonlinear.F12(ref solution);
                    break;

                case Function.f13:
                    minimum = Nonlinear.F13(ref solution);
                    break;

                case Function.f14:
                    minimum = Nonlinear.F14(ref solution);
                    break;

                case Function.f15:
                    minimum = Nonlinear.F15(ref solution);
                    break;

                case Function.f16:
                    minimum = Nonlinear.F16(ref solution);
                    break;

                case Function.f17:
                    minimum = Nonlinear.F17(ref solution);
                    break;

                case Function.f18:
                    minimum = Nonlinear.F18(ref solution);
                    break;

                case Function.f19:
                    minimum = Nonlinear.F19(ref solution);
                    break;

                case Function.f20:
                    minimum = Nonlinear.F20(ref solution);
                    break;

                case Function.f21:
                    minimum = Nonlinear.F21(ref solution);
                    break;

                case Function.f22:
                    minimum = Nonlinear.F22(ref solution);
                    break;

                case Function.f23:
                    minimum = Nonlinear.F23(ref solution);
                    break;

                case Function.f24:
                    minimum = Nonlinear.F24(ref solution);
                    break;

                case Function.f25:
                    minimum = Nonlinear.F25(ref solution);
                    break;

                case Function.f26:
                    minimum = Nonlinear.F26(ref solution);
                    break;

                case Function.f27:
                    minimum = Nonlinear.F27(ref solution);
                    break;

                case Function.f28:
                    minimum = Nonlinear.F28(ref solution);
                    break;

                case Function.f29:
                    minimum = Nonlinear.F29(ref solution);
                    break;

                case Function.f30:
                    minimum = Nonlinear.F30(ref solution);
                    break;

                default:
                    Console.WriteLine("Not a valid function type");
                    Console.ReadKey();
                    break;
            }
            return minimum;
        }
    }
}