namespace ChessBotTokenCounter.Settings;

public static class SettingsHandler
{
    public static void SetFilePath(string path)
    {
        Settings.Default.MyBotFilepath = path;
        Settings.Default.Save();
    }

    public static string GetFilePath()
    {
        return Settings.Default.MyBotFilepath;
    }
}
