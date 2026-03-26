using Encryptor.Encryptions;
using Encryptor.Interfaces;
using Encryptor.Managers;

namespace Encryptor
{
    public class FileEncryptor(IEncryptionAlgorithm encryption)
    {
        private readonly IEncryptionAlgorithm _encryption = encryption;



        public void EncryptFile(string originalFilePath, string outputFilePath, string keyPath)
        {
            var fileContent = IOManager.ReadFile(originalFilePath);

            var (data, keys) = _encryption.Encrypt(fileContent);

            IOManager.WriteFile(outputFilePath, data);
            IOManager.WriteFile(keyPath, KeyManager.GetKeyString(keys));
        }

        public void DecryptFile(string encryptedFilePath, string outputFilePath, string keyPath)
        {
            var encryptedData = IOManager.ReadFile(encryptedFilePath);

            var keysRaw = IOManager.ReadFile(keyPath);

            try
            {
                int[] keys = keysRaw
          .Split(' ')
          .Select(s => int.TryParse(s, out int n)
              ? n
              : throw new FormatException("One or more of the keys are invalid!"))
          .ToArray();

                var decryptedData = _encryption.Decrypt(encryptedData, keys);

                IOManager.WriteFile(outputFilePath, decryptedData);
            }
            catch (Exception e)
            {
                IOManager.WriteLine(e.Message);
            }
        }
    }
}