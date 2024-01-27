using Discord;
using Discord.WebSocket;
using Orpheus.Commands;

namespace Orpheus
{
    internal class Startup
    {
        public DiscordSocketClient _client { get; }
        private CommandHandler? _commandHandler;

        public Startup() => _client = new ();
        public Startup(DiscordSocketClient client) => _client = client;

        public Startup InitLogger()
        {
            _client.Log += Logger.MainLogger.LogsHandler;
            return this;
        }

        public Startup InitCommands()
        {
            _commandHandler = new(_client);
            _client.SlashCommandExecuted += _commandHandler.SlashCommandHandler;
            return this;
        }

        public Startup InitReady()
        {
            _client.Ready += async () => await Logger.MainLogger.Log("\n\n" + "===Бот запущен. Для перезагрузки ручек введите 'r'===");
            return this;
        }

        public async Task<Startup> Launch()
        {
            await _client.LoginAsync(TokenType.Bot, Settings.SettingsHandler.MainSettings.Token);
            await _client.StartAsync();
            return this;
        }

        public void CompleteAndListen()
        {
            if (_commandHandler == null)
            {
                Logger.MainLogger.Log($"{nameof(Startup)} запущен, но команда InitCommands не выполнилась");
                return;
            }

            while (true)
                switch (Console.ReadLine())
                {
                    case "r":
                        _commandHandler.Reload();
                        break;
                    case "d":
                        _commandHandler.DeleteAllCommands();
                        break;
                }
        }
    }
}
