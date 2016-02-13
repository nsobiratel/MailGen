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
            this.worker = new System.ComponentModel.BackgroundWorker();
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
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.lbLog);
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
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
            this.tsbtnClearLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.tsbtnClearLog, "tsbtnClearLog");
            this.tsbtnClearLog.Name = "tsbtnClearLog";
            this.tsbtnClearLog.Click += new System.EventHandler(this.ToolStripButton1Click);
            // 
            // tsbtnOpenLog
            // 
            this.tsbtnOpenLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnOpenLog.Name = "tsbtnOpenLog";
            resources.ApplyResources(this.tsbtnOpenLog, "tsbtnOpenLog");
            this.tsbtnOpenLog.Click += new System.EventHandler(this.ToolStripButton2Click);
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Controls.Add(this.panel2);
            resources.ApplyResources(this.toolStripContainer2.ContentPanel, "toolStripContainer2.ContentPanel");
            resources.ApplyResources(this.toolStripContainer2, "toolStripContainer2");
            this.toolStripContainer2.Name = "toolStripContainer2";
            // 
            // toolStripContainer2.TopToolStripPanel
            // 
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer2);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            resources.ApplyResources(this.splitContainer2.Panel1, "splitContainer2.Panel1");
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.toolStripContainer1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbSteps);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // tbSteps
            // 
            this.tbSteps.Controls.Add(this.tpContacts);
            this.tbSteps.Controls.Add(this.tpGen);
            this.tbSteps.Controls.Add(this.tpGenerate);
            resources.ApplyResources(this.tbSteps, "tbSteps");
            this.tbSteps.Name = "tbSteps";
            this.tbSteps.SelectedIndex = 0;
            // 
            // tpContacts
            // 
            this.tpContacts.Controls.Add(this.splitContainer4);
            resources.ApplyResources(this.tpContacts, "tpContacts");
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
            this.splitContainer4.Panel1.Controls.Add(this.clEwsContacts);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.clTargetContacts);
            // 
            // clEwsContacts
            // 
            resources.ApplyResources(this.clEwsContacts, "clEwsContacts");
            // 
            // 
            // 
            this.clEwsContacts.barTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.clEwsContacts.barTools.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location")));
            this.clEwsContacts.barTools.Name = "_barTools";
            this.clEwsContacts.barTools.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size")));
            this.clEwsContacts.barTools.TabIndex = ((int)(resources.GetObject("resource.TabIndex")));
            // 
            // 
            // 
            this.clEwsContacts.dgObjects.DataSource = null;
            this.clEwsContacts.dgObjects.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock")));
            this.clEwsContacts.dgObjects.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location")));
            this.clEwsContacts.dgObjects.Name = "_dgObjects";
            this.clEwsContacts.dgObjects.ShowImagesOnSubItems = true;
            this.clEwsContacts.dgObjects.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size")));
            this.clEwsContacts.dgObjects.TabIndex = ((int)(resources.GetObject("resource.TabIndex")));
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
            this.clTargetContacts.barTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.clTargetContacts.barTools.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location2")));
            this.clTargetContacts.barTools.Name = "_barTools";
            this.clTargetContacts.barTools.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size2")));
            this.clTargetContacts.barTools.TabIndex = ((int)(resources.GetObject("resource.TabIndex2")));
            // 
            // 
            // 
            this.clTargetContacts.dgObjects.DataSource = null;
            this.clTargetContacts.dgObjects.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock1")));
            this.clTargetContacts.dgObjects.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location1")));
            this.clTargetContacts.dgObjects.Name = "_dgObjects";
            this.clTargetContacts.dgObjects.ShowImagesOnSubItems = true;
            this.clTargetContacts.dgObjects.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size1")));
            this.clTargetContacts.dgObjects.TabIndex = ((int)(resources.GetObject("resource.TabIndex1")));
            this.clTargetContacts.dgObjects.UseCompatibleStateImageBehavior = false;
            this.clTargetContacts.Name = "clTargetContacts";
            // 
            // tpGen
            // 
            this.tpGen.Controls.Add(this.splitContainer3);
            resources.ApplyResources(this.tpGen, "tpGen");
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
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer3.Panel2
            // 
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
            this.splitContainer1.Panel1.Controls.Add(this.clMailTemplates);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.clEventTemplates);
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer1SplitterMoved);
            // 
            // clMailTemplates
            // 
            resources.ApplyResources(this.clMailTemplates, "clMailTemplates");
            // 
            // 
            // 
            this.clMailTemplates.barTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.clMailTemplates.barTools.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location4")));
            this.clMailTemplates.barTools.Name = "_barTools";
            this.clMailTemplates.barTools.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size4")));
            this.clMailTemplates.barTools.TabIndex = ((int)(resources.GetObject("resource.TabIndex4")));
            // 
            // 
            // 
            this.clMailTemplates.dgObjects.DataSource = null;
            this.clMailTemplates.dgObjects.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock2")));
            this.clMailTemplates.dgObjects.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location2")));
            this.clMailTemplates.dgObjects.Name = "_dgObjects";
            this.clMailTemplates.dgObjects.ShowImagesOnSubItems = true;
            this.clMailTemplates.dgObjects.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size2")));
            this.clMailTemplates.dgObjects.TabIndex = ((int)(resources.GetObject("resource.TabIndex2")));
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
            this.clEventTemplates.barTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.clEventTemplates.barTools.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location6")));
            this.clEventTemplates.barTools.Name = "_barTools";
            this.clEventTemplates.barTools.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size6")));
            this.clEventTemplates.barTools.TabIndex = ((int)(resources.GetObject("resource.TabIndex6")));
            // 
            // 
            // 
            this.clEventTemplates.dgObjects.DataSource = null;
            this.clEventTemplates.dgObjects.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("resource.Dock3")));
            this.clEventTemplates.dgObjects.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location3")));
            this.clEventTemplates.dgObjects.Name = "_dgObjects";
            this.clEventTemplates.dgObjects.ShowImagesOnSubItems = true;
            this.clEventTemplates.dgObjects.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size3")));
            this.clEventTemplates.dgObjects.TabIndex = ((int)(resources.GetObject("resource.TabIndex3")));
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
            this.tpGenerate.Controls.Add(this.btnGenerateAll);
            this.tpGenerate.Controls.Add(this.btnGenerateEvents);
            this.tpGenerate.Controls.Add(this.btnGenMail);
            this.tpGenerate.Controls.Add(this.pgGenProgress);
            resources.ApplyResources(this.tpGenerate, "tpGenerate");
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
            this.actionsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToEWSToolStripMenuItem1,
            this.generateToolStripMenuItem,
            this.saveSettingsToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            resources.ApplyResources(this.actionsToolStripMenuItem, "actionsToolStripMenuItem");
            // 
            // connectToEWSToolStripMenuItem1
            // 
            this.connectToEWSToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.connectToEWSToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.v2010ToolStripMenuItem,
            this.v2010SP1ToolStripMenuItem,
            this.v2010SP2ToolStripMenuItem,
            this.v2013ToolStripMenuItem,
            this.v2013SPToolStripMenuItem});
            this.connectToEWSToolStripMenuItem1.Name = "connectToEWSToolStripMenuItem1";
            resources.ApplyResources(this.connectToEWSToolStripMenuItem1, "connectToEWSToolStripMenuItem1");
            // 
            // v2010ToolStripMenuItem
            // 
            this.v2010ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.v2010ToolStripMenuItem.Name = "v2010ToolStripMenuItem";
            resources.ApplyResources(this.v2010ToolStripMenuItem, "v2010ToolStripMenuItem");
            this.v2010ToolStripMenuItem.Tag = "Exchange2010";
            this.v2010ToolStripMenuItem.Click += new System.EventHandler(this.V2010ToolStripMenuItemClick);
            // 
            // v2010SP1ToolStripMenuItem
            // 
            this.v2010SP1ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.v2010SP1ToolStripMenuItem.Name = "v2010SP1ToolStripMenuItem";
            resources.ApplyResources(this.v2010SP1ToolStripMenuItem, "v2010SP1ToolStripMenuItem");
            this.v2010SP1ToolStripMenuItem.Tag = "Exchange2010_SP1";
            this.v2010SP1ToolStripMenuItem.Click += new System.EventHandler(this.V2010Sp1ToolStripMenuItemClick);
            // 
            // v2010SP2ToolStripMenuItem
            // 
            this.v2010SP2ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.v2010SP2ToolStripMenuItem.Name = "v2010SP2ToolStripMenuItem";
            resources.ApplyResources(this.v2010SP2ToolStripMenuItem, "v2010SP2ToolStripMenuItem");
            this.v2010SP2ToolStripMenuItem.Tag = "Exchange2010_SP2";
            this.v2010SP2ToolStripMenuItem.Click += new System.EventHandler(this.V2010Sp2ToolStripMenuItemClick);
            // 
            // v2013ToolStripMenuItem
            // 
            this.v2013ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.v2013ToolStripMenuItem.Name = "v2013ToolStripMenuItem";
            resources.ApplyResources(this.v2013ToolStripMenuItem, "v2013ToolStripMenuItem");
            this.v2013ToolStripMenuItem.Tag = "Exchange2013";
            this.v2013ToolStripMenuItem.Click += new System.EventHandler(this.V2013ToolStripMenuItemClick);
            // 
            // v2013SPToolStripMenuItem
            // 
            this.v2013SPToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.v2013SPToolStripMenuItem.Name = "v2013SPToolStripMenuItem";
            resources.ApplyResources(this.v2013SPToolStripMenuItem, "v2013SPToolStripMenuItem");
            this.v2013SPToolStripMenuItem.Tag = "Exchange2013_SP1";
            this.v2013SPToolStripMenuItem.Click += new System.EventHandler(this.V2013SpToolStripMenuItemClick);
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            resources.ApplyResources(this.generateToolStripMenuItem, "generateToolStripMenuItem");
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.GenerateToolStripMenuItemClick);
            // 
            // saveSettingsToolStripMenuItem
            // 
            this.saveSettingsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            resources.ApplyResources(this.saveSettingsToolStripMenuItem, "saveSettingsToolStripMenuItem");
            this.saveSettingsToolStripMenuItem.Click += new System.EventHandler(this.SaveSettingsToolStripMenuItemClick);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.russianToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // russianToolStripMenuItem
            // 
            this.russianToolStripMenuItem.Name = "russianToolStripMenuItem";
            resources.ApplyResources(this.russianToolStripMenuItem, "russianToolStripMenuItem");
            this.russianToolStripMenuItem.Click += new System.EventHandler(this.RussianToolStripMenuItemClick);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.EnglishToolStripMenuItemClick);
            // 
            // worker
            // 
            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;
            this.worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.worker_ProgressChanged);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
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
        private System.ComponentModel.BackgroundWorker worker;
    }
}

