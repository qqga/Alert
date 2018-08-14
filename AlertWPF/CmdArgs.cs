using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertWPF
{
    public class CmdArgs : IAlertOptions
    {
        [Option('t', "time", HelpText = "Alert time.")]
        public string DTStr { get; set; }

        [Option('w', "wait", HelpText = "Time to wait before alert, in TimeSpan format")]
        public string WaitTimeStr { get; set; }

        [Value(0,MetaName = "AlertMessage", Default = "!", Required = true, HelpText = "Alert message, which will be displayed")]
        public string AlertMessageRaw { get; set; }

        public DateTime? DT => DTStr != null ? (DateTime?)DateTime.Parse(DTStr) : null;

        public TimeSpan? WaitTime => WaitTimeStr != null ? (TimeSpan?)TimeSpan.Parse(WaitTimeStr) : null;

        public string AlertMessage => AlertMessageRaw.Replace("\\n", Environment.NewLine);
    }
}
