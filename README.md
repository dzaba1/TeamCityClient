# TeamCity HTTP API client libraries

Those are [TeamCity API](https://www.jetbrains.com/help/teamcity/teamcity-rest-api.html) client libraries created based on OpenAPI (swagger.json)

## .NET (C#)

## Usage

Install nuget 

Register services into IoC container:
```csharp
services.RegisterDzabaTeamCityClient()
```

Inject `ITeamCityClientFactory` into your classes and create clients:
```csharp
class MyClass
{
	private readonly ITeamCityClientFactory factory;

	public MyClass(ITeamCityClientFactory factory)
	{
		this.factory = factory;
	}

	public async Task DoAsync()
	{
		var client = factory.CreateClient(new TeamCityClientOptions
		{
			Url = new Uri("https://MyTeamCityServer"),
			Token = "123abc"
		});

		var builds = await client.GetAllBuildsAsync(...);
	}
}
```
