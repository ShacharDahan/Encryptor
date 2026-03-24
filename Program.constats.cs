namespace Encryptor
{
    public enum UserOptions
    {
        Exit,
        Encrypt,
        Decrypt,
    }

    public enum EncryptionType
    {
        ShiftUp,
        ShiftMultiply,
    }

    public static class EncryptorConstants
    {
        public const int AsciiMaxValue = 127;
    }
}