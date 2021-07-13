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
    public class ObjectArrayPlane
    {
        // structure of an object
        public Square[][] squares;

        Texture texture;

        public uint rows;
        public uint cols;

        public ObjectArrayPlane(float[] x, float[] y, float[][] z, Shader shader)
        {
            
            rows = (uint)x.Length - 1;
            cols = (uint)y.Length - 1;
            squares = new Square[cols][];
              
            for (uint i = 0; i < cols; i++)
            {
                squares[i] = new Square[rows];
                for (uint j = 0; j < rows; j++)
                {
                    float[] X = { x[j], x[j + 1] };
                    float[] Y = { y[i], y[i + 1] };
                    float[] Z =
                    {
                        z[i + 1][j + 1], // bottom right
                        z[i][j + 1], // top right 
                        z[i][j], // top left
                        z[i + 1][j] // bottom left
                    };
                    squares[i][j] = new Square(X, Y, Z);
                    squares[i][j].loadShaderDependence(shader);
                }
            }
            
        }
        public void loadTextureFromFile(string path)
        {
            texture = Texture.LoadFromFile(path);
            //texture.Use(TextureUnit.Texture0);
        }

        public void OnRenderFrame(Shader shader)
        {
            texture.Use(TextureUnit.Texture0);
            shader.Use();
            for (uint i = 0; i < cols; i++)
            {
                for (uint j = 0; j < rows; j++)
                {
                    squares[i][j].OnRenderFrameArray(shader);
                }
            }
            return;
        }

        public void OnUnload()
        {
            for (uint i = 0; i < cols; i++)
            {
                for (uint j = 0; j < rows; j++)
                {
                    squares[i][j].OnUnload();
                }
            }
        }

        public float[][] GetMesh()
        {
            int offset = squares[0][0]._vertices.Length / 4;
            float[][] Z = new float[cols][];
            for(uint i = 0; i < cols; i++)
            {
                Z[i] = new float[rows];
                for(uint j = 0; j < rows; j++)
                {
                    Z[i][j] = squares[i][j]._vertices[2 * offset + 2];
                }
            }
            return Z;
        }
    }
}
