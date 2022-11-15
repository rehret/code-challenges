﻿namespace AdventOfCodeRunner;

using System.Text.RegularExpressions;

using AdventOfCode;

using Autofac;

using Microsoft.Extensions.Hosting;

internal class AdventOfCodeService : IHostedService
{
    private readonly IHostApplicationLifetime _hostLifetime;
    private readonly IInputReader _inputReader;
    private readonly ILifetimeScope _lifetimeScope;

    private readonly Regex _argumentRegex = new(@"(?<year>\d{4})/(?<day>\d{1,2})/(?<puzzle>\d{1,2})", RegexOptions.Compiled);

    public AdventOfCodeService(IHostApplicationLifetime hostLifetime, IInputReader inputReader, ILifetimeScope lifetimeScope)
    {
        _hostLifetime = hostLifetime;
        _inputReader = inputReader;
        _lifetimeScope = lifetimeScope;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var args = Environment.GetCommandLineArgs();
        if (args.Length == 0 || !args.Any(arg => _argumentRegex.IsMatch(arg)))
        {
            Console.WriteLine("Usage: ./run <year>/<day>/<puzzle>");
            _hostLifetime.StopApplication();
            return;
        }

        var match = args.Select(arg => _argumentRegex.Match(arg)).First(match => match.Success);
        if (!TryParseInputGroup(match.Groups["year"].Value, "year", out var year)) return;
        if (!TryParseInputGroup(match.Groups["day"].Value, "day", out var day)) return;
        if (!TryParseInputGroup(match.Groups["puzzle"].Value, "puzzle", out var puzzle)) return;

        var input = ProcessInput(await _inputReader.GetInputAsync(year, day).ConfigureAwait(false));
        var solution = _lifetimeScope.ResolveKeyed<ISolution>((year, day, puzzle));

        var result = await solution.SolveAsync(input).ConfigureAwait(false);

        Console.WriteLine(result);
        _hostLifetime.StopApplication();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private static IEnumerable<string> ProcessInput(string input)
    {
        return input
            .Trim()
            .Split('\n')
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(line => line.Trim());
    }

    private bool TryParseInputGroup(string value, string name, out int parsedInt)
    {
        if (int.TryParse(value, out parsedInt)) return true;
        Console.WriteLine($"Could not parse {name}: '{value}'");
        _hostLifetime.StopApplication();
        return false;
    }
}