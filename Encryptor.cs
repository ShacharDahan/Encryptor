namespace Encryptor
{
  public sealed class Encryptor
  {
    private const int Maxkey = 65409;

    private Encryptor() { }

    private static Encryptor _instance;

    public static Encryptor GetInstance()
    {
      _instance ??= new Encryptor();

      return _instance;
    }

    public string[] Encrypt(string filepath)
    {
      var key = new Random().Next(1, Maxkey);

      IOManager iom = IOManager.GetInstance();

      var fileContent = iom.ReadFile(filepath);

      var encryptedData = new string([.. fileContent.Select(c => (char)(c + key))]);

      var encryptedFilePath = Path.Combine(
        Path.GetDirectoryName(filepath),
        Path.GetFileNameWithoutExtension(filepath) + "_encrypted" + Path.GetExtension(filepath)
      );

      var keyFilePath = Path.Combine(Path.GetDirectoryName(filepath), "key.txt");

      iom.WriteFile(encryptedFilePath, encryptedData);
      iom.WriteFile(keyFilePath, key.ToString());

      return [encryptedFilePath, keyFilePath];
    }
  }
}
