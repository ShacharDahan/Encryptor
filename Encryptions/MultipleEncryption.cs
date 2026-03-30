using System;
using Encryptor.Interfaces;

namespace Encryptor.Encryptions
{
    public class MultipleEncryption(IEncryptionAlgorithm encryptionAlgorithm, int numberOfTimesToEncrypt) : IEncryptionAlgorithm
    {
        private readonly IEncryptionAlgorithm _encryptionAlgorithm = encryptionAlgorithm;
        private readonly int _numberOfTimesToEncrypt = numberOfTimesToEncrypt;

        public EncryptionResult Encrypt(string data)
        {
            var encryptedData = data;
            int[] keys = new int[_numberOfTimesToEncrypt];
            int[] tempKeysArr;

            for (int i = 0; i < _numberOfTimesToEncrypt; i++)
            {
                (encryptedData, tempKeysArr) = _encryptionAlgorithm.Encrypt(encryptedData);
                keys[i] = tempKeysArr[0];
            }

            Console.WriteLine($"keys: {string.Join(", ", keys)}");

            return new EncryptionResult(encryptedData, keys);
        }

        public string Decrypt(string encryptedData, int[] keys)
        {
            var decryptedData = encryptedData;

            for (int i = _numberOfTimesToEncrypt; i > 0; i--)
            {
                decryptedData = _encryptionAlgorithm.Decrypt(decryptedData, [keys[i - 1]]);
            }

            return decryptedData;
        }
    }
}