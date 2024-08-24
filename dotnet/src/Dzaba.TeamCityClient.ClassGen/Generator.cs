using Microsoft.Extensions.Logging;
using NSwag.CodeGeneration.CSharp;
using NSwag.CodeGeneration;
using NSwag;
using System.Diagnostics;

namespace Dzaba.TeamCityClient.ClassGen;

public interface IGenerator
{
    Task GenerateAsync(Uri baseUrl, DirectoryInfo output, string @namespace);
}

internal sealed class Generator : IGenerator
{
    private readonly ILogger<Generator> logger;

    public Generator(ILogger<Generator> logger)
    {
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));

        this.logger = logger;
    }

    public async Task GenerateAsync(Uri baseUrl, DirectoryInfo output, string @namespace)
    {
        ArgumentNullException.ThrowIfNull(baseUrl, nameof(baseUrl));
        ArgumentNullException.ThrowIfNull(output, nameof(output));
        ArgumentException.ThrowIfNullOrWhiteSpace(@namespace, nameof(@namespace));

        var perfWatch = Stopwatch.StartNew();
        logger.LogInformation("Start generating TeamCity client from {Url} to {Output}", baseUrl, output);

        var documentRaw = await DownloadSwaggerJsonAsync(baseUrl)
            .ConfigureAwait(false);
        var document = await OpenApiDocument.FromJsonAsync(documentRaw).ConfigureAwait(false);

        var settings = new CSharpClientGeneratorSettings
        {
            ClassName = "TeamCityClient",
            CSharpGeneratorSettings =
            {
                Namespace = @namespace
            },
            GenerateClientInterfaces = true,
        };

        var generator = new CSharpClientGenerator(document, settings);

        logger.LogDebug("Start generating the code...");
        var impl = generator.GenerateFile(ClientGeneratorOutputType.Implementation);
        var contracts = generator.GenerateFile(ClientGeneratorOutputType.Contracts);

        SaveFile(impl, output, "TeamCityClient.cs");
        SaveFile(contracts, output, "Model.cs");

        logger.LogInformation("Generating TeamCity client from {Url} to {Output} finished. Took: {Elapsed}", baseUrl, output, perfWatch.Elapsed);
    }

    private void SaveFile(string code, DirectoryInfo output, string file)
    {
        string filepath = Path.Combine(ResolveOutput(output), file);

        if (!output.Exists)
        {
            output.Create();
        }

        logger.LogDebug("Saving {File}", filepath);
        File.WriteAllText(filepath, code);
    }

    private string ResolveOutput(DirectoryInfo output)
    {
        if (Path.IsPathRooted(output.FullName))
        {
            return output.FullName;
        }

        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, output.FullName);
    }

    private async Task<string> DownloadSwaggerJsonAsync(Uri baseUrl)
    {
        var url = new Uri(baseUrl, "app/rest/swagger.json");

        using var client = new HttpClient();

        logger.LogDebug("GET {Url}", url);
        return await client.GetStringAsync(url);
    }
}
