using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ExamlesCs
{
    class Program
    {
        static int count = 0;

        static Mutex myMutex = new Mutex();

        static void Main(string[] args)
        {
            Thread myThread1 = new Thread(new ThreadStart(Program.function));

            myThread1.IsBackground = false;
            myThread1.Start();
            //myThread1.Join();
            Console.WriteLine(count);
            
        }

        static void function()
        {
            //myMutex.WaitOne();
            for (int i = 0; i < 100000000; i++)
                count++;
            //myMutex.ReleaseMutex();
   
        }
    }
}
