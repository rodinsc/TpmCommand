using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpmCommand
{
    public class Config : IRocketPluginConfiguration
    {
        public string RemoveMarkerAfterTeleport;
        public void LoadDefaults()
        {
            RemoveMarkerAfterTeleport = "yes";
        }
    }
}
