using System;
using System.Linq;

namespace AlertWPF
{
    public interface IAlertOptions
    {
        string AlertMessage { get; }
        DateTime? DT { get; }
        TimeSpan? WaitTime { get; }
    }
}
