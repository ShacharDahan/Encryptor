using Encryptor;
using Encryptor.Encryptions;
using Encryptor.Interfaces;

public static class EncryptorFactory
{

    public static IEncryptionAlgorithm Create(int repeatCount, EncryptionType encryptionAlgorithmType)
    {
        IEncryptionAlgorithm encryptionAlgorithm = encryptionAlgorithmType == EncryptionType.ShiftUp ? new ShiftUpEncryption() : new ShiftMultiplyEncryption();

        return repeatCount switch
        {
            (int)NumberOfTimesToEncrypt.NoEncryption => throw new Exception("Amount of encryptions cannot be 0!"),
            (int)NumberOfTimesToEncrypt.SingleEncryption => encryptionAlgorithm,
            (int)NumberOfTimesToEncrypt.DoubleEncryption => new DoubleEncryption(encryptionAlgorithm),
            _ => new MultipleEncryption(encryptionAlgorithm, repeatCount),
        };
    }
}