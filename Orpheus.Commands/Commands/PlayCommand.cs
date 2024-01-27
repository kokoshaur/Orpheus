using Discord;
using Discord.WebSocket;
using Orpheus.Audio;

namespace Orpheus.Commands.Commands
{
    internal class PlayCommand : BaseCommand
    {
        public PlayCommand(DiscordSocketClient client, SocketGuild? guild) : base(client, guild) { }

        public override void Init() => CatchError(null, DecorateCommand(new()));

        private SlashCommandBuilder DecorateCommand(SlashCommandBuilder command)
        {
            command
                .WithName("play") //^[\w-]{3,32}$
                .WithDescription("Пуск трека по названию")
                .AddOption("название", ApplicationCommandOptionType.String, "название трека", isRequired: true);

            return command;
        }

        public async Task Play(SocketSlashCommand command)
        {
            var channel = (command.User as IGuildUser)?.VoiceChannel;
            if (channel == null) 
            {
                await command.RespondAsync("1.mp3");
                return; 
            }

            _ = Task.Run(async () => 
            new AudioHandler()
            .PlayTrack(
                @"1.wav", 
                await channel.ConnectAsync(true, false, false)));

            await command.RespondAsync(@"1.wav");
        }
    }
}
