using System;
using Encryptor.Interfaces;

namespace Encryptor.Encryptions
{
    public record MultipleEncryptionResult(string Data, int[] Keys);

    public class MultipleEncryption(IEncryptionAlgorithm encryptionAlgorithm, int numberOfTimesToEncrypt)
    {
        private readonly IEncryptionAlgorithm _encryptionAlgorithm = encryptionAlgorithm;
        private readonly int _numberOfTimesToEncrypt = numberOfTimesToEncrypt;

        public MultipleEncryptionResult Encrypt(string data)
        {
            var encryptedData = data;
            int[] keys = new int[_numberOfTimesToEncrypt];

            for (int i = 0; i < _numberOfTimesToEncrypt; i++)
            {
                (encryptedData, keys[i]) = _encryptionAlgorithm.Encrypt(encryptedData);
            }

            Console.WriteLine($"keys: {string.Join(", ", keys)}");

            return new MultipleEncryptionResult(encryptedData, keys);
        }

        public string Decrypt(string encryptedData, int[] keys)
        {
            var decryptedData = encryptedData;

            for (int i = _numberOfTimesToEncrypt; i > 0; i--)
            {
                decryptedData = _encryptionAlgorithm.Decrypt(decryptedData, keys[i - 1]);
            }

            return decryptedData;
        }
    }

    public class SingleEncryption(IEncryptionAlgorithm encryptionAlgorithm) : MultipleEncryption(encryptionAlgorithm, 1) { }

    public class DoubleEncryption(IEncryptionAlgorithm encryptionAlgorithm) : MultipleEncryption(encryptionAlgorithm, 2) { }
}