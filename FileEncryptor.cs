namespace Encryptor
{
  public class FileEncryptor(IEncryptionAlgorithm encryptionAlgorithm)
  {
    private readonly IEncryptionAlgorithm _encryptionAlgorithm = encryptionAlgorithm;

    public void EncryptFile(string originalFilePath, string outputFilePath, string keyPath)
    {
      var fileContent = IOManager.ReadFile(originalFilePath);

      var (data, key) = _encryptionAlgorithm.Encrypt(fileContent);

      IOManager.WriteFile(outputFilePath, data);
      IOManager.WriteFile(keyPath, key.ToString());
    }

    public void DecryptFile(string encryptedFilePath, string outputFilePath, string keyPath)
    {
      var encryptedData = IOManager.ReadFile(encryptedFilePath);

      if (!int.TryParse(IOManager.ReadFile(keyPath), out int key))
      {
        throw new Exception("Key is invalid!");
      }

      var decryptedData = _encryptionAlgorithm.Decrypt(encryptedData, key);

      IOManager.WriteFile(outputFilePath, decryptedData);
    }
  }
}