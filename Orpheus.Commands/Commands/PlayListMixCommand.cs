using Discord;
using Discord.WebSocket;

namespace Orpheus.Commands.Commands
{
    internal class PlayListMixCommand : BaseCommand
    {
        public PlayListMixCommand(DiscordSocketClient client, SocketGuild? guild) : base(client, guild) { }

        public override void Init() => CatchError(null, DecorateCommand(new()));

        private SlashCommandBuilder DecorateCommand(SlashCommandBuilder command)
        {
            command
                .WithName("play-list-mix") //^[\w-]{3,32}$
                .WithDescription("Пуск плейлиста в псевдослучайном порядке")
                .AddOption("название", ApplicationCommandOptionType.String, "название плейлиста", isRequired: true);

            return command;
        }

        public async Task PlayListMix(SocketSlashCommand command)
        {
            await command.RespondAsync($"{command.Data.Name} + {command.Data.Options.First().Value}");
        }
    }
}
