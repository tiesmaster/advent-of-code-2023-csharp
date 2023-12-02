namespace AdventOfCode2023;

public class SanityCheckTests
{
    [Fact]
    public void ValidateAssertionFramework()
    {
        var result = GetTestValues();

        result.Should().BeEquivalentTo([1, 3]);
    }

    private IEnumerable<int> GetTestValues()
    {
        yield return 1;
        yield return 3;
    }
}