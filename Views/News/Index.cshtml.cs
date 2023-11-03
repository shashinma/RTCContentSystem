namespace POSTerminal.Views.News;

public class NewsAction
{
    public static string GetLimitedWords(string input, int wordCount)
    {
        var words = input.Split(' ');
        if (words.Length <= wordCount)
        {
            return input;
        }

        var limitedContent = string.Join(' ', words.Take(wordCount));
        limitedContent = TrimPunctuation(limitedContent);
        limitedContent += "...";
        return limitedContent;
    }

    public static string TrimPunctuation(string input)
    {
        char[] punctuation = { '.', ',', '!', '?' }; // Добавьте другие знаки препинания по необходимости
        input = input.TrimEnd(punctuation);
        return input;
    }
}