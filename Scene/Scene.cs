using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

using LearnOpenTK.Common;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;
using OpenTK.WinForms;

using Keys = System.Windows.Forms.Keys;


namespace Scene
{
    sealed class PATH
    {
        public static string SHADER_VERT = "Shaders/shader.vert";
        public static string SHADER_FRAG = "Shaders/shader.frag";
        public static string TEXTURE_PLANE = "Resources/plane.png";
    }

    class Scene
    {
        double _time;

        Camera _camera;
        bool _firstMove = true;
        public bool grabedMouse = false;
        Vector2 _lastPos;
        float cameraSpeed = 7f;

        Shader _shader;

        public World _landscape;

        public Stopwatch _clock;

        Square profile = null;

        public Scene(Vector2i Size)
        {

            _shader = new Shader(PATH.SHADER_VERT, PATH.SHADER_FRAG);
            _shader.Use();
            _shader.SetInt("texture0", 0);

            _landscape = new World(20, 20, -1, _shader);
            _landscape.loadTextureFromFile(PATH.TEXTURE_PLANE);

            _camera = new Camera(Vector3.UnitZ * 4, Size.X / (float)Size.Y);


            float[] v1 = { 4, 4, 2 };
            float[] v2 = { -5, 5, 5 };
            doSection(v1, v2);
            _clock = new Stopwatch();
            _clock.Start();
        }

        public void OnRender()
        {
            Matrix4 model = Matrix4.Identity * Matrix4.CreateRotationX((float)MathHelper.DegreesToRadians(0));

            _shader.SetMatrix4("model", model);
            _shader.SetMatrix4("view", _camera.GetViewMatrix());
            _shader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            _shader.Use();

            _landscape.OnRenderFrame(_shader);
            OnRenderProfile(_shader);
        }

        public void OnRenderProfile(Shader shader)
        {
            if (profile != null)
            {
                profile.OnRenderFrame(shader);
            }
        }

        public void OnMouseMove(MouseEventArgs mouse)
        {
            _clock.Restart();
            float sensitivity = 0.3f;
            if (grabedMouse == true)
            {
                if (_firstMove)
                {
                    _lastPos = new Vector2(mouse.X, mouse.Y);
                    _firstMove = false;
                }
                else
                {

                    // Calculate the offset of the mouse position
                    var deltaX = mouse.X - _lastPos.X;
                    var deltaY = mouse.Y - _lastPos.Y;
                    _lastPos = new Vector2(mouse.X, mouse.Y);

                    // Apply the camera pitch and yaw (we clamp the pitch in the camera class)
                    _camera.Yaw -= deltaX * sensitivity;
                    _camera.Pitch -= deltaY * sensitivity; // reversed since y-coordinates range from bottom to top
                }
            }
        }

        public void OnMouseLeave()
        {
            _clock.Reset();
            //MouseState mouse;
            grabedMouse = false;
        }

        public void OnKeyDown(PreviewKeyDownEventArgs e)
        {


            double time = _clock.Elapsed.TotalMilliseconds / 1000.0;
            _clock.Restart();
            float offset = 5;
            Keys input = e.KeyCode;
            switch (input)
            {
                case Keys.W:
                    {
                        _camera.Position += _camera.Front * cameraSpeed * (float)time;
                    }; break;
                case Keys.S:
                    {
                        _camera.Position -= _camera.Front * cameraSpeed * (float)time;
                    }; break;
                case Keys.A:
                    {
                        _camera.Position -= _camera.Right * cameraSpeed * (float)time;
                    }; break;
                case Keys.D:
                    {
                        _camera.Position += _camera.Right * cameraSpeed * (float)time;
                    }; break;
                case Keys.Oemplus:
                    {
                        _camera.Fov -= offset;
                    }; break;
                case Keys.OemMinus:
                    {
                        _camera.Fov += offset;
                    }; break;
                case Keys.Shift:
                    {
                        cameraSpeed = 15f;
                    }; break;
                case Keys.LControlKey:
                    {
                        cameraSpeed = 2.5f;
                    }; break;
                case Keys.E:
                    {
                        if (grabedMouse == false)
                        {
                            grabedMouse = true;
                        }
                        else
                        {
                            grabedMouse = false;
                        }
                    }; break;
            }
        }

        public void doSection(float[] v1, float[] v2)
        {
            profile = new Square(v1, v2);
            //doCalculate();
            profile.loadShaderDependence(_shader);
        }

        
    }
}
