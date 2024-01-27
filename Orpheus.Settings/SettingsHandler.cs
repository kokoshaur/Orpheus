using System.Text.Json;
using static Orpheus.Settings.CommandSettings;

namespace Orpheus.Settings
{
    public static class SettingsHandler
    {
#pragma warning disable CS8618 // Поле, не допускающее значения NULL
        public static MainSettings MainSettings { get; private set; }
#pragma warning restore CS8618 // Поле, не допускающее значения NULL
        public static void InitSettings(string path)
        {
#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.

            MainSettings = JsonSerializer.Deserialize<MainSettings>(File.ReadAllText("main_settings.json"));


#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
            ShowCommand = new CommandSetting
            {
                Command = "show",
                Global = false,
                Guilds = new List<ulong> { MainSettings.GuildId, }
            };
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
        }
    }
}
