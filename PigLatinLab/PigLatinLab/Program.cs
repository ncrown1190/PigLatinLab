// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


do
{
    Console.WriteLine("Enter a word to be translated: ");
    string userWord = Console.ReadLine().Trim();
    userWord = userWord.ToLower();

    //This will take a word or words.

    if (userWord != "" && userWord != null)
    {
        string[] words = userWord.Split(' ');
        string translateSentence = "";
        foreach (string word in words)
        {
            translateSentence += Translate(word) + " ";
        }
        Console.Write($"This is translated Piglatin: {translateSentence}");
    }
    else
    {
        Console.WriteLine("You have entered anything, so nothing to translate");
    }

} while (GetPlayAgainAnswer() == true);




static bool IsVowel(char c)
{
    char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

    c = char.ToLower(c);
    if (vowels.Contains(c))
    {
        return true;
    }
    else
    {
        return false;
    }
}
static int FirstVowelIndex(string word)
{
    for (int i = 0; i < word.Length; i++)
    {
        //Why am I able to look at the character in my string like an array?
        char c = word[i];
        if (IsVowel(c))
        {
            return i;
        }
    }
    return -1;
}

static string Translate(string input)
{
    int firstVowelIndex = FirstVowelIndex(input);
    //Console.WriteLine($"Index of First Vowel: {firstVowelIndex}");

    string translated = "";
    if(firstVowelIndex == 0)
    {
        // i.e the word is started with a vowel
        translated = input + "way";
    }
    //else if(firstVowelIndex == -1)
    //{
    //    Console.WriteLine("");
    //}
    else
    {
        string prefix = input.Substring(0, firstVowelIndex);
        string postfix = input.Substring(firstVowelIndex);
        //Console.WriteLine($"This is prefix: {prefix}");
        //Console.WriteLine($"This is PostFix: {postfix}");
        translated = postfix + prefix + "ay";
    }
    return translated;
}

static bool GetPlayAgainAnswer()
{

    Console.Write("\n Would you like play again. Anything but 'yes' will end the game. ");
    string? userAnswer = Console.ReadLine();
    if (userAnswer?.ToLower() != "y")
    {
        Console.WriteLine("Goodbye!");
        return false;
    }
    else
    {
        Console.WriteLine("YEAH LETS PLAY");
        //continue;
        return true;
    }
}