
namespace Eumel.EmailCategorizerNG
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
            this.EumelTab = this.Factory.CreateRibbonTab();
            this.CategorizerGroup = this.Factory.CreateRibbonGroup();
            this.SettingsButton = this.Factory.CreateRibbonButton();
            this.DonateButton = this.Factory.CreateRibbonButton();
            this.EumelTab.SuspendLayout();
            this.CategorizerGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // EumelTab
            // 
            this.EumelTab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.EumelTab.Groups.Add(this.CategorizerGroup);
            this.EumelTab.Label = "Eumel";
            this.EumelTab.Name = "EumelTab";
            // 
            // CategorizerGroup
            // 
            this.CategorizerGroup.Items.Add(this.SettingsButton);
            this.CategorizerGroup.Items.Add(this.DonateButton);
            this.CategorizerGroup.Label = "Categorizer";
            this.CategorizerGroup.Name = "CategorizerGroup";
            // 
            // SettingsButton
            // 
            this.SettingsButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.SettingsButton.Image = ((System.Drawing.Image)(resources.GetObject("SettingsButton.Image")));
            this.SettingsButton.Label = "Settings";
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.ShowImage = true;
            this.SettingsButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.SettingsButton_Click);
            // 
            // DonateButton
            // 
            this.DonateButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.DonateButton.Image = ((System.Drawing.Image)(resources.GetObject("DonateButton.Image")));
            this.DonateButton.Label = "Donate";
            this.DonateButton.Name = "DonateButton";
            this.DonateButton.ShowImage = true;
            this.DonateButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.DonateButton_Click);
            // 
            // EumelRibbon
            // 
            this.Name = "EumelRibbon";
            this.RibbonType = "Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.EumelTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.EumelRibbon_Load);
            this.EumelTab.ResumeLayout(false);
            this.EumelTab.PerformLayout();
            this.CategorizerGroup.ResumeLayout(false);
            this.CategorizerGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab EumelTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup CategorizerGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton SettingsButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton DonateButton;
    }

    partial class ThisRibbonCollection
    {
        internal EumelRibbon EumelRibbon
        {
            get { return this.GetRibbon<EumelRibbon>(); }
        }
    }
}
