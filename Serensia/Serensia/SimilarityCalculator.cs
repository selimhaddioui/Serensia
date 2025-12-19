namespace Serensia;

public static class SimilarityCalculator
{
    public static IEnumerable<TermSimilarity> CalculateSimilarities(string searchTerm, IEnumerable<string> candidates)
        => candidates
            .Where(candidate => candidate.Length >= searchTerm.Length)
            .Select(candidate => CalculateTermSimilarity(searchTerm, candidate));

    private static TermSimilarity CalculateTermSimilarity(string searchTerm, string candidate)
        => new(candidate, CalculateLettersToReplace(searchTerm, candidate), CalculateDistance(searchTerm, candidate));

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

    private static int CountDifferences(string searchTerm, string candidate, int offset)
        => searchTerm
            .Select((c, i) => candidate.Length <= offset + i || c != candidate[offset + i] ? 1 : 0)
            .Sum();

    private static int CalculateDistance(string searchTerm, string candidate)
        => candidate.Length - searchTerm.Length;
}