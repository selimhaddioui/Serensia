namespace Serensia;

public static class Guard
{
    private const int MinRange = 0;

    public static void IsLowerAlphaNumeric(string value, string paramName)
    {
        IsNotNullOrWhiteSpace(value, paramName);
        
        if(!value.All(char.IsLetterOrDigit) || !value.All(char.IsLower))
            throw new ArgumentException("Value is not alphanumeric", paramName);
    }

    public static void AreAlphaNumeric(IEnumerable<string> choices, string paramName)
    {
        IsNotNullOrEmpty(choices, paramName);

        foreach (var choice in choices)
        {
            IsLowerAlphaNumeric(choice, paramName);
        }
    }

    private static void IsNotNullOrWhiteSpace(string value, string paramName)
        => ArgumentException.ThrowIfNullOrWhiteSpace(value, paramName);

    private static void IsNotNullOrEmpty(IEnumerable<string> values, string paramName)
    {
        if(values is null)
            throw new ArgumentNullException("Values is null.", paramName);
        if(!values.Any())
            throw new ArgumentException("Values is empty", paramName);
    }

    public static void IsInRange(int numberOfSuggestions, int numberOfChoices, string paramName)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(numberOfSuggestions, numberOfChoices, paramName);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(numberOfSuggestions, MinRange, paramName);
    }
}