using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AlertWPF
{
    public class AlertUtil
    {
        public static void Alert(IAlertOptions options, Action onAlert = null)
        {
            if(string.IsNullOrEmpty(options.AlertMessage))
                Application.Current.Shutdown();

            WaitForAlert(options);

            Console.Beep();
            Console.WriteLine(options.AlertMessage);
            onAlert?.Invoke();
        }

        static void WaitForAlert(IAlertOptions options)
        {
            if(options.DT.HasValue && options.DT.Value - DateTime.Now is TimeSpan tsToDT && tsToDT.TotalSeconds > 0)
                System.Threading.Thread.Sleep(tsToDT);

            if(options.WaitTime.HasValue)
                System.Threading.Thread.Sleep(options.WaitTime.Value);
        }
    }
}
