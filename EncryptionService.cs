using Encryptor.Encryptions;
using Encryptor.Managers;

namespace Encryptor
{
    public class EncryptionService
    {
        private MultipleEncryption GetUserEncryptor()
        {
            var encryptionType = UserInputManager.GetEncryptionType();
            var repeatCount = UserInputManager.GetRepeatCount();
            return EncryptorFactory.Create(repeatCount, encryptionType);
        }

        public void Encrypt()
        {
            IOManager.Write("Enter file to encrypt path: ");
            var filePath = IOManager.ReadLine();

            if (!File.Exists(filePath))
            {
                IOManager.WriteLine("Can't find file");
                return;
            }

            var newFilePath = PathManager.GetEncryptedFilePath(filePath);
            var keyPath = PathManager.GetEncryptionKeyPath(filePath);

            FileEncryptor fileEncryptor = new(GetUserEncryptor());
            fileEncryptor.EncryptFile(filePath, newFilePath, keyPath);

            IOManager.WriteLine("Encrypted file!");
            IOManager.WriteLine($"Path for the new file is: {newFilePath}");
            IOManager.WriteLine($"Path for the key file is: {keyPath}");
        }

        public void Decrypt()
        {
            IOManager.Write("Enter file to decrypt path: ");
            var encryptedFilePath = IOManager.ReadLine();
            IOManager.Write("Enter file of encryption key path: ");
            var keyFilePath = IOManager.ReadLine();

            if (!File.Exists(encryptedFilePath))
            {
                IOManager.WriteLine("The file to decrypt was not found");
                return;
            }
            if (!File.Exists(keyFilePath))
            {
                IOManager.WriteLine("The key file was not found");
                return;
            }

            var decryptedFilePath = PathManager.GetDecryptionPath(encryptedFilePath);
            FileEncryptor decryptor = new(GetUserEncryptor());
            decryptor.DecryptFile(encryptedFilePath, decryptedFilePath, keyFilePath);

            IOManager.WriteLine($"Decrypted successfully! The file path is: {decryptedFilePath}");
        }
    }
}