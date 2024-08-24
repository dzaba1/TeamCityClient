using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.CommandLine;

namespace Dzaba.TeamCityClient.ClassGen;

internal static class Program
{
    public static async Task<int> Main(string[] args)
    {
		try
		{
			using var container = CreateContainer();

            var rootCommand = new RootCommand();
			var outOption = rootCommand.AddOption(() =>
			{
				return new Option<DirectoryInfo>(["--out", "-o"], "Output directory.")
				{
					IsRequired = true,
				};
			});
            var nsOption = rootCommand.AddOption(() =>
            {
                return new Option<string>(["--namespace", "-ns"], "Generated client class namespace.")
                {
                    IsRequired = true,
                };
            });
            var urlOption = rootCommand.AddOption(() =>
            {
                return new Option<string>(["--url", "-u"], "TeamCity server base url.")
                {
                    IsRequired = true,
                };
            });

            rootCommand.SetHandler(async (u, n, o, s) =>
            {
				var generator = s.GetRequiredService<IGenerator>();
				await generator.GenerateAsync(new Uri(u), o, n);
            }, urlOption, nsOption, outOption, new ContainerBinder(container));

			return await rootCommand.InvokeAsync(args);
        }
		catch (Exception ex)
		{
			Console.WriteLine(ex);
			return 2;
		}
    }

	private static ServiceProvider CreateContainer()
	{
		var services = new ServiceCollection();

		var logger = new LoggerConfiguration()
			.MinimumLevel.Information()
			.WriteTo.Console()
			.CreateLogger();

		services.AddLogging(l => l.AddSerilog(logger, true));

		services.AddTransient<IGenerator, Generator>();
		return services.BuildServiceProvider();
	}
}
