namespace Eumel.EmailCategorizer
{
    partial class CategorizerRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public CategorizerRibbon()
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
            this.tabSwk = this.Factory.CreateRibbonTab();
            this.grpCategorizer = this.Factory.CreateRibbonGroup();
            this.btnEditTopics = this.Factory.CreateRibbonButton();
            this.btnDonate = this.Factory.CreateRibbonButton();
            this.tabSwk.SuspendLayout();
            this.grpCategorizer.SuspendLayout();
            // 
            // tabSwk
            // 
            this.tabSwk.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tabSwk.Groups.Add(this.grpCategorizer);
            this.tabSwk.Label = "Categorizer";
            this.tabSwk.Name = "tabSwk";
            // 
            // grpCategorizer
            // 
            this.grpCategorizer.Items.Add(this.btnEditTopics);
            this.grpCategorizer.Items.Add(this.btnDonate);
            this.grpCategorizer.Label = "Topics";
            this.grpCategorizer.Name = "grpCategorizer";
            // 
            // btnEditTopics
            // 
            this.btnEditTopics.Label = "Manage Topics";
            this.btnEditTopics.Name = "btnEditTopics";
            this.btnEditTopics.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnEditTopics_Click);
            // 
            // btnDonate
            // 
            this.btnDonate.Label = "Donate with PayPal";
            this.btnDonate.Name = "btnDonate";
            this.btnDonate.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnDonate_Click);
            // 
            // CategorizerRibbon
            // 
            this.Name = "CategorizerRibbon";
            this.RibbonType = "Microsoft.Outlook.Explorer, Microsoft.Outlook.Mail.Compose";
            this.Tabs.Add(this.tabSwk);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.CategorizerRibbon_Load);
            this.tabSwk.ResumeLayout(false);
            this.tabSwk.PerformLayout();
            this.grpCategorizer.ResumeLayout(false);
            this.grpCategorizer.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabSwk;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpCategorizer;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnEditTopics;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDonate;
    }

    partial class ThisRibbonCollection
    {
        internal CategorizerRibbon CategorizerRibbon
        {
            get { return this.GetRibbon<CategorizerRibbon>(); }
        }
    }
}
