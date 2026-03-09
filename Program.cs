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
                    Console.Write("Enter file to encrypt path: ");
                    var filePath = Console.ReadLine();

                    var isFileExist = File.Exists(filePath);

                    if (isFileExist)
                    {
                        Encryptor encryptor = new();

                        var paths = encryptor.Encrypt(filePath);

                        IOManager.WriteLine($"Encrypted file!");
                        IOManager.WriteLine($"path for the new file is: {paths[0]}");
                        IOManager.WriteLine($"path for the key file is: {paths[1]}");
                    }
                    else
                    {
                        IOManager.WriteLine("Can't find file");
                    }
                    break;
                case UserOptions.Decrypt:
                    Console.Write("Enter file to decrypt path: ");
                    var encryptedFilePath = Console.ReadLine();
                    Console.Write("Enter file of encryption key path: ");
                    var keyFilePath = Console.ReadLine();

                    var isEncryptedFileExist = File.Exists(encryptedFilePath);
                    var isKeyExist = File.Exists(keyFilePath);

                    if (isEncryptedFileExist && isKeyExist)
                    {
                        Decryptor decryptor = new();
                        var decryptedFilePath = decryptor.Decrypt(encryptedFilePath, keyFilePath);

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

