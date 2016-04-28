namespace AspNetCoreExample.Core
{
    public interface ICoreLibraryService
    {
        string CreateMessage();
    }

    public class CoreLibraryService : ICoreLibraryService
    {
        public string CreateMessage()
        {
            return "Core library message";
        }
    }
}
