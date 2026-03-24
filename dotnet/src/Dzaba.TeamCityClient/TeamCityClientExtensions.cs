namespace Dzaba.TeamCityClient;

/// <summary>
/// TeamCity client extensions
/// </summary>
public static class TeamCityClientExtensions
{
    /// <summary>
    /// Delete user group matching the locator.
    /// </summary>
    /// <param name="client"></param>
    /// <param name="locator"></param>
    /// <returns>successful operation</returns>
    public static async Task DeleteGroupAsync(this ITeamCityClient client, Locators.UserGroupLocator locator)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(locator);

        await client.DeleteGroupAsync(locator.ToString()).ConfigureAwait(false);
    }

    /// <summary>
    /// Delete user group matching the locator.
    /// </summary>
    /// <param name="client"></param>
    /// <param name="locator"></param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>successful operation</returns>
    public static async Task DeleteGroupAsync(this ITeamCityClient client, Locators.UserGroupLocator locator, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(client);
        ArgumentNullException.ThrowIfNull(locator);

        await client.DeleteGroupAsync(locator.ToString(), cancellationToken)
            .ConfigureAwait(false);
    }
}
