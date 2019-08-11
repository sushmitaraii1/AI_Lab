using System;

namespace Backpopagation
{
    class Program
    {
        static double[,] weight = new double[6, 6];
        static double[] bias = new double[6];
        static double Learning_rate = 0.1;
        static double[] O = new double[6];
        static double[] I = new double[6];
        static double[] E = new double[6];

        static int[] T = new int[4];
        static int[] A = new int[4];
        static int[] B = new int[4];

        static void Main(string[] args)
        {
            int epoch_count = 1;
           randoiminitialize(bias, weight);

            int i, j, k;
            for (i = 0; i < 4; i++)
            {
                Console.WriteLine("Enter the value of A [" + i + "] :");
                A[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the value of B [" + i + "] :");
                B[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the value of T [" + i + "] :");
                T[i] = Convert.ToInt32(Console.ReadLine());



            }
            
            while (epoch_count <= 5)
            {
                Console.WriteLine("Epoch " + epoch_count);
                for (j = 0; j < 4; j++)
                {
                    Console.WriteLine("Training Set " + (j + 1));
                    training(A[j], B[j], T[j]);
                    for (i = 1; i <= 2; i++)
                    {
                        for (k = 3; k <= 4; k++)
                        {
                            Console.WriteLine("Weight" + i + " " + k + " :"+weight[i,k]);
                           

                        }
                    }
                    
                        for (k = 3; k <= 4; k++)
                        {
                            Console.WriteLine("Weight" + i + " " + 5 + " :"+weight[k,5]);


                        }
                }
                epoch_count++;



            }

        }
        public static void randoiminitialize(double[] bias, double[,] weight)
        {
            Console.WriteLine("Random Initialization for bias:");
            for (int i = 3; i <= 5; i++)
            {

                bias[i] = new Random().NextDouble();
          

                 Console.WriteLine("bias[" + i + "] = " + bias[i]);
            }
            Console.WriteLine("Random Initialization for weight:");
            for (int i = 1; i <= 2; i++)
            {
                for (int j = 3; j <= 4; j++)
                {
                      weight[i, j] = new Random().NextDouble();

                    

                }
                  for (int j = 3; j <= 4; j++)
                {

                      weight[j, 5] = new Random().NextDouble();


                }  

            }
            for (int i = 1; i <= 2; i++)
            {
                for (int j = 3; j <= 4; j++)
                {

                    Console.WriteLine("weight[" + i + "][" + j + "] =" + weight[i, j]);
                }
            }
            for (int j = 3; j <= 4; j++)
            {
                Console.WriteLine("weight[" + j + "][" + 5 + "] =" + weight[j, 5]);
            }

        }
        public static void training(int A, int B, int T)
        {
            I[1] = A;
            I[2] = B;
            O[1] = I[1];
            O[2] = I[2];
            

            //step3
            for (int j = 3; j <= 4; j++)
            {

                I[j] = weight[1,j] * O[1] + weight[2,j] * O[2] + bias[j];
                O[j] = 1 / (1 + Math.Exp(-I[j]));
                

            }
            
            //step4
            I[5] = weight[3,5] * O[3] + weight[4,5] + bias[5];
            O[5] = 1 / (1 + Math.Exp(-I[5]));
          
            //step5
            E[5] = O[5] * (1 - O[5]) * (T - O[5]);

            for (int j = 3; j <= 4; j++)
            {

                E[j] = O[j] * (1 - O[j]) * (E[5] * weight[j,5]);
            }


            //step6 update
            for (int i = 1; i <= 2; i++)
            {

                for (int j = 3; j <= 4; j++)
                {

                    weight[i,j] = weight[i,j] + (Learning_rate * E[j] * O[i]);

                }
            }

            for (int j = 3; j <= 4; j++)
            {

                bias[j] = bias[j] + (Learning_rate * E[j]);

                weight[j,5] = weight[j,5] + (Learning_rate * E[5] * O[j]);
            }

            bias[5] = bias[5] + (Learning_rate * E[5]);


        }
    }
} 

