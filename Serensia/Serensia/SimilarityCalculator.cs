namespace Serensia;

/// <summary>
/// Calculates similarity scores between a search term and candidate strings using sliding window comparison.
/// </summary>
public static class SimilarityCalculator
{
    /// <summary>
    /// Computes similarity for all candidates longer than or equal to the search term.
    /// </summary>
    public static IEnumerable<TermSimilarity> CalculateSimilarities(string searchTerm, IEnumerable<string> candidates)
    {
        return candidates
            .Where(candidate => candidate.Length >= searchTerm.Length)
            .Select(candidate => CalculateTermSimilarity(searchTerm, candidate));
    }

    /// <summary>
    /// Creates a TermSimilarity object with replacement count and length difference.
    /// </summary>
    private static TermSimilarity CalculateTermSimilarity(string searchTerm, string candidate)
    {
        return new TermSimilarity(candidate, CalculateLettersToReplace(searchTerm, candidate), candidate.Length - searchTerm.Length);
    }

    /// <summary>
    /// Finds minimum character differences using sliding window across all possible positions.
    /// </summary>
    private static int CalculateLettersToReplace(string searchTerm, string candidate)
    {
        if (candidate.Length == searchTerm.Length)
            return CountDifferences(searchTerm, candidate, 0);

        var minDifferences = int.MaxValue;

        for (int offset = 0; offset <= candidate.Length - searchTerm.Length; offset++)
        {
            var differences = CountDifferences(searchTerm, candidate, offset);
            minDifferences = Math.Min(minDifferences, differences);
        }

        return minDifferences;
    }

    /// <summary>
    /// Counts character mismatches between search term and candidate at a given offset.
    /// </summary>
    private static int CountDifferences(string searchTerm, string candidate, int offset)
    {
        return searchTerm
            .Select((c, i) => candidate.Length <= offset + i || c != candidate[offset + i] ? 1 : 0)
            .Sum();
    }
}