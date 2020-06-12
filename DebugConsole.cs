using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SiegeStorm
{
    internal class DebugConsole
    {
        private Dictionary<string, MethodInfo> commands;

        public void RunConsole()
        {
            commands = new Dictionary<string, MethodInfo>();
            GetCommands();

            while (true)
            {
                var input = Console.ReadLine();

                var command = input.Split(' ')[0];
                string[] args = new string[] { "" };
                if (input.Split(' ').Length > 1)
                    args = input.Remove(0, command.Count() + 1).Split(' ');

                RunCommand(command, args);
            }
        }

        private void GetCommands()
        {
            MethodInfo[] methodInfos = GetType()
                           .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var method in methodInfos)
            {
                var attr = method.GetCustomAttributes(typeof(DebugCommandAttribute), false);
                if (attr.Length > 0)
                {
                    commands.Add(method.Name.ToLower(), method);
                    Console.WriteLine("- Name: " + method.Name);
                }
            }
        }

        private void RunCommand(string command, string[] args)
        {
            if (commands.ContainsKey(command.ToLower()))
                commands[command.ToLower()].Invoke(this, new object[] { args });
        }

        [DebugCommand("Echos out the argument passed.", "echo test message")]
        private void Echo(string[] args)
        {
            string output = string.Join(" ", args);
            Console.WriteLine(output);
        }

        [DebugCommand("Prints out this message, prints out specific help for the command passed as an argument.", "help echo")]
        private void Help(string[] args)
        {
            var arg = args[0];
            if (arg.Length < 1)
            {
                var coms = commands.Keys.ToArray();
                Console.WriteLine("- " + string.Join(Environment.NewLine + "- ", coms));
            }
            else
            {
                if (commands.ContainsKey(arg))
                {
                    var attr = commands[arg].GetCustomAttribute(typeof(DebugCommandAttribute)) as DebugCommandAttribute;
                    var h = "- " + arg + Environment.NewLine;
                    h = h + Environment.NewLine + "  Description:" + Environment.NewLine + "        " + attr.GetHelp();
                    h = h + Environment.NewLine + "  Usage:" + Environment.NewLine + "        " + attr.GetUsage();
                    Console.WriteLine(h);
                }
                else
                {
                    var coms = commands.Keys.ToArray();
                    Console.WriteLine("- " + string.Join(Environment.NewLine + "- ", coms));
                }
            }
        }

        [DebugCommand("Stops the game.", "exit")]
        private void Exit(string[] args)
        {
            SiegeStorm.Instance.Exit();
        }

        [DebugCommand("Prints out the current game screen, or switches to the specified screen if it is passed as an argument and exists.", "screen MainMenu")]
        private void Screen(string[] args)
        {
            var arg = args[0];
            if (arg.Length != 0)
            {
                if (SiegeStorm.ScreenManager.GetScreenNames().Contains(arg))
                {
                    SiegeStorm.ScreenManager.ChangeScreenTo(arg);
                }
            }
            Console.WriteLine("Current screen: " + SiegeStorm.ScreenManager.GetCurrentScreenName());
        }

        [DebugCommand("Clears the debug console", "clear")]
        private void Clear(string[] args)
        {
            Console.Clear();
        }
    }
}