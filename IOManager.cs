using System.IO;

namespace Encryptor
{

  public sealed class IOManager
  {
    private IOManager() { }

    private static IOManager _instance;

    public static IOManager GetInstance()
    {
      _instance ??= new IOManager();

      return _instance;
    }

    public void WriteLine(string output)
    {
      Console.WriteLine(output);
    }

    public string ReadLine()
    {
      var input = Console.ReadLine();

      return input ?? throw new Exception("Empty input received");
    }

    public string ReadFile(string filepath)
    {
      var file = File.ReadAllText(filepath).Trim();

      return file;
    }

    public void WriteFile(string filepath, string data)
    {
      using var file = File.Open(filepath, FileMode.Create);
      using StreamWriter streamWriter = new(file);

      streamWriter.Write(data);
    }
  }
}
