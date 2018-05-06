using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertWPF
{
    public class CmdArgs
    {
        string CommandPrefix { get; }

        string[] Args { get; }
        public Dictionary<string, string> ArgsDictinoary { get; }
        public CmdArgs(string commandPrefix = "-")
        {
            CommandPrefix = commandPrefix;
            Args = Environment.GetCommandLineArgs().Skip(1).ToArray();
            ArgsDictinoary = GetArgsDictionary(Args);
        }

        public string this[string arg]
        {
            get
            {
                if (ArgsDictinoary.TryGetValue(arg, out string param))
                    return param;
                else
                    return null;
            }
        }

        Dictionary<string, string> GetArgsDictionary(string[] args)
        {
            Dictionary<string, string> argsDic = new Dictionary<string, string>();
            for (int i = 0; i < Args.Length; i++)
            {
                string arg = Args[i];

                if (arg.StartsWith(CommandPrefix) && i + 1 < Args.Length && !Args[i + 1].StartsWith(CommandPrefix))
                    argsDic.Add(arg, Args[++i]);
                else
                    argsDic.Add(arg, string.Empty);
            }
            return argsDic;
        }


    }
}
