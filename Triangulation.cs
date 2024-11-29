using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorProject
{
    internal class Triangulation
    {
        public List<double> UniqueNumbers;
        public List<Triangle> Triangles;

        public Triangulation()
        {
            UniqueNumbers = new List<double>();
            Triangles = new List<Triangle>();
        }
        ~Triangulation() { }
    }
}
