using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Eumel.EmailCategorizer.Model;
using Eumel.EmailCategorizer.Persister;

namespace Eumel.EmailCategorizer
{
    public partial class ManageTopicsForm : Form
    {
        private readonly Topic[] _topic;

        public ManageTopicsForm()
        {
            InitializeComponent();

            _topic = ThisAddIn.ServiceLocator.TopicPersister.GetTopics().ToArray();
        }

        private void LoadTopics()
        {
            // add selected topic
            lstTopics.Items.Clear();
            lstTopics.Items.AddRange(_topic);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) return;

            if (lstTopics.Items.Cast<Topic>().Any(item =>
                string.Compare(item.Title, textBox1.Text, StringComparison.CurrentCultureIgnoreCase) == 0))
                return;

            lstTopics.Items.Add(new Topic {Title = textBox1.Text});
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstTopics.SelectedIndex < 0) return;

            lstTopics.Items.Remove(lstTopics.SelectedItem);
        }

        private void ManageTopicsForm_Load(object sender, EventArgs e)
        {
            LoadTopics();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var newTopics = lstTopics.Items.Cast<Topic>();
            ThisAddIn.ServiceLocator.TopicPersister.SetTopics(newTopics);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}