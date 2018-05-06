using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertWPF
{
    public class AlertUtil
    {
        public static void Alert(Action<string> messageHandler = null)
        {
            var cmdargs = new CmdArgsAlert();
            var message = cmdargs.AlertMessage;
            cmdargs.ParamsAction();

            Console.Beep();
            Console.WriteLine(message);
            messageHandler?.Invoke(message);
        }      
    }
}
