namespace WirelessLanProfiles
{
    partial class WlanBrowser
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
                components.Dispose( );
            }
            base.Dispose(disposing);
            native.Dispose();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbInterfaces = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pageState = new System.Windows.Forms.TabPage();
            this.pgState = new System.Windows.Forms.PropertyGrid();
            this.pageProfile = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbProfiles = new System.Windows.Forms.ComboBox();
            this.btnProfilesRefresh = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.pgProf = new System.Windows.Forms.PropertyGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageNetworks = new System.Windows.Forms.TabPage();
            this.pageTemporaryProfiles = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbTmpProfile = new System.Windows.Forms.TextBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.btnSetProfile = new System.Windows.Forms.Button();
            this.btnResetProfile = new System.Windows.Forms.Button();
            this.tbProfileXML = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tbEAPXML = new System.Windows.Forms.TextBox();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.cbNetworks = new System.Windows.Forms.ComboBox();
            this.btnNetworkRefresh = new System.Windows.Forms.Button();
            this.pgNetwork = new System.Windows.Forms.PropertyGrid();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.cbNotifyChanges = new System.Windows.Forms.CheckBox();
            this.btnRescan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.pageState.SuspendLayout();
            this.pageProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.pageNetworks.SuspendLayout();
            this.pageTemporaryProfiles.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl);
            this.splitContainer1.Size = new System.Drawing.Size(1579, 870);
            this.splitContainer1.SplitterDistance = 38;
            this.splitContainer1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.cbInterfaces);
            this.flowLayoutPanel1.Controls.Add(this.btnRefresh);
            this.flowLayoutPanel1.Controls.Add(this.cbNotifyChanges);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1579, 38);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Interfaces:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbInterfaces
            // 
            this.cbInterfaces.FormattingEnabled = true;
            this.cbInterfaces.Location = new System.Drawing.Point(119, 3);
            this.cbInterfaces.Name = "cbInterfaces";
            this.cbInterfaces.Size = new System.Drawing.Size(680, 32);
            this.cbInterfaces.TabIndex = 1;
            this.cbInterfaces.SelectedIndexChanged += new System.EventHandler(this.cbInterfaces_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.Location = new System.Drawing.Point(805, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(145, 34);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.pageState);
            this.tabControl.Controls.Add(this.pageProfile);
            this.tabControl.Controls.Add(this.pageNetworks);
            this.tabControl.Controls.Add(this.pageTemporaryProfiles);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1579, 828);
            this.tabControl.TabIndex = 0;
            // 
            // pageState
            // 
            this.pageState.Controls.Add(this.pgState);
            this.pageState.Location = new System.Drawing.Point(4, 34);
            this.pageState.Name = "pageState";
            this.pageState.Padding = new System.Windows.Forms.Padding(3);
            this.pageState.Size = new System.Drawing.Size(1359, 884);
            this.pageState.TabIndex = 2;
            this.pageState.Text = "State";
            this.pageState.UseVisualStyleBackColor = true;
            // 
            // pgState
            // 
            this.pgState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgState.Location = new System.Drawing.Point(3, 3);
            this.pgState.Name = "pgState";
            this.pgState.Size = new System.Drawing.Size(1353, 878);
            this.pgState.TabIndex = 0;
            // 
            // pageProfile
            // 
            this.pageProfile.Controls.Add(this.splitContainer2);
            this.pageProfile.Location = new System.Drawing.Point(4, 33);
            this.pageProfile.Name = "pageProfile";
            this.pageProfile.Padding = new System.Windows.Forms.Padding(3);
            this.pageProfile.Size = new System.Drawing.Size(1571, 791);
            this.pageProfile.TabIndex = 0;
            this.pageProfile.Text = "Profiles";
            this.pageProfile.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.flowLayoutPanel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1565, 785);
            this.splitContainer2.SplitterDistance = 48;
            this.splitContainer2.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.cbProfiles);
            this.flowLayoutPanel2.Controls.Add(this.btnProfilesRefresh);
            this.flowLayoutPanel2.Controls.Add(this.btnEdit);
            this.flowLayoutPanel2.Controls.Add(this.btnConnect);
            this.flowLayoutPanel2.Controls.Add(this.btnDisconnect);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1565, 48);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Profiles:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbProfiles
            // 
            this.cbProfiles.FormattingEnabled = true;
            this.cbProfiles.Location = new System.Drawing.Point(96, 3);
            this.cbProfiles.Name = "cbProfiles";
            this.cbProfiles.Size = new System.Drawing.Size(680, 32);
            this.cbProfiles.TabIndex = 1;
            this.cbProfiles.SelectedIndexChanged += new System.EventHandler(this.cbProfiles_SelectedIndexChanged);
            // 
            // btnProfilesRefresh
            // 
            this.btnProfilesRefresh.AutoSize = true;
            this.btnProfilesRefresh.Location = new System.Drawing.Point(782, 3);
            this.btnProfilesRefresh.Name = "btnProfilesRefresh";
            this.btnProfilesRefresh.Size = new System.Drawing.Size(107, 42);
            this.btnProfilesRefresh.TabIndex = 2;
            this.btnProfilesRefresh.Text = "Refresh";
            this.btnProfilesRefresh.UseVisualStyleBackColor = true;
            this.btnProfilesRefresh.Click += new System.EventHandler(this.btnProfilesRefresh_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = true;
            this.btnEdit.Location = new System.Drawing.Point(895, 3);
            this.btnEdit.MinimumSize = new System.Drawing.Size(113, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(113, 42);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.pgProf);
            this.splitContainer3.Panel1MinSize = 150;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Panel2MinSize = 150;
            this.splitContainer3.Size = new System.Drawing.Size(1565, 733);
            this.splitContainer3.SplitterDistance = 335;
            this.splitContainer3.TabIndex = 0;
            // 
            // pgProf
            // 
            this.pgProf.ContextMenuStrip = this.contextMenuStrip1;
            this.pgProf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgProf.Location = new System.Drawing.Point(0, 0);
            this.pgProf.Name = "pgProf";
            this.pgProf.Size = new System.Drawing.Size(335, 733);
            this.pgProf.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(131, 40);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(130, 36);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // pageNetworks
            // 
            this.pageNetworks.Controls.Add(this.splitContainer6);
            this.pageNetworks.Location = new System.Drawing.Point(4, 33);
            this.pageNetworks.Name = "pageNetworks";
            this.pageNetworks.Padding = new System.Windows.Forms.Padding(3);
            this.pageNetworks.Size = new System.Drawing.Size(1571, 791);
            this.pageNetworks.TabIndex = 1;
            this.pageNetworks.Text = "Available Networks";
            this.pageNetworks.UseVisualStyleBackColor = true;
            // 
            // pageTemporaryProfiles
            // 
            this.pageTemporaryProfiles.Controls.Add(this.button1);
            this.pageTemporaryProfiles.Controls.Add(this.groupBox1);
            this.pageTemporaryProfiles.Location = new System.Drawing.Point(4, 33);
            this.pageTemporaryProfiles.Name = "pageTemporaryProfiles";
            this.pageTemporaryProfiles.Size = new System.Drawing.Size(1297, 791);
            this.pageTemporaryProfiles.TabIndex = 3;
            this.pageTemporaryProfiles.Text = "Temporary Profiles";
            this.pageTemporaryProfiles.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 752);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1297, 39);
            this.button1.TabIndex = 2;
            this.button1.Text = "Connect this profile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbTmpProfile);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1297, 791);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profile XML";
            // 
            // tbTmpProfile
            // 
            this.tbTmpProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTmpProfile.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTmpProfile.Location = new System.Drawing.Point(3, 28);
            this.tbTmpProfile.Multiline = true;
            this.tbTmpProfile.Name = "tbTmpProfile";
            this.tbTmpProfile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTmpProfile.Size = new System.Drawing.Size(1291, 760);
            this.tbTmpProfile.TabIndex = 1;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.splitContainer5);
            this.splitContainer4.Panel1MinSize = 200;
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer4.Panel2MinSize = 100;
            this.splitContainer4.Size = new System.Drawing.Size(1226, 733);
            this.splitContainer4.SplitterDistance = 485;
            this.splitContainer4.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.button2);
            this.splitContainer5.Panel2.Controls.Add(this.btnResetProfile);
            this.splitContainer5.Panel2.Controls.Add(this.btnSetProfile);
            this.splitContainer5.Size = new System.Drawing.Size(1226, 485);
            this.splitContainer5.SplitterDistance = 422;
            this.splitContainer5.TabIndex = 0;
            // 
            // btnSetProfile
            // 
            this.btnSetProfile.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSetProfile.Location = new System.Drawing.Point(0, 0);
            this.btnSetProfile.Name = "btnSetProfile";
            this.btnSetProfile.Size = new System.Drawing.Size(166, 59);
            this.btnSetProfile.TabIndex = 0;
            this.btnSetProfile.Text = "Set Profile";
            this.btnSetProfile.UseVisualStyleBackColor = true;
            this.btnSetProfile.Click += new System.EventHandler(this.btnSetProfile_Click);
            // 
            // btnResetProfile
            // 
            this.btnResetProfile.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnResetProfile.Location = new System.Drawing.Point(1077, 0);
            this.btnResetProfile.Name = "btnResetProfile";
            this.btnResetProfile.Size = new System.Drawing.Size(149, 59);
            this.btnResetProfile.TabIndex = 1;
            this.btnResetProfile.Text = "Reset Profile";
            this.btnResetProfile.UseVisualStyleBackColor = true;
            this.btnResetProfile.Click += new System.EventHandler(this.btnResetProfile_Click);
            // 
            // tbProfileXML
            // 
            this.tbProfileXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbProfileXML.Location = new System.Drawing.Point(3, 28);
            this.tbProfileXML.Multiline = true;
            this.tbProfileXML.Name = "tbProfileXML";
            this.tbProfileXML.Size = new System.Drawing.Size(1220, 391);
            this.tbProfileXML.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbEAPXML);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1226, 244);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "EAP XML (or just edit it directly in the profile)";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbProfileXML);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1226, 422);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Profile";
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(166, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(911, 59);
            this.button2.TabIndex = 2;
            this.button2.Text = "Set EAP Data - All Users";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbEAPXML
            // 
            this.tbEAPXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEAPXML.Location = new System.Drawing.Point(3, 28);
            this.tbEAPXML.Multiline = true;
            this.tbEAPXML.Name = "tbEAPXML";
            this.tbEAPXML.Size = new System.Drawing.Size(1220, 213);
            this.tbEAPXML.TabIndex = 1;
            this.tbEAPXML.TextChanged += new System.EventHandler(this.tbEAPXML_TextChanged);
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(3, 3);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.btnRescan);
            this.splitContainer6.Panel1.Controls.Add(this.label3);
            this.splitContainer6.Panel1.Controls.Add(this.cbNetworks);
            this.splitContainer6.Panel1.Controls.Add(this.btnNetworkRefresh);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.pgNetwork);
            this.splitContainer6.Size = new System.Drawing.Size(1565, 785);
            this.splitContainer6.SplitterDistance = 44;
            this.splitContainer6.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Networks:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbNetworks
            // 
            this.cbNetworks.FormattingEnabled = true;
            this.cbNetworks.Location = new System.Drawing.Point(112, 5);
            this.cbNetworks.Name = "cbNetworks";
            this.cbNetworks.Size = new System.Drawing.Size(680, 32);
            this.cbNetworks.TabIndex = 4;
            this.cbNetworks.SelectedIndexChanged += new System.EventHandler(this.cbNetworks_SelectedIndexChanged);
            // 
            // btnNetworkRefresh
            // 
            this.btnNetworkRefresh.AutoSize = true;
            this.btnNetworkRefresh.Location = new System.Drawing.Point(798, 5);
            this.btnNetworkRefresh.Name = "btnNetworkRefresh";
            this.btnNetworkRefresh.Size = new System.Drawing.Size(145, 34);
            this.btnNetworkRefresh.TabIndex = 5;
            this.btnNetworkRefresh.Text = "Refresh";
            this.btnNetworkRefresh.UseVisualStyleBackColor = true;
            this.btnNetworkRefresh.Click += new System.EventHandler(this.button3_Click);
            // 
            // pgNetwork
            // 
            this.pgNetwork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgNetwork.Location = new System.Drawing.Point(0, 0);
            this.pgNetwork.Name = "pgNetwork";
            this.pgNetwork.Size = new System.Drawing.Size(1565, 737);
            this.pgNetwork.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.AutoSize = true;
            this.btnConnect.Location = new System.Drawing.Point(1014, 3);
            this.btnConnect.MinimumSize = new System.Drawing.Size(113, 0);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(113, 42);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.AutoSize = true;
            this.btnDisconnect.Location = new System.Drawing.Point(1133, 3);
            this.btnDisconnect.MinimumSize = new System.Drawing.Size(113, 0);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(125, 42);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // cbNotifyChanges
            // 
            this.cbNotifyChanges.AutoSize = true;
            this.cbNotifyChanges.Location = new System.Drawing.Point(956, 3);
            this.cbNotifyChanges.Name = "cbNotifyChanges";
            this.cbNotifyChanges.Size = new System.Drawing.Size(248, 28);
            this.cbNotifyChanges.TabIndex = 3;
            this.cbNotifyChanges.Text = "Notify Me Of Changes";
            this.cbNotifyChanges.UseVisualStyleBackColor = true;
            this.cbNotifyChanges.CheckedChanged += new System.EventHandler(this.cbNotifyChanges_CheckedChanged);
            // 
            // btnRescan
            // 
            this.btnRescan.AutoSize = true;
            this.btnRescan.Location = new System.Drawing.Point(949, 3);
            this.btnRescan.Name = "btnRescan";
            this.btnRescan.Size = new System.Drawing.Size(145, 34);
            this.btnRescan.TabIndex = 6;
            this.btnRescan.Text = "Scan";
            this.btnRescan.UseVisualStyleBackColor = true;
            this.btnRescan.Click += new System.EventHandler(this.btnRescan_Click);
            // 
            // WlanBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1579, 870);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Arial", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "WlanBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wireless LAN Browser";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.pageState.ResumeLayout(false);
            this.pageProfile.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.pageNetworks.ResumeLayout(false);
            this.pageTemporaryProfiles.ResumeLayout(false);
            this.pageTemporaryProfiles.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel1.PerformLayout();
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbInterfaces;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage pageProfile;
        private System.Windows.Forms.TabPage pageNetworks;
        private System.Windows.Forms.TabPage pageState;
        private System.Windows.Forms.PropertyGrid pgState;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbProfiles;
        private System.Windows.Forms.Button btnProfilesRefresh;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.PropertyGrid pgProf;
        private System.Windows.Forms.TabPage pageTemporaryProfiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbTmpProfile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbProfileXML;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnResetProfile;
        private System.Windows.Forms.Button btnSetProfile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbEAPXML;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbNetworks;
        private System.Windows.Forms.Button btnNetworkRefresh;
        private System.Windows.Forms.PropertyGrid pgNetwork;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.CheckBox cbNotifyChanges;
        private System.Windows.Forms.Button btnRescan;
    }
}

