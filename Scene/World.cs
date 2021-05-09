using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LearnOpenTK.Common;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Scene
{
    class World
    {
        public Square box;

        public ObjectArrayPlane bottom;

        public World(float x, float y, float z, Shader shader, bool isTextured = true)
        {
            x /= 2f;
            y /= 2f;
            float[] v1 = { -x, -y, z };
            float[] v2 = { x, y, z };
            box = new Square(v1, v2);
            box.loadShaderDependence(shader);

            float s = -10f;
            float e = 10f;
            uint a = 100;
            float[] X = Functions.arrange(s, e, a);
            float[] Y = Functions.arrange(s, e, a);
            float[][] Z = new float[a][];
            for (uint i = 0; i < a; i++)
            {
                Z[i] = new float[a];
                for (int j = 0; j < a; j++)
                {
                    Z[i][j] = Functions.funcTest(X[j], Y[i]);
                    //Z[i][j] = Functions.funcParaboloid(X[j], Y[i], 5, 3);
                    Z[i][j] += 2;
                }
            }
            //defineBottom(X, Y, Z, shader);
        }

        public void defineBottom(float[] x, float[] y, float[][] z, Shader shader)
        {
            bottom = new ObjectArrayPlane(x, y, z, shader);
            bottom.loadTextureFromFile("Resources/sqr.png");
        }

        public void loadTextureFromFile(string path)
        {
            box.loadTextureFromFile(path);
        }

        public void OnRenderFrame(Shader shader)
        {
            box.OnRenderFrame(shader);
            //plane.OnRenderFrame(shader);
            //bottom.OnRenderFrame(shader);
        }

        public void OnUnload()
        {
            box.OnUnload();
        }

        
    }
}
