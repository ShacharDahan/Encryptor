namespace Encryptor.Interfaces
{
  public record MultipleEncryptionResult(string Data, int[] Keys);
  
  public interface IMultipleEncryptionAlgorithm
  {
    public EncryptionResult Encrypt(string data);
    public string Decrypt(string data, int[] keys);
  }
}