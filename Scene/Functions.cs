using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scene
{
    static class Functions
    {
        public static float funcLine(float x, float k, float b)
        {
            return k * x + b;
        }

        public static float funcSquare(float x, float a, float b, float c)
        {
            return a * x * x + b * x + c;
        }

        public static float funcParaboloid(float x, float y, float a, float b)
        {
            return x * x / (a * a) - y * y / (b * b); 
        }
        
        public static float funcPlane(float x, float y)
        {
            return x + y;
        }

        public static float funcTest(float x, float y)
        {
           
            return Convert.ToSingle(Math.Sin(x)+Math.Cos(y));
        }

        public static float funcLineZValue(float x, float x1, float x2, float y1, float y2, float z1, float z2)
        {
            return z1 + (((x - x1)/(x2 - x1)*(y2 - y1) - y1)*(x2 - x1)*(z2 - z1)) /(y2 - y1)*(x - x1);
        }



        public static float[] arrange(float start, float end, uint amount)
        {
            float h = (end - start) / amount;
            float[] result = new float[amount];
            for (uint i = 0; i < amount; i++)
            {
                result[i] = start;
                start += h;
            }
            return result;
        }
    }
}
