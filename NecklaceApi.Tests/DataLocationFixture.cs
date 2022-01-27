using Org.BouncyCastle.Security;
using System;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

public class DataLocationFixture
{
    private string dataPath;
	public DataLocationFixture()
    {
        dataPath = Path.Combine(Path.GetTempPath(), "necklace-data-path");
        if(Directory.Exists(dataPath))
        {
            Directory.Delete(dataPath, true);
        }

        if (!Directory.Exists(dataPath))
        {
            Directory.CreateDirectory(dataPath);
        }
    }

    public void Dispose()
    {
    }

    private static string RandomString(int length)
    {
        Random random = new SecureRandom();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public Tuple<string, string> WriteChangelogAndRandomBinaryData(string appname, string version, string changelog_content, int binaryDataLength = 200, string ext = "exe")
    {
        string binaryData = RandomString(binaryDataLength);
        string changeLogPath = Path.Combine(dataPath, $"{version}.md");
        string dataBinaryPath = Path.Combine(dataPath, $"{appname} {version}.{ext}");
        File.WriteAllText(changeLogPath, changelog_content);
        File.WriteAllBytes(dataBinaryPath, Encoding.UTF8.GetBytes(binaryData));
        return new Tuple<string, string>(dataBinaryPath, changeLogPath);
    }

    public Tuple<string, string> WriteRandomChangelogAndRandomBinaryData(string appname, string version, int binaryDataLength = 200, string ext = "exe")
    {
        return WriteChangelogAndRandomBinaryData(appname, version, RandomString(binaryDataLength), binaryDataLength, ext);
    }

    [CollectionDefinition("DataFile")]
    public class SignatureManagerCollection : ICollectionFixture<DataLocationFixture>
    {

    }
}
