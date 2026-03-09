namespace Encryptor
{
  sealed class Decryptor
  {
    private Decryptor() { }

    private static Decryptor _instance;

    public static Decryptor GetInstance()
    {
      _instance ??= new Decryptor();

      return _instance;
    }

    public string Decrypt(string filepath, string keypath)
    {
      var iom = IOManager.GetInstance();

      var encryptedData = iom.ReadFile(filepath);
      var key = int.Parse(iom.ReadFile(keypath));

      var decryptedData = new string([.. encryptedData.Select(c => (char)(c - key))]);

      var decryptedFilepath = Path.Combine(
        Path.GetDirectoryName(filepath),
        Path.GetFileName(filepath).Replace("encrypted", "decrypted")
      );

      iom.WriteFile(decryptedFilepath, decryptedData);

      return decryptedFilepath;
    }
  }
}