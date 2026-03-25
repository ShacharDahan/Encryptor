using Encryptor;
using Encryptor.Encryptions;
using Encryptor.Interfaces;

public static class EncryptorFactory
{
    private static readonly Dictionary<int, Func<IEncryptionAlgorithm, MultipleEncryption>> _encryptors = new()
    {
        { 1, encryptionAlgorithm => new SingleEncryption(encryptionAlgorithm) },
        { 2, encryptionAlgorithm => new DoubleEncryption(encryptionAlgorithm) },
    };

    public static MultipleEncryption Create(int repeatCount, EncryptionType encryptionAlgorithmType)
    {
        IEncryptionAlgorithm encryptionAlgorithm = encryptionAlgorithmType == EncryptionType.ShiftUp ? new ShiftUpEncryption() : new ShiftMultiplyEncryption();

        return repeatCount switch
        {
            (int)NumberOfTimesToEncrypt.NoEncryption => throw new Exception("Amount of encryptions cannot be 0!"),
            (int)NumberOfTimesToEncrypt.SingleEncryption => new SingleEncryption(encryptionAlgorithm),
            (int)NumberOfTimesToEncrypt.DoubleEncryption => new DoubleEncryption(encryptionAlgorithm),
            _ => new MultipleEncryption(encryptionAlgorithm, repeatCount),
        };
    }
}