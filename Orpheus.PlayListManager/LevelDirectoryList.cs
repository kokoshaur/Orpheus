namespace Orpheus.PlayListManager
{
    internal class LevelDirectoryList
    {
        private LevelDirectory _head;
        private LevelDirectory _ptr;
        public int Length { get; private set; } = 0;

        public LevelDirectoryList()
        {
            _head = new LevelDirectory();
            _ptr = _head;
        }

        public FileInfo[] AddFiles(FileInfo[] files) => _ptr.AddFiles(files);

        public DirectoryInfo[] AddDirectories(DirectoryInfo[] directories) => _ptr.AddDirectories(directories);

        public LevelDirectoryList ToStepUp()
        {
            _ptr = _ptr.Parent;
            return this;
        }

        public LevelDirectoryList ToStepDown(string name)
        {
            if (_ptr.Children.ContainsKey(name))
                _ptr = _ptr.Children[name];
            else
                throw new Exception($"Имя подпапки {name} не найдено");

            return this;
        }

        public void Build()
        {

        }
    }
}
