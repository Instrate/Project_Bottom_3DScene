using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace Scene
{
    public partial class FormApplication : Form
    {
        private Size sizeDelta;
        Elements scene = null;
        bool _glLoaded = false;
        bool _renderFull = true;
        DebugHelper cmd = null;

        public FormApplication()
        {
            InitializeComponent();
            sizeDelta = this.Size;
            sizeDelta.Width -= glWindow.Width;
            sizeDelta.Height -= glWindow.Height;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            Vector2i size = new Vector2i()
            {
                X = glWindow.Width,
                Y = glWindow.Height
            };
            scene = new Elements(size, 100);

            glWindow.Resize += glOnResize;
            glWindow.Select();
            _glLoaded = true;

            cmd = new DebugHelper();
            dataLoad();
        }

        public void dataLoad()
        {
            dataGridSection.Rows.Add();
            dataGridSection.Rows.Add();

        }

        private void OnResize(object sender, EventArgs e)
        {
            Size size = new Size {
                Width = this.Width - sizeDelta.Width,
                Height = this.Height - sizeDelta.Height
            };
            glWindow.Size = size;
        }

        
        private void OnKeyPrewDown(object sender, PreviewKeyDownEventArgs e)
        {
            scene.camControl.OnKeyDown(e);
            Render();
        }

        private void glOnLoad(object sender, EventArgs e)
        {
            GL.ClearColor(Color.FromArgb(88, 94, 93, 255));
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend | EnableCap.FogCoordArray);
            GL.Viewport(0, 0, glWindow.Width, glWindow.Height);
            glWindow.MakeCurrent();
            glWindow.Invalidate();
            GL.Flush();
        }

        private void glOnPaint(object sender, PaintEventArgs e)
        {
            Render();
        }

        private void glOnDraw(object sender, MouseEventArgs e)
        {
            Vector2i point = new Vector2i
            {
                X = this.Size.Width / 2,
                Y = this.Size.Height / 2
            };

            //Cursor = new System.Windows.Forms.Cursor(Cursor.Current.Handle);
            //System.Windows.Forms.Cursor.Position = new Point(point.X, point.Y);

            scene.camControl.OnMouseMove(e,glWindow.Size);
            Render();
        }

        private void glOnResize(object sender, EventArgs e)
        {
            if (!_glLoaded)
            {
                return;
            }
            glWindow.MakeCurrent();
            GL.Viewport(0, 0, glWindow.Width, glWindow.Height);
            glWindow.Invalidate();
        }

        private void bottomChangeSharp(object sender, EventArgs e)
        {
            Vector2i size = new Vector2i()
            {
                X = glWindow.Width,
                Y = glWindow.Height
            };
            scene = new Elements(size,(uint) scaleSharp.Value);
            glWindow.Focus();
        }

        private void glOnMouseLeave(object sender, EventArgs e)
        {
            scene.camControl.OnMouseLeave();
        }

        public void Render()
        {
            if (_renderFull)
            {
                Renderer.render("scene", glWindow, scene);
            }
            else
            {
                Renderer.render("projection", glWindow, scene);
            }
        }

        private void comboCamera_SelectedValueChanged(object sender, EventArgs e)
        {
            scene.camControl.viewStyle = comboCamera.SelectedIndex;
            glWindow.Focus();
        }
    }
}
