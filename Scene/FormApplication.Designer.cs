
namespace Scene
{
    partial class FormApplication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.glWindow = new OpenTK.WinForms.GLControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // glWindow
            // 
            this.glWindow.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            this.glWindow.APIVersion = new System.Version(3, 3, 0, 0);
            this.glWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glWindow.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
            this.glWindow.IsEventDriven = true;
            this.glWindow.Location = new System.Drawing.Point(0, 0);
            this.glWindow.Name = "glWindow";
            this.glWindow.Profile = OpenTK.Windowing.Common.ContextProfile.Core;
            this.glWindow.Size = new System.Drawing.Size(781, 590);
            this.glWindow.TabIndex = 0;
            this.glWindow.Text = "glWindow";
            this.glWindow.Load += new System.EventHandler(this.glOnLoad);
            this.glWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.glOnPaint);
            this.glWindow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glOnDraw);
            this.glWindow.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.OnKeyPrewDown);
            this.glWindow.Resize += new System.EventHandler(this.glOnResize);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(781, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 590);
            this.panel1.TabIndex = 1;
            // 
            // FormApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1143, 590);
            this.Controls.Add(this.glWindow);
            this.Controls.Add(this.panel1);
            this.Name = "FormApplication";
            this.Text = "Application";
            this.Load += new System.EventHandler(this.OnLoad);
            this.Resize += new System.EventHandler(this.OnResize);
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.WinForms.GLControl glWindow;
        private System.Windows.Forms.Panel panel1;
    }
}