using System;
using System.Linq;

namespace AlertWPF
{
    public class CmdArgsAlert : CmdArgs
    {
        const string CmdPrefix = "-";
        const string TargetTimeArgName = CmdPrefix + "t";
        const string TimeWaitArgName = CmdPrefix + "tw";


        public string AlertMessage { get; }
        public Action ParamsAction { get; private set; } = () => { };

        public CmdArgsAlert() : base(CmdPrefix)
        {
            AlertMessage = GetAlertMessage();
            AppendTargetTimeAction();
            AppendTimeWaitAction();
        }

        private void AppendTimeWaitAction()
        {
            if (this.ArgsDictinoary.TryGetValue(TimeWaitArgName, out string tParam))
            {
                var waitTimeSpan = TimeSpan.Parse(tParam);

                System.Diagnostics.Trace.TraceInformation($"Alert wait time: '{waitTimeSpan}'");

                ParamsAction += GetWatiAction(waitTimeSpan);
            }
        }

        Action GetWatiAction(TimeSpan timeSpan) => () => System.Threading.Thread.Sleep(timeSpan);

        TimeSpan GetTargetTimeSpan(string tParam)
        {
            var targetDt = DateTime.Parse(tParam);
            var now = DateTime.Now;
            var difDt = targetDt > now ? targetDt - now : TimeSpan.FromSeconds(0);

            System.Diagnostics.Trace.TraceInformation($"Alert target time: '{targetDt}', so waiting '{difDt}'");

            return difDt;

        }

        private void AppendTargetTimeAction()
        {
            if (this.ArgsDictinoary.TryGetValue(TargetTimeArgName, out string tParam))
            {
                var targetTimeSpan = GetTargetTimeSpan(tParam);
                ParamsAction += GetWatiAction(targetTimeSpan);
            }
        }


        string GetAlertMessage()
        {
            var messages = this.ArgsDictinoary.Select(kv => kv.Key.StartsWith(CmdPrefix) ? string.Empty : kv.Key);
            string alertMessage = string.Join(Environment.NewLine, messages);
            return alertMessage;
        }
    }
}
