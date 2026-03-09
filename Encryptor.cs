namespace Encryptor
{
  public class Encryptor
  {
    private const int Maxkey = 65409;

    public Encryptor() { }

    public string[] Encrypt(string filepath)
    {
      var key = new Random().Next(1, Maxkey);

      var fileContent = IOManager.ReadFile(filepath);

      var encryptedData = new string([.. fileContent.Select(c => (char)(c + key))]);

      var encryptedFilePath = Path.Combine(
        Path.GetDirectoryName(filepath),
        Path.GetFileNameWithoutExtension(filepath) + "_encrypted" + Path.GetExtension(filepath)
      );

      var keyFilePath = Path.Combine(Path.GetDirectoryName(filepath), "key.txt");

      IOManager.WriteFile(encryptedFilePath, encryptedData);
      IOManager.WriteFile(keyFilePath, key.ToString());

      return [encryptedFilePath, keyFilePath];
    }
  }
}
