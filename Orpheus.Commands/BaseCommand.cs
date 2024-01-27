using Discord;
using Discord.Net;
using Discord.WebSocket;
using Newtonsoft.Json;

namespace Orpheus.Commands
{
    internal abstract class BaseCommand
    {
        protected DiscordSocketClient client;
        protected SocketGuild? guild;

        protected BaseCommand(DiscordSocketClient client, SocketGuild? guild)
        {
            this.client = client;
            if (guild != null)
                this.guild = guild;
        }

        public abstract void Init();

        protected async void CatchError(SlashCommandBuilder? globalCommand, SlashCommandBuilder? guildCommand)
        {
            try
            {
                if (globalCommand != null)
                    await client.CreateGlobalApplicationCommandAsync(globalCommand.Build());
                if (guild != null && guildCommand != null)
                    await guild.CreateApplicationCommandAsync(guildCommand.Build());
            }
            catch (HttpException exception)
            {
                await Logger.MainLogger.Log(JsonConvert.SerializeObject(exception.Errors, Formatting.Indented));
            }
        }
    }
}
