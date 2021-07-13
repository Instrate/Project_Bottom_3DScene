
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
            this.dataGridSection = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboCamera = new System.Windows.Forms.ComboBox();
            this.scaleSharp = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleSharp)).BeginInit();
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
            this.glWindow.Leave += new System.EventHandler(this.glOnMouseLeave);
            this.glWindow.MouseLeave += new System.EventHandler(this.glOnMouseLeave);
            this.glWindow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glOnDraw);
            this.glWindow.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.OnKeyPrewDown);
            this.glWindow.Resize += new System.EventHandler(this.glOnResize);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.dataGridSection);
            this.panel1.Controls.Add(this.comboCamera);
            this.panel1.Controls.Add(this.scaleSharp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(781, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 590);
            this.panel1.TabIndex = 1;
            // 
            // dataGridSection
            // 
            this.dataGridSection.BackgroundColor = System.Drawing.SystemColors.Highlight;
            this.dataGridSection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridSection.Location = new System.Drawing.Point(40, 184);
            this.dataGridSection.Name = "dataGridSection";
            this.dataGridSection.ReadOnly = true;
            this.dataGridSection.RowHeadersWidth = 51;
            this.dataGridSection.RowTemplate.Height = 29;
            this.dataGridSection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridSection.Size = new System.Drawing.Size(286, 188);
            this.dataGridSection.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Name";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "X";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Y";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 125;
            // 
            // comboCamera
            // 
            this.comboCamera.FormattingEnabled = true;
            this.comboCamera.Items.AddRange(new object[] {
            "custom",
            "side view",
            "top view",
            "bottom view",
            "front view"});
            this.comboCamera.Location = new System.Drawing.Point(200, 56);
            this.comboCamera.Name = "comboCamera";
            this.comboCamera.Size = new System.Drawing.Size(151, 28);
            this.comboCamera.TabIndex = 1;
            this.comboCamera.Text = "custom";
            this.comboCamera.SelectedValueChanged += new System.EventHandler(this.comboCamera_SelectedValueChanged);
            // 
            // scaleSharp
            // 
            this.scaleSharp.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.scaleSharp.Location = new System.Drawing.Point(200, 12);
            this.scaleSharp.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.scaleSharp.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.scaleSharp.Name = "scaleSharp";
            this.scaleSharp.Size = new System.Drawing.Size(150, 27);
            this.scaleSharp.TabIndex = 0;
            this.scaleSharp.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.scaleSharp.ValueChanged += new System.EventHandler(this.bottomChangeSharp);
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
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleSharp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.WinForms.GLControl glWindow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown scaleSharp;
        private System.Windows.Forms.ComboBox comboCamera;
        private System.Windows.Forms.DataGridView dataGridSection;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}