using Encryptor.Encryptions;
using Encryptor.Interfaces;

namespace Encryptor
{
  public class EncryptionComparer : IComparer<CharManipulationEncryption>
  {
    public int Compare(CharManipulationEncryption? x, CharManipulationEncryption? y)
    {
      return x.KeyStrength.CompareTo(y.KeyStrength);
    }
  }
}