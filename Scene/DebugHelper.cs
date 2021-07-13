using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Scene
{
    class DebugHelper
    {
        public Process console = null;

        public DebugHelper()
        {
            console = new Process();
            console.StartInfo = new ProcessStartInfo(@"cmd.exe");
            console.StartInfo.RedirectStandardInput = true;
            console.StartInfo.UseShellExecute = false;
            console.Start();
        }

        public void Write(string command)
        {
            console.StandardInput.WriteLine("echo " + command);
        }

    }
}
