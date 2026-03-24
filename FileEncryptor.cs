using Encryptor.Encryptions;
using Encryptor.Interfaces;

namespace Encryptor
{
  public class FileEncryptor(MultipleEncryption multipleEncryption)
  {
    private readonly IMultipleEncryptionAlgorithm _multipleEncryption = multipleEncryption;

    private string GetKeyString(int[] keys)
    {
      var key = $"{keys[0]}";
      
      for (int i = 1; i < keys.Length; i++)
      {
        key += $" {keys[0]}";
      }

      return key;
    }

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