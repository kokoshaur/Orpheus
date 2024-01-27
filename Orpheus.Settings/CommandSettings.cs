namespace Orpheus.Settings
{
    public static class CommandSettings
    {
        public struct CommandSetting
        {
            public string Command { get; init; }
            public bool Global { get; init; }
            public List<ulong> Guilds { get; init; }
        }

        public static CommandSetting ShowCommand {  get; set; }
    }
}
