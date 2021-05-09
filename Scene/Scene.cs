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
        }

        public void OnRenderProfile()
        {
            if (profile != null)
            {
                profile.OnRenderFrame(_shader);
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
            doCalculate();
            profile.loadShaderDependence(_shader);
        }

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
        public void doCalculate()
        {
            float[][] sect = doVerticesToArray(profile._vertices);
            uint rows = _landscape.bottom.rows;
            uint cols = _landscape.bottom.cols;
            uint size = rows * cols;
            float[][][] btm = new float[size][][];
            for (uint i = 0, k = 0; i < cols; i++)
            {
                for (uint j = 0; j < rows; j++)
                {
                    btm[k] = doVerticesToArray(_landscape.bottom.squares[i][j]._vertices);
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
