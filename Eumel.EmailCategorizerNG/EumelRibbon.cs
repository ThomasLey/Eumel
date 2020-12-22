using System.Diagnostics;
using Eumel.EmailCategorizer.Core.Ui;
using Microsoft.Office.Tools.Ribbon;

namespace Eumel.EmailCategorizerNG
{
    public partial class EumelRibbon
    {
        private void EumelRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void SettingsButton_Click(object sender, RibbonControlEventArgs e)
        {
            new SettingsControl().ShowModel("Eumel Configuration");
        }

        private void DonateButton_Click(object sender, RibbonControlEventArgs e)
        {
            Process.Start("https://www.paypal.com/donate?hosted_button_id=PHRRBV9C8P5J6");
        }
    }
}