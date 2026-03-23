namespace Encryptor.Encryptions
{
  public class ShiftMultiplyAlgorithm : CharManipulationAlgorithm
  {
    protected override int Maxkey => char.MaxValue / EncryptorConstants.AsciiMaxValue;

    protected override char EncryptAction(char c, int key) => (char)(c * key);
    protected override char DecryptAction(char c, int key) => (char)(c / key);
  }
}
