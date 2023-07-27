using System.IO;
using System.Threading;

namespace ChessBotTokenCounter.Helper;

public class FileReader
{
    /// <summary>
    /// Tries multiple times to get the text out of a specific file.
    /// Returns an empty string on failure
    /// </summary>
    public static string ReadFile(string filePath)
    {
        string code = string.Empty;

        const int MAX_ATTEMPTS = 50;
        for(int attempt = 0; attempt < MAX_ATTEMPTS; attempt++)
        {
            try
            {
                using(StreamReader reader = new StreamReader(filePath))
                {
                    code = reader.ReadToEnd();
                }
                break;

            } catch
            {
                //The file wont open, that means its usually still being overwritten and cant be parsed.
                //Just wait and try again...
                Thread.Sleep(200);
            }
        }

        return code;
    }


}
