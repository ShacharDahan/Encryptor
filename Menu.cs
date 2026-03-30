using Encryptor.Managers;

namespace Encryptor
{
  public static class Menu
  {
    public static void StartMenu()
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