namespace Encryptor.Encryptions
{
  public class ShiftUpEncryption : CharManipulationAlgorithm
  {
    protected override int ComputeMaxKeyForSource(int sourceMax) => char.MaxValue - sourceMax;

    protected override char EncryptAction(char c, int key) => (char)(c + key);
    protected override char DecryptAction(char c, int key) => (char)(c - key);
  }
}
