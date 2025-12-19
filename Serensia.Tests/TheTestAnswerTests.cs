namespace Serensia.Tests;

public class TheTestAnswerTests
{
    private IAmTheTest _sut;

    [SetUp]
    public void Setup()
    {
        _sut = new TheTestAnswer();
    }

    [TestCase("gros", new[] { "gros", "gras", "graisse", "aggressif", "go", "ros", "gro" }, 2, new[] { "gros", "gras" },
        Description = "Subject test")]
    [TestCase("gros", new[] {"brow", "gros", "gris", "abcd"}, 4, new[] {"gros", "gris", "brow", "abcd"},
        Description = "Letter replacement order")]
    [TestCase("gros", new[] {"123456", "1234", "1234567"}, 3, new[] {"1234", "123456", "1234567"},
        Description = "Size order")]
    [TestCase("gros", new[] {"azbc", "abcd", "azac"}, 3, new[] {"abcd", "azac", "azbc"},
        Description = "Alphabet order")]
    [TestCase("gros", new[] {"grise", "gris", "gros", "grabaa", "grabbb", "zz"}, 5, new[] {"gros", "gris", "grise", "grabaa", "grabbb"},
        Description = "Global order")]
    [TestCase("gros", new[] {"aaa", "gro", "r", "ros"}, 3, new string[0],
        Description = "Smaller term")]
    public void GivenValidArguments_GetSuggestions_ShouldReturnsExpectedResults(string term, string[] choices, int numberOfSuggestions, string[] expected)
    {
        // Act
        var suggestions = _sut.GetSuggestions(term, choices, numberOfSuggestions);

        // Assert
        Assert.That(suggestions, Is.EqualTo(expected));
    }

    [TestCase("Gros", new[] { "some", "thing" }, 1,
        Description = "Capital letter in term")]
    [TestCase("@ros", new[] { "some", "thing" }, 1,
        Description = "Symbol in term")]
    [TestCase("", new[] { "some", "thing" }, 1,
        Description = "Empty term")]
    [TestCase("gros", new[] { "sOme", "thing" }, 1,
        Description = "Capital letter in choices")]
    [TestCase("gros", new[] { "some", "&thing" }, 1,
        Description = "Symbol in choices")]
    [TestCase("gros", new string[0], 3,
        Description = "Empty choices")]
    public void GivenInvalidArguments_GetSuggestions_ThrowArgumentException(string term, string[] choices, int numberOfSuggestions)
    {
        // Act & Assert
        Assert.That(() => _sut.GetSuggestions(term, choices, numberOfSuggestions), Throws.ArgumentException);
    }

    [TestCase(-8, Description = "Negative number of suggestions")]
    [TestCase(0, Description = "Zero suggestions requested")]
    [TestCase(3, Description = "More suggestions than available choices")]
    public void GivenInvalidNumberOfSuggestion_GetSuggestions_ThrowArgumentOutOfRangeException(int numberOfSuggestions)
    {
        // Act & Assert
        Assert.That(() => _sut.GetSuggestions("gros", new[] { "some", "thing" }, numberOfSuggestions),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }
    
    [Test]
    public void GivenNullTerm_GetSuggestions_ThrowArgumentException()
    {
        // Arrange
        var choices = new[] { "some", "thing" };
        const int numberOfSuggestions = 2;

        // Act & Assert
        Assert.That(() => _sut.GetSuggestions(null, choices, numberOfSuggestions), Throws.ArgumentNullException);
    }
    
    [Test]
    public void GivenNullChoices_GetSuggestions_ThrowArgumentException()
    {
        // Arrange
        const string term = "gros";
        const int numberOfSuggestions = 2;

        // Act & Assert
        Assert.That(() => _sut.GetSuggestions(term, null, numberOfSuggestions), Throws.ArgumentNullException);
    }
}