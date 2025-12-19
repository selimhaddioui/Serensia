namespace Serensia;

public interface IAmTheTest
{
    IEnumerable<string> GetSuggestions(string term, IEnumerable<string> choices, int numberOfSuggestions);
}