using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LearnOpenTK.Common;

namespace Scene
{
    class Section : IElement
    {
        Square array;

        public Section()
        {

        }

        ~Section()
        {

        }

        public void OnRender(Shader shader) { }

        public void OnUnload() { }

        public float[][] doVerticesToArray(float[] vert)
        {
            int size = vert.Length;
            int points = 4;
            int offset = size / points;
            float[][] matr = new float[points][];
            for (short i = 0; i < points; i++)
            {
                matr[i] = new float[3];
                for (short j = 0; j < 3; j++)
                {
                    matr[i][j] = 0;
                }
            }
            for (int ii = 0, i = 0, j = 0; i < points; ii -= 3, ii = ii + offset, i++, j = 0)
            {
                matr[i][j] = vert[ii];
                ii++; j++;
                matr[i][j] = vert[ii];
                ii++; j++;
                matr[i][j] = vert[ii];
            }
            return doFindMinMaxVector(matr);
        }

        public float[][] doFindMinMaxVector(float[][] matr)
        {
            float[][] vert = new float[2][];
            for (short i = 0; i < 2; i++)
            {
                vert[i] = new float[3];
                for (short j = 0; j < 3; j++)
                {
                    vert[i][j] = matr[i][j];
                }
            }

            for (short i = 0; i < 4; i++)
            {
                for (short j = 0; j < 3; j++)
                {
                    if (vert[0][j] > matr[i][j])
                    {
                        vert[0][j] = matr[i][j];
                    }
                    if (vert[1][j] < matr[i][j])
                    {
                        vert[1][j] = matr[i][j];
                    }


                }
            }
            return vert;
        }

        // find where section crosses the bottom
        public void doCalculate(ObjectArrayPlane land)
        {
            float[][] sect = doVerticesToArray(array._vertices);
            uint rows = land.rows;
            uint cols = land.cols;
            uint size = rows * cols;
            float[][][] btm = new float[size][][];
            for (uint i = 0, k = 0; i < cols; i++)
            {
                for (uint j = 0; j < rows; j++)
                {
                    btm[k] = doVerticesToArray(land.squares[i][j]._vertices);
                    k++;
                }
            }

            float[][] flsect = new float[size][];
            for (uint i = 0, j = 0; i < size; i++)
            {
                if (sect[1][0] >= btm[i][0][0] && sect[1][1] >= btm[i][0][1] &&
                    sect[0][0] <= btm[i][1][0] && sect[0][1] <= btm[i][1][1])
                {
                    float x1 = sect[0][0];
                    float x2 = sect[1][0];
                    float x3 = btm[i][0][0];
                    float x4 = btm[i][1][0];
                    float y1 = sect[0][1];
                    float y2 = sect[1][1];
                    float y3 = btm[i][0][1];
                    float y4 = btm[i][1][1];

                    float p = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
                    float x0 = ((x1 * y2 - y1 * x2) * (x3 - x4) - (x1 - x2) * (x3 * y4 - y3 * x4)) / p;
                    float y0 = ((x1 * y2 - y1 * x2) * (y3 - y4) - (y1 - y2) * (x3 * y4 - y3 * x4)) / p;
                    float z = 0;


                    if (x1 == x3 && y1 != y3)
                    {
                        float c = Math.Abs(btm[i][0][2] - btm[i][1][2]);
                        float x = Math.Abs(y3 - y0);
                        float y = Math.Abs(y4 - y0);
                        float k = x / y;
                        float a = 1.0f / (1.0f + k);
                        z = a * c + btm[i][0][2];
                    }
                    else if (y1 == y3 && x1 != x3)
                    {
                        float c = Math.Abs(btm[i][0][2] - btm[i][1][2]);
                        float x = Math.Abs(x3 - x0);
                        float y = Math.Abs(x4 - x0);
                        float k = x / y;
                        float a = 1.0f / (1.0f + k);
                        z = a * c + btm[i][0][2];
                    }
                    else
                    {
                        z = btm[i][0][2];
                    }

                    flsect[j] = new float[3];
                    flsect[j][0] = x0;
                    flsect[j][1] = y0;
                    flsect[j][2] = z;
                    j++;
                }
            }

        }

    }
}
