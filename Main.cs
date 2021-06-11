using Rocket.Core;
using Rocket.Core.Plugins;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;
using Rocket.API.Collections;
using SDG.Unturned;

namespace TpmCommand
{
    public class Main : RocketPlugin<Config>
    {
        protected override void Load()
        {
            Console.WriteLine("TpmCommand loaded!");
            var command = new Command(
                allowedCaller: AllowedCaller.Player,
                name: "tpm",
                help: "Teleports you to where you marked on your map.",
                syntax: "/tpm",
                aliases: new List<string>(),
                permissions: new List<string> { "tpm" },
                action: new Action<UnturnedPlayer, string[]>((player, args) => {
                    if (player.Player.quests.isMarkerPlaced)
                    {
                        var konum = player.Player.quests.markerPosition;
                        player.Player.teleportToLocationUnsafe(new Vector3(konum.x, LevelGround.getHeight(konum), konum.z), player.Rotation);
                        UnturnedChat.Say(player, DefaultTranslations.Translate("teleported"), Color.green);

                        bool RemoveMarker = Configuration.Instance.RemoveMarkerAfterTeleport == "yes" ? true : false;

                        if (RemoveMarker)
                        {
                            player.Player.quests.replicateSetMarker(false, konum);
                        }
                    }
                    else
                    {
                        UnturnedChat.Say(player, DefaultTranslations.Translate("marker_not_found"), Color.red);
                    }
                })
                );
            R.Commands.Register(command);
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "teleported", "Successfully teleported to your marker location." },
            { "marker_not_found", "Please set a marker!" }
        };

        protected override void Unload()
        {
            Console.WriteLine("TpmCommand unloaded!");
        }
    }
}
