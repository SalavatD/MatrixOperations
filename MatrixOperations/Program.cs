using System;
using System.Runtime.InteropServices;

namespace ConsoleApp2
{
    class Program
    {
        [DllImport("C:\\Users\\User\\source\\repos\\ConsoleApp1\\x64\\Debug\\Dll1.dll")]
        public static unsafe extern void ToFoldMatrices(double* A, double* B, int n, int m, double* C);

        [DllImport("C:\\Users\\User\\source\\repos\\ConsoleApp1\\x64\\Debug\\Dll1.dll")]
        public static unsafe extern void MultiplyMatrices(double* A, int nA, int mA, double* B, int nB, int mB, double* C);

        [DllImport("C:\\Users\\User\\source\\repos\\ConsoleApp1\\x64\\Debug\\Dll1.dll")]
        public static unsafe extern void TransposeMatrix(double* A, int nA, int mA, double* B);

        static void Main(string[] args)
        {
            int nA = 15;
            int mA = 15;
            int nB = 15;
            int mB = 15;

            double[,] matrixA = new double[nA, mA];
            double[,] matrixB = new double[nB, mB];

            double[,] toFoldMatricesResult = new double[nA, mA];
            double[,] multiplyMatricesResult = new double[nA, mB];
            double[,] transposeMatrixAResult = new double[mA, nA];

            Console.WriteLine("Matrix A({0}, {1}):", nA, mA);
            for (int i = 0; i < nA; i++)
            {
                for (int j = 0; j < mA; j++)
                {
                    matrixA[i, j] = 2;
                    Console.Write(matrixA[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Matrix B({0}, {1}):", nB, mB);
            for (int i = 0; i < nB; i++)
            {
                for (int j = 0; j < mB; j++)
                {
                    matrixB[i, j] = 3;
                    Console.Write(matrixB[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            unsafe
            {
                fixed (double* ptrMatrixA = matrixA,
                    ptrMatrixB = matrixB,
                    ptrToFoldMatricesResult = toFoldMatricesResult,
                    ptrMultiplyMatricesResult = multiplyMatricesResult,
                    ptrTransposeMatrixAResult = transposeMatrixAResult)
                {
                    ToFoldMatrices(ptrMatrixA, ptrMatrixB, nA, mA, ptrToFoldMatricesResult);
                    MultiplyMatrices(ptrMatrixA, nA, mA, ptrMatrixB, nB, mB, ptrMultiplyMatricesResult);
                    TransposeMatrix(ptrMatrixA, nA, mA, ptrTransposeMatrixAResult);
                }
            }

            Console.WriteLine("To Fold Matrices Result ({0}, {1}):", nA, mA);
            for (int i = 0; i < nA; i++)
            {
                for (int j = 0; j < mA; j++)
                {
                    Console.Write(toFoldMatricesResult[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Multiply Matrices Result ({0}, {1}):", nA, mB);
            for (int i = 0; i < nA; i++)
            {
                for (int j = 0; j < mB; j++)
                {
                    Console.Write(multiplyMatricesResult[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Transpose Matrix A Result ({0}, {1}):", mA, nA);
            for (int i = 0; i < mA; i++)
            {
                for (int j = 0; j < nA; j++)
                {
                    Console.Write(transposeMatrixAResult[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
