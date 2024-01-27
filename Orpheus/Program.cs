namespace Orpheus
{
    internal class Program
    {
        static void Main(string[] args) => new Program().StartAsync().GetAwaiter().GetResult();

        private async Task StartAsync()
        {
            Settings.SettingsHandler.InitSettings("d");

            (await new Startup()
                .InitLogger()
                .InitCommands()
                .InitReady()
                .Launch())
                .CompleteAndListen();
        }
    }
}
