﻿namespace CodeChallenge.AdventOfCode.AdventOfCode2021.Modules;

using System.Reflection;

using CodeChallenge.Core.Modules;

internal class InputProviderModule() : InputProviderAutoRegisteringModule(Assembly.GetExecutingAssembly());