using Rocket.API;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpmCommand
{
    public class Command : IRocketCommand
    {
        public Command(AllowedCaller allowedCaller, string name, string help, string syntax, List<string> aliases, List<string> permissions, Action<UnturnedPlayer, string[]> action)
        {
            AllowedCaller = allowedCaller;
            Name = name;
            Help = help;
            Syntax = syntax;
            Aliases = aliases;
            Permissions = permissions;
            Action = action;
        }

        public AllowedCaller AllowedCaller { get; private set; }

        public string Name { get; private set; }

        public string Help { get; private set; }

        public string Syntax { get; private set; }

        public List<string> Aliases { get; private set; }

        public List<string> Permissions { get; private set; }

        public Action<UnturnedPlayer, string[]> Action { get; private set; }

        public void Execute(IRocketPlayer caller, string[] command) => Action((UnturnedPlayer)caller, command);
    }
}
