namespace Encryptor.Interfaces
{
  public record EncryptionResult(string Data, int Keys);
  
  public interface IEncryptionAlgorithm
  {
    public EncryptionResult Encrypt(string data);
    public string Decrypt(string data, int key);
  }
}