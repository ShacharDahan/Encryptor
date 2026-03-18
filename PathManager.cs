namespace Encryptor
{
  public record GetEncryptionPathsResult(string EncryptedFilePath, string KeyPath);

  public static class PathManager
  {
    public static GetEncryptionPathsResult GetEncryptionPaths(string originalFilePath)
    {
      var encryptedFilePath = Path.Combine(
        Path.GetDirectoryName(originalFilePath),
        Path.GetFileNameWithoutExtension(originalFilePath) + "_encrypted" + Path.GetExtension(originalFilePath)
      );

      var keyPath = Path.Combine(Path.GetDirectoryName(originalFilePath), "key.txt");

      return new GetEncryptionPathsResult(encryptedFilePath, keyPath);
    }

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