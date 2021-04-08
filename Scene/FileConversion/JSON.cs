using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

using OpenTK;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;
using OpenTK.WinForms;

using Newtonsoft.Json;

namespace Scene.FileConversion
{
    static class JSON
    {
        
        static public void loadFromFile()
        {
            

            return;
        }

        static public void loadToFile(string name, float[] x, float[] y, float[][] z)
        {
            string X = JsonConvert.SerializeObject(x);
            string Y = JsonConvert.SerializeObject(y);
            string Z = JsonConvert.SerializeObject(z);

            var g = 0;
            
            return;
        }
    }
}
