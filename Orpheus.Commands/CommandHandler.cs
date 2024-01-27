using Discord.WebSocket;
using Orpheus.Commands.Commands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orpheus.PlayListManager;

namespace Orpheus.Commands
{
    public class CommandHandler
    {
        IHost host;
        IServiceProvider? _serviceProvider;
        public CommandHandler(DiscordSocketClient client)
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                services
                    .AddSingleton(x => client)
                    .AddSingleton(x => client.GetGuild(Settings.SettingsHandler.MainSettings.GuildId))
                    .AddSingleton<FileHandler>()
                    .AddSingleton<JoinCommand>()
                    .AddSingleton<ShowCommand>()
                    .AddSingleton<PlayCommand>()
                    .AddSingleton<PlayListCommand>()
                    .AddSingleton<PlayListMixCommand>()
                ).Build();
        }

        public async void Reload()
        {
            var provider = GetProvider();

            provider.GetRequiredService<JoinCommand>().Init();
            //provider.GetRequiredService<ShowCommand>().Init();
            //provider.GetRequiredService<PlayCommand>().Init();
            //provider.GetRequiredService<PlayListCommand>().Init();
            //provider.GetRequiredService<PlayListMixCommand>().Init();

            await Logger.MainLogger.Log("Ручки перезапущены, для очередного перезапуска введите 'r'");
        }

        public async void DeleteAllCommands()
        {
            var client = GetProvider().GetRequiredService<DiscordSocketClient>();

            await client.Rest.DeleteAllGlobalCommandsAsync();
            await client.Rest.BulkOverwriteGuildCommands([], Settings.SettingsHandler.MainSettings.GuildId);

            await Logger.MainLogger.Log($"Все глобальные команды и команды Гильдии: {Settings.SettingsHandler.MainSettings.GuildId} удалены");
        }

        public async Task SlashCommandHandler(SocketSlashCommand command)
        {
            var provider = GetProvider();

            switch (command.Data.Name)
            {
                case "join":
                    await provider.GetRequiredService<JoinCommand>().Join(command);
                    break;
                case "show":
                    await provider.GetRequiredService<ShowCommand>().Show(command);
                    break;
                case "play":
                    await provider.GetRequiredService<PlayCommand>().Play(command);
                    break;
                case "play-list":
                    await provider.GetRequiredService<PlayListCommand>().PlayList(command);
                    break;
                case "play-list-mix":
                    await provider.GetRequiredService<PlayListMixCommand>().PlayListMix(command);
                    break;
            }
        }

        private IServiceProvider GetProvider()
        {
            if (_serviceProvider == null)
                _serviceProvider = host.Services.CreateScope().ServiceProvider;
            return _serviceProvider;
        }
    }
}
