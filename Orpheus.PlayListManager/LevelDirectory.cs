namespace Orpheus.PlayListManager
{
    internal class LevelDirectory
    {
        public LevelDirectory Parent { get; private init; }
        public Dictionary<string, LevelDirectory> Children { get; private init; } = new();
        List<string> _files = new();

        public LevelDirectory(LevelDirectory? parent = null)
        {
            if (parent == null)
                Parent = this;
            else
                Parent = parent;
        }

        public FileInfo[] AddFiles(FileInfo[] files)
        {
            return files;
        }

        public DirectoryInfo[] AddDirectories(DirectoryInfo[] directories)
        {
            return directories;
        }

        public void Build()
        {

        }
    }
}
