namespace Serensia;

public class TheTestAnswer : IAmTheTest
{
    /// <summary>
    /// Returns the N most similar lowercase alphanumeric terms from choices, filtered and sorted by similarity.
    /// </summary>
    public IEnumerable<string> GetSuggestions(string term, IEnumerable<string> choices, int numberOfSuggestions)
    {
        Guard.IsLowerAlphaNumeric(term, nameof(term));
        Guard.AreAlphaNumeric(choices, nameof(choices));
        Guard.IsInRange(numberOfSuggestions, choices.Count(), nameof(numberOfSuggestions));
        
        var termSimilarities = SimilarityCalculator.CalculateSimilarities(term, choices);
        var orderedSimilarities = termSimilarities
            .OrderBy(termSimilarity => termSimilarity.LettersToReplace)
            .ThenBy(termSimilarity => termSimilarity.Distance)
            .ThenBy(termSimilarity => termSimilarity.Term)
            .Take(numberOfSuggestions);
        
        return orderedSimilarities.Select(termSimilarity => termSimilarity.Term);
    }
}