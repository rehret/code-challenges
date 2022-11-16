﻿namespace CodeChallenge.AdventOfCode.IoC;

using System.Reflection;

using CodeChallenge.IoC;

internal class InputReaderModule : InputReaderAutoRegisteringModule
{
    protected override Assembly GetAssembly() => Assembly.GetExecutingAssembly();
}