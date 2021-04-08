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
    class Square
    {
        public float[] _vertices;

        int size;
        int off;

        int _vertexBufferObject;
        int _vertexArrayObject;
        int _elementBufferObject;

        public float[] _t = {
            1.0f, 0.0f,
            1.0f, 1.0f,
            0.0f, 1.0f,
            0.0f, 0.0f
        };

        public readonly float[] color =
        {
            0f, 0f, 0f,
            0f, 0f, 0f,
            0f, 0f, 0f,
            0f, 0f, 0f
        };

        public readonly uint[] _indices = {
            0, 1, 3,
            1, 2, 3
        };

        Texture texture;
        bool _textureEnable;

        public Square(float[] x, float[] y, float[] z, bool isTextured = true)
        {
            _textureEnable = isTextured;
            _buildVertice(x, y, z);
            if (isTextured == true)
            {
                _buildTextureVertice();
            }
            else
            {
                _buildColorVertice();
            }
            _loadBufferObject();
            _loadArrayObject();
            _loadElementBufferObject();
        }

        public Square(float[] v1, float[] v2, bool isTextured = true)
        {
            _textureEnable = isTextured;
            _buildVertice(v1, v2);
            if (isTextured == true)
            {
                _buildTextureVertice();
            }
            else
            {
                _buildColorVertice();
            }
            _loadBufferObject();
            _loadArrayObject();
            _loadElementBufferObject();
        }

        void _buildVertice(float[] x, float[] y, float[] z)
        {
            size = 24;
            off = size / 4;
            _vertices = new float[size];
            _vertices[0] = x[1]; // x
            _vertices[1] = y[1]; // y
            _vertices[2] = z[0]; // z
            _vertices[0 + off] = x[1]; // x
            _vertices[1 + off] = y[0]; // y
            _vertices[2 + off] = z[1]; // z
            _vertices[0 + 2 * off] = x[0]; // x
            _vertices[1 + 2 * off] = y[0]; // y
            _vertices[2 + 2 * off] = z[2]; // z
            _vertices[0 + 3 * off] = x[0]; // x
            _vertices[1 + 3 * off] = y[1]; // y
            _vertices[2 + 3 * off] = z[3]; // z
        }

        void _buildVertice(float[] v1, float[] v2)
        {
            size = 24;
            off = size / 4;
            _vertices = new float[size];
            _vertices[0] = v2[0]; // x
            _vertices[1] = v2[1]; // y
            _vertices[2] = v2[2]; // z
            _vertices[0 + off] = v2[0]; // x
            _vertices[1 + off] = v1[1]; // y
            _vertices[2 + off] = v1[2]; // z
            _vertices[0 + 2 * off] = v1[0]; // x
            _vertices[1 + 2 * off] = v1[1]; // y
            _vertices[2 + 2 * off] = v1[2]; // z
            _vertices[0 + 3 * off] = v1[0]; // x
            _vertices[1 + 3 * off] = v2[1]; // y
            _vertices[2 + 3 * off] = v2[2]; // z
        }

        void _buildTextureVertice()
        {
            for (int i = 3, j = 0; i < _vertices.Length; i += off - 2, j += 1)
            {
                _vertices[i] = _t[j];
                i++; j++;
                _vertices[i] = _t[j];
                i++;
                _vertices[i] = 0;
            }
        }

        void _buildColorVertice()
        {
            int offset = _vertices.Length / 4;
            for(int i = 6, j = 0; i < _vertices.Length; i += offset, j++)
            {
                _vertices[i] = color[j];
                i++; j++;
                _vertices[i] = color[j];
                i++; j++;
                _vertices[i] = color[j];
            }
        }

        void _loadBufferObject()
        {
            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
        }

        void _loadArrayObject()
        {
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, off * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
        }

        void _loadElementBufferObject()
        {
            _elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);
        }

        public void loadShaderDependence(Shader shader)
        {
            var vertexLocation = shader.GetAttribLocation("aPosition");
            GL.EnableVertexAttribArray(vertexLocation);
            GL.VertexAttribPointer(vertexLocation, 3, VertexAttribPointerType.Float, false, off * sizeof(float), 0);

            int texCoordLocation;
            if (_textureEnable == true) { 
                texCoordLocation = shader.GetAttribLocation("aTexCoord");
            }
            else
            {
                texCoordLocation = shader.GetAttribLocation("aColor");
            }
            GL.EnableVertexAttribArray(texCoordLocation);
            if (_textureEnable == true)
            {
                GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, off * sizeof(float), 3 * sizeof(float));
            }
            else
            {
                GL.VertexAttribPointer(texCoordLocation, 3, VertexAttribPointerType.Float, false, off * sizeof(float), 6 * sizeof(float));
            }
        }

        public void loadTextureFromFile(string path)
        {
            texture = Texture.LoadFromFile(path);
            texture.Use(TextureUnit.Texture0);
        }

        public void OnRenderFrame(Shader shader)
        {
            texture.Use(TextureUnit.Texture0);
            shader.Use();
            GL.BindVertexArray(_vertexArrayObject);
            GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
            return;
        }

        public void OnRenderFrameArray(Shader shader)
        {
            GL.BindVertexArray(_vertexArrayObject);
            GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        public void OnUnload()
        {
            GL.DeleteBuffer(_vertexBufferObject);
            GL.DeleteBuffer(_elementBufferObject);
            GL.DeleteVertexArray(_vertexArrayObject);
            GL.DeleteTexture(texture.Handle);
        }
    }
}
