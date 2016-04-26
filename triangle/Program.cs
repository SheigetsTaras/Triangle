using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triangle
{
    class Program
    {

        static void Main(string[] args)
        {
            CalcTriangle calcTriangle = new CalcTriangle();

            Boolean readFileStatus;
            if (args.Length != 0)
            {
                readFileStatus = calcTriangle.ReadFile(args[0]);
            }
            else
            {
                readFileStatus = calcTriangle.ReadFile(Console.ReadLine());

            }

            if (readFileStatus == true)
            {
                calcTriangle.PrintTriangle();
                calcTriangle.TriangleCalc();
                calcTriangle.PrintResult();
            }

            Console.ReadLine();
        }
    }
}
