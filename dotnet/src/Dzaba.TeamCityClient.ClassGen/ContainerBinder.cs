using System.CommandLine.Binding;

namespace Dzaba.TeamCityClient.ClassGen;

internal class ContainerBinder : BinderBase<IServiceProvider>
{
	private readonly IServiceProvider serviceProvider;

    public ContainerBinder(IServiceProvider serviceProvider)
    {
		ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

        this.serviceProvider = serviceProvider;
    }

    protected override IServiceProvider GetBoundValue(BindingContext bindingContext)
    {
		return serviceProvider;
    }
}
