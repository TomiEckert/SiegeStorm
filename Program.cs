using System;
using System.Threading.Tasks;

namespace SiegeStorm
{
#if WINDOWS || LINUX

    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
#if DEBUG
            Task.Run(() => { new DebugConsole().RunConsole(); });
#endif
            using (var game = new SiegeStorm())
                game.Run();
        }
    }

#endif
}