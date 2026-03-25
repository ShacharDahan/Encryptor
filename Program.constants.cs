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

    public enum NumberOfTimesToEncrypt
    {
        NoEncryption = 0,
        SingleEncryption = 1,
        DoubleEncryption = 2,
    }

    public static class EncryptorConstants
    {
        public const int AsciiMaxValue = 127;
    }
}