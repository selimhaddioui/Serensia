namespace Serensia;

public static class Guard
{
    private const int MinRange = 0;

    public static void IsLowerAlphaNumeric(string value, string paramName)
    {
        IsNotNullOrWhiteSpace(value, paramName);
        
        if(!value.All(c => char.IsDigit(c) || char.IsLower(c)))
            throw new ArgumentException("Value is not lowercase alphanumeric", paramName);
    }

    public static void AreAlphaNumeric(IEnumerable<string> choices, string paramName)
    {
        IsNotNullOrEmpty(choices, paramName);

        foreach (var choice in choices)
        {
            IsLowerAlphaNumeric(choice, $"{paramName}[{choice}]");
        }
    }

    public static void IsInRange(int numberOfSuggestions, int numberOfChoices, string paramName)
    {
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(numberOfSuggestions, MinRange, paramName);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(numberOfSuggestions, numberOfChoices, paramName);
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
}