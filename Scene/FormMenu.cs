using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;
using OpenTK.WinForms;


namespace Scene
{
    public partial class FormMenu : Form
    {

        Scene scene;
        string PATH_WORKING_DIR = "./";
        Size dW;
        unsafe IGraphicsContext controlToContext = new GLFWGraphicsContext(null);

        public FormMenu()
        {
            InitializeComponent();
            dW = this.Size;
            dW.Width -= glScene.Width;
            dW.Height -= glScene.Height;
        }

        private void formOnResize(object sender, EventArgs e)
        {

        }

        private void OnResize(object sender, EventArgs e)
        {
            Size nSize = new Size();
            nSize.Width = this.Width - dW.Width;
            nSize.Height = this.Height - dW.Height;
            glScene.Size = nSize;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            
            
            Vector2i size = new Vector2i();
            size.X = glScene.Width;
            size.Y = glScene.Height;
            scene = new Scene(size);


            glScene.Resize += glOnResize;
            glScene.Select();

            dataLoad();
        }

        private void dataLoad()
        { 
            dataSection.ForeColor = Color.Black;
            DataGridViewRowHeaderCell header = new DataGridViewRowHeaderCell();
            for (int i = 0; i < 2; i++)
            {
                dataSection.Rows.Add();
                header.Value = i + 1;
                dataSection.Rows[i].HeaderCell = header;
            }
            

            float[][] data = scene._landscape.bottom.GetMesh();
            DataTable matrix = new DataTable("Mesh");
            matrix.Clear();
            //for (uint i = 0; i < data.Length; i++)
            //{
            //    matrix.Columns.Add(i.ToString(), Type.GetType("string"));
            //}
            //for(uint i = 0; i < data.Length; i++)
            //{
            //    matrix.Rows.Add(data[i]);
            //    for(uint j = 0; j < data[i].Length; j++)
            //    {
                    
            //    }
            //}

            dataBottom.DataSource = matrix;
        }

        private void glOnLoad(object sender, EventArgs e)
        {
            GL.ClearColor(Color.FromArgb(88, 94, 93, 255));
            GL.Enable(EnableCap.DepthTest);
            GL.Viewport(0, 0, glScene.Width, glScene.Height);
            glScene.Invalidate();
            GL.Flush();
            GL.Viewport(0, 0, glProfile.Width, glProfile.Height);
            glProfile.Invalidate();
        }

        private void glOnResize(object sender, EventArgs e)
        {
            glScene.MakeCurrent();
            GL.Viewport(0, 0, glScene.Width, glScene.Height);
            glScene.Invalidate();
        }

        double frame = 0;
        private void Render()
        {    
            // Simple displaying amount of elapsed time
            textFrames.Text = frame.ToString();
            frame += 1;
            // render time
            glScene.MakeCurrent();
            glProfile.Invalidate();
            GL.ClearColor(Color.FromArgb(88, 94, 93, 255));
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            scene.OnRender();
            GL.Flush();
            glScene.SwapBuffers();
        }

        // Render the "Main" GL viewport
        private void glOnPaint(object sender, PaintEventArgs e)
        {
            Render();
        }
        
        // Render when mouse moves
        private void glOnDraw(object sender, MouseEventArgs e)
        {
            scene.OnMouseMove(e);
            Render();
        }

        private void glMouseMove(object sender, MouseEventArgs e)
        {
            //scene.OnMouseMove(e);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            // doesn't work
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            // doesn't work
        }

        private void OnKeyPrewDown(object sender, PreviewKeyDownEventArgs e)
        {
            scene.OnKeyDown(e);
            Render();
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == System.Windows.Forms.Keys.E)
            //{
            //    scene.grabedMouse = false;
            //}
        }

        private void glOnMouseLeave(object sender, EventArgs e)
        {
            if(scene.grabedMouse == true)
            {
                scene.OnMouseLeave();
            }
        }

        private void eventButtonSave(object sender, EventArgs e)
        {
            //openFile.InitialDirectory = PATH_WORKING_DIR;
            //openFile.ShowDialog();
            //fileWatcher.EnableRaisingEvents = true;
            saveFile.AddExtension = true;
            saveFile.AutoUpgradeEnabled = true;
            saveFile.Filter = "TIFF files (*.tiff)|*.tiff|XML files(*.xml)|*.xml|JSON files (*.json)|*.json|All files (*.*)|*.*";
            saveFile.ShowDialog();

        }

        private void objectDoSection(object sender, EventArgs e)
        {
            int size = 3;
            float[] v1 = new float[size];
            float[] v2 = new float[size];
            for  (int i = 0; i < size; i++)
            {
                v1[i] = float.Parse(dataSection.Rows[0].Cells[i].Value.ToString());
            }
            for (int i = 0; i < size; i++)
            {
                v2[i] = float.Parse(dataSection.Rows[1].Cells[i].Value.ToString());
            }
            scene.doSection(v1, v2);
            tabGLControls.SelectedIndex = 1;
        }


        private void glProfile_OnLoad(object sender, EventArgs e)
        {
            GL.ClearColor(Color.FromArgb(88, 94, 93, 255));
            GL.Enable(EnableCap.DepthTest);
            GL.Viewport(0, 0, glProfile.Width, glProfile.Height);
            glProfile.Invalidate();
        }

        private void glProfile_OnPaint(object sender, PaintEventArgs e)
        {
            glProfile.MakeCurrent();
            glProfile.Invalidate();
            GL.ClearColor(Color.FromArgb(255, 255, 204, 255));
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            GL.Flush();
            glProfile.SwapBuffers();
        }
    }
}
