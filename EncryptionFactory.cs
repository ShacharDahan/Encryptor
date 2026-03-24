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

        if (repeatCount >= 3)
            return new MultipleEncryption(encryptionAlgorithm, repeatCount);

        return _encryptors[repeatCount](encryptionAlgorithm);
    }
}