using System.Linq;
using System.Text;

namespace training.automation.common.Utilities
{
    public class RandomGen
    {
        private static System.Random random = new System.Random();

        public static string RandomAlphanumericString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomAlphabetString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomSentence(int WordCount)
        {
            string[] words = { "Lorem", "ipsum", "dolor", "sit", "amet", "cursus", "posuere", "vehicula", "integer", "tincidunt",
                               "nam", "laoreet", "ac", "at", "imperdiet", "vitae", "pede", "ut", "tempus", "sit", "sed", "integer",
                               "egestas", "iaculis", "eget", "eu" };

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < WordCount; i++)
            {
                // Select a random word from the array
                builder.Append(words[random.Next(words.Length)]).Append(" ");
            }

            string sentence = builder.ToString().Trim() + ". ";

            // Set the first letter of the first word in the sentenece to uppercase
            sentence = char.ToUpper(sentence[0]) + sentence.Substring(1);

            builder = new StringBuilder();
            builder.Append(sentence);

            return builder.ToString();
        }

        public static int RandomNumber(int max)
        {
            return random.Next(max);
        }

        public static int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
