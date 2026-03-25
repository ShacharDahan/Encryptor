namespace Encryptor.Interfaces
{
  public record EncryptionResult(string Data, int Key);
  
  public interface IEncryptionAlgorithm
  {
    public EncryptionResult Encrypt(string data);
    public string Decrypt(string data, int key);
  }
}