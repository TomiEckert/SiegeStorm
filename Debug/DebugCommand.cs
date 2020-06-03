using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiegeStorm
{
    [System.AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    sealed class DebugCommandAttribute : Attribute
    {
        string help;
        string usage;
        public DebugCommandAttribute(string help, string usage)
        {
            this.help = help;
            this.usage = usage;
        }

        public string GetHelp()
        {
            return help;
        }
        public string GetUsage()
        {
            return usage;
        }
    }
}
