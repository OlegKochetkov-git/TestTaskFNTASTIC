using System.Text;

public class Example
{
    static bool isProgramContinuesToRun = true;

    public static void Main()
    {
        while (isProgramContinuesToRun)
        {
            var inputString = Console.ReadLine();
            var resultString = ConvertStringIntoBrackets(inputString);
            Console.WriteLine(resultString);
        }      
    }

    public static string ConvertStringIntoBrackets(string testString)
    {
        if (String.IsNullOrEmpty(testString)) return "string is null or empty";

        if (testString.Equals("exit"))
        {
            isProgramContinuesToRun = false;
            return "exit program";
        }

        HashSet<char> uniqueChars = new HashSet<char>();

        testString = testString.ToLower();

        foreach (var item in testString)
            uniqueChars.Add(item);

        var stringWithoutRepeatingCharacters = new String(uniqueChars.ToArray());

        if (testString.Equals(stringWithoutRepeatingCharacters))
            return ConvertAllCharactersIntoOpenBrackets(testString);
        else
            return ConvertCharactersIntoBrackets(ref testString);
    }
    private static string ConvertAllCharactersIntoOpenBrackets(string testString)
    {
        foreach (var item in testString)
            testString = testString.Replace(item, '(');

        return testString;
    }

    private static string ConvertCharactersIntoBrackets(ref string testString)
    {
        HashSet<int> indexOfRepeatingLetter = new HashSet<int>();
        FindIndexesOfRepeatedCharacters(testString, indexOfRepeatingLetter);
        testString = ConverCharactersIntoOpenAndCloseBrackets(testString, indexOfRepeatingLetter);
        return testString;
    }
    private static void FindIndexesOfRepeatedCharacters(string testString, HashSet<int> indexOfRepeatingLetter)
    {
        for (int characterIndex = 0; characterIndex < testString.Length; characterIndex++)
        {
            for (int comparedIndex = characterIndex + 1; comparedIndex < testString.Length; comparedIndex++)
            {
                if (testString[characterIndex].Equals(testString[comparedIndex]))
                {
                    indexOfRepeatingLetter.Add(characterIndex);
                    indexOfRepeatingLetter.Add(comparedIndex);
                }
            }
        }
    }

    private static string ConverCharactersIntoOpenAndCloseBrackets(string testString, HashSet<int> indexOfRepeatingLetter)
    {
        StringBuilder sb = new StringBuilder(testString);

        foreach (var item in indexOfRepeatingLetter)
            sb[item] = ')';

        for (int i = 0; i < testString.Length; i++)
        {
            if (indexOfRepeatingLetter.Contains(i)) continue;

            sb[i] = '(';
        }

        testString = sb.ToString();
        return testString;
    } 
}
