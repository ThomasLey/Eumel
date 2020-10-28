using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Eumel.EmailCategorizer.Persister;

// ReSharper disable InconsistentNaming
namespace Eumel.EmailCategorizer
{
    public partial class MailModDialog : Form
    {
        private readonly EnhancedSubject _subject;
        private readonly IEnumerable<Topic> _topic;

        public MailModDialog()
        {
            InitializeComponent();

            this.DialogResult = DialogResult.Cancel;
        }

        public MailModDialog(EnhancedSubject subject)
            : this()
        {
            _subject = subject;
            _topic = ThisAddIn.ServiceLocator.TopicPersister.GetTopics();
        }

        private void MailModDialog_Load(object sender, EventArgs e)
        {
            txtSubject.Text = _subject.Subject;

            LoadTopics();
        }

        private void LoadTopics()
        {
            // add selected topic
            cboTopics.Items.Clear();
            cboTopics.Items.AddRange(_topic.ToArray());
            cboTopics.Items.Insert(0, _subject.Topic);
            cboTopics.SelectedItem = _subject.Topic;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cboTopics.SelectedItem == null && !string.IsNullOrWhiteSpace(cboTopics.Text))
            {
                var tmp = new Topic() { Title = cboTopics.Text };
                cboTopics.Items.Insert(0, tmp);
                cboTopics.SelectedItem = tmp;
            }

            _subject.Topic = (Topic)cboTopics.SelectedItem;
            _subject.Subject = txtSubject.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void btnManageTopics_Click(object sender, EventArgs e)
        {
            new ManageTopicsForm().ShowDialog();
            LoadTopics();
        }
    }
}
