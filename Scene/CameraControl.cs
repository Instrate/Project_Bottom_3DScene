using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using LearnOpenTK.Common;
using OpenTK.Mathematics;
using Keys = System.Windows.Forms.Keys;

namespace Scene
{
    class CameraControl
    {
        public Camera camera;
        bool _firstMove;
        public bool grabedMouse;
        Vector2 _lastPos;
        public float cameraSpeed;

        public CameraControl(Vector2i Size)
        {
            _firstMove = true;
            grabedMouse = false;
            cameraSpeed = 7f;
            camera = new Camera(Vector3.UnitZ * 4, Size.X / (float)Size.Y);
        }

        ~CameraControl()
        {

        }

        public void OnRender(Shader shader)
        {
            Matrix4 model = Matrix4.Identity * Matrix4.CreateRotationX((float)MathHelper.DegreesToRadians(0));

            shader.SetMatrix4("model", model);
            shader.SetMatrix4("view", camera.GetViewMatrix());
            shader.SetMatrix4("projection", camera.GetProjectionMatrix());

            shader.Use();
        }

        public void MouseMove(MouseEventArgs mouse)
        {

        }

        public void OnMouseLeave()
        {
            //_clock.Reset();
            grabedMouse = false;
        }

        public void OnKeyDown(PreviewKeyDownEventArgs e)
        {
            //double time = _clock.Elapsed.TotalMilliseconds / 1000.0;
            //_clock.Restart();
            float offset = 5;
            Keys input = e.KeyCode;
            switch (input)
            {
                case Keys.W:
                    {
                        //camera.Position += camera.Front * cameraSpeed * (float)time;
                    }; break;
                case Keys.S:
                    {
                        //camera.Position -= camera.Front * cameraSpeed * (float)time;
                    }; break;
                case Keys.A:
                    {
                        //camera.Position -= camera.Right * cameraSpeed * (float)time;
                    }; break;
                case Keys.D:
                    {
                        //camera.Position += camera.Right * cameraSpeed * (float)time;
                    }; break;
                case Keys.Oemplus:
                    {
                        camera.Fov -= offset;
                    }; break;
                case Keys.OemMinus:
                    {
                        camera.Fov += offset;
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
    }
}
