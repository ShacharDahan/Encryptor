using Encryptor.Interfaces;

namespace Encryptor
{
  public abstract class CharManipulationAlgorithm : IEncryptionAlgorithm
  {
    protected abstract int Maxkey { get; }
    protected abstract char EncryptAction(char c, int key);
    protected abstract char DecryptAction(char c, int key);
    public EncryptionResult Encrypt(string data)
    {
      var key = new Random().Next(1, Maxkey);

      var encryptedData = new string([.. data.Select(c => EncryptAction(c, key))]);

      return new EncryptionResult(encryptedData, key);
    }

    public string Decrypt(string encryptedData, int key)
    {
      var decryptedData = new string([.. encryptedData.Select(c => DecryptAction(c, key))]);

      return decryptedData;
    }
  }
}