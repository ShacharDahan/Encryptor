using Encryptor.Interfaces;

namespace Encryptor.Encryptions
{
  public class DoubleEncryption
  {
    public MultipleEncryptionResult Encrypt(string data)
    {
      return new MultipleEncryptionResult("", [1]);
    }

    public string Decrypt(string data, int[] keys)
    {
      return "";
    }
  }
}