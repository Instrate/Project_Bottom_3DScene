using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scene.Source
{

    class Light
    {
        static string _basicLightShaderPath = "Shaders/lighting.frag";
        static string _basicVertexShaderPath = "Shaders/shader.vert";
        static string _basicFragShaderPath = "Shaders/shader.frag";

        private Vector3 _lightPos; // Vector3(1.2f, 1.0f, 2.0f) by default

        private int _vaoModel;

        private int _vaoLamp;

        private Shader _lampShader;

        private Shader _lightingShader;

        public void OnLoad(int vertSize, Vector3 lightPos)
        {
            _lightPos = lightPos;

            _lightingShader = new Shader(_basicVertexShaderPath, _basicLightShaderPath);
            _lampShader = new Shader(_basicVertexShaderPath, _basicFragShaderPath);

            int offset = 3;
            int size = vertSize / 4;
            {
                _vaoModel = GL.GenVertexArray();
                GL.BindVertexArray(_vaoModel);
                int positionLocation = _lightingShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(positionLocation);
                GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, size * sizeof(float), 0);

                int normalLocation = _lightingShader.GetAttribLocation("aNormal");
                GL.EnableVertexAttribArray(normalLocation);
                GL.VertexAttribPointer(normalLocation, 3, VertexAttribPointerType.Float, false, size * sizeof(float), offset);
            }

            {
                _vaoLamp = GL.GenVertexArray();
                GL.BindVertexArray(_vaoLamp);

                int positionLocation = _lampShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(positionLocation);
                GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, size * sizeof(float), 0);
            }
        }

        public void OnRenderFrame(Camera camera)
        {
            GL.BindVertexArray(_vaoModel);

            GL.BindVertexArray(_vaoModel);

            _lightingShader.Use();

            _lightingShader.SetMatrix4("model", Matrix4.Identity);
            _lightingShader.SetMatrix4("view", camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", camera.GetProjectionMatrix());

            _lightingShader.SetVector3("objectColor", new Vector3(1.0f, 0.5f, 0.31f));
            _lightingShader.SetVector3("lightColor", new Vector3(1.0f, 1.0f, 1.0f));
            _lightingShader.SetVector3("lightPos", _lightPos);
            _lightingShader.SetVector3("viewPos", camera.Position);

            GL.BindVertexArray(_vaoModel);

            _lampShader.Use();

            Matrix4 lampMatrix = Matrix4.CreateScale(0.2f);
            lampMatrix = lampMatrix * Matrix4.CreateTranslation(_lightPos);

            _lampShader.SetMatrix4("model", lampMatrix);
            _lampShader.SetMatrix4("view", camera.GetViewMatrix());
            _lampShader.SetMatrix4("projection", camera.GetProjectionMatrix());
        }

        public void OnDelete()
        {
            GL.DeleteVertexArray(_vaoModel);
            GL.DeleteVertexArray(_vaoLamp);

            GL.DeleteProgram(_lampShader.Handle);
            GL.DeleteProgram(_lightingShader.Handle);
        }
    }
}
