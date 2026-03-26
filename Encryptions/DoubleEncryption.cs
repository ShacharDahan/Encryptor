using Encryptor.Interfaces;

namespace Encryptor.Encryptions
{
  public class DoubleEncryption<TAlgorithm> : IEncryptionAlgorithm where TAlgorithm : IEncryptionAlgorithm
  {
    public required TAlgorithm Algorithm { get; set; }
    public EncryptionResult Encrypt(string data)
    {
      int[] keys = new int[2];
      var (encryptedData, tempKeyArr) = Algorithm.Encrypt(data);
      keys[0] = tempKeyArr[0];
      (encryptedData, tempKeyArr) = Algorithm.Encrypt(encryptedData);
      keys[1] = tempKeyArr[0];

      return new EncryptionResult(encryptedData, keys);
    }
    public string Decrypt(string data, int[] keys)
    {
      var decryptedData = Algorithm.Decrypt(data, [keys[1]]);
      decryptedData = Algorithm.Decrypt(decryptedData, [keys[0]]);

      return decryptedData;
    }

  }
}