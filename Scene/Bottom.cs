using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LearnOpenTK.Common;

namespace Scene 
{
    class Bottom : IElement
    {
        ObjectArrayPlane array;

        public Bottom(float x, float y, float z, uint scale, Shader shader)
        {
            float x1 = x / 2;
            float y1 = y / 2;
            uint a = scale;
            float[] X = Functions.arrange(-x1, x1, a);
            float[] Y = Functions.arrange(-y1, y1, a);
            float[][] Z = new float[a][];
            for (uint i = 0; i < a; i++)
            {
                Z[i] = new float[a];
                for (int j = 0; j < a; j++)
                {
                    Z[i][j] = Functions.funcTest(X[j], Y[i]);
                    //Z[i][j] = Functions.funcParaboloid(X[j], Y[i], 5, 3);
                    Z[i][j] += z;
                }
            }
            defineBottom(X, Y, Z, shader);
            
        }

        ~Bottom()
        {
            OnUnload();
        }

        public void OnRender(Shader shader)
        {
            array.OnRenderFrame(shader);
        }

        public void OnUnload() {
            array.OnUnload();
        }

        public void defineBottom(float[] x, float[] y, float[][] z, Shader shader)
        {
            array = new ObjectArrayPlane(x, y, z, shader);
            array.loadTextureFromFile("Resources/spr.png");
        }



    }
}
