namespace Serensia;

/// <summary>
/// Provides input validation methods for guard clauses.
/// </summary>
public static class Guard
{
    private const int MinRange = 0;

    /// <summary>
    /// Validates that a string contains only lowercase letters and digits.
    /// </summary>
    public static void IsLowerAlphaNumeric(string value, string paramName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value, paramName);
        
        if(!value.All(c => char.IsDigit(c) || char.IsLower(c)))
            throw new ArgumentException("Value is not lowercase alphanumeric", paramName);
    }

    /// <summary>
    /// Validates that all strings in a collection are lowercase alphanumeric.
    /// </summary>
    public static void AreAlphaNumeric(IEnumerable<string> choices, string paramName)
    {
        if(choices is null || !choices.Any())
            throw new ArgumentException("Values is null or empty.", paramName);

        foreach (var choice in choices)
        {
            IsLowerAlphaNumeric(choice, $"{paramName}[{choice}]");
        }
    }

    /// <summary>
    /// Validates that a value is greater than zero and does not exceed a maximum bound.
    /// </summary>
    public static void IsInRange(int numberOfSuggestions, int numberOfChoices, string paramName)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(numberOfSuggestions, MinRange, paramName);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(numberOfSuggestions, numberOfChoices, paramName);
    }
}