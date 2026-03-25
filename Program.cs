using Encryptor.Managers;

namespace Encryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            var encryptionService = new EncryptionService();

            switch (UserInputManager.GetUserSelection())
            {
                case UserOptions.Encrypt:
                    encryptionService.Encrypt();
                    break;
                case UserOptions.Decrypt:
                    encryptionService.Decrypt();
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