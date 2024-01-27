using Discord.WebSocket;
using Discord;
using Orpheus.Audio;
using Orpheus.PlayListManager;

namespace Orpheus.Commands.Commands
{
    internal class JoinCommand : BaseCommand
    {
        private FileHandler _fileHandler;
        public JoinCommand(DiscordSocketClient client, SocketGuild? guild, FileHandler fileHandler) : base(client, guild) => _fileHandler = fileHandler;

        public override void Init() => CatchError(null, DecorateCommand(new()));

        private SlashCommandBuilder DecorateCommand(SlashCommandBuilder command)
        {
            command
                .WithName("join") //^[\w-]{3,32}$
                .WithDescription("Старт");

            return command;
        }

        public async Task Join(SocketSlashCommand command)
        {
            if (_fileHandler != null) { }
            var channel = (command.User as IGuildUser)?.VoiceChannel;
            if (channel == null)
            {
                await command.RespondAsync("Ты не в канале, бро");
                return;
            }

            _ = Task.Run(async () =>
            new AudioHandler()
            .PlayTrack(
                @"1.wav",
                await channel.ConnectAsync(true, false, false)));

            await command.RespondAsync("1.mp3");
        }
    }
}
