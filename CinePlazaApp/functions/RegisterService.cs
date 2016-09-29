using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Popups;

namespace CinePlazaApp.functions
{
    class RegisterService
    {
        public static async void registerService()
        {
            string myTaskName = "FirstTask";

            // check if task is already registered
            foreach (var cur in BackgroundTaskRegistration.AllTasks)
                if (cur.Value.Name == myTaskName)
                {
                    Debug.Write("Task already registered");
                    return;
                }

            // Windows Phone app must call this to use trigger types (see MSDN)
            await BackgroundExecutionManager.RequestAccessAsync();
            
            // register a new task
            BackgroundTaskBuilder taskBuilder = new BackgroundTaskBuilder { Name = "FirstTask", TaskEntryPoint = "Services.CheckMovie" };
            //taskBuilder.SetTrigger(new TimeTrigger(15, false));new SystemTrigger(SystemTriggerType.LockScreenApplicationAdded, false)
            IBackgroundTrigger trigger = new TimeTrigger(15, false);
            taskBuilder.SetTrigger(trigger);
            taskBuilder.AddCondition(new SystemCondition(SystemConditionType.InternetAvailable));
            BackgroundTaskRegistration myFirstTask = taskBuilder.Register();
            
            Debug.Write("Task register");

        }
        
    }
}
