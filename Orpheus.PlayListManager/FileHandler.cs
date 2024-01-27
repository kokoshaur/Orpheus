namespace Orpheus.PlayListManager
{
    public class FileHandler
    {
        private LevelDirectoryList _levelDirectoryList = new();

        public FileHandler()
        {
            if (ReloadButtons(Settings.SettingsHandler.MainSettings.PathToPlayLists))
                Logger.MainLogger.Log("Кнопки успешно перестроены в соответствие с файлами на диске");
        }

        public bool ReloadButtons(string path)
        {
            DirectoryInfo directoryInfo = new(path);
            if (!directoryInfo.Exists)
            {
                Logger.MainLogger.Log($"Папка {path} не существует");
                return false;
            }

            _levelDirectoryList = new();
            IncludeDirectory(directoryInfo, _levelDirectoryList);
            _levelDirectoryList.Build();

            return true;
        }

        private void IncludeDirectory(DirectoryInfo directoryInfo, LevelDirectoryList levelDirectoryList)
        {
            levelDirectoryList.AddFiles(directoryInfo.GetFiles());
            var dirs = directoryInfo.GetDirectories();
        }
    }
}
