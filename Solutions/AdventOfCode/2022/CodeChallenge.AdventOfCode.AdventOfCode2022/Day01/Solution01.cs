﻿namespace CodeChallenge.AdventOfCode.AdventOfCode2022.Day01;

using CodeChallenge.AdventOfCode.Attributes;
using CodeChallenge.Core.IO;

[AdventOfCodeSolution(2022, 1, 1)]
internal class Solution01 : AdventOfCodeSolution<IEnumerable<IEnumerable<int>>, int>
{
    public Solution01(IInputProviderBuilder<AdventOfCodeChallengeSelection> inputProviderBuilder)
        : base(inputProviderBuilder.BuildDay01InputProvider())
    { }

    protected override int ComputeSolution(IEnumerable<IEnumerable<int>> input)
    {
        return input.Max(x => x.Sum());
    }
}