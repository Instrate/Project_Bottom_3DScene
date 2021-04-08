
namespace Scene
{
    partial class FormMenu
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Mesh");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("World", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Light");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Scene", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            this.textFrames = new System.Windows.Forms.MaskedTextBox();
            this.glScene = new OpenTK.WinForms.GLControl();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            this.menuTop = new System.Windows.Forms.MenuStrip();
            this.menuTopComboBuild = new System.Windows.Forms.ToolStripComboBox();
            this.menuTopMethodChangeKeys = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataSection = new System.Windows.Forms.DataGridView();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAddObject = new System.Windows.Forms.Button();
            this.buttonSaveFile = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataBottom = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeViewScene = new System.Windows.Forms.TreeView();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.fileWatcher = new System.IO.FileSystemWatcher();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabGLControls = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.glProfile = new OpenTK.WinForms.GLControl();
            this.menuTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSection)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBottom)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileWatcher)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabGLControls.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // textFrames
            // 
            this.textFrames.Location = new System.Drawing.Point(12, 3);
            this.textFrames.Name = "textFrames";
            this.textFrames.ReadOnly = true;
            this.textFrames.Size = new System.Drawing.Size(125, 27);
            this.textFrames.TabIndex = 7;
            this.textFrames.Text = "0";
            this.textFrames.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // glScene
            // 
            this.glScene.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            this.glScene.APIVersion = new System.Version(4, 0, 0, 0);
            this.glScene.BackColor = System.Drawing.Color.Black;
            this.glScene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glScene.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
            this.glScene.IsEventDriven = true;
            this.glScene.Location = new System.Drawing.Point(3, 3);
            this.glScene.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.glScene.Name = "glScene";
            this.glScene.Profile = OpenTK.Windowing.Common.ContextProfile.Core;
            this.glScene.Size = new System.Drawing.Size(742, 783);
            this.glScene.TabIndex = 3;
            this.glScene.Text = "Main";
            this.glScene.Load += new System.EventHandler(this.glOnLoad);
            this.glScene.Paint += new System.Windows.Forms.PaintEventHandler(this.glOnPaint);
            this.glScene.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.glScene.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.glScene.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this.glScene.MouseLeave += new System.EventHandler(this.glOnMouseLeave);
            this.glScene.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glOnDraw);
            this.glScene.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.OnKeyPrewDown);
            // 
            // timerTick
            // 
            this.timerTick.Tick += new System.EventHandler(this.eventTickTimer);
            // 
            // menuTop
            // 
            this.menuTop.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.menuTop.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTopComboBuild,
            this.menuTopMethodChangeKeys});
            this.menuTop.Location = new System.Drawing.Point(0, 0);
            this.menuTop.Name = "menuTop";
            this.menuTop.Size = new System.Drawing.Size(1582, 32);
            this.menuTop.TabIndex = 6;
            this.menuTop.Text = "menuStrip1";
            // 
            // menuTopComboBuild
            // 
            this.menuTopComboBuild.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.menuTopComboBuild.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuTopComboBuild.Name = "menuTopComboBuild";
            this.menuTopComboBuild.Size = new System.Drawing.Size(121, 28);
            this.menuTopComboBuild.Text = "Build";
            // 
            // menuTopMethodChangeKeys
            // 
            this.menuTopMethodChangeKeys.Name = "menuTopMethodChangeKeys";
            this.menuTopMethodChangeKeys.Size = new System.Drawing.Size(87, 28);
            this.menuTopMethodChangeKeys.Text = "Keyboard";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.buttonSaveFile);
            this.panel1.Controls.Add(this.textFrames);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 821);
            this.panel1.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.DimGray;
            this.groupBox3.Controls.Add(this.dataSection);
            this.groupBox3.Controls.Add(this.buttonAddObject);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(12, 73);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(357, 279);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Addition";
            // 
            // dataSection
            // 
            this.dataSection.AllowUserToAddRows = false;
            this.dataSection.AllowUserToDeleteRows = false;
            this.dataSection.AllowUserToResizeColumns = false;
            this.dataSection.AllowUserToResizeRows = false;
            this.dataSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataSection.BackgroundColor = System.Drawing.Color.DimGray;
            this.dataSection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataSection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y,
            this.Z});
            this.dataSection.GridColor = System.Drawing.Color.DimGray;
            this.dataSection.Location = new System.Drawing.Point(6, 26);
            this.dataSection.Name = "dataSection";
            this.dataSection.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataSection.RowTemplate.Height = 29;
            this.dataSection.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataSection.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataSection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataSection.Size = new System.Drawing.Size(345, 86);
            this.dataSection.TabIndex = 15;
            // 
            // X
            // 
            this.X.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.X.HeaderText = "X";
            this.X.MinimumWidth = 6;
            this.X.Name = "X";
            this.X.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Y
            // 
            this.Y.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Y.HeaderText = "Y";
            this.Y.MinimumWidth = 6;
            this.Y.Name = "Y";
            this.Y.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Z
            // 
            this.Z.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Z.HeaderText = "Z";
            this.Z.MinimumWidth = 6;
            this.Z.Name = "Z";
            this.Z.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // buttonAddObject
            // 
            this.buttonAddObject.AutoEllipsis = true;
            this.buttonAddObject.BackColor = System.Drawing.Color.White;
            this.buttonAddObject.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonAddObject.ForeColor = System.Drawing.Color.Black;
            this.buttonAddObject.Location = new System.Drawing.Point(6, 118);
            this.buttonAddObject.Name = "buttonAddObject";
            this.buttonAddObject.Size = new System.Drawing.Size(108, 29);
            this.buttonAddObject.TabIndex = 14;
            this.buttonAddObject.Text = "Section";
            this.buttonAddObject.UseVisualStyleBackColor = false;
            this.buttonAddObject.Click += new System.EventHandler(this.objectDoSection);
            // 
            // buttonSaveFile
            // 
            this.buttonSaveFile.ForeColor = System.Drawing.Color.Black;
            this.buttonSaveFile.Location = new System.Drawing.Point(12, 37);
            this.buttonSaveFile.Name = "buttonSaveFile";
            this.buttonSaveFile.Size = new System.Drawing.Size(94, 29);
            this.buttonSaveFile.TabIndex = 8;
            this.buttonSaveFile.Text = "Save";
            this.buttonSaveFile.UseVisualStyleBackColor = true;
            this.buttonSaveFile.Click += new System.EventHandler(this.eventButtonSave);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1131, 32);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(451, 821);
            this.panel3.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.DimGray;
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(16, 371);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 438);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Properties";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.19802F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.80198F));
            this.tableLayoutPanel1.Controls.Add(this.dataBottom, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.55837F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.44162F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 264F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(406, 405);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataBottom
            // 
            this.dataBottom.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataBottom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataBottom.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataBottom.Location = new System.Drawing.Point(127, 141);
            this.dataBottom.Name = "dataBottom";
            this.dataBottom.RowHeadersWidth = 51;
            this.dataBottom.RowTemplate.Height = 29;
            this.dataBottom.Size = new System.Drawing.Size(274, 259);
            this.dataBottom.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bottom";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.DimGray;
            this.groupBox1.Controls.Add(this.treeViewScene);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(421, 337);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tree view";
            // 
            // treeViewScene
            // 
            this.treeViewScene.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewScene.BackColor = System.Drawing.SystemColors.WindowText;
            this.treeViewScene.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.treeViewScene.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.treeViewScene.FullRowSelect = true;
            this.treeViewScene.LineColor = System.Drawing.Color.White;
            this.treeViewScene.Location = new System.Drawing.Point(9, 26);
            this.treeViewScene.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.treeViewScene.Name = "treeViewScene";
            treeNode1.BackColor = System.Drawing.Color.Black;
            treeNode1.ForeColor = System.Drawing.Color.White;
            treeNode1.Name = "Mesh";
            treeNode1.Text = "Mesh";
            treeNode2.BackColor = System.Drawing.Color.Black;
            treeNode2.ForeColor = System.Drawing.Color.White;
            treeNode2.Name = "World";
            treeNode2.Text = "World";
            treeNode3.BackColor = System.Drawing.Color.Black;
            treeNode3.ForeColor = System.Drawing.Color.White;
            treeNode3.Name = "Light";
            treeNode3.Text = "Light";
            treeNode4.BackColor = System.Drawing.Color.Black;
            treeNode4.ForeColor = System.Drawing.Color.White;
            treeNode4.Name = "NodeScene";
            treeNode4.Text = "Scene";
            this.treeViewScene.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.treeViewScene.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.treeViewScene.ShowNodeToolTips = true;
            this.treeViewScene.Size = new System.Drawing.Size(404, 222);
            this.treeViewScene.TabIndex = 0;
            // 
            // saveFile
            // 
            this.saveFile.InitialDirectory = "./";
            this.saveFile.Title = "Save matrix data";
            // 
            // fileWatcher
            // 
            this.fileWatcher.EnableRaisingEvents = true;
            this.fileWatcher.SynchronizingObject = this;
            // 
            // openFile
            // 
            this.openFile.FileName = "file";
            this.openFile.InitialDirectory = "./";
            this.openFile.Title = "Search for the matrix container";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabGLControls);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(375, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(756, 821);
            this.panel2.TabIndex = 11;
            // 
            // tabGLControls
            // 
            this.tabGLControls.Controls.Add(this.tabMain);
            this.tabGLControls.Controls.Add(this.tabProfile);
            this.tabGLControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGLControls.Location = new System.Drawing.Point(0, 0);
            this.tabGLControls.Name = "tabGLControls";
            this.tabGLControls.SelectedIndex = 0;
            this.tabGLControls.Size = new System.Drawing.Size(756, 821);
            this.tabGLControls.TabIndex = 4;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.glScene);
            this.tabMain.Location = new System.Drawing.Point(4, 28);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(748, 789);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // tabProfile
            // 
            this.tabProfile.Controls.Add(this.glProfile);
            this.tabProfile.Location = new System.Drawing.Point(4, 28);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tabProfile.Size = new System.Drawing.Size(748, 789);
            this.tabProfile.TabIndex = 1;
            this.tabProfile.Text = "Profile";
            this.tabProfile.UseVisualStyleBackColor = true;
            // 
            // glProfile
            // 
            this.glProfile.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            this.glProfile.APIVersion = new System.Version(3, 3, 0, 0);
            this.glProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glProfile.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
            this.glProfile.IsEventDriven = true;
            this.glProfile.Location = new System.Drawing.Point(3, 3);
            this.glProfile.Name = "glProfile";
            this.glProfile.Profile = OpenTK.Windowing.Common.ContextProfile.Core;
            this.glProfile.Size = new System.Drawing.Size(742, 783);
            this.glProfile.TabIndex = 0;
            this.glProfile.Text = "glProfile";
            this.glProfile.Load += new System.EventHandler(this.glProfile_OnLoad);
            this.glProfile.Paint += new System.Windows.Forms.PaintEventHandler(this.glProfile_OnPaint);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuTop);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.Name = "FormMenu";
            this.Text = "Start";
            this.Load += new System.EventHandler(this.OnLoad);
            this.Resize += new System.EventHandler(this.OnResize);
            this.menuTop.ResumeLayout(false);
            this.menuTop.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSection)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBottom)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileWatcher)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabGLControls.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabProfile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerTick;
        private OpenTK.WinForms.GLControl glScene;
        private System.Windows.Forms.MaskedTextBox textFrames;
        private System.Windows.Forms.MenuStrip menuTop;
        private System.Windows.Forms.ToolStripComboBox menuTopComboBuild;
        private System.Windows.Forms.ToolStripMenuItem menuTopMethodChangeKeys;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeViewScene;
        private System.Windows.Forms.Button buttonSaveFile;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.IO.FileSystemWatcher fileWatcher;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataBottom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabGLControls;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataSection;
        private System.Windows.Forms.Button buttonAddObject;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Z;
        private OpenTK.WinForms.GLControl gl;
        private OpenTK.WinForms.GLControl glProfile;
    }
}