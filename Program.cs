namespace Encryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            var userChoice = IOManager.GetUserSelection();

            switch (userChoice)
            {
                case UserOptions.Encrypt:
                    IOManager.Write("Enter file to encrypt path: ");
                    var filePath = Console.ReadLine();

                    var isFileExist = File.Exists(filePath);

                    if (isFileExist)
                    {
                        var (newFilePath, keyPath) = PathManager.GetEncryptionPaths(filePath);

                        FileEncryptor encryptor = new(new ShiftMultiplyAlgorithm());

                        encryptor.EncryptFile(filePath, newFilePath, keyPath);

                        IOManager.WriteLine($"Encrypted file!");
                        IOManager.WriteLine($"path for the new file is: {newFilePath}");
                        IOManager.WriteLine($"path for the key file is: {keyPath}");
                    }
                    else
                    {
                        IOManager.WriteLine("Can't find file");
                    }
                    break;
                case UserOptions.Decrypt:
                    IOManager.Write("Enter file to decrypt path: ");
                    var encryptedFilePath = IOManager.ReadLine();
                    IOManager.Write("Enter file of encryption key path: ");
                    var keyFilePath = IOManager.ReadLine();

                    var isEncryptedFileExist = File.Exists(encryptedFilePath);
                    var isKeyExist = File.Exists(keyFilePath);

                    if (isEncryptedFileExist && isKeyExist)
                    {
                        var decryptedFilePath = PathManager.GetDecryptionPath(encryptedFilePath);

                        FileEncryptor decryptor = new(new ShiftMultiplyAlgorithm());

                        decryptor.DecryptFile(encryptedFilePath, decryptedFilePath, keyFilePath);

                        IOManager.WriteLine($"Decrypted successfully! The file path is: {decryptedFilePath}");
                    }
                    else
                    {
                        IOManager.WriteLine(isEncryptedFileExist ? "The key file was not found" : "The file to decrypt was not found");
                    }
                    break;
                case UserOptions.Exit:
                    IOManager.WriteLine("bye bye");
                    Environment.Exit(0);
                    break;
                default:
                    IOManager.WriteLine("How did you even get here????");
                    break;
            }

            IOManager.WriteLine("Press key to exit...");
            IOManager.ReadLine();
        }
    }
}

