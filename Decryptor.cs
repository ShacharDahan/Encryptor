namespace Encryptor
{
  public class Decryptor
  {
    public Decryptor() { }

    public string Decrypt(string filepath, string keypath)
    {

      var encryptedData = IOManager.ReadFile(filepath);

      try
      {
        if (!int.TryParse(IOManager.ReadFile(keypath), out int key))
        {
          throw new Exception("Key is invalid!");
        }

        var decryptedData = new string([.. encryptedData.Select(c => (char)(c - key))]);

        var decryptedFilepath = Path.Combine(
          Path.GetDirectoryName(filepath),
          Path.GetFileName(filepath).Replace("encrypted", "decrypted")
        );

        IOManager.WriteFile(decryptedFilepath, decryptedData);

        return decryptedFilepath;
      }
      catch (Exception e)
      {
        IOManager.WriteLine(e.Message);
        Environment.Exit(1);
        return default;
      }
    }
  }
}