using Encryptor.Interfaces;

namespace Encryptor.Encryptions
{
  public class DoubleEncryption(IEncryptionAlgorithm encryptionAlgorithm) : MultipleEncryption(encryptionAlgorithm, 2) { }
}