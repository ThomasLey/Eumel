using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Eumel.EmailCategorizer.Model;
using Eumel.EmailCategorizer.Persister;
using NetOffice.OutlookApi;
using NetOffice.OutlookApi.Enums;
using NetOffice.OutlookApi.Tools;
using NetOffice.Tools;

namespace Eumel.EmailCategorizer
{
    [ComVisible(true)]
    [ProgId("ExcelAddinSample.Connect")]
    [Guid("CC85F97A-F409-4497-B2F2-A9581D4A2ED2")]
    public class EumelAddin : COMAddin
    {
        private const string CategorizerDataStore = "Eumel.EmailCategorizer";

        private void ThisAddIn_Startup(ref Array custom)
        {
            var folder = Application.Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
            var storage = folder.GetStorage(CategorizerDataStore, OlStorageIdentifierType.olIdentifyBySubject);

            // initialize config persister with static [ and ] as topic separator
            var configPersister = new StaticConfigPersister();
            ServiceLocator.ConfigPersister = configPersister;

            // initialize topic persister with StorageItem
            var topicPersister = new OutlookPstTopicPersister(storage);
            ServiceLocator.TopicPersister = topicPersister;

            Application.ItemSendEvent += Application_ItemSend;
        }

        #region ItemSent EventHandler

        private void Application_ItemSend(object Item, ref bool Cancel)
        {
            if (!(Item is MailItem mail)) return;

            var cfg = ServiceLocator.ConfigPersister.GetConfig();
            var subject = new EnhancedSubject(mail.Subject, cfg);
            //var usedTopics = ServiceLocator.TopicPersister.GetTopics();

            var dlg = new MailModDialog(subject);
            var res = dlg.ShowDialog();

            switch (res)
            {
                case DialogResult.OK:
                    mail.Subject = subject.ToString();

                    // add new topic to store
                    ServiceLocator.TopicPersister.AddTopic(subject.Topic);
                    break;

                case DialogResult.Abort:
                    Cancel = true;
                    break;
            }
        }

        #endregion ItemSent EventHandler

        #region VSTO generated code

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        // ReSharper disable RedundantDelegateCreation
        private void InternalStartup()
        {
            this.OnStartupComplete += new OnStartupCompleteEventHandler(ThisAddIn_Startup);
        }

        // ReSharper restore RedundantDelegateCreation

        #endregion VSTO generated code

        #region ServiceLocator

        internal static class ServiceLocator
        {
            public static ITopicPersister TopicPersister { get; internal set; }

            public static IConfigPersister ConfigPersister { get; internal set; }
        }

        #endregion ServiceLocator
    }
}