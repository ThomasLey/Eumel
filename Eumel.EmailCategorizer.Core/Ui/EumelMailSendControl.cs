using System.Collections.Generic;
using System.Windows.Controls;
using Eumel.EmailCategorizer.Core.Model;

namespace Eumel.EmailCategorizer.Core.Ui
{
    /// <summary>
    ///     Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class EumelMailSendControl : UserControl
    {
        public EumelMailSendControl()
        {
            InitializeComponent();
        }

        public IEnumerable<Topic> Topics { get; set; }
        public EnhancedSubject Subject { get; set; }
    }
}