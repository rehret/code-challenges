﻿namespace CodeChallenge.AdventOfCode.AdventOfCode2022.Day01;

using CodeChallenge.AdventOfCode.Attributes;
using CodeChallenge.Core.IO;

[AdventOfCodeSolution(2022, 1, 2)]
internal class Solution02 : AdventOfCodeSolution<IEnumerable<IEnumerable<int>>, int>
{
    public Solution02(IInputProviderBuilder<AdventOfCodeChallengeSelection> inputProviderBuilder)
        : base(inputProviderBuilder.BuildDay01InputProvider())
    { }

    protected override int ComputeSolution(IEnumerable<IEnumerable<int>> input)
    {
        return input.Select(x => x.Sum())
            .OrderDescending()
            .Take(3)
            .Sum();
    }
}