using System;

namespace Adaline_NN
{

    class Program
    {
        
        static double WeightA = new Random().Next(0,1);
        static double WeightB = new Random().Next(0,1);
        static double Bias = new Random().Next(0,1);
        static double LearningRate = 0.1;
             
        static int[] T = new int[4];
        static double[] Y = new double[4];
        static int[] A = new int[4];
        static int[] B = new int[4];
        static int[] result = new int[4];



        static void Main(string[] args)
        {
            int epoch_count = 1;
            int i, j,k;
            for (i = 0; i < 4; i++)
            {
                Console.WriteLine("Enter the value of A [" + i + "] :");
                A[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the value of B [" + i + "] :");
                B[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the value of T [" + i + "] :");
                T[i] = Convert.ToInt32(Console.ReadLine());


            }
            while (epoch_count < 10)
            {
                Console.WriteLine("Epoch " + epoch_count);
                for (j = 0; j < 4; j++)
                {
                    Console.WriteLine("Training Set " + (j + 1));
                    training(A[j], B[j], T[j], Y[j]);
                    result[j] = condition(A[j], B[j], WeightA, WeightB, Bias);
                }
               for  (k=0;k<4;k++)
                {
                    Console.WriteLine(result[k]);
                }

                epoch_count++;

            }
           
        }
        public static void training(int A, int B, int T, double Y)
        {
            Y = Bias + WeightA * A + WeightB * B;
            WeightA = WeightA + A * (T - Y) * LearningRate;
            WeightB = WeightB + B * (T - Y) * LearningRate;
            Bias = Bias + Convert.ToDouble((T - Y) * LearningRate);
            Console.WriteLine("Yin:" + Y + " " + "WeightA:" + WeightA + " " + "WeightB:" + WeightB + " " + "Bias:" + Bias);

        }
        public static int condition(int A, int B, double WeightA, double WeightB, double Bias)
        {
            if ((Bias + WeightA * A + WeightB * B) >= 0)
                return 1;
            else
                return 0;
             
        }
    }
}
