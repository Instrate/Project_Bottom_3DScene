using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LearnOpenTK.Common;
using OpenTK.Mathematics;
using Keys = System.Windows.Forms.Keys;

namespace Scene
{
    class Elements
    {
        public Bottom bottom = null;
        public Section section = null;
        public CameraControl camControl = null;
        public Shader shader = null;

        public Elements(Vector2i Size, uint scale)
        {
            shader = new Shader(PATH.SHADER_VERT, PATH.SHADER_FRAG);
            shader.Use();
            shader.SetInt("texture0", 0);

            camControl = new CameraControl(Size);

            bottom = new Bottom(20, 20, 0, scale, shader);

            section = new Section(new float[] { 0, 0, 0 }, new float[] { 3, 3, 0 });
            
        }

        ~Elements()
        {

        }



    }
}
