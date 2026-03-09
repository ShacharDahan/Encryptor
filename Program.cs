namespace Encryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            IOManager ioManager = IOManager.GetInstance();

            ioManager.WriteLine("Choose encrypt or decrypt");
            var input = ioManager.ReadLine();

            switch (input)
            {
                case "encrypt":
                    Console.Write("Enter file to encrypt path: ");
                    var filePath = Console.ReadLine();

                    var isFileExist = File.Exists(filePath);

                    if (isFileExist)
                    {
                        Encryptor encryptor = Encryptor.GetInstance();

                        var paths = encryptor.Encrypt(filePath);

                        ioManager.WriteLine($"Encrypted file!");
                        ioManager.WriteLine($"path for the new file is: {paths[0]}");
                        ioManager.WriteLine($"path for the key file is: {paths[1]}");
                    }
                    else
                    {
                        ioManager.WriteLine("Can't find file");
                    }
                    break;
                case "decrypt":
                    Console.Write("Enter file to decrypt path: ");
                    var encryptedFilePath = Console.ReadLine();
                    Console.Write("Enter file of encryption key path: ");
                    var keyFilePath = Console.ReadLine();

                    var isFileAndKeyExist = File.Exists(encryptedFilePath) && File.Exists(keyFilePath);

                    if (isFileAndKeyExist)
                    {
                        Decryptor decryptor = Decryptor.GetInstance();
                        var decryptedFilePath = decryptor.Decrypt(encryptedFilePath, keyFilePath);

                        ioManager.WriteLine($"Decrypted successfully! The file path is: {decryptedFilePath}");
                    }
                    else
                    {
                        ioManager.WriteLine("Couldn't find files");
                    }
                    break;
                default:
                    break;
            }

            ioManager.WriteLine("Press key to exit...");
            ioManager.ReadLine();
        }
    }
}

