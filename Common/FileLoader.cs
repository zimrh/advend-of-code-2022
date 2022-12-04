namespace Common
{
    public class FileLoader
    {
        public async static IAsyncEnumerable<string> GetLinesAsync(string path)
        {
            await using var file = File.OpenRead(path);
            using var reader = new StreamReader(file);
            do
            {
                yield return await reader.ReadLineAsync() ?? string.Empty;
            } while (!reader.EndOfStream);
        }
    }
}