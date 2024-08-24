# TeamCity HTTP API .NET / C# client library

[![NuGet](https://img.shields.io/nuget/v/Dzaba.TeamCityClient.svg)](https://www.nuget.org/packages/Dzaba.TeamCityClient)

## Getting Started

The library is available on [NuGet](https://www.nuget.org/packages/Dzaba.TeamCityClient/):
```
dotnet add package Dzaba.TeamCityClient
```

The library is DI based. Call `services.RegisterDzabaTeamCityClient();` having your [ServiceCollection](https://learn.microsoft.com/pl-pl/dotnet/api/microsoft.extensions.dependencyinjection.servicecollection) object.
Example:
```csharp
var services = new ServiceCollection();

services.RegisterDzabaTeamCityClient();
```

Then, inject `ITeamCityClientFactory` into your classes and create clients:
```csharp
internal sealed class MyClass
{
    private readonly ITeamCityClientFactory clientFactory;

    public BuildsService(ITeamCityClientFactory clientFactory)
    {
        ArgumentNullException.ThrowIfNull(clientFactory, nameof(clientFactory));

        this.clientFactory = clientFactory;
    }

    public async Task<Build> TriggerBuild(string buildTypeId, string branch)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(buildTypeId, nameof(buildTypeId));

        var body = new Build
        {
            BuildTypeId = buildTypeId,
            BranchName = branch
        };

        var client = factory.CreateClient(new TeamCityClientOptions
		{
			Url = new Uri("https://MyTeamCityServer"),
			Token = "123abc"
		});
        return await client.AddBuildToQueueAsync(body, null);
    }
```

### Paging

You can use the `TeamCityPageExpander` for enumerating all resource items. Example:
```csharp
public IAsyncEnumerable<Build> GetBuildsAsync(string buildType)
{
    ArgumentException.ThrowIfNullOrWhiteSpace(buildType, nameof(buildType));

    var locator = new Locator
    {
        ["defaultFilter"] = false,
        ["buildType"] = $"(id:{buildType})"
    };

    return TeamCityPageExpander.GetAllAsync(GetBuildsAsyncPage, locator, 50);
}

private async IAsyncEnumerable<Build> GetBuildsAsyncPage(Locator locator)
{
    var result = await client.GetAllBuildsAsync(locator.ToString(), null);
    foreach (var build in result.Build)
    {
        yield return build;
    }
}
```
