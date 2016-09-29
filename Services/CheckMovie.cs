using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.UI.Popups;

namespace Services
{
    public sealed class CheckMovie : IBackgroundTask
    {

        void IBackgroundTask.Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral _deferral = taskInstance.GetDeferral();

            // simple example with a Toast, to enable this go to manifest file
            // and mark App as TastCapable - it won't work without this
            // The Task will start but there will be no Toast.
            ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList textElements = toastXml.GetElementsByTagName("text");
            textElements[0].AppendChild(toastXml.CreateTextNode("CinePlazaApp"));
            textElements[1].AppendChild(toastXml.CreateTextNode("Temos um novo Filme em Cartaz, venha Conferir..."));
            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(toastXml));


           _deferral.Complete();
        }
    }
}
