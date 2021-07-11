using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LearnOpenTK.Common;

namespace Scene
{
    public interface IElement
    {
        public void OnRender(Shader shader) { }

        //public void OnInit(Shader shader) { }

        public void OnUnload() { }
    }
}
