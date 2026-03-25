using Encryptor.Encryptions;
using Encryptor.Interfaces;

namespace Encryptor
{
    public class FileEncryptor(IEncryptionAlgorithm encryption)
    {
        private readonly IEncryptionAlgorithm _encryption = encryption;

        private static string GetKeyString(int[] keys)
        {
            var key = $"{keys[0]}";

            for (int i = 1; i < keys.Length; i++)
            {
                key += $" {keys[i]}";
            }

            return key;
        }

        public void EncryptFile(string originalFilePath, string outputFilePath, string keyPath)
        {
            var fileContent = IOManager.ReadFile(originalFilePath);

            var (data, keys) = _encryption.Encrypt(fileContent);

            IOManager.WriteFile(outputFilePath, data);
            IOManager.WriteFile(keyPath, GetKeyString(keys));
        }

        public void DecryptFile(string encryptedFilePath, string outputFilePath, string keyPath)
        {
            var encryptedData = IOManager.ReadFile(encryptedFilePath);

            var keysRaw = IOManager.ReadFile(keyPath);

            int[] keys = keysRaw
          .Split(' ')
          .Select(s => int.TryParse(s, out int n)
              ? n
              : throw new FormatException("One or more of the keys are invalid!"))
          .ToArray();

            var decryptedData = _encryption.Decrypt(encryptedData, keys);

            IOManager.WriteFile(outputFilePath, decryptedData);
        }
    }
}