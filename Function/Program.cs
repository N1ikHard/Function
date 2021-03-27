using System;
using System.Threading;

namespace Function
{
    static class Function
    {
        /// <summary>
        /// Метод умножающий квадратичные матрицы
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        static public double[,] MatrixMult(double[,] A, double[,] B)
        {
            if (A.GetLength(1) != B.GetLength(0)) return null;
            double[,] C = new double[A.GetLength(0), B.GetLength(1)];
            for (int i = 0; i < C.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(0); j++)
                {
                    C[i, j] = 0;
                    for (int k = 0; k < C.GetLength(1); k++)
                    {
                        C[i, j] += A[k, i] * B[j, k];
                    }
                }
            }
            return C;
        }
        /// <summary>
        /// Метод поиска подстроки в строке
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="txt"></param>
        /// <returns></returns>
        static public bool FindTxt(string Text, string txt)
        {
            if (txt.Length >= Text.Length) return false;
            bool presence = false;
            for (int j, i = 0; i <= Text.Length - txt.Length; i++)
            {
                j = 0;
                if (Text[i] == txt[j])
                {
                    j++;
                    int k = i + 1;
                    while (Text[k] == txt[j])
                    {
                        k++; j++;
                        if (j == txt.Length) return presence = true;
                    }
                }
            }
            return presence;
        }
        /// <summary>
        /// Таймер , принимает в себя количество секунд
        /// </summary>
        /// <param name="obj"></param>
        static public void Timer(object obj)
        {
            int second = (int)obj;
            int count = 1;
            while (count <= second)
            {
                Thread.Sleep(1000);
                count++;
            }
        }
        /// <summary>
        /// Секундомер
        /// </summary>
        /// <returns></returns>
        static public int Stopwatch()
        {
            int count = 0;
            Thread thread = new Thread(new ThreadStart(() => { if (Console.ReadKey().Key == ConsoleKey.Escape) Thread.CurrentThread.Interrupt(); }));
            thread.Start();
            Console.WriteLine("Beggining");
            while (true)
            {
                if (thread.ThreadState != ThreadState.Running) break;
                count++;
                Thread.Sleep(1000);
            }
            return count;
        }
    }
}
