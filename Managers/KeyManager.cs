namespace Encryptor.Managers
{
  public static class KeyManager
  {
    public static int GenerateKey(int maxKey)
    {
      var upperBound = Math.Max(2, maxKey);
      var key = new Random().Next(1, upperBound);

      return key;
    }

    public static string GetKeyString(int[] keys)
    {
      var key = $"{keys[0]}";

      for (int i = 1; i < keys.Length; i++)
      {
        key += $" {keys[i]}";
      }

      return key;
    }
  }
}