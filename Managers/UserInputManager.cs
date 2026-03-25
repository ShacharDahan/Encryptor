namespace Encryptor.Managers
{
    public static class UserInputManager
    {
        private static T GetEnumSelection<T>(string prompt) where T : struct, Enum // This is AI, Basically what I did before but with a generic method to reduce code duplication.
        {
            IOManager.WriteLine(prompt);
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                IOManager.WriteLine($"{value} = {(int)(object)value}");
            }

            var input = IOManager.ReadLine();

            if (!int.TryParse(input, out var num) || !Enum.IsDefined(typeof(T), num))
            {
                IOManager.WriteLine("Invalid selection.");
                Environment.Exit(1);
                return default;
            }

            return (T)(object)num;
        }

        public static UserOptions GetUserSelection() =>
            GetEnumSelection<UserOptions>("Enter desired action:");

        public static EncryptionType GetEncryptionType() =>
            GetEnumSelection<EncryptionType>("Choose an encryption type:");

        public static int GetRepeatCount()
        {
            IOManager.WriteLine("What's the amount of encryptions?");

            var input = IOManager.ReadLine();

            if (!int.TryParse(input, out var count) || count < 1)
            {
                IOManager.WriteLine("Invalid input :(");
                Environment.Exit(1);
                return default;
            }

            return count;
        }
    }
}