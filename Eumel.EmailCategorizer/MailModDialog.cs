using Eumel.EmailCategorizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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

            DialogResult = DialogResult.Cancel;
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
                var tmp = new Topic { Title = cboTopics.Text };
                cboTopics.Items.Insert(0, tmp);
                cboTopics.SelectedItem = tmp;
            }

            _subject.Topic = (Topic)cboTopics.SelectedItem;
            _subject.Subject = txtSubject.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            Close();
        }

        private void btnManageTopics_Click(object sender, EventArgs e)
        {
            new ManageTopicsForm().ShowDialog();
            LoadTopics();
        }
    }
}