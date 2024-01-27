namespace Orpheus.Settings
{
    public class MainSettings
    {
#pragma warning disable CS8618 // Поле, не допускающее значения NULL
        public string Token { get; init; }
        public ulong GuildId { get; init; }
        public string PathToPlayLists { get; init; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL
    }
}
