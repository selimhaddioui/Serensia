namespace Serensia;

public static class SimilarityCalculator
{
    public static IEnumerable<TermSimilarity> CalculateSimilarities(string searchTerm, IEnumerable<string> candidates)
        => candidates.Select(candidate => CalculateTermSimilarity(searchTerm, candidate));

    private static TermSimilarity CalculateTermSimilarity(string searchTerm, string candidate)
        => new(candidate, CalculateLetterToReplace(searchTerm, candidate), CalculateDistance(searchTerm, candidate));

    private static int CalculateLetterToReplace(string searchTerm, string candidate)
        => 0;

    private static int CalculateDistance(string searchTerm, string candidate)
        => Math.Abs(searchTerm.Length - candidate.Length);
}