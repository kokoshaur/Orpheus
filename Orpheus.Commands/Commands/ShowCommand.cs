using Discord;
using Discord.WebSocket;

namespace Orpheus.Commands.Commands
{
    internal class ShowCommand : BaseCommand
    {
        public ShowCommand(DiscordSocketClient client, SocketGuild? guild) : base(client, guild) { }

        public override void Init() => CatchError(null, DecorateCommand(new()));

        private SlashCommandBuilder DecorateCommand(SlashCommandBuilder command)
        {
            command
                .WithName("show") //^[\w-]{3,32}$
                .WithDescription("Вывод всех непустых плейлистов");

            return command;
        }

        public async Task Show(SocketSlashCommand command)
        {
            await command.RespondAsync($"{command.Data.Name} + {command.Data.Options.First().Value}");
        }
    }
}
