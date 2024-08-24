using System.CommandLine;

namespace Dzaba.TeamCityClient.ClassGen;

public static class Extensions
{
    public static Option<T> AddOption<T>(this Command command, Func<Option<T>> factory)
    {
        var option = factory();
        command.AddOption(option);
        return option;
    }
}
