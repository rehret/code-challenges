﻿namespace CodeChallenge.AdventOfCode.AdventOfCode2022.Tests.Day02;

using CodeChallenge.AdventOfCode.AdventOfCode2022.Day02;
using CodeChallenge.AdventOfCode.AdventOfCode2022.Day02.Models;
using CodeChallenge.Core.IO;

public class Solution02Tests
{
    private readonly Solution02 _solution;
    public Solution02Tests()
    {
        var inputReaderMock = new Mock<IInputReader<AdventOfCodeChallengeSelection>>();
        var inputBuilder = new InputProviderBuilder<AdventOfCodeChallengeSelection>(inputReaderMock.Object);
        _solution = new Solution02(inputBuilder);
    }

    [Fact]
    public async Task ComputeSolutionAsync_WithSampleInput_ProducesSampleOutput()
    {
        // Arrange
        var input = new List<StrategyGuideStep>
        {
            new(RockPaperScissorsResult.Draw, RockPaperScissorsMove.Rock),
            new(RockPaperScissorsResult.Lose, RockPaperScissorsMove.Paper),
            new(RockPaperScissorsResult.Win, RockPaperScissorsMove.Scissors)
        };

        // Act
        var result = await _solution.ComputeSolutionAsync(input).ConfigureAwait(false);

        // Assert
        Assert.Equal(12, result);
    }
}