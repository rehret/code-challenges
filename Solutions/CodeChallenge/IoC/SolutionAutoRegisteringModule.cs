﻿namespace CodeChallenge.IoC;

using System.Reflection;

using Autofac;

using Module = Autofac.Module;

public abstract class SolutionAutoRegisteringModule<T> : Module
    where T : SolutionAttribute
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(GetAssembly())
            .Where(type => type.GetCustomAttribute<T>(true) != null)
            .Keyed<ISolution>(type => type.GetCustomAttribute<T>()!.ToPuzzleSelection());
    }

    protected abstract Assembly GetAssembly();
}