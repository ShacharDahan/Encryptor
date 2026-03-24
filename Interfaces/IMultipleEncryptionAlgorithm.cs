namespace Encryptor.Interfaces
{
  public record MultipleEncryptionResult(string Data, int[] Keys);
  
  public interface IMultipleEncryptionAlgorithm
  {
    public MultipleEncryptionResult Encrypt(string data);
    public string Decrypt(string data, int[] keys);
  }
}