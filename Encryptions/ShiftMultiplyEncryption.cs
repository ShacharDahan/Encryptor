namespace Encryptor.Encryptions
{
  public class ShiftMultiplyEncryption : CharManipulationEncryption
  {
    protected override int ComputeMaxKeyForSource(int sourceMax) => sourceMax == 0 ? 1 : char.MaxValue / sourceMax;

    protected override char EncryptAction(char c, int key) => (char)(c * key);
    protected override char DecryptAction(char c, int key) => (char)(c / key);
  }
}
