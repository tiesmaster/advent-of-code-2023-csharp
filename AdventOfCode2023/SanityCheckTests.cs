using System;

using Xunit;

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

    [Fact]
    public void CheckCharToIntConversion()
    {
        var c = '1';

        var i = c - '0';

        i.Should().Be(1);
    }
}