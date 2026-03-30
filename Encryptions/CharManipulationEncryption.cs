using System;
using System.Linq;
using Encryptor.Interfaces;
using Encryptor.Managers;

namespace Encryptor.Encryptions
{
    public abstract class CharManipulationEncryption : IEncryptionAlgorithm
    {
        public int KeyStrength { get; }
        protected abstract int ComputeMaxKeyForSource(int sourceMax);
        protected abstract char EncryptAction(char c, int key);
        protected abstract char DecryptAction(char c, int key);

        protected CharManipulationEncryption()
        {
            this.KeyStrength = ComputeMaxKeyForSource(EncryptorConstants.AsciiMaxValue).ToString().Length;
        }


        public EncryptionResult Encrypt(string data)
        {
            var sourceMax = data.Max(c => (int)c);

            var key = KeyManager.GenerateKey(sourceMax);

            var encryptedData = new string([.. data.Select(c => EncryptAction(c, key))]);

            return new EncryptionResult(encryptedData, [key]);
        }

        public string Decrypt(string encryptedData, int[] keys)
        {
            var decryptedData = new string([.. encryptedData.Select(c => DecryptAction(c, keys[0]))]);

            return decryptedData;
        }
    }
}