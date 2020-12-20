namespace Eumel.EmailCategorizer
{
    partial class EumelRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public EumelRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EumelRibbon));
            this.tabSwk = this.Factory.CreateRibbonTab();
            this.grpCategorizer = this.Factory.CreateRibbonGroup();
            this.btnEditTopics = this.Factory.CreateRibbonButton();
            this.donateGroup = this.Factory.CreateRibbonGroup();
            this.btnDonate = this.Factory.CreateRibbonButton();
            this.tabSwk.SuspendLayout();
            this.grpCategorizer.SuspendLayout();
            this.donateGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSwk
            // 
            this.tabSwk.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tabSwk.Groups.Add(this.grpCategorizer);
            this.tabSwk.Groups.Add(this.donateGroup);
            this.tabSwk.Label = "Eumel";
            this.tabSwk.Name = "tabSwk";
            // 
            // grpCategorizer
            // 
            this.grpCategorizer.Items.Add(this.btnEditTopics);
            this.grpCategorizer.Label = "Topics";
            this.grpCategorizer.Name = "grpCategorizer";
            // 
            // btnEditTopics
            // 
            this.btnEditTopics.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnEditTopics.Image = ((System.Drawing.Image)(resources.GetObject("btnEditTopics.Image")));
            this.btnEditTopics.Label = "Manage";
            this.btnEditTopics.Name = "btnEditTopics";
            this.btnEditTopics.ShowImage = true;
            this.btnEditTopics.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnEditTopics_Click);
            // 
            // donateGroup
            // 
            this.donateGroup.Items.Add(this.btnDonate);
            this.donateGroup.Label = "Donate";
            this.donateGroup.Name = "donateGroup";
            // 
            // btnDonate
            // 
            this.btnDonate.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnDonate.Image = ((System.Drawing.Image)(resources.GetObject("btnDonate.Image")));
            this.btnDonate.Label = " ";
            this.btnDonate.Name = "btnDonate";
            this.btnDonate.ShowImage = true;
            this.btnDonate.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnDonate_Click);
            // 
            // EumelRibbon
            // 
            this.Name = "EumelRibbon";
            this.RibbonType = "Microsoft.Outlook.Explorer, Microsoft.Outlook.Mail.Compose";
            this.Tabs.Add(this.tabSwk);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.CategorizerRibbon_Load);
            this.tabSwk.ResumeLayout(false);
            this.tabSwk.PerformLayout();
            this.grpCategorizer.ResumeLayout(false);
            this.grpCategorizer.PerformLayout();
            this.donateGroup.ResumeLayout(false);
            this.donateGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabSwk;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpCategorizer;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnEditTopics;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDonate;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup donateGroup;
    }

    partial class ThisRibbonCollection
    {
        internal EumelRibbon CategorizerRibbon
        {
            get { return this.GetRibbon<EumelRibbon>(); }
        }
    }
}
