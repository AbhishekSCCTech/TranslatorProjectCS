using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorProject
{
    internal class Point
    {
        private int mX;
        private int mY;
        private int mZ;

        // Constructor
        public Point(int x, int y, int z)
        {
            mX = x;
            mY = y;
            mZ = z;
        }

        ~Point()
        {
        }

        // Properties for X, Y, Z
        public int X => mX;
        public int Y => mY;
        public int Z => mZ;

        public bool IsLessThan(Point other)
        {
            if (mX != other.mX)
                return mX < other.mX;

            if (mY != other.mY)
                return mY < other.mY;

            return mZ < other.mZ;
        }
    }

}
