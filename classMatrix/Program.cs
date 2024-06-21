using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix A = new Matrix(@"..\..\TextFile1.txt");
            foreach (string s in A.View())
                Console.WriteLine(s);
            Console.WriteLine();
            Matrix B = new Matrix(A);
            Matrix C = A + B;
            foreach (string s in C.View())
                Console.WriteLine(s);
            Console.WriteLine();
            Matrix D = A * B;
            if (D != Matrix.Empty)
                foreach (string s in D.View())
                    Console.WriteLine(s);

        }
    }
}
