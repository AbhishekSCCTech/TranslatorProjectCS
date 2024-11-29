using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TranslatorProject
{
    internal class STLReader
    {
        private const double TOLERANCE = 0.0000001;

        public STLReader() { }

        public bool Compare(double a, double b)
        {
            // Compares two doubles with a tolerance
            return Math.Abs(a - b) > TOLERANCE ? a < b : false;
        }
        private static int CompareValues(double a, double b)
        {
            // Compares two doubles with tolerance
            if (Math.Abs(a - b) > TOLERANCE)
                return a < b ? -1 : 1;
            return 0;
        }

        public void read(string fileName, Triangulation triangulation)
        {
            SortedDictionary<double, int> uniqueValueMap = new SortedDictionary<double, int>(Comparer<double>.Create(CompareValues));
            double[] xyz = new double[3]; // To store 3 coordinates as double
            List<int> pointIndices = new List<int>();


            if (File.Exists(fileName))
            {
                foreach (string line in File.ReadLines(fileName))
                {
                    var words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < words.Length; i++)
                    {
                        if (words[i] == "vertex" || words[i] == "normal")
                        {
                            xyz[0] = double.Parse(words[i + 1]);
                            xyz[1] = double.Parse(words[i + 2]);
                            xyz[2] = double.Parse(words[i + 3]);
                            i += 3; // Skip parsed values

                            for (int j = 0; j < 3; j++)
                            {
                                if (!uniqueValueMap.TryGetValue(xyz[j], out int index))
                                {
                                    triangulation.UniqueNumbers.Add(xyz[j]);
                                    int newIndex = triangulation.UniqueNumbers.Count - 1;
                                    uniqueValueMap[xyz[j]] = newIndex;
                                    pointIndices.Add(newIndex);
                                }
                                else
                                {
                                    pointIndices.Add(index);
                                }
                            }
                        }

                        if (pointIndices.Count == 12)
                        {
                            var normal = new Point(pointIndices[0], pointIndices[1], pointIndices[2]);
                            var p1 = new Point(pointIndices[3], pointIndices[4], pointIndices[5]);
                            var p2 = new Point(pointIndices[6], pointIndices[7], pointIndices[8]);
                            var p3 = new Point(pointIndices[9], pointIndices[10], pointIndices[11]);
                            var triangle = new Triangle(normal, p1, p2, p3);
                            triangulation.Triangles.Add(triangle);
                            pointIndices.Clear();
                        }
                    }
                }
            }
        }
    }
    
}
