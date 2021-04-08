using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using LearnOpenTK.Common;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;



namespace Scene
{

    class Window : GameWindow
    {

        //static string _path_add = "../../../";

        World world;

        Shader _shader;

        double _time;

        Camera _camera;

        bool _firstMove = true;

        Vector2 _lastPos;

        // input 
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState input = KeyboardState;

            if (!IsFocused) // check to see if the window is focused
            {
                return;
            }

            float cameraSpeed;
            float sensitivity = 0.2f;

            if (input.IsKeyDown(Keys.LeftShift))
            {
                cameraSpeed = 7f;
            }
            else
            {
                cameraSpeed = 1.5f;
            }

            if (input.IsKeyDown(Keys.W))
            {
                _camera.Position += _camera.Front * cameraSpeed * (float)e.Time; // Forward
            }

            if (input.IsKeyDown(Keys.S))
            {
                _camera.Position -= _camera.Front * cameraSpeed * (float)e.Time; // Backwards
            }
            if (input.IsKeyDown(Keys.A))
            {
                _camera.Position -= _camera.Right * cameraSpeed * (float)e.Time; // Left
            }
            if (input.IsKeyDown(Keys.D))
            {
                _camera.Position += _camera.Right * cameraSpeed * (float)e.Time; // Right
            }
            if (input.IsKeyDown(Keys.Space))
            {
                _camera.Position += _camera.Up * cameraSpeed * (float)e.Time; // Up
            }
            if (input.IsKeyDown(Keys.LeftControl))
            {
                _camera.Position -= _camera.Up * cameraSpeed * (float)e.Time; // Down
            }

            // Get the mouse state
            var mouse = MouseState;

            if (_firstMove) // this bool variable is initially set to true
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

            if (input.IsKeyDown(Keys.Escape)) {
                Close();
            }
            
            base.OnUpdateFrame(e);
        }

        // In the mouse wheel function we manage all the zooming of the camera
        // this is simply done by changing the FOV of the camera
        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            _camera.Fov -= e.OffsetY;
            base.OnMouseWheel(e);
        }

        protected override void OnLoad()
        {
            GL.ClearColor(Color.FromArgb(72, 118, 181, 255));

            GL.Enable(EnableCap.DepthTest);

            _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
            _shader.Use();
            _shader.SetInt("texture0", 0);


            world = new World(5f, 5f, 0f, _shader);
            world.loadTextureFromFile("Resources/plane.png");

            _camera = new Camera(Vector3.UnitZ * 3, Size.X / (float)Size.Y);
            CursorGrabbed = true;

            base.OnLoad();
        }

        double max_time = 1;
        double time = 0;
        double frame = 0;
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            _time += 100  * e.Time;
            if (time >= max_time) {
                Title = $"Fps: {frame:0}";
                frame = 0;
                time = 0;
            } else
            {
                frame += 1;
                time += e.Time;
            }

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            var model = Matrix4.Identity * Matrix4.CreateRotationX((float)MathHelper.DegreesToRadians(0));

            _shader.SetMatrix4("model", model);
            _shader.SetMatrix4("view", _camera.GetViewMatrix());
            _shader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            _shader.Use();

            world.OnRenderFrame(_shader);

            SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnUnload()
        {
            CursorGrabbed = false;

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);
            GL.DeleteProgram(_shader.Handle);
            base.OnUnload();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, Size.X, Size.Y);
            _camera.AspectRatio = Size.X / (float)Size.Y;
            base.OnResize(e);
        }

        // ctor
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base (gameWindowSettings, nativeWindowSettings)
        {

        }

    }
}
