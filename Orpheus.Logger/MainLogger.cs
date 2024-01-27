using Discord;

namespace Orpheus.Logger
{
    public static class MainLogger
    {
        public static Task LogsHandler(LogMessage message) => Log(message.ToString());

        public static Task Log(string message)
        {
            Console.WriteLine(message);
            return Task.CompletedTask;
        }
    }
}
