using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triangle
{
    class CalcTriangle
    {
        private Stopwatch _timeAlgorithm;
        private Stopwatch _timeReadFile;
        private Stopwatch _timePrintTriangle;

        private List<ArrayList> _triangle;

        private int _result = 0;
        private int _maxElement = 0;
        private int _minElement = 0;

        public void PrintTriangle()
        {
            if (_triangle == null)
            {
                Console.WriteLine("No triangle");
            }
            else
            {
                _timePrintTriangle = Stopwatch.StartNew();

                foreach (var line in _triangle)
                {
                    for (int i = 0; i < line.Count; i++)
                    {
                        Console.Write(line[i] + " ");
                    }
                    Console.WriteLine();
                }

                _timePrintTriangle.Stop();
            }
        }


        public void TriangleCalc()
        {
            if (_triangle == null)
            {
                Console.WriteLine("No triangle");
            }
            else
            {
                _timeAlgorithm = Stopwatch.StartNew();

                int pos = 0;

                foreach (var line in _triangle)
                {
                    char shift = '=';
                    var max = Convert.ToInt32(line[pos]);

                    if (pos - 1 >= 0)
                    {
                        int temp = Convert.ToInt32(line[pos - 1]);
                        if (max < temp)
                        {
                            max = temp;
                            shift = '-';
                        }
                    }

                    if (pos + 1 < line.Count)
                    {
                        int temp = Convert.ToInt32(line[pos + 1]);

                        if (max < temp)
                        {
                            max = temp;
                            shift = '+';
                        }
                    }

                    _result += max;

                    switch (shift)
                    {
                        case '+': pos += 1; break;
                        case '-': pos -= 1; break;
                    }

                    var tmpList = line;
                    tmpList.Sort();

                    var tmpMin = Convert.ToInt32(tmpList[0]);
                    var tmpMax = Convert.ToInt32(tmpList[tmpList.Count - 1]);

                    if (tmpMax > _maxElement)
                        _maxElement = tmpMax;

                    if (tmpMin < _minElement)
                        _minElement = tmpMin;
                }

                _timeAlgorithm.Stop();
            }
        }


        public bool ReadFile(string filePath)
        {
            bool getFile = false;

            if (string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine("No path to file");
                getFile = false;
            }
            else
            {

                try
                {
                    _timeReadFile = Stopwatch.StartNew();

                    _triangle = new List<ArrayList>();

                    StreamReader file = new StreamReader(filePath);
                    string line = "";

                    while (line != null)
                    {
                        line = file.ReadLine();
                        if (!string.IsNullOrEmpty(line))
                        {
                            ArrayList row = new ArrayList();
                            string[] split = line.Split(' ');
                            foreach (var sp in split)
                            {
                                row.Add(Convert.ToInt32(sp));
                            }
                            _triangle.Add(row);
                        }

                    }

                    _timeReadFile.Stop();
                    getFile = true;
                }


                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    getFile = false;
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    getFile = false;
                }
            }
            return getFile;
        }

        public void PrintResult()
        {
            Console.WriteLine("Result = " + _result);
            Console.WriteLine("MaxElement = " + _maxElement);
            Console.WriteLine("MinElement = " + _minElement);

            if (_timeReadFile != null)
                Console.WriteLine("Time taken to read the file: {0}ms", _timeReadFile.Elapsed.TotalMilliseconds);
            if (_timeAlgorithm != null)
                Console.WriteLine("The elapsed time of the algorithm: {0}ms", _timeAlgorithm.Elapsed.TotalMilliseconds);
            if (_timePrintTriangle != null)
                Console.WriteLine("The elapsed time to print triangle: {0}ms", _timeAlgorithm.Elapsed.TotalMilliseconds);
        }

    }
}
