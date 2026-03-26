namespace Encryptor.Encryptions
{
  public class ShiftMultiplyEncryption : CharManipulationEncryption
  {
    private readonly EncryptionComparer comparer = new();

    protected override int ComputeMaxKeyForSource(int sourceMax) => sourceMax == 0 ? 1 : char.MaxValue / sourceMax;

    public override bool Equals(object? obj)
    {
      if (obj is not ShiftMultiplyEncryption objParsed)
      {
        return false;
      }
      return comparer.Compare(this, objParsed) == EncryptorConstants.ObjectsEqual;
    }

    public override int GetHashCode()
    {
      return KeyStrength;
    }

    protected override char EncryptAction(char c, int key) => (char)(c * key);
    protected override char DecryptAction(char c, int key) => (char)(c / key);
  }
}
