using System.Diagnostics;
using Microsoft.Office.Tools.Ribbon;

namespace Eumel.EmailCategorizer
{
    public partial class EumelRibbon
    {
        private void CategorizerRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void btnEditTopics_Click(object sender, RibbonControlEventArgs e)
        {
            new ManageTopicsForm().ShowDialog();
        }

        private void btnDonate_Click(object sender, RibbonControlEventArgs e)
        {
            Process.Start("https://www.paypal.com/donate?hosted_button_id=PHRRBV9C8P5J6");
        }
    }
}