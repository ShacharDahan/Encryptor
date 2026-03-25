namespace Encryptor
{

    public static class IOManager
    {
        public static void WriteLine(string output)
        {
            try
            {
                Console.WriteLine(output);
            }
            catch (Exception e)
            {
                Console.WriteLine("If it didn't work once i guess we'll try again?");
                Environment.Exit(1);
            }
        }

        public static void Write(string output)
        {
            try
            {
                Console.Write(output);
            }
            catch (Exception e)
            {
                Console.WriteLine("If it didn't work once i guess we'll try again?");
                Environment.Exit(1);
            }
        }

        public static string ReadLine()
        {
            var input = Console.ReadLine();

            try
            {
                return input ?? throw new Exception("Input Error");
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
                Environment.Exit(1);
                return default;
            }
        }

        public static string ReadFile(string filepath)
        {
            try
            {
                var file = File.ReadAllText(filepath).Trim();

                return file;
            }
            catch (Exception e)
            {
                WriteLine($"Error reading file: {e.Message}");
                Environment.Exit(1);
                return default;
            }
        }

        public static void WriteFile(string filepath, string data)
        {
            try
            {
                using var file = File.Open(filepath, FileMode.Create);
                using StreamWriter streamWriter = new(file);

                streamWriter.Write(data);
            }
            catch (Exception e)
            {
                WriteLine($"Error writing file: {e.Message}");
                Environment.Exit(1);
            }
        }
    }
}
