using System;
using Eumel.EmailCategorizer.Core;
using Eumel.EmailCategorizer.Core.Impl;
using Eumel.EmailCategorizer.Core.Model;
using Eumel.EmailCategorizer.Core.Ui;
using Eumel.EmailCategorizerNG.Wrapper;
using Microsoft.Office.Interop.Outlook;

namespace Eumel.EmailCategorizerNG
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            var folder = Application.Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
            var storage = new StorageWrapper(
                folder.GetStorage(
                    StorageWrapper.CategorizerDataStore,
                    OlStorageIdentifierType.olIdentifyBySubject));

            // initialize config persister with static [ and ] as topic separator
            var configPersister = new StaticConfigPersister();
            ServiceLocator.ConfigPersister = configPersister;

            // initialize topic persister with StorageItem
            var topicPersister = new TopicPersister(storage);
            ServiceLocator.TopicPersister = topicPersister;

            Application.ItemSend += Application_ItemSend;
        }

        private void Application_ItemSend(object item, ref bool cancel)
        {
            if (!(item is MailItem mail)) return;

            var cfg = ServiceLocator.ConfigPersister.GetConfig();
            var subject = new EnhancedSubject(mail.Subject, cfg);
            var usedTopics = ServiceLocator.TopicPersister.GetTopics();

            var ctrl = new EumelMailSendControl
            {
                Topics = usedTopics,
                Subject = subject
            };

            var dlgResult = ctrl.ShowModel("Eumel Email Categorizer");
            if (dlgResult.HasValue && dlgResult.Value)
            {
                mail.Subject = subject.ToString();
                ServiceLocator.TopicPersister.AddTopic(subject.Topic);
            }
            else
            {
                cancel = true;
            }
        }

        private void ThisAddIn_Shutdown(object sender, EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO generated code

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            Startup += ThisAddIn_Startup;
            Shutdown += ThisAddIn_Shutdown;
        }

        #endregion VSTO generated code
    }
}