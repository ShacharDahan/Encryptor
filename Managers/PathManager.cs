namespace Encryptor.Managers
{

  public static class PathManager
  {
    public static string GetEncryptedFilePath(string originalFilePath) =>
      Path.Combine(
        Path.GetDirectoryName(originalFilePath),
        Path.GetFileNameWithoutExtension(originalFilePath) + "_encrypted" + Path.GetExtension(originalFilePath)
      );


    public static string GetEncryptionKeyPath(string originalFilePath) =>
      Path.Combine(Path.GetDirectoryName(originalFilePath), "key.txt");

    public static string GetDecryptionPath(string encryptedFilePath)
    {
      var decryptedFilePath = Path.Combine(
        Path.GetDirectoryName(encryptedFilePath),
        Path.GetFileName(encryptedFilePath).Replace("encrypted", "decrypted")
      );

      return decryptedFilePath;
    }
  }
}