using Encryptor.Encryptions;
using Encryptor.Interfaces;
using Encryptor.Managers;

namespace Encryptor
{
  public class EncryptionService
  {
    private IEncryptionAlgorithm GetUserEncryptor()
    {
      var encryptionType = UserInputManager.GetEncryptionType();
      var repeatCount = UserInputManager.GetRepeatCount();
      return EncryptorFactory.Create(repeatCount, encryptionType);
    }

    public void Encrypt()
    {
      IOManager.Write("Enter file to encrypt path: ");
      var filePath = IOManager.ReadLine();


      try
      {
        if (!File.Exists(filePath))
        {
          throw new Exception("Can't find file");

        }

        var newFilePath = PathManager.GetEncryptedFilePath(filePath);
        var keyPath = PathManager.GetEncryptionKeyPath(filePath);

        FileEncryptor fileEncryptor = new(GetUserEncryptor());
        fileEncryptor.EncryptFile(filePath, newFilePath, keyPath);

        IOManager.WriteLine("Encrypted file!");
        IOManager.WriteLine($"Path for the new file is: {newFilePath}");
        IOManager.WriteLine($"Path for the key file is: {keyPath}");
      }
      catch (Exception e)
      {
        IOManager.WriteLine(e.Message);
      }
    }

    public void Decrypt()
    {
      IOManager.Write("Enter file to decrypt path: ");
      var encryptedFilePath = IOManager.ReadLine();
      IOManager.Write("Enter file of encryption key path: ");
      var keyFilePath = IOManager.ReadLine();

      try
      {

        if (!File.Exists(encryptedFilePath))
        {
          throw new Exception("The file to decrypt was not found");
        }
        if (!File.Exists(keyFilePath))
        {
          throw new Exception("The key file was not found");
        }

        var decryptedFilePath = PathManager.GetDecryptionPath(encryptedFilePath);
        FileEncryptor decryptor = new(GetUserEncryptor());
        decryptor.DecryptFile(encryptedFilePath, decryptedFilePath, keyFilePath);

        IOManager.WriteLine($"Decrypted successfully! The file path is: {decryptedFilePath}");
      }
      catch (Exception e)
      {
        IOManager.WriteLine(e.Message);
      }
    }
  }
}