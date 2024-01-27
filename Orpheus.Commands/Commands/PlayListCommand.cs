using Discord;
using Discord.WebSocket;

namespace Orpheus.Commands.Commands
{
    internal class PlayListCommand : BaseCommand
    {
        public PlayListCommand(DiscordSocketClient client, SocketGuild? guild) : base(client, guild) { }

        public override void Init() => CatchError(null, DecorateCommand(new()));

        private SlashCommandBuilder DecorateCommand(SlashCommandBuilder command)
        {
            command
                .WithName("play-list") //^[\w-]{3,32}$
                .WithDescription("Пуск плейлиста последовательно")
                .AddOption("название", ApplicationCommandOptionType.String, "название плейлиста", isRequired: true);

            return command;
        }

        public async Task PlayList(SocketSlashCommand command)
        {
            await command.RespondAsync($"{command.Data.Name} + {command.Data.Options.First().Value}");
        }
    }
}
