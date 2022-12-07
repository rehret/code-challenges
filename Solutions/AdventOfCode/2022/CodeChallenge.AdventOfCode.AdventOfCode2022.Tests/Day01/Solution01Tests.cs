﻿namespace CodeChallenge.AdventOfCode.AdventOfCode2022.Tests.Day01;

using CodeChallenge.AdventOfCode.AdventOfCode2022.Day01;
using CodeChallenge.Core.IO;

public class Solution01Tests
{
    private readonly Solution01 _solution;

    public Solution01Tests()
    {
        var inputReaderMock = new Mock<IInputReader<AdventOfCodeChallengeSelection>>();
        var inputBuilder = new InputProviderBuilder<AdventOfCodeChallengeSelection>(inputReaderMock.Object);
        _solution = new Solution01(inputBuilder);
    }

    [Fact]
    public async Task ComputeSolutionAsync_WithSampleInput_ProducesSampleOutput()
    {
        // Arrange
        var input = new List<IEnumerable<int>>
        {
            new List<int> { 1000, 2000, 3000 },
            new List<int> { 4000 },
            new List<int> { 5000, 6000 },
            new List<int> { 7000, 8000, 9000 },
            new List<int> { 10000 }
        };

        // Act
        var result = await _solution.ComputeSolutionAsync(input).ConfigureAwait(false);

        // Assert
        Assert.Equal(24000, result);
    }
}