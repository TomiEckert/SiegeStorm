using System;

namespace SiegeStorm
{
    [System.AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    internal sealed class DebugCommandAttribute : Attribute
    {
        private string help;
        private string usage;

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