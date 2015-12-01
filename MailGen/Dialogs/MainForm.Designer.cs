namespace MailGen.Dialogs
{
    internal sealed partial class MainForm
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnClearLog = new System.Windows.Forms.ToolStripButton();
            this.tsbtnOpenLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbSteps = new System.Windows.Forms.TabControl();
            this.tpContacts = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.clEwsContacts = new Controls.ComplexList();
            this.clTargetContacts = new Controls.ComplexList();
            this.tpGen = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.clMailTemplates = new Controls.ComplexList();
            this.clEventTemplates = new Controls.ComplexList();
            this.numEventsCount = new System.Windows.Forms.NumericUpDown();
            this.lbEventsCount = new System.Windows.Forms.Label();
            this.lbMailsCount = new System.Windows.Forms.Label();
            this.numMailsCount = new System.Windows.Forms.NumericUpDown();
            this.tpGenerate = new System.Windows.Forms.TabPage();
            this.btnGenerateAll = new System.Windows.Forms.Button();
            this.btnGenerateEvents = new System.Windows.Forms.Button();
            this.btnGenMail = new System.Windows.Forms.Button();
            this.pgGenProgress = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToEWSToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.v2010ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.v2010SP1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.v2010SP2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.v2013ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.v2013SPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.russianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tbSteps.SuspendLayout();
            this.tpContacts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clEwsContacts.dgObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clTargetContacts.dgObjects)).BeginInit();
            this.tpGen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clMailTemplates.dgObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clEventTemplates.dgObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEventsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMailsCount)).BeginInit();
            this.tpGenerate.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.BottomToolStripPanel, "toolStripContainer1.BottomToolStripPanel");
            // 
            // toolStripContainer1.ContentPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            this.toolStripContainer1.ContentPanel.Controls.Add(this.lbLog);
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.LeftToolStripPanel, "toolStripContainer1.LeftToolStripPanel");
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.RightToolStripPanel, "toolStripContainer1.RightToolStripPanel");
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.TopToolStripPanel, "toolStripContainer1.TopToolStripPanel");
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // lbLog
            // 
            resources.ApplyResources(this.lbLog, "lbLog");
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Name = "lbLog";
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClearLog,
            this.tsbtnOpenLog});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // tsbtnClearLog
            // 
            resources.ApplyResources(this.tsbtnClearLog, "tsbtnClearLog");
            this.tsbtnClearLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnClearLog.Name = "tsbtnClearLog";
            this.tsbtnClearLog.Click += new System.EventHandler(this.ToolStripButton1Click);
            // 
            // tsbtnOpenLog
            // 
            resources.ApplyResources(this.tsbtnOpenLog, "tsbtnOpenLog");
            this.tsbtnOpenLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnOpenLog.Name = "tsbtnOpenLog";
            this.tsbtnOpenLog.Click += new System.EventHandler(this.ToolStripButton2Click);
            // 
            // toolStripContainer2
            // 
            resources.ApplyResources(this.toolStripContainer2, "toolStripContainer2");
            // 
            // toolStripContainer2.BottomToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer2.BottomToolStripPanel, "toolStripContainer2.BottomToolStripPanel");
            // 
            // toolStripContainer2.ContentPanel
            // 
            resources.ApplyResources(this.toolStripContainer2.ContentPanel, "toolStripContainer2.ContentPanel");
            this.toolStripContainer2.ContentPanel.Controls.Add(this.panel2);
            // 
            // toolStripContainer2.LeftToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer2.LeftToolStripPanel, "toolStripContainer2.LeftToolStripPanel");
            this.toolStripContainer2.Name = "toolStripContainer2";
            // 
            // toolStripContainer2.RightToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer2.RightToolStripPanel, "toolStripContainer2.RightToolStripPanel");
            // 
            // toolStripContainer2.TopToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer2.TopToolStripPanel, "toolStripContainer2.TopToolStripPanel");
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.splitContainer2);
            this.panel2.Name = "panel2";
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            resources.ApplyResources(this.splitContainer2.Panel1, "splitContainer2.Panel1");
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            resources.ApplyResources(this.splitContainer2.Panel2, "splitContainer2.Panel2");
            this.splitContainer2.Panel2.Controls.Add(this.toolStripContainer1);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.tbSteps);
            this.panel1.Name = "panel1";
            // 
            // tbSteps
            // 
            resources.ApplyResources(this.tbSteps, "tbSteps");
            this.tbSteps.Controls.Add(this.tpContacts);
            this.tbSteps.Controls.Add(this.tpGen);
            this.tbSteps.Controls.Add(this.tpGenerate);
            this.tbSteps.Name = "tbSteps";
            this.tbSteps.SelectedIndex = 0;
            // 
            // tpContacts
            // 
            resources.ApplyResources(this.tpContacts, "tpContacts");
            this.tpContacts.Controls.Add(this.splitContainer4);
            this.tpContacts.Name = "tpContacts";
            this.tpContacts.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            resources.ApplyResources(this.splitContainer4, "splitContainer4");
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            resources.ApplyResources(this.splitContainer4.Panel1, "splitContainer4.Panel1");
            this.splitContainer4.Panel1.Controls.Add(this.clEwsContacts);
            // 
            // splitContainer4.Panel2
            // 
            resources.ApplyResources(this.splitContainer4.Panel2, "splitContainer4.Panel2");
            this.splitContainer4.Panel2.Controls.Add(this.clTargetContacts);
            // 
            // clEwsContacts
            // 
            resources.ApplyResources(this.clEwsContacts, "clEwsContacts");
            // 
            // 
            // 
            this.clEwsContacts.barTools.AccessibleDescription = resources.GetString("resource.AccessibleDescription");
            this.clEwsContacts.barTools.AccessibleName = resources.GetString("resource.AccessibleName");
            this.clEwsContacts.barTools.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resource.Anchor")));
            this.clEwsContacts.barTools.AutoSize = ((bool)(resources.GetObject("resource.AutoSize")));
            this.clEwsContacts.barTools.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resource.BackgroundImage")));
            this.clEwsContacts.barTools.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("resource.BackgroundImageLayout")));
            this.clEwsContacts.barTools.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock")));
            this.clEwsContacts.barTools.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font")));
            this.clEwsContacts.barTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.clEwsContacts.barTools.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode")));
            this.clEwsContacts.barTools.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location")));
            this.clEwsContacts.barTools.MaximumSize = ((System.Drawing.Size)(resources.GetObject("resource.MaximumSize")));
            this.clEwsContacts.barTools.Name = "_barTools";
            this.clEwsContacts.barTools.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resource.RightToLeft")));
            this.clEwsContacts.barTools.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size")));
            this.clEwsContacts.barTools.TabIndex = ((int)(resources.GetObject("resource.TabIndex")));
            // 
            // 
            // 
            this.clEwsContacts.dgObjects.AccessibleDescription = resources.GetString("resource.AccessibleDescription1");
            this.clEwsContacts.dgObjects.AccessibleName = resources.GetString("resource.AccessibleName1");
            this.clEwsContacts.dgObjects.Alignment = ((System.Windows.Forms.ListViewAlignment)(resources.GetObject("resource.Alignment")));
            this.clEwsContacts.dgObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resource.Anchor1")));
            this.clEwsContacts.dgObjects.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resource.BackgroundImage1")));
            this.clEwsContacts.dgObjects.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("resource.BackgroundImageLayout1")));
            this.clEwsContacts.dgObjects.DataSource = null;
            this.clEwsContacts.dgObjects.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock1")));
            this.clEwsContacts.dgObjects.EmptyListMsg = resources.GetString("resource.EmptyListMsg");
            this.clEwsContacts.dgObjects.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font1")));
            this.clEwsContacts.dgObjects.GroupWithItemCountFormat = resources.GetString("resource.GroupWithItemCountFormat");
            this.clEwsContacts.dgObjects.GroupWithItemCountSingularFormat = resources.GetString("resource.GroupWithItemCountSingularFormat");
            this.clEwsContacts.dgObjects.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode1")));
            this.clEwsContacts.dgObjects.LabelWrap = ((bool)(resources.GetObject("resource.LabelWrap")));
            this.clEwsContacts.dgObjects.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location1")));
            this.clEwsContacts.dgObjects.MaximumSize = ((System.Drawing.Size)(resources.GetObject("resource.MaximumSize1")));
            this.clEwsContacts.dgObjects.MenuLabelColumns = resources.GetString("resource.MenuLabelColumns");
            this.clEwsContacts.dgObjects.MenuLabelGroupBy = resources.GetString("resource.MenuLabelGroupBy");
            this.clEwsContacts.dgObjects.MenuLabelLockGroupingOn = resources.GetString("resource.MenuLabelLockGroupingOn");
            this.clEwsContacts.dgObjects.MenuLabelSelectColumns = resources.GetString("resource.MenuLabelSelectColumns");
            this.clEwsContacts.dgObjects.MenuLabelSortAscending = resources.GetString("resource.MenuLabelSortAscending");
            this.clEwsContacts.dgObjects.MenuLabelSortDescending = resources.GetString("resource.MenuLabelSortDescending");
            this.clEwsContacts.dgObjects.MenuLabelTurnOffGroups = resources.GetString("resource.MenuLabelTurnOffGroups");
            this.clEwsContacts.dgObjects.MenuLabelUnlockGroupingOn = resources.GetString("resource.MenuLabelUnlockGroupingOn");
            this.clEwsContacts.dgObjects.MenuLabelUnsort = resources.GetString("resource.MenuLabelUnsort");
            this.clEwsContacts.dgObjects.Name = "_dgObjects";
            this.clEwsContacts.dgObjects.OverlayText.Text = resources.GetString("resource.Text");
            this.clEwsContacts.dgObjects.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resource.RightToLeft1")));
            this.clEwsContacts.dgObjects.RightToLeftLayout = ((bool)(resources.GetObject("resource.RightToLeftLayout")));
            this.clEwsContacts.dgObjects.ShowImagesOnSubItems = true;
            this.clEwsContacts.dgObjects.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size1")));
            this.clEwsContacts.dgObjects.TabIndex = ((int)(resources.GetObject("resource.TabIndex1")));
            this.clEwsContacts.dgObjects.UseCompatibleStateImageBehavior = false;
            this.clEwsContacts.dgObjects.View = System.Windows.Forms.View.Details;
            this.clEwsContacts.dgObjects.VirtualMode = true;
            this.clEwsContacts.Name = "clEwsContacts";
            // 
            // clTargetContacts
            // 
            resources.ApplyResources(this.clTargetContacts, "clTargetContacts");
            // 
            // 
            // 
            this.clTargetContacts.barTools.AccessibleDescription = resources.GetString("resource.AccessibleDescription2");
            this.clTargetContacts.barTools.AccessibleName = resources.GetString("resource.AccessibleName2");
            this.clTargetContacts.barTools.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resource.Anchor2")));
            this.clTargetContacts.barTools.AutoSize = ((bool)(resources.GetObject("resource.AutoSize1")));
            this.clTargetContacts.barTools.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resource.BackgroundImage2")));
            this.clTargetContacts.barTools.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("resource.BackgroundImageLayout2")));
            this.clTargetContacts.barTools.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock2")));
            this.clTargetContacts.barTools.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font2")));
            this.clTargetContacts.barTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.clTargetContacts.barTools.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode2")));
            this.clTargetContacts.barTools.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location2")));
            this.clTargetContacts.barTools.MaximumSize = ((System.Drawing.Size)(resources.GetObject("resource.MaximumSize2")));
            this.clTargetContacts.barTools.Name = "_barTools";
            this.clTargetContacts.barTools.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resource.RightToLeft2")));
            this.clTargetContacts.barTools.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size2")));
            this.clTargetContacts.barTools.TabIndex = ((int)(resources.GetObject("resource.TabIndex2")));
            // 
            // 
            // 
            this.clTargetContacts.dgObjects.AccessibleDescription = resources.GetString("resource.AccessibleDescription3");
            this.clTargetContacts.dgObjects.AccessibleName = resources.GetString("resource.AccessibleName3");
            this.clTargetContacts.dgObjects.Alignment = ((System.Windows.Forms.ListViewAlignment)(resources.GetObject("resource.Alignment1")));
            this.clTargetContacts.dgObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resource.Anchor3")));
            this.clTargetContacts.dgObjects.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resource.BackgroundImage3")));
            this.clTargetContacts.dgObjects.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("resource.BackgroundImageLayout3")));
            this.clTargetContacts.dgObjects.DataSource = null;
            this.clTargetContacts.dgObjects.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock3")));
            this.clTargetContacts.dgObjects.EmptyListMsg = resources.GetString("resource.EmptyListMsg1");
            this.clTargetContacts.dgObjects.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font3")));
            this.clTargetContacts.dgObjects.GroupWithItemCountFormat = resources.GetString("resource.GroupWithItemCountFormat1");
            this.clTargetContacts.dgObjects.GroupWithItemCountSingularFormat = resources.GetString("resource.GroupWithItemCountSingularFormat1");
            this.clTargetContacts.dgObjects.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode3")));
            this.clTargetContacts.dgObjects.LabelWrap = ((bool)(resources.GetObject("resource.LabelWrap1")));
            this.clTargetContacts.dgObjects.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location3")));
            this.clTargetContacts.dgObjects.MaximumSize = ((System.Drawing.Size)(resources.GetObject("resource.MaximumSize3")));
            this.clTargetContacts.dgObjects.MenuLabelColumns = resources.GetString("resource.MenuLabelColumns1");
            this.clTargetContacts.dgObjects.MenuLabelGroupBy = resources.GetString("resource.MenuLabelGroupBy1");
            this.clTargetContacts.dgObjects.MenuLabelLockGroupingOn = resources.GetString("resource.MenuLabelLockGroupingOn1");
            this.clTargetContacts.dgObjects.MenuLabelSelectColumns = resources.GetString("resource.MenuLabelSelectColumns1");
            this.clTargetContacts.dgObjects.MenuLabelSortAscending = resources.GetString("resource.MenuLabelSortAscending1");
            this.clTargetContacts.dgObjects.MenuLabelSortDescending = resources.GetString("resource.MenuLabelSortDescending1");
            this.clTargetContacts.dgObjects.MenuLabelTurnOffGroups = resources.GetString("resource.MenuLabelTurnOffGroups1");
            this.clTargetContacts.dgObjects.MenuLabelUnlockGroupingOn = resources.GetString("resource.MenuLabelUnlockGroupingOn1");
            this.clTargetContacts.dgObjects.MenuLabelUnsort = resources.GetString("resource.MenuLabelUnsort1");
            this.clTargetContacts.dgObjects.Name = "_dgObjects";
            this.clTargetContacts.dgObjects.OverlayText.Text = resources.GetString("resource.Text1");
            this.clTargetContacts.dgObjects.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resource.RightToLeft3")));
            this.clTargetContacts.dgObjects.RightToLeftLayout = ((bool)(resources.GetObject("resource.RightToLeftLayout1")));
            this.clTargetContacts.dgObjects.ShowImagesOnSubItems = true;
            this.clTargetContacts.dgObjects.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size3")));
            this.clTargetContacts.dgObjects.TabIndex = ((int)(resources.GetObject("resource.TabIndex3")));
            this.clTargetContacts.dgObjects.UseCompatibleStateImageBehavior = false;
            this.clTargetContacts.Name = "clTargetContacts";
            // 
            // tpGen
            // 
            resources.ApplyResources(this.tpGen, "tpGen");
            this.tpGen.Controls.Add(this.splitContainer3);
            this.tpGen.Name = "tpGen";
            this.tpGen.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            resources.ApplyResources(this.splitContainer3, "splitContainer3");
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            resources.ApplyResources(this.splitContainer3.Panel1, "splitContainer3.Panel1");
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer3.Panel2
            // 
            resources.ApplyResources(this.splitContainer3.Panel2, "splitContainer3.Panel2");
            this.splitContainer3.Panel2.Controls.Add(this.numEventsCount);
            this.splitContainer3.Panel2.Controls.Add(this.lbEventsCount);
            this.splitContainer3.Panel2.Controls.Add(this.lbMailsCount);
            this.splitContainer3.Panel2.Controls.Add(this.numMailsCount);
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.clMailTemplates);
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.clEventTemplates);
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer1SplitterMoved);
            // 
            // clMailTemplates
            // 
            resources.ApplyResources(this.clMailTemplates, "clMailTemplates");
            // 
            // 
            // 
            this.clMailTemplates.barTools.AccessibleDescription = resources.GetString("resource.AccessibleDescription4");
            this.clMailTemplates.barTools.AccessibleName = resources.GetString("resource.AccessibleName4");
            this.clMailTemplates.barTools.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resource.Anchor4")));
            this.clMailTemplates.barTools.AutoSize = ((bool)(resources.GetObject("resource.AutoSize2")));
            this.clMailTemplates.barTools.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resource.BackgroundImage4")));
            this.clMailTemplates.barTools.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("resource.BackgroundImageLayout4")));
            this.clMailTemplates.barTools.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock4")));
            this.clMailTemplates.barTools.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font4")));
            this.clMailTemplates.barTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.clMailTemplates.barTools.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode4")));
            this.clMailTemplates.barTools.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location4")));
            this.clMailTemplates.barTools.MaximumSize = ((System.Drawing.Size)(resources.GetObject("resource.MaximumSize4")));
            this.clMailTemplates.barTools.Name = "_barTools";
            this.clMailTemplates.barTools.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resource.RightToLeft4")));
            this.clMailTemplates.barTools.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size4")));
            this.clMailTemplates.barTools.TabIndex = ((int)(resources.GetObject("resource.TabIndex4")));
            // 
            // 
            // 
            this.clMailTemplates.dgObjects.AccessibleDescription = resources.GetString("resource.AccessibleDescription5");
            this.clMailTemplates.dgObjects.AccessibleName = resources.GetString("resource.AccessibleName5");
            this.clMailTemplates.dgObjects.Alignment = ((System.Windows.Forms.ListViewAlignment)(resources.GetObject("resource.Alignment2")));
            this.clMailTemplates.dgObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resource.Anchor5")));
            this.clMailTemplates.dgObjects.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resource.BackgroundImage5")));
            this.clMailTemplates.dgObjects.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("resource.BackgroundImageLayout5")));
            this.clMailTemplates.dgObjects.DataSource = null;
            this.clMailTemplates.dgObjects.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock5")));
            this.clMailTemplates.dgObjects.EmptyListMsg = resources.GetString("resource.EmptyListMsg2");
            this.clMailTemplates.dgObjects.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font5")));
            this.clMailTemplates.dgObjects.GroupWithItemCountFormat = resources.GetString("resource.GroupWithItemCountFormat2");
            this.clMailTemplates.dgObjects.GroupWithItemCountSingularFormat = resources.GetString("resource.GroupWithItemCountSingularFormat2");
            this.clMailTemplates.dgObjects.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode5")));
            this.clMailTemplates.dgObjects.LabelWrap = ((bool)(resources.GetObject("resource.LabelWrap2")));
            this.clMailTemplates.dgObjects.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location5")));
            this.clMailTemplates.dgObjects.MaximumSize = ((System.Drawing.Size)(resources.GetObject("resource.MaximumSize5")));
            this.clMailTemplates.dgObjects.MenuLabelColumns = resources.GetString("resource.MenuLabelColumns2");
            this.clMailTemplates.dgObjects.MenuLabelGroupBy = resources.GetString("resource.MenuLabelGroupBy2");
            this.clMailTemplates.dgObjects.MenuLabelLockGroupingOn = resources.GetString("resource.MenuLabelLockGroupingOn2");
            this.clMailTemplates.dgObjects.MenuLabelSelectColumns = resources.GetString("resource.MenuLabelSelectColumns2");
            this.clMailTemplates.dgObjects.MenuLabelSortAscending = resources.GetString("resource.MenuLabelSortAscending2");
            this.clMailTemplates.dgObjects.MenuLabelSortDescending = resources.GetString("resource.MenuLabelSortDescending2");
            this.clMailTemplates.dgObjects.MenuLabelTurnOffGroups = resources.GetString("resource.MenuLabelTurnOffGroups2");
            this.clMailTemplates.dgObjects.MenuLabelUnlockGroupingOn = resources.GetString("resource.MenuLabelUnlockGroupingOn2");
            this.clMailTemplates.dgObjects.MenuLabelUnsort = resources.GetString("resource.MenuLabelUnsort2");
            this.clMailTemplates.dgObjects.Name = "_dgObjects";
            this.clMailTemplates.dgObjects.OverlayText.Text = resources.GetString("resource.Text2");
            this.clMailTemplates.dgObjects.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resource.RightToLeft5")));
            this.clMailTemplates.dgObjects.RightToLeftLayout = ((bool)(resources.GetObject("resource.RightToLeftLayout2")));
            this.clMailTemplates.dgObjects.ShowImagesOnSubItems = true;
            this.clMailTemplates.dgObjects.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size5")));
            this.clMailTemplates.dgObjects.TabIndex = ((int)(resources.GetObject("resource.TabIndex5")));
            this.clMailTemplates.dgObjects.UseCompatibleStateImageBehavior = false;
            this.clMailTemplates.dgObjects.View = System.Windows.Forms.View.Details;
            this.clMailTemplates.dgObjects.VirtualMode = true;
            this.clMailTemplates.Name = "clMailTemplates";
            // 
            // clEventTemplates
            // 
            resources.ApplyResources(this.clEventTemplates, "clEventTemplates");
            // 
            // 
            // 
            this.clEventTemplates.barTools.AccessibleDescription = resources.GetString("resource.AccessibleDescription6");
            this.clEventTemplates.barTools.AccessibleName = resources.GetString("resource.AccessibleName6");
            this.clEventTemplates.barTools.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resource.Anchor6")));
            this.clEventTemplates.barTools.AutoSize = ((bool)(resources.GetObject("resource.AutoSize3")));
            this.clEventTemplates.barTools.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resource.BackgroundImage6")));
            this.clEventTemplates.barTools.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("resource.BackgroundImageLayout6")));
            this.clEventTemplates.barTools.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock6")));
            this.clEventTemplates.barTools.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font6")));
            this.clEventTemplates.barTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.clEventTemplates.barTools.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode6")));
            this.clEventTemplates.barTools.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location6")));
            this.clEventTemplates.barTools.MaximumSize = ((System.Drawing.Size)(resources.GetObject("resource.MaximumSize6")));
            this.clEventTemplates.barTools.Name = "_barTools";
            this.clEventTemplates.barTools.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resource.RightToLeft6")));
            this.clEventTemplates.barTools.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size6")));
            this.clEventTemplates.barTools.TabIndex = ((int)(resources.GetObject("resource.TabIndex6")));
            // 
            // 
            // 
            this.clEventTemplates.dgObjects.AccessibleDescription = resources.GetString("resource.AccessibleDescription7");
            this.clEventTemplates.dgObjects.AccessibleName = resources.GetString("resource.AccessibleName7");
            this.clEventTemplates.dgObjects.Alignment = ((System.Windows.Forms.ListViewAlignment)(resources.GetObject("resource.Alignment3")));
            this.clEventTemplates.dgObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("resource.Anchor7")));
            this.clEventTemplates.dgObjects.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("resource.BackgroundImage7")));
            this.clEventTemplates.dgObjects.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("resource.BackgroundImageLayout7")));
            this.clEventTemplates.dgObjects.DataSource = null;
            this.clEventTemplates.dgObjects.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock7")));
            this.clEventTemplates.dgObjects.EmptyListMsg = resources.GetString("resource.EmptyListMsg3");
            this.clEventTemplates.dgObjects.Font = ((System.Drawing.Font)(resources.GetObject("resource.Font7")));
            this.clEventTemplates.dgObjects.GroupWithItemCountFormat = resources.GetString("resource.GroupWithItemCountFormat3");
            this.clEventTemplates.dgObjects.GroupWithItemCountSingularFormat = resources.GetString("resource.GroupWithItemCountSingularFormat3");
            this.clEventTemplates.dgObjects.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode7")));
            this.clEventTemplates.dgObjects.LabelWrap = ((bool)(resources.GetObject("resource.LabelWrap3")));
            this.clEventTemplates.dgObjects.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location7")));
            this.clEventTemplates.dgObjects.MaximumSize = ((System.Drawing.Size)(resources.GetObject("resource.MaximumSize7")));
            this.clEventTemplates.dgObjects.MenuLabelColumns = resources.GetString("resource.MenuLabelColumns3");
            this.clEventTemplates.dgObjects.MenuLabelGroupBy = resources.GetString("resource.MenuLabelGroupBy3");
            this.clEventTemplates.dgObjects.MenuLabelLockGroupingOn = resources.GetString("resource.MenuLabelLockGroupingOn3");
            this.clEventTemplates.dgObjects.MenuLabelSelectColumns = resources.GetString("resource.MenuLabelSelectColumns3");
            this.clEventTemplates.dgObjects.MenuLabelSortAscending = resources.GetString("resource.MenuLabelSortAscending3");
            this.clEventTemplates.dgObjects.MenuLabelSortDescending = resources.GetString("resource.MenuLabelSortDescending3");
            this.clEventTemplates.dgObjects.MenuLabelTurnOffGroups = resources.GetString("resource.MenuLabelTurnOffGroups3");
            this.clEventTemplates.dgObjects.MenuLabelUnlockGroupingOn = resources.GetString("resource.MenuLabelUnlockGroupingOn3");
            this.clEventTemplates.dgObjects.MenuLabelUnsort = resources.GetString("resource.MenuLabelUnsort3");
            this.clEventTemplates.dgObjects.Name = "_dgObjects";
            this.clEventTemplates.dgObjects.OverlayText.Text = resources.GetString("resource.Text3");
            this.clEventTemplates.dgObjects.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("resource.RightToLeft7")));
            this.clEventTemplates.dgObjects.RightToLeftLayout = ((bool)(resources.GetObject("resource.RightToLeftLayout3")));
            this.clEventTemplates.dgObjects.ShowImagesOnSubItems = true;
            this.clEventTemplates.dgObjects.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size7")));
            this.clEventTemplates.dgObjects.TabIndex = ((int)(resources.GetObject("resource.TabIndex7")));
            this.clEventTemplates.dgObjects.UseCompatibleStateImageBehavior = false;
            this.clEventTemplates.dgObjects.View = System.Windows.Forms.View.Details;
            this.clEventTemplates.dgObjects.VirtualMode = true;
            this.clEventTemplates.Name = "clEventTemplates";
            // 
            // numEventsCount
            // 
            resources.ApplyResources(this.numEventsCount, "numEventsCount");
            this.numEventsCount.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numEventsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numEventsCount.Name = "numEventsCount";
            this.numEventsCount.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lbEventsCount
            // 
            resources.ApplyResources(this.lbEventsCount, "lbEventsCount");
            this.lbEventsCount.Name = "lbEventsCount";
            // 
            // lbMailsCount
            // 
            resources.ApplyResources(this.lbMailsCount, "lbMailsCount");
            this.lbMailsCount.Name = "lbMailsCount";
            // 
            // numMailsCount
            // 
            resources.ApplyResources(this.numMailsCount, "numMailsCount");
            this.numMailsCount.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numMailsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMailsCount.Name = "numMailsCount";
            this.numMailsCount.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // tpGenerate
            // 
            resources.ApplyResources(this.tpGenerate, "tpGenerate");
            this.tpGenerate.Controls.Add(this.btnGenerateAll);
            this.tpGenerate.Controls.Add(this.btnGenerateEvents);
            this.tpGenerate.Controls.Add(this.btnGenMail);
            this.tpGenerate.Controls.Add(this.pgGenProgress);
            this.tpGenerate.Name = "tpGenerate";
            this.tpGenerate.UseVisualStyleBackColor = true;
            // 
            // btnGenerateAll
            // 
            resources.ApplyResources(this.btnGenerateAll, "btnGenerateAll");
            this.btnGenerateAll.Name = "btnGenerateAll";
            this.btnGenerateAll.UseVisualStyleBackColor = true;
            this.btnGenerateAll.Click += new System.EventHandler(this.BtnGenerateAllClick);
            // 
            // btnGenerateEvents
            // 
            resources.ApplyResources(this.btnGenerateEvents, "btnGenerateEvents");
            this.btnGenerateEvents.Name = "btnGenerateEvents";
            this.btnGenerateEvents.UseVisualStyleBackColor = true;
            this.btnGenerateEvents.Click += new System.EventHandler(this.BtnGenerateEventsClick);
            // 
            // btnGenMail
            // 
            resources.ApplyResources(this.btnGenMail, "btnGenMail");
            this.btnGenMail.Name = "btnGenMail";
            this.btnGenMail.UseVisualStyleBackColor = true;
            this.btnGenMail.Click += new System.EventHandler(this.BtnGenMailClick);
            // 
            // pgGenProgress
            // 
            resources.ApplyResources(this.pgGenProgress, "pgGenProgress");
            this.pgGenProgress.Name = "pgGenProgress";
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionsToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // actionsToolStripMenuItem
            // 
            resources.ApplyResources(this.actionsToolStripMenuItem, "actionsToolStripMenuItem");
            this.actionsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToEWSToolStripMenuItem1,
            this.generateToolStripMenuItem,
            this.saveSettingsToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            // 
            // connectToEWSToolStripMenuItem1
            // 
            resources.ApplyResources(this.connectToEWSToolStripMenuItem1, "connectToEWSToolStripMenuItem1");
            this.connectToEWSToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.connectToEWSToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.v2010ToolStripMenuItem,
            this.v2010SP1ToolStripMenuItem,
            this.v2010SP2ToolStripMenuItem,
            this.v2013ToolStripMenuItem,
            this.v2013SPToolStripMenuItem});
            this.connectToEWSToolStripMenuItem1.Name = "connectToEWSToolStripMenuItem1";
            // 
            // v2010ToolStripMenuItem
            // 
            resources.ApplyResources(this.v2010ToolStripMenuItem, "v2010ToolStripMenuItem");
            this.v2010ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.v2010ToolStripMenuItem.Name = "v2010ToolStripMenuItem";
            this.v2010ToolStripMenuItem.Tag = "Exchange2010";
            this.v2010ToolStripMenuItem.Click += new System.EventHandler(this.V2010ToolStripMenuItemClick);
            // 
            // v2010SP1ToolStripMenuItem
            // 
            resources.ApplyResources(this.v2010SP1ToolStripMenuItem, "v2010SP1ToolStripMenuItem");
            this.v2010SP1ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.v2010SP1ToolStripMenuItem.Name = "v2010SP1ToolStripMenuItem";
            this.v2010SP1ToolStripMenuItem.Tag = "Exchange2010_SP1";
            this.v2010SP1ToolStripMenuItem.Click += new System.EventHandler(this.V2010Sp1ToolStripMenuItemClick);
            // 
            // v2010SP2ToolStripMenuItem
            // 
            resources.ApplyResources(this.v2010SP2ToolStripMenuItem, "v2010SP2ToolStripMenuItem");
            this.v2010SP2ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.v2010SP2ToolStripMenuItem.Name = "v2010SP2ToolStripMenuItem";
            this.v2010SP2ToolStripMenuItem.Tag = "Exchange2010_SP2";
            this.v2010SP2ToolStripMenuItem.Click += new System.EventHandler(this.V2010Sp2ToolStripMenuItemClick);
            // 
            // v2013ToolStripMenuItem
            // 
            resources.ApplyResources(this.v2013ToolStripMenuItem, "v2013ToolStripMenuItem");
            this.v2013ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.v2013ToolStripMenuItem.Name = "v2013ToolStripMenuItem";
            this.v2013ToolStripMenuItem.Tag = "Exchange2013";
            this.v2013ToolStripMenuItem.Click += new System.EventHandler(this.V2013ToolStripMenuItemClick);
            // 
            // v2013SPToolStripMenuItem
            // 
            resources.ApplyResources(this.v2013SPToolStripMenuItem, "v2013SPToolStripMenuItem");
            this.v2013SPToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.v2013SPToolStripMenuItem.Name = "v2013SPToolStripMenuItem";
            this.v2013SPToolStripMenuItem.Tag = "Exchange2013_SP1";
            this.v2013SPToolStripMenuItem.Click += new System.EventHandler(this.V2013SpToolStripMenuItemClick);
            // 
            // generateToolStripMenuItem
            // 
            resources.ApplyResources(this.generateToolStripMenuItem, "generateToolStripMenuItem");
            this.generateToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.GenerateToolStripMenuItemClick);
            // 
            // saveSettingsToolStripMenuItem
            // 
            resources.ApplyResources(this.saveSettingsToolStripMenuItem, "saveSettingsToolStripMenuItem");
            this.saveSettingsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            this.saveSettingsToolStripMenuItem.Click += new System.EventHandler(this.SaveSettingsToolStripMenuItemClick);
            // 
            // languageToolStripMenuItem
            // 
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.russianToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            // 
            // russianToolStripMenuItem
            // 
            resources.ApplyResources(this.russianToolStripMenuItem, "russianToolStripMenuItem");
            this.russianToolStripMenuItem.Name = "russianToolStripMenuItem";
            this.russianToolStripMenuItem.Click += new System.EventHandler(this.RussianToolStripMenuItemClick);
            // 
            // englishToolStripMenuItem
            // 
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.EnglishToolStripMenuItemClick);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer2);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.PerformLayout();
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tbSteps.ResumeLayout(false);
            this.tpContacts.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clEwsContacts.dgObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clTargetContacts.dgObjects)).EndInit();
            this.tpGen.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clMailTemplates.dgObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clEventTemplates.dgObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEventsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMailsCount)).EndInit();
            this.tpGenerate.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.ComplexList clMailTemplates;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnClearLog;
        private System.Windows.Forms.NumericUpDown numMailsCount;
        private System.Windows.Forms.Label lbMailsCount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToEWSToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem russianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem v2010ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem v2010SP1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem v2010SP2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem v2013ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem v2013SPToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbtnOpenLog;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TabControl tbSteps;
        private System.Windows.Forms.TabPage tpContacts;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private Controls.ComplexList clEwsContacts;
        private System.Windows.Forms.TabPage tpGen;
        private Controls.ComplexList clEventTemplates;
        private Controls.ComplexList clTargetContacts;
        private System.Windows.Forms.TabPage tpGenerate;
        private System.Windows.Forms.Button btnGenMail;
        private System.Windows.Forms.ProgressBar pgGenProgress;
        private System.Windows.Forms.Label lbEventsCount;
        private System.Windows.Forms.NumericUpDown numEventsCount;
        private System.Windows.Forms.Button btnGenerateEvents;
        private System.Windows.Forms.Button btnGenerateAll;
    }
}

