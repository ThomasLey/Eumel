using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Eumel.EmailCategorizer.Core.Model;

namespace Eumel.EmailCategorizer.Core.Ui
{
    /// <summary>
    ///     Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class EumelMailSendControl : UserControl
    {
        public static readonly DependencyProperty TopicsProperty = DependencyProperty.Register(
            "Topics", typeof(ObservableCollection<Topic>), typeof(EumelMailSendControl), new PropertyMetadata(default(ObservableCollection<Topic>)));

        public ObservableCollection<Topic> Topics
        {
            get => (ObservableCollection<Topic>) GetValue(TopicsProperty);
            set => SetValue(TopicsProperty, value);
        }

        public static readonly DependencyProperty SubjectProperty = DependencyProperty.Register(
            "Subject", typeof(EnhancedSubject), typeof(EumelMailSendControl), new PropertyMetadata(default(EnhancedSubject)));

        public EnhancedSubject Subject
        {
            get => (EnhancedSubject) GetValue(SubjectProperty);
            set => SetValue(SubjectProperty, value);
        }
        
        public EumelMailSendControl()
        {
            InitializeComponent();

            this.DataContext = this;
        }
    }
}