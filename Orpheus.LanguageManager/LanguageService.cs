namespace Orpheus.LanguageManager
{
    public class LanguageService
    {
        public CULTURE Culture { get; set; }
        public LanguageService(CULTURE culture) => Culture = culture;

        public string this[string path]
        {
            get
            {
                return "d";
            }
        }

        public enum CULTURE
        {
            Russia,
            English,
        }
    }
}
