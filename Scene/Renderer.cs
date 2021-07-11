using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using OpenTK.WinForms;
using OpenTK.Graphics.OpenGL4;

namespace Scene
{
    static class Renderer
    {
        static public void render(string type, GLControl glControl, Elements elements)
        {
            GL.ClearColor(Color.FromArgb(88, 94, 93, 255));
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            switch (type)
            {
                case "scene": { renderScene(glControl,elements); };break;
                case "projection": { renderProjection(glControl, elements); }; break;
            }
            glControl.SwapBuffers();
        }

        static public void renderScene(GLControl glControl, Elements elements) {
            elements.bottom.OnRender(elements.shader);
            if (elements.section != null)
            {
                elements.section.OnRender(elements.shader);
            }
            elements.camControl.OnRender(elements.shader);
        }

        static public void renderProjection(GLControl glControl, Elements elements)
        {
            //
        }
    }
}
