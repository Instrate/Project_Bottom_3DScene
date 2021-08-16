using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        private Stopwatch _clock = null;
        private Vector2i _camSize;
        public int viewStyle = 0;

        public CameraControl(Vector2i Size)
        {
            _firstMove = true;
            grabedMouse = false;
            cameraSpeed = 7f;
            _camSize = Size;
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

            cameraView();

            shader.Use();
        }

        public void OnMouseMove(MouseEventArgs mouse, Size size)
        {

            float sensitivity = 0.3f;
            Vector2 displaySize = new Vector2
            {
                X = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width,
                Y = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
            };
            if (grabedMouse == true)
            {
                //Cursor.Hide();
                if (_firstMove)
                {
                    _firstMove = false;
                    Cursor.Position = new System.Drawing.Point((int)displaySize.X / 2, (int)displaySize.Y / 2);
                    //_lastPos = new Vector2(mouse.X + (int)displaySize.X / 2, mouse.Y + (int)displaySize.Y / 2);
                    _lastPos = new Vector2(0, 0);
                }
                else //if (displaySize.X / 2 != Cursor.Position.X && displaySize.Y / 2 != Cursor.Position.Y)
                {   
                    
                    // Calculate the offset of the mouse position
                    //float deltaX = mouse.X - displaySize.X;
                    float deltaX = mouse.X * size.Width / displaySize.X - _lastPos.X;
                    //float deltaY = mouse.Y - displaySize.Y;
                    float deltaY = mouse.Y * size.Height / displaySize.Y - _lastPos.Y;

                    Vector2 newPos = new Vector2{
                        X = _lastPos.X + deltaX, 
                        Y = _lastPos.Y + deltaY };
                    
                    //Cursor.Position = new System.Drawing.Point((int)displaySize.X / 2, (int)displaySize.Y / 2);
                    // Apply the camera pitch and yaw (we clamp the pitch in the camera class)
                    camera.Yaw -= deltaX * sensitivity;
                    camera.Pitch -= deltaY * sensitivity; // reversed since y-coordinates range from bottom to top
                    _lastPos = newPos;
                }
            }
            else
            {
                Cursor.Show();
            }
        }

        public void OnMouseLeave()
        {
            _clock = null;
            grabedMouse = false;
            //_firstMove = true;
            //_lastPos = new Vector2()
            Cursor.Show();
        }

        public void OnKeyDown(PreviewKeyDownEventArgs e)
        {
            if (_clock == null)
            {
                _clock = new Stopwatch();
                _clock.Restart();
            }
            double coolTime = 1000;
            double elapsed = _clock.Elapsed.TotalMilliseconds;
            double time = elapsed / coolTime;
            if (time > 1)
            {
                time = 1.0 / coolTime;
            }
            _clock.Restart();
            float offset = 5;
            Keys input = e.KeyCode;
            switch (input)
            {
                case Keys.W:
                    {
                        camera.Position += camera.Front * cameraSpeed * (float)time;
                    }; break;
                case Keys.S:
                    {
                        camera.Position -= camera.Front * cameraSpeed * (float)time;
                    }; break;
                case Keys.A:
                    {
                        camera.Position -= camera.Right * cameraSpeed * (float)time;
                    }; break;
                case Keys.D:
                    {
                        camera.Position += camera.Right * cameraSpeed * (float)time;
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
                case Keys.Up:
                    {
                        Vector3 temp = camera.Position;
                        camera.Position = new Vector3()
                        {
                            X = temp.X,
                            Y = temp.Y,
                            Z = temp.Z - 1
                        };

                    }; break;
                case Keys.Down:
                    {
                        Vector3 temp = camera.Position;
                        camera.Position = new Vector3()
                        {
                            X = temp.X,
                            Y = temp.Y,
                            Z = temp.Z - 1
                        };
                    }; break;
                case Keys.E:
                    {
                        if (grabedMouse == false)
                        {
                            grabedMouse = true;
                            _lastPos.X = Cursor.Position.X * _camSize.X / Cursor.Position.X / 2;
                            _lastPos.Y = Cursor.Position.Y * _camSize.Y / Cursor.Position.Y / 2;
                            Vector2 displaySize = new Vector2
                            {
                                X = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width,
                                Y = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
                            };
                            Cursor.Position = new System.Drawing.Point((int)displaySize.X / 2, (int)displaySize.Y / 2);
                        }
                        else
                        {
                            //_firstMove = true;    
                            grabedMouse = false;
                        }
                    }; break;
            }
            if (grabedMouse == false)
            {
                Cursor.Show();
                _clock = null;
            }
        }

        private void cameraView() {
            switch (viewStyle)
            {
                case 1: {
                        //camera.Yaw = 90;
                        camera.Pitch = 0;
                    }; break;
                case 2: { }; break;
                case 3: { }; break;
                case 4: { }; break;
                default: break;
            }
            
        }

        public void rayCast()
        {

        }
    }
}
