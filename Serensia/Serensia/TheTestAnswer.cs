namespace Serensia;

public class TheTestAnswer : IAmTheTest
{
    public IEnumerable<string> GetSuggestions(string term, IEnumerable<string> choices, int numberOfSuggestions)
    {
        Guard.IsLowerAlphaNumeric(term, nameof(term));
        Guard.AreAlphaNumeric(choices, nameof(choices));
        Guard.IsInRange(numberOfSuggestions, choices.Count(), nameof(numberOfSuggestions));
        
        throw new NotImplementedException();
    }
}